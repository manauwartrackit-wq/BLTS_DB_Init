Public Class frmDevices
    Dim fMode As FormMode = FormMode.Insert
    Dim FormID As Integer = 0
    Private Sub frmDevices_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        RadioButton1.Checked = True
        RefreshList()
    End Sub
    Private Sub RefreshList()
        ListView1.Items.Clear()
        Dim ta As New DBTableAdapters.ReadersTableAdapter
        Dim dt As DB.ReadersDataTable = ta.GetData
        For Each rw As DB.ReadersRow In dt.Rows
            Dim li As New ListViewItem(rw.ReaderCode)
            If Not rw.IsReaderIPNull Then
                li.SubItems.Add(rw.ReaderIP)
            Else
                li.SubItems.Add("")
            End If
            If Not rw.IsStatusNull Then
                li.SubItems.Add(rw.Status)
            Else
                li.SubItems.Add("NA")
            End If
            If Not rw.IsCreatedDateNull Then
                li.SubItems.Add(rw.CreatedDate.ToString("dd MMM yyyy HH:mm"))
            Else
                li.SubItems.Add("NA")
            End If
            If Not rw.IsLastConnectedNull Then
                li.SubItems.Add(rw.LastConnected.ToString("dd MMM yyyy HH:mm"))
            Else
                li.SubItems.Add("NA")
            End If
            If rw.isActive Then
                li.ForeColor = Color.DarkGreen
            Else
                li.ForeColor = Color.DarkRed
            End If
            li.Tag = rw.ID
            ListView1.Items.Add(li)
        Next
        AutoSizeList(ListView1)
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        fMode = FormMode.Insert
        FormID = 0
        TextBox1.Text = ""
        TextBox2.Text = ""
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If ListView1.SelectedItems.Count = 0 Then
            MsgBox("Please select an item to edit")
            Exit Sub
        End If
        FormID = ListView1.SelectedItems(0).Tag
        TextBox1.Text = ListView1.SelectedItems(0).SubItems(0).Text
        TextBox2.Text = ListView1.SelectedItems(0).SubItems(1).Text
        Dim ta As New DBTableAdapters.AntennasTableAdapter
        Dim dt As DB.AntennasDataTable = ta.GetData(FormID)
        If dt.Rows.Count = 0 Then
            'add 8 Antennas
            For i As Integer = 1 To 8
                ta.Insert(FormID, i, TextBox1.Text & "_" & i, "", 300, Nothing, Nothing, "", "", True, 1, Now)
            Next
        ElseIf dt.Rows.Count = 4 Then
            RadioButton1.Checked = True
            For Each rw As DB.AntennasRow In dt.Rows
                CheckedListBox1.SetItemChecked(rw.AntennaPort - 1, rw.isActive)
            Next
        ElseIf dt.Rows.Count = 8 Then
            RadioButton2.Checked = True
        Else
            MsgBox("Invalid Antenna Count. Please delete and re-create reader")
            Exit Sub
        End If
        fMode = FormMode.Edit
    End Sub
    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged, RadioButton1.CheckedChanged
        CheckedListBox1.Items.Clear()
        Dim X As Integer = 4
        If RadioButton2.Checked Then
            X = 8
        End If
        For i As Integer = 1 To X
            CheckedListBox1.Items.Add("Port " & i, True)
        Next
    End Sub
End Class