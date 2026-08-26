Public Class frmMain
    Private Sub Label2_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Dim l As Label = sender
        l.BackColor = Color.FromArgb(249, 249, 249)
    End Sub
    Private Sub Label2_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim l As Label = sender
        l.BackColor = Color.LightGray
    End Sub
    Private Sub Label2_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim l As Label = sender
        l.BackColor = Color.FromArgb(249, 249, 249)
    End Sub
    Private Sub Label2_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Dim l As Label = sender
        l.BackColor = Color.LightGray
    End Sub
    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim t As String = sender.tag
        For Each c As Control In Panel2.Controls
            If c.Tag = "I" & t Then
                c.Visible = Not c.Visible
            End If
        Next
    End Sub
    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fMain = Me
        For Each c As Control In Panel2.Controls
            Dim l As Label = c
            If l.Tag.ToString.StartsWith("I") Then
                AddHandler l.MouseDown, AddressOf Label2_MouseDown
                AddHandler l.MouseEnter, AddressOf Label2_MouseEnter
                AddHandler l.MouseLeave, AddressOf Label2_MouseLeave
                AddHandler l.MouseUp, AddressOf Label2_MouseUp
            Else
                AddHandler l.Click, AddressOf Label1_Click
            End If
        Next
    End Sub
    Private Sub Label14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label14.Click
        CloseAllChild()
        Dim frm As New frmSysSettings
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub Label10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label10.Click
        CloseAllChild()
        Dim frm As New frmDeviceStatusv2
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub Label12_Click(sender As Object, e As EventArgs) Handles Label12.Click
        CloseAllChild()
        Dim frm As New frmTagReport
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        CloseAllChild()
        Dim frm As New frmLogicalDevice
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        CloseAllChild()
        Dim frm As New frmLicense
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub CloseAllChild()
        For Each f As Form In Me.MdiChildren
            f.Close()
        Next
    End Sub
End Class