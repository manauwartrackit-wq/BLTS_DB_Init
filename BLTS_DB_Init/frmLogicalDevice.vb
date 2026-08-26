Public Class frmLogicalDevice
    Dim fMode As String = "None"
    Dim RID As Integer = 0
    Private Sub frmLogicalDevice_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RefreshReaders()
    End Sub
    Private Sub RefreshReaders()
        ComboBox1.Items.Clear()
        Dim ta As New DBTableAdapters.ReadersTableAdapter
        Dim dt As DB.ReadersDataTable = ta.GetData
        Dim arr As New ArrayList
        arr.Add(0)
        ComboBox1.Items.Add("[Select One]")
        For Each rw As DB.ReadersRow In dt.Rows
            If rw.IsReaderIPNull Then
                ComboBox1.Items.Add(rw.ReaderCode)
            Else
                ComboBox1.Items.Add(rw.ReaderCode & ":" & rw.ReaderIP)
            End If
            arr.Add(rw.ID)
        Next
        ComboBox1.Tag = arr
        ComboBox1.SelectedIndex = 0
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        RID = 0
        fMode = "None"
        If ComboBox1.SelectedIndex = 0 Then
            MsgBox("Please select a reader")
            Exit Sub
        End If
        Dim ta As New DBTableAdapters.ReadersTableAdapter
        Dim dt As DB.ReadersDataTable = ta.GetDataByID(GetComboValue(ComboBox1))
        If dt.Rows.Count = 0 Then
            MsgBox("An error occured")
            Exit Sub
        End If
        Dim rw As DB.ReadersRow = dt.Rows(0)
        TextBox1.Text = rw.ReaderCode
        If Not rw.IsReaderIPNull Then
            TextBox2.Text = rw.ReaderIP
        Else
            TextBox2.Text = ""
        End If
        Dim ata As New DBTableAdapters.AntennasTableAdapter
        Dim adt As DB.AntennasDataTable = ata.GetData(rw.ID)
        If adt.Rows.Count = 0 Then
            NumericUpDown1.Value = 1
        Else
            NumericUpDown1.Value = adt.Rows.Count
        End If
        If rw.IsisActiveNull Then
            CheckBox1.Checked = True
        Else
            CheckBox1.Checked = rw.isActive
        End If
        RID = rw.ID
        fMode = "Edit"
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        RID = 0
        fMode = "None"
        TextBox1.Text = ""
        TextBox2.Text = ""
        NumericUpDown1.Value = 1
        CheckBox1.Checked = False
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If RID > 0 And fMode = "Edit" Then
            If TextBox1.TextLength = 0 Then
                MsgBox("Please enter a reader code")
                Exit Sub
            End If
            If TextBox2.TextLength = 0 Then
                MsgBox("Please enter reader IP Address")
                Exit Sub
            End If
            Dim ip As System.Net.IPAddress
            If Not System.Net.IPAddress.TryParse(TextBox2.Text, ip) Then
                MsgBox("Please enter a valid reader IP Address")
                Exit Sub
            End If
            'Update values
            Dim ta As New DBTableAdapters.ReadersTableAdapter
            ta.UpdateQuery(TextBox1.Text, TextBox1.Text, TextBox2.Text, 5084, CheckBox1.Checked, RID)
            'Check if antennas are same
            Dim ata As New DBTableAdapters.AntennasTableAdapter
            Dim AnCnt As Integer = ata.GetData(RID).Rows.Count
            If AnCnt = NumericUpDown1.Value Then
                'Same, no changes
            Else
                If AnCnt < NumericUpDown1.Value Then
                    'Add more
                    For i As Integer = AnCnt To NumericUpDown1.Value - 1
                        ata.Insert(RID, i + 1, TextBox1.Text & "-" & i + 1, TextBox1.Text & "-" & i + 1, 200, Nothing, Nothing, "", "", True, 1, Now)
                    Next
                End If
            End If
            Button3_Click(Nothing, Nothing)
            RefreshReaders()
        Else
            MsgBox("Please select a reader to edit")
        End If
    End Sub
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim frm As New frmDevices
        frm.ShowDialog()
    End Sub
End Class