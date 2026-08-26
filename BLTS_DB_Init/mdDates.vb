Imports System
Imports System.Web
Imports System.Diagnostics
Imports System.Globalization
Imports System.Data
Imports System.Collections

Public Module mdDates
    'Private cur As HttpContext

    Private Const startGreg As Integer = 1900
    Private Const endGreg As Integer = 2100
    Private allFormats As String() = {"yyyy/MM/dd", "yyyy/M/d", "dd/MM/yyyy", "d/M/yyyy", "dd/M/yyyy", "d/MM/yyyy", "yyyy-MM-dd", "yyyy-M-d", "dd-MM-yyyy", "d-M-yyyy", "dd-M-yyyy", "d-MM-yyyy", "yyyy MM dd", "yyyy M d", "dd MM yyyy", "d M yyyy", "dd M yyyy", "d MM yyyy"}
    Private arCul As CultureInfo
    Private enCul As CultureInfo
    Private h As HijriCalendar
    Private g As GregorianCalendar

    Public Sub Init()
        arCul = New CultureInfo("ar-SA")
        enCul = New CultureInfo("en-US")
        h = New HijriCalendar
        g = New GregorianCalendar(GregorianCalendarTypes.USEnglish)
        arCul.DateTimeFormat.Calendar = h
    End Sub
    Public Function IsHijri(ByVal hijri As String) As Boolean
        If (hijri.Length <= 0) Then
            Return False
        End If
        Try
            Dim tempDate As DateTime = DateTime.ParseExact(hijri, allFormats, arCul.DateTimeFormat, DateTimeStyles.AllowWhiteSpaces)
            If (tempDate.Year >= startGreg And tempDate.Year <= endGreg) Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Function IsGreg(ByVal greg As String) As Boolean
        If (greg.Length <= 0) Then
            Return False
        End If
        Try
            Dim tempDate As DateTime = DateTime.ParseExact(greg, allFormats, enCul.DateTimeFormat, DateTimeStyles.AllowWhiteSpaces)
            If (tempDate.Year >= startGreg And tempDate.Year <= endGreg) Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Function FormatHijri(ByVal dt As String, ByVal format As String) As String
        If (dt.Length <= 0) Then
            Return ""
        End If
        Try
            Dim tempDate As DateTime = DateTime.ParseExact(dt, allFormats, arCul.DateTimeFormat, DateTimeStyles.AllowWhiteSpaces)
            Return tempDate.ToString(format, arCul.DateTimeFormat)
        Catch ex As Exception
            Return ""
        End Try
    End Function
    Public Function FormatGreg(ByVal dt As String, ByVal format As String) As String
        If (dt.Length <= 0) Then
            Return ""
        End If
        Try
            Dim tempDate As DateTime = DateTime.ParseExact(dt, allFormats, enCul.DateTimeFormat, DateTimeStyles.AllowWhiteSpaces)
            Return tempDate.ToString(format, enCul.DateTimeFormat)
        Catch ex As Exception
            Return ""
        End Try
    End Function
    Public Function GDateNow() As String
        Try
            Return DateTime.Now.ToString("yyyy/MM/dd", enCul.DateTimeFormat)
        Catch ex As Exception
            Return ""
        End Try
    End Function
    Public Function dGDateNow() As DateTime
        Try
            Dim tempDate As DateTime = DateTime.ParseExact(GDateNow, allFormats, enCul.DateTimeFormat, DateTimeStyles.AllowWhiteSpaces)
            Return tempDate
        Catch ex As Exception
            Return ""
        End Try
    End Function
    Public Function GDateConvert(ByVal dt As Date, Optional ByVal format As String = "dd MMM yyyy HH:mm:ss") As String
        Try
            Return dt.ToString(format, enCul.DateTimeFormat)
        Catch ex As Exception
            Return ""
        End Try
    End Function
    Public Function HDateConvert(ByVal dt As Date, Optional ByVal format As String = "dd MMM yyyy HH:mm:ss") As String
        Try
            Return dt.ToString(format, arCul.DateTimeFormat)
        Catch ex As Exception
            Return ""
        End Try
    End Function
    Public Function GDateNow(ByVal format As String) As String
        Try
            Return DateTime.Now.ToString(format, enCul.DateTimeFormat)
        Catch ex As Exception
            Return ""
        End Try
    End Function
    Public Function HDateNow() As String
        Try
            Return DateTime.Now.ToString("yyyy/MM/dd", arCul.DateTimeFormat)
        Catch ex As Exception
            Return ""
        End Try
    End Function
    Public Function dHDateNow() As DateTime
        Try
            Dim tempDate As DateTime = DateTime.ParseExact(HDateNow, allFormats, arCul.DateTimeFormat, DateTimeStyles.AllowWhiteSpaces)
            Return tempDate
        Catch ex As Exception
            Return ""
        End Try
    End Function
    Public Function HDateNow(ByVal format As String) As String
        Try
            Return DateTime.Now.ToString(format, arCul.DateTimeFormat)
        Catch ex As Exception
            Return ""
        End Try
    End Function
    Public Function HijriToGreg(ByVal hijri As String) As String
        If (hijri.Length <= 0) Then
            Return ""
        End If
        Try
            Dim tempDate As DateTime = DateTime.ParseExact(hijri, allFormats, arCul.DateTimeFormat, DateTimeStyles.AllowWhiteSpaces)
            Return tempDate.ToString("yyyy/MM/dd", enCul.DateTimeFormat)
        Catch ex As Exception
            Return ""
        End Try
    End Function
    Public Function HijriToGreg(ByVal hijri As String, ByVal format As String) As String
        If (hijri.Length <= 0) Then
            Return ""
        End If
        Try
            Dim tempDate As DateTime = DateTime.ParseExact(hijri, allFormats, arCul.DateTimeFormat, DateTimeStyles.AllowWhiteSpaces)
            Return tempDate.ToString(format, enCul.DateTimeFormat)
        Catch ex As Exception
            Return ""
        End Try
    End Function
    Public Function GregToHijri(ByVal greg As String) As String
        If (greg.Length <= 0) Then
            Return ""
        End If
        Try
            Dim tempDate As DateTime = DateTime.ParseExact(greg, allFormats, enCul.DateTimeFormat, DateTimeStyles.AllowWhiteSpaces)
            Return tempDate.ToString("yyyy/MM/dd", arCul.DateTimeFormat)
        Catch ex As Exception
            Return ""
        End Try
    End Function
    Public Function GregToHijri(ByVal greg As String, ByVal format As String) As String
        If (greg.Length <= 0) Then
            Return ""
        End If
        Try
            Dim tempDate As DateTime = DateTime.ParseExact(greg, allFormats, enCul.DateTimeFormat, DateTimeStyles.AllowWhiteSpaces)
            Return tempDate.ToString(format, arCul.DateTimeFormat)
        Catch ex As Exception
            Return ""
        End Try
    End Function
    Public Function GTimeStamp() As String
        Return GDateNow("yyyyMMddHHmmss")
    End Function
    Public Function HTimeStamp() As String
        Return HDateNow("yyyyMMddHHmmss")
    End Function
    Public Function Compare(ByVal d1 As String, ByVal d2 As String) As Integer
        Try
            Dim date1 As DateTime = DateTime.ParseExact(d1, allFormats, arCul.DateTimeFormat, DateTimeStyles.AllowWhiteSpaces)
            Dim date2 As DateTime = DateTime.ParseExact(d2, allFormats, arCul.DateTimeFormat, DateTimeStyles.AllowWhiteSpaces)
            Return DateTime.Compare(date1, date2)
        Catch ex As Exception
            Return -1
        End Try
    End Function

End Module
