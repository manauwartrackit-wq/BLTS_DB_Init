Public Class frmTagStatus

    Private Sub frmTagStatus_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ComboBox1.SelectedIndex = 0
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ListView1.Items.Clear()
        If TextBox1.TextLength = 0 Then
            MsgBox("Please specify Tag ID")
            Exit Sub
        End If
        Dim ta As New DBTableAdapters.AlarmListTableAdapter
        Dim dt As DB.AlarmListDataTable = ta.GetData(TextBox1.Text)
        For Each rw As DB.AlarmListRow In dt.Rows
            Dim li As New ListViewItem(rw.TStamp.ToString("dd MMM yyyy HH:mm:ss"))
            li.SubItems.Add(rw.TagID)
            li.SubItems.Add(GetText(rw.ScanResult))
            li.SubItems.Add(rw.LogicalDeviceCode)
            li.SubItems.Add(rw.DeviceName)
            li.SubItems.Add(rw.AlarmDesc)
            li.SubItems.Add(IIf(rw.isAlarm, "Yes", "No"))
            If rw.isAlarm Then
                li.ForeColor = Color.Red
            Else
                li.ForeColor = Color.Black
            End If
            ListView1.Items.Add(li)
        Next
        AutoSizeList(ListView1)
    End Sub
    Private Function GetText(ByVal x As Integer) As String
        Dim t As ThreatType = CType(x, ThreatType)
        Return t.ToString
    End Function
End Class
Public Enum ThreatType
    B_Unknown = 0
    W_Drugs = 1
    G_Food = 2
    Y_Alcohol = 3
    R_CDDVD = 4
End Enum