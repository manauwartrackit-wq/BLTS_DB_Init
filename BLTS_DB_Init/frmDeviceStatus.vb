Public Class frmDeviceStatus

    Private Sub frmDeviceStatus_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ComboBox1.SelectedIndex = 0
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        ListView1.Items.Clear()
        If ComboBox1.SelectedIndex = 0 Then
            Timer1.Enabled = False
            Exit Sub
        Else
            Timer1.Enabled = True
        End If
        Dim ta As New DBTableAdapters.LogicalDeviceTableAdapter
        Dim dt As New DB.LogicalDeviceDataTable
        Select Case ComboBox1.SelectedIndex
            Case 1
                'Tagging
                dt = ta.GetData(1)
            Case 2
                'Tagging Read Point
                dt = ta.GetData(2)
            Case 3
                'Dog House
                dt = ta.GetData(3)
            Case 4
                'ADG
                dt = ta.GetData(5)
            Case 5
                'Recheck
                dt = ta.GetData(8)
            Case 6
                'Lounge
                dt = ta.GetData(6)
            Case 7
                'BHS RF
                dt = ta.GetData(9)
        End Select
        For Each rw As DB.LogicalDeviceRow In dt.Rows
            Dim li As New ListViewItem(rw.LogicalDeviceCode)
            If rw.DeviceType = 2 Or rw.DeviceType = 3 Or rw.DeviceType = 5 Or rw.DeviceType = 6 Or rw.DeviceType = 9 Then
                li.SubItems.Add(rw.ReaderIP)
            Else
                li.SubItems.Add(rw.IPAddress)
            End If
            Dim LC As DateTime = Nothing
            If rw.DeviceType = 2 Or rw.DeviceType = 3 Or rw.DeviceType = 5 Or rw.DeviceType = 6 Or rw.DeviceType = 9 Then
                If rw.IsReaderLastConnectedNull Then
                    LC = Nothing
                Else
                    LC = rw.ReaderLastConnected
                End If
            Else
                If rw.IsLastConnectedNull Then
                    LC = Nothing
                Else
                    LC = rw.LastConnected
                End If
            End If

            If LC = New Date() Then
                li.SubItems.Add("Disconnected")
                li.ForeColor = Color.Red
                li.SubItems.Add("--")
            Else
                If Now.Subtract(LC).TotalSeconds > 30 Then
                    li.SubItems.Add("Disconnected")
                    li.ForeColor = Color.Red
                Else
                    li.SubItems.Add("Connected")
                    li.ForeColor = Color.Green
                End If
                li.SubItems.Add(LC.ToString("dd MMM yyyy HH:mm"))
            End If
            li.SubItems.Add(rw.LastError)
            ListView1.Items.Add(li)
        Next
        AutoSizeList(ListView1)
    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        ComboBox1_SelectedIndexChanged(Nothing, Nothing)
    End Sub
    Private Sub ListView1_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListView1.MouseDoubleClick
        If ListView1.SelectedItems.Count = 0 Then
            Exit Sub
        End If
        If ComboBox1.SelectedIndex <> 4 Then
            Exit Sub
        End If
        Timer1.Enabled = False
        Dim frm As New frmAntennaStatus

        frm.lblID.Text = ListView1.SelectedItems(0).SubItems(0).Text
        frm.lblStatus.Text = ListView1.SelectedItems(0).SubItems(2).Text
        frm.lblID.Text = ListView1.SelectedItems(0).SubItems(3).Text

        'Dim ta As New DBTableAdapters.AntennasTableAdapter
        'Dim dt As DB.AntennasDataTable = ta.GetData(ListView1.SelectedItems(0).Tag)
        'For Each rw As DB.AntennasRow In dt.Rows
        '    Dim li As New ListViewItem(rw.AntennaPort)
        '    If ListView1.SelectedItems(0).SubItems(2).Text = "Disconnected" Then
        '        li.SubItems.Add("Disconnected")
        '    Else
        '        li.SubItems.Add(rw.Status)
        '    End If
        '    If li.SubItems(1).Text = "Disconnected" Then
        '        li.ForeColor = Color.Red
        '    Else
        '        li.ForeColor = Color.Green
        '    End If
        '    If rw.IsLastConnectedNull Then
        '        li.SubItems.Add("--")
        '    Else
        '        li.SubItems.Add(rw.LastConnected.ToString("dd MMM yyyy HH:mm:ss"))
        '    End If
        '    frm.ListView1.Items.Add(li)
        'Next
        AutoSizeList(frm.ListView1)
        frm.ShowDialog()
        Timer1.Enabled = True
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Timer1_Tick(Nothing, Nothing)
    End Sub
End Class