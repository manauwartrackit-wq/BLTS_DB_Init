Public Class frmLicense
    Dim epoch As New Date(1970, 1, 1)
    Private Sub frmLicense_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ta As New DBTableAdapters.SystemSettingsTableAdapter
        Dim _dt As DB.SystemSettingsDataTable = ta.GetData
        Dim flg As Boolean = False
        For Each rw As DB.SystemSettingsRow In _dt.Rows
            If rw.SettingName = "LicenseKey" Then
                flg = True
                Exit For
            End If
        Next
        If Not flg Then
            ta.Insert(36, "LicenseKey", "", Now)
        End If
        Dim qta As New DBTableAdapters.QueriesTableAdapter
        Dim ac As String = qta.GetSettings("LicenseKey")
        'TextBox1.Text = qta.GetSettings("LicenseKey")
        Dim str As String = DecryptText(ac)
        Dim dt() As String = str.Split(",")
        If dt.Count = 3 Then
            'Valid
            FillList(dt, ac)
        Else
            MsgBox("Invalid License Key")
        End If
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.TextLength > 0 Then
            'Validate
            Dim str As String = DecryptText(TextBox1.Text)
            Dim dt() As String = str.Split(",")
            If dt.Count = 3 Then
                'Valid
                FillList(dt, TextBox1.Text)
            Else
                MsgBox("Invalid License Key")
            End If
            Dim qta As New DBTableAdapters.SystemSettingsTableAdapter
            qta.UpdateQuery(TextBox1.Text, "LicenseKey")
            MsgBox("License key updated")
        Else
            MsgBox("Please enter the activation code")
        End If
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim str As String = "111," & Today.AddMonths(12).Subtract(epoch).TotalSeconds & "," & Guid.NewGuid.ToString
        Dim encrypt As String = EncryptText(str)
        TextBox1.Text = encrypt
    End Sub
    Private Sub FillList(dt() As String, ac As String)
        ListView1.Items.Clear()
        Dim lc As New ListViewItem("Licensed Count of Devices")
        lc.SubItems.Add(dt(0))
        ListView1.Items.Add(lc)
        Dim la As New ListViewItem("Activation Code")
        la.SubItems.Add(ac)
        ListView1.Items.Add(la)
        Dim ld As New ListViewItem("Valid Till")
        ld.SubItems.Add(epoch.AddSeconds(dt(1)).ToString("dd MMM yyyy"))
        ListView1.Items.Add(ld)
        Dim lv As New ListViewItem("Validation code")
        lv.SubItems.Add(dt(2))
        ListView1.Items.Add(lv)
        Dim _ta As New DBTableAdapters.LogicalDeviceTableAdapter
        Dim _dt As DB.LogicalDeviceDataTable = _ta.GetDataBy
        Dim lb As New ListViewItem("Current Device Count")
        lb.SubItems.Add(_dt.Rows.Count)
        ListView1.Items.Add(lb)
        Dim le As New ListViewItem("Available Licenses")
        Dim cnt As Integer = dt(0) - _dt.Rows.Count
        le.SubItems.Add(dt(0) - _dt.Rows.Count)
        If cnt > 0 Then
            le.ForeColor = Color.DarkGreen
        Else
            le.ForeColor = Color.DarkRed
        End If
        ListView1.Items.Add(le)
        AutoSizeList(ListView1)
    End Sub
End Class