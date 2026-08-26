Public Class frmTagReport
    Private Sub frmTagReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtFrom.Value = Today
        dtTo.Value = Now
        dtFrom.Checked = False
    End Sub
    Private Sub cbSuspect_CheckedChanged(sender As Object, e As EventArgs) Handles cbSuspect.CheckedChanged
        cbProper.Checked = cbSuspect.Checked
        cbImproper.Checked = cbSuspect.Checked
        cbMissed.Checked = cbSuspect.Checked
    End Sub
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        'Prepare Data
        Dim strSQL As String = "Select * from vwTags where (AlarmTime < GETDATE()) AND (isCancelled = 0) "
        If txtTagID.TextLength > 0 Then
            strSQL &= " and TagID='" & txtTagID.Text & "'"
        End If
        'Validate dates
        If dtFrom.Checked Then
            If dtFrom.Value > dtTo.Value Then
                MsgBox("Please select correct date range. From date cannot be after to date.")
                Exit Sub
            End If
            If dtFrom.Value > Now Then
                MsgBox("Please select correct date range. Incorrect start date.")
                Exit Sub
            End If
            strSQL &= " and TStamp between '" & dtFrom.Value.ToString("dd MMM yyyy HH:mm:ss") & "' and '" & dtTo.Value.ToString("dd MMM yyyy HH:mm:ss") & "' "
        End If
        strSQL &= " order by TStamp desc,AlarmID desc"
        Dim dt As DataTable = gfnExecSQL(strSQL)
        If dt.Rows.Count > 0 Then
            Dim lst As New List(Of RecordLine)
            For Each rw As DataRow In dt.Rows
                Dim flg As Boolean = False
                Dim idx As Integer
                For i As Integer = 0 To lst.Count - 1
                    If lst(i).TagID = rw("TagID") Then
                        flg = True
                        idx = i
                        Exit For
                    End If
                Next
                Dim l As RecordLine
                If Not flg Then
                    l = New RecordLine
                    l.TagID = rw("TagID")
                    l.Threat = rw("ScanResult")
                    l.AlarmID = rw("AlarmID")
                    l.EventTime = rw("TStamp")
                    l.LastSeen = rw("LastSeenTime")
                    l.LastSeenAt = rw("LogicalDeviceCode")
                    l.Location = rw("CurrentAlarmLocation")
                    l.lst.Add(rw)
                    l.AType = AlarmType.NormalEvent
                    If l.Threat = ThreatLevel.Drugs Then
                        l.AType = AlarmType.ProhibitedLuggage
                    Else
                        If rw("AlarmType") = 40 Or rw("AlarmType") = 41 Then
                            l.AType = AlarmType.SuspectLuggage
                        End If
                    End If
                    lst.Add(l)
                Else
                    l = lst(idx)
                    l.LastSeen = rw("LastSeenTime")
                    l.LastSeenAt = rw("LogicalDeviceCode")
                    If l.Threat = ThreatLevel.Drugs Then
                        l.AType = AlarmType.ProhibitedLuggage
                    Else
                        If rw("AlarmType") = 40 Or rw("AlarmType") = 41 Then
                            l.AType = AlarmType.SuspectLuggage
                        End If
                    End If
                    l.lst.Add(rw)
                End If
            Next
            ListView1.Items.Clear()
            For Each l As RecordLine In lst
                Dim li As New ListViewItem(l.TagID)
                li.SubItems.Add(l.Threat.ToString)
                li.SubItems(1).ForeColor = GetForeColor(l.Threat)
                li.SubItems(1).BackColor = GetBackColor(l.Threat)
                li.SubItems.Add(l.EventTime.ToString("dd MMM HH:mm"))
                li.SubItems.Add(l.AType.ToString)
                li.SubItems(3).Font = New Font(li.Font, FontStyle.Bold)
                If l.AType = AlarmType.ProhibitedLuggage Then
                    If Not cbProhibited.Checked Then
                        Continue For
                    End If
                    li.SubItems(3).ForeColor = Color.Red
                End If
                If l.AType = AlarmType.SuspectLuggage Then
                    If Not cbSuspect.Checked Then
                        Continue For
                    Else
                        'Check which type
                        Dim flg As Boolean = False
                        For Each rw As DataRow In l.lst
                            If rw("AlarmType") = 40 And rw("isDelayed") = True Then
                                l.ASubType = AlarmSubType.MissedBag
                                If Not cbMissed.Checked Then
                                    flg = True
                                    Exit For
                                End If
                                Exit For
                            End If
                            If rw("AlarmType") = 40 And rw("isDelayed") = False Then
                                l.ASubType = AlarmSubType.DelayProperPath
                                If Not cbProper.Checked Then
                                    flg = True
                                    Exit For
                                End If
                                Exit For
                            End If
                            If rw("AlarmType") = 41 Then
                                l.ASubType = AlarmSubType.MissedBag
                                If Not cbImproper.Checked Then
                                    flg = True
                                    Exit For
                                End If
                                Exit For
                            End If
                        Next
                        If flg = True Then
                            Continue For
                        End If
                    End If
                    li.SubItems(3).ForeColor = Color.Orange
                End If
                If l.AType = AlarmType.NormalEvent Then
                    If Not cbNormal.Checked Then
                        Continue For
                    End If
                    li.SubItems(3).ForeColor = Color.Gray
                End If
                li.SubItems.Add(l.Location)
                li.SubItems.Add(l.LastSeen.ToString("dd MMM HH:mm"))
                li.SubItems.Add(l.LastSeenAt)
                li.SubItems.Add(l.lst.Count)
                li.UseItemStyleForSubItems = False
                ListView1.Items.Add(li)
            Next
            AutoSizeList(ListView1)
        Else
            MsgBox("No records found!")
        End If
    End Sub
    Private Sub ListView1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles ListView1.MouseDoubleClick
        If ListView1.SelectedItems.Count = 0 Then
            Exit Sub
        End If
        Dim strSQL As String = "Select * from vwTags where (AlarmTime < GETDATE()) AND (isCancelled = 0) "
        strSQL &= " and TagID='" & ListView1.SelectedItems(0).SubItems(0).Text & "'"
        strSQL &= " order by TStamp desc, AlarmID desc"
        Dim dt As DataTable = gfnExecSQL(strSQL)
        If dt.Rows.Count > 0 Then
            Dim frm As New frmTagHistory
            Dim r As DataRow = dt.Rows(0)
            frm.Label2.Text = r("TagID")
            frm.lblBHS.Text = r("GlobalID")
            frm.lblIATA.Text = r("IATACode")
            frm.lblLSAt.Text = r("LogicalDeviceCode")
            frm.lblLSTime.Text = CDate(r("LastSeenTime")).ToString("dd MMM HH:mm")
            Dim d As DeviceType = r("LastStage")
            frm.lblStage.Text = d.ToString
            Dim t As ThreatLevel = r("ScanResult")
            frm.lblThreat.Text = t.ToString
            frm.lblThreat.ForeColor = GetForeColor(t)
            For Each rw As DataRow In dt.Rows
                Dim li As New ListViewItem(CDate(rw("TStamp")).ToString("dd MMM HH:mm"))
                li.SubItems.Add(rw("AlarmType"))
                If rw("AlarmType") = 40 Or rw("AlarmType") = 41 Then
                    li.ForeColor = Color.Red
                End If
                li.SubItems.Add(rw("AlarmDesc"))
                li.SubItems.Add(rw("CurrentAlarmLocation"))
                li.SubItems.Add(rw("isReported"))
                li.UseItemStyleForSubItems = True
                frm.ListView1.Items.Add(li)
            Next
            AutoSizeList(frm.ListView1)
            frm.ShowDialog()
        End If
    End Sub
End Class