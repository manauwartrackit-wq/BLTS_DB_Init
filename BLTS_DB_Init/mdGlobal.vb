Public Module mdGlobal
    Public fMain As frmMain
    Public Sub AutoSizeList(ByRef lst As ListView)
        For i As Integer = 0 To lst.Columns.Count - 1
            lst.Columns(i).Width = -2
        Next
    End Sub
    Public Function getAppPath() As String
        Dim strPath As String = System.Reflection.Assembly.GetExecutingAssembly.Location.ToString()
        strPath = strPath.Substring(0, strPath.LastIndexOf("\"))
        getAppPath = strPath
    End Function
    Public Sub Panel_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs)
        Dim r As Rectangle = sender.ClientRectangle
        r.Height = r.Height - 1
        r.Width = r.Width - 1
        e.Graphics.DrawRectangle(New Pen(Color.LightGray, 1), r)
    End Sub
    Public Enum FormMode
        None
        Insert
        Edit
        Delete
    End Enum
    Public Function GetComboValue(ByVal cmb As ComboBox) As Integer
        Try
            Dim arr As ArrayList = cmb.Tag
            Return arr(cmb.SelectedIndex)
        Catch ex As Exception

        End Try
    End Function
    Public Sub SetComboValue(ByRef cmb As ComboBox, ByVal Val As Integer)
        Dim arr As ArrayList = cmb.Tag
        For i As Integer = 0 To arr.Count - 1
            If arr(i) = Val Then
                cmb.SelectedIndex = i
                Exit Sub
            End If
        Next
    End Sub
    Public Function gfnExecSQL(ByVal strSQL As String) As Data.DataTable
        Dim dt As New DataTable
        Dim conn As New SqlClient.SqlConnection(My.Settings.ConnectionString.ToString)
        Dim comm As New SqlClient.SqlCommand(strSQL, conn)
        Dim da As New SqlClient.SqlDataAdapter(comm)
        Try
            conn.Open()
            da.Fill(dt)
            conn.Close()
        Catch ex As Exception
            conn.Close()
            MsgBox(ex.Message)
            MsgBox(strSQL)
        End Try
        Return dt
    End Function
    Public Function GetForeColor(Threat As ThreatLevel) As Color
        Select Case Threat
            Case ThreatLevel.Alcohol
                GetForeColor = Color.FromArgb(255, 196, 13)
            Case ThreatLevel.CD_DVD
                GetForeColor = Color.FromArgb(238, 17, 17)
            Case ThreatLevel.Drugs
                GetForeColor = Color.Gray
            Case ThreatLevel.Food
                GetForeColor = Color.FromArgb(0, 163, 0)
            Case ThreatLevel.Unknown
                GetForeColor = Color.FromArgb(45, 137, 239)
            Case ThreatLevel.TimeOut
                GetForeColor = Color.FromArgb(45, 137, 239)
        End Select
    End Function
    Public Function GetBackColor(Threat As ThreatLevel) As Color
        Select Case Threat
            Case ThreatLevel.Alcohol
                GetBackColor = Color.White
            Case ThreatLevel.CD_DVD
                GetBackColor = Color.White
            Case ThreatLevel.Drugs
                GetBackColor = Color.FromArgb(198, 198, 198)
            Case ThreatLevel.Food
                GetBackColor = Color.White
            Case ThreatLevel.Unknown
                GetBackColor = Color.White
            Case ThreatLevel.TimeOut
                GetBackColor = Color.White
        End Select
    End Function
    Public Function GetAlarmDesc(AlarmType As Integer) As String
        Select Case AlarmType
            Case 30
                Return "Bag Crossed Tagging Point"
            Case 31
                Return "Bag crossed Airside Dog House"
            Case 32
                Return "Bag crossed landside Dog House"
            Case 40
                Return "Suspect Bag"
        End Select
    End Function
End Module
Public Class RecordLine
    Public AlarmID As Integer
    Public TagID As String
    Public Threat As ThreatLevel
    Public EventTime As DateTime
    Public AType As AlarmType
    Public ASubType As AlarmSubType
    Public Location As String
    Public LastSeen As DateTime
    Public LastSeenAt As String
    Public lst As New List(Of DataRow)
End Class
Public Enum ThreatLevel
    Unknown = 0
    Drugs = 1
    Food = 2
    Alcohol = 3
    CD_DVD = 4
    TimeOut = 5
End Enum
Public Enum DeviceType
    Unknown = 0
    TaggingStation = 1
    TaggingReadPoint = 2
    DogHouseAir = 3
    DogHouseLand = 4
    ExitGate = 5
    InsideLounge = 6
    ExitLounge = 7
    RecheckStation = 8
    BHSReturnFeed = 9
End Enum
Public Enum AlarmType
    ProhibitedLuggage
    SuspectLuggage
    DeviceOffline
    NormalEvent
End Enum
Public Enum AlarmSubType
    None
    DelayProperPath
    DelayImproperPath
    MissedBag
End Enum
Public Class ListViewDoubleBuffered
    Inherits ListView

    Public Sub New()
        Me.DoubleBuffered = True
    End Sub
End Class