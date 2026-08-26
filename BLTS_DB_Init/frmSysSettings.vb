Public Class frmSysSettings
    Dim qta As New DBTableAdapters.QueriesTableAdapter
    Dim HATime As Integer
    Private Sub frmSysSettings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            S1_0.Value = qta.GetSettings("TimeTagToReadPoint")
            S1_1.Value = qta.GetSettings("TimeTagToReadPoint_Delay")
            S2_0.Value = qta.GetSettings("TimeRPToDGAir")
            S2_1.Value = qta.GetSettings("TimeRPToDGAir_Delay")
            S3_0.Value = qta.GetSettings("TimeDGAirToLand")
            S3_1.Value = qta.GetSettings("TimeDGAirToLand_Delay")
            S4_0.Value = qta.GetSettings("TimeDGLandToExit")
            S4_1.Value = qta.GetSettings("TimeDGLandToExit_Delay")
            S5_0.Value = qta.GetSettings("TimeExitToRecheck")
            S5_1.Value = qta.GetSettings("TimeExitToRecheck_Delay")
            S6_0.Value = qta.GetSettings("TimeLInToLOut")
            S6_1.Value = qta.GetSettings("TimeLInToLOut_Delay")
            S7_0.Value = qta.GetSettings("TimeLOutToExit")
            S7_1.Value = qta.GetSettings("TimeLOutToExit_Delay")
            S8_0.Value = qta.GetSettings("TimeRFToDGAir")
            S8_1.Value = qta.GetSettings("TimeRFToDGAir_Delay")
            HATime = qta.GetSettings("HATimeOut")
            Timer1_Tick(Nothing, Nothing)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Try
            TextBox1.Text = qta.GetSettings("PrimaryServerRS_ADG_IP")
            Dim str As String = qta.GetSettings("PrimaryServerRS_ADG_Date")
            lblTime.Text = CDate(str.Substring(0, str.Length - 4)).ToString("dd MMM yyyy HH:mm:ss")
            If Now.Subtract(CDate(str.Substring(0, str.Length - 4))).TotalSeconds > HATime Then
                TextBox1.BackColor = Color.LightPink
            Else
                TextBox1.BackColor = Color.LightGreen
            End If
        Catch ex As Exception
            TextBox1.Text = "DB Error"
            TextBox1.BackColor = Color.LightPink
        End Try
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim ta As New DBTableAdapters.SystemSettingsTableAdapter
            ta.UpdateQuery(S1_0.Value, "TimeTagToReadPoint")
            ta.UpdateQuery(S1_1.Value, "TimeTagToReadPoint_Delay")
            ta.UpdateQuery(S2_0.Value, "TimeRPToDGAir")
            ta.UpdateQuery(S2_1.Value, "TimeRPToDGAir_Delay")
            ta.UpdateQuery(S3_0.Value, "TimeDGAirToLand")
            ta.UpdateQuery(S3_1.Value, "TimeDGAirToLand_Delay")
            ta.UpdateQuery(S4_0.Value, "TimeDGLandToExit")
            ta.UpdateQuery(S4_1.Value, "TimeDGLandToExit_Delay")
            ta.UpdateQuery(S5_0.Value, "TimeExitToRecheck")
            ta.UpdateQuery(S5_1.Value, "TimeExitToRecheck_Delay")
            ta.UpdateQuery(S6_0.Value, "TimeLInToLOut")
            ta.UpdateQuery(S6_1.Value, "TimeLInToLOut_Delay")
            ta.UpdateQuery(S7_0.Value, "TimeLOutToExit")
            ta.UpdateQuery(S7_1.Value, "TimeLOutToExit_Delay")
            ta.UpdateQuery(S8_0.Value, "TimeRFToDGAir")
            ta.UpdateQuery(S8_1.Value, "TimeRFToDGAir_Delay")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub
End Class