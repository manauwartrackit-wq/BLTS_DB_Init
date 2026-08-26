Imports System
Imports System.Management
Imports System.Security.Cryptography
Module mdLicensing
    Private key() As Byte = {1, 2, 3, 4, 5, 6, 7, 8, 9, 20, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24}
    Private ivIn() As Byte = {68, 85, 82, 82, 73, 89, 65, 46}
    Private ivPassword() As Byte = {0, 9, 8, 7, 6, 5, 4, 3}
    Private ivOut() As Byte = {72, 85, 83, 65, 73, 78, 46, 46}
    Public Function VerifyLicense(ByVal KeyCode As String, ByRef _ValidTill As Date) As Object
        VerifyLicense = Nothing
        Dim Type As String = KeyCode.Substring(0, 1)
        Select Case Type
            Case "A"
                VerifyLicense = VerifyMACLicense(KeyCode)
                If VerifyMACLicense(KeyCode) Then
                    _ValidTill = ValidTill(KeyCode)
                Else
                    _ValidTill = Now.Subtract(New TimeSpan(1, 0, 0, 0))
                End If
            Case "B"
                VerifyLicense = True
                _ValidTill = VerifyTimeLicense(KeyCode)
        End Select
    End Function
    Private Function getMacAddress() As String
        getMacAddress = ""
        Dim mc As System.Management.ManagementClass
        Dim mo As ManagementObject
        mc = New ManagementClass("Win32_NetworkAdapterConfiguration")
        Dim moc As ManagementObjectCollection = mc.GetInstances()
        For Each mo In moc
            If mo.Item("IPEnabled") = True Then
                getMacAddress = mo.Item("MacAddress").ToString().Replace(":", "") & "00000000"
                Exit For
            End If
        Next
    End Function
    Public Function getMachineCode() As String
        Dim strMAC As String = getMacAddress()
        Dim MacCode() As Byte = Encrypt(strMAC, ivIn)
        Return Byte2String(MacCode)
    End Function
    Public Function VerifyMACLicense(ByVal KeyCode() As Byte) As Boolean
        VerifyMACLicense = False
        Dim strMAC As String = getMacAddress()
        'Dim MacCode() As Byte = Decrypt(strMAC, ivOut)
        Dim strCalcMAC As String = Decrypt(KeyCode, ivOut)
        'Compare
        Try
            If strCalcMAC.Substring(0, 12) = strMAC.Substring(0, 12) Then
                VerifyMACLicense = True
            End If
        Catch ex As Exception
        End Try
    End Function
    Public Function VerifyMACLicense(ByVal KeyCode As String) As Boolean
        VerifyMACLicense = VerifyMACLicense(String2Byte(KeyCode.Substring(1)))
    End Function
    Private Function Encrypt(ByVal plainText As String, ByVal iv() As Byte) As Byte()
        Dim utf8encoder As System.Text.UTF8Encoding = New System.Text.UTF8Encoding
        Dim inputInBytes() As Byte = utf8encoder.GetBytes(plainText)
        Dim tdesProvider As TripleDESCryptoServiceProvider = New TripleDESCryptoServiceProvider
        Dim cryptoTransform As ICryptoTransform = tdesProvider.CreateEncryptor(key, iv)
        Dim encryptedStream As System.IO.MemoryStream = New System.IO.MemoryStream
        Dim cryptStream As CryptoStream = New CryptoStream(encryptedStream, cryptoTransform, CryptoStreamMode.Write)
        cryptStream.Write(inputInBytes, 0, inputInBytes.Length)
        cryptStream.FlushFinalBlock()
        encryptedStream.Position = 0
        Dim result(encryptedStream.Length - 1) As Byte
        encryptedStream.Read(result, 0, encryptedStream.Length)
        cryptStream.Close()
        Return result
    End Function
    Private Function Decrypt(ByVal inputInBytes() As Byte, ByVal iv() As Byte) As String
        Decrypt = ""
        Try
            Dim utf8encoder As System.Text.UTF8Encoding = New System.Text.UTF8Encoding
            Dim tdesProvider As TripleDESCryptoServiceProvider = New TripleDESCryptoServiceProvider
            Dim cryptoTransform As ICryptoTransform = tdesProvider.CreateDecryptor(key, iv)
            Dim decryptedStream As System.IO.MemoryStream = New System.IO.MemoryStream
            Dim cryptStream As CryptoStream = New CryptoStream(decryptedStream, cryptoTransform, CryptoStreamMode.Write)
            cryptStream.Write(inputInBytes, 0, inputInBytes.Length)
            cryptStream.FlushFinalBlock()
            decryptedStream.Position = 0
            Dim result(decryptedStream.Length - 1) As Byte
            decryptedStream.Read(result, 0, decryptedStream.Length)
            cryptStream.Close()
            Dim myutf As System.Text.UTF8Encoding = New System.Text.UTF8Encoding
            Return myutf.GetString(result)
        Catch ex As Exception
        End Try
    End Function
    Private Function GetDecryptedMAC(ByVal by() As Byte) As String
        GetDecryptedMAC = Decrypt(by, ivIn)
    End Function
    Public Function GetMACLicenseKey(ByVal MachineCode As String, ByVal dt As Date) As String
        Dim mac As String = GetDecryptedMAC(String2Byte(MachineCode))
        mac = mac & dt.Ticks
        GetMACLicenseKey = "A" & Byte2String(Encrypt(mac, ivOut))
    End Function
    Private Function Byte2String(ByVal by() As Byte) As String
        Byte2String = ""
        Try
            Dim i As Integer
            Dim str As String = ""
            For i = 0 To by.Length - 2
                str &= by(i).ToString & "-"
            Next
            str &= by(i).ToString
            Byte2String = str
        Catch ex As Exception
        End Try
    End Function
    Private Function String2Byte(ByVal str As String) As Byte()
        Dim strByte() As String = str.Split("-")
        Dim by(strByte.Length - 1) As Byte
        String2Byte = by
        Try
            Dim i As Integer
            For i = 0 To strByte.Length - 1
                by(i) = strByte(i)
            Next
            String2Byte = by
        Catch ex As Exception
        End Try
    End Function
    Public Function ValidTill(ByVal KeyCode As String) As Date
        Dim str As String = GetDecryptedMAC(String2Byte(KeyCode.Substring(1)))
        str = str.Substring(20)
        Dim dt As New Date(str)
        ValidTill = dt
    End Function
    Public Function GetTimeLimitedLicense(ByVal cd As Date) As String
        Return "B" & Byte2String(Encrypt(cd.Ticks, ivIn))
    End Function
    Public Function VerifyTimeLicense(ByVal Key As String) As Date
        Try
            Key = Key.Substring(1)
            VerifyTimeLicense = dGDateNow.Subtract(New TimeSpan(1, 0, 0, 0))
            Dim dt As New Date(Decrypt(String2Byte(Key), ivIn))
            If dt > dGDateNow() Then
                VerifyTimeLicense = dt
            Else
                MsgBox("License has expired")
            End If
        Catch ex As Exception
            MsgBox("Invalid License")
        End Try
    End Function
    Private Function toDec(ByVal st As String) As Integer
        If Not IsNumeric(st) Then
            toDec = Microsoft.VisualBasic.Asc(UCase(st)) - 55
        Else
            toDec = Microsoft.VisualBasic.Val(st)
        End If
    End Function
    Private Function toDec2(ByVal st As String) As Long
        Dim i As Integer = st.Length
        Dim cnt As Integer
        Dim ln As Long = 0
        For cnt = 0 To i - 1
            ln = (ln * 16) + toDec(st.Substring(cnt, 1))
        Next
        toDec2 = ln
    End Function
    Public Function EncryptText(ByVal strData As String) As String
        Dim by() As Byte = Encrypt(strData, ivPassword)
        EncryptText = ""
        Try
            Dim i As Integer
            For i = 0 To by.Length - 1
                EncryptText &= Hex(by(i)).PadLeft(2, "0")
            Next
        Catch ex As Exception
        End Try
    End Function
    Public Function DecryptText(ByVal strData As String) As String
        DecryptText = ""
        Try
            Dim by((strData.Length / 2) - 1) As Byte
            Dim i As Integer
            For i = 0 To (strData.Length / 2) - 1
                by(i) = toDec2(strData.Substring(i * 2, 2))
            Next
            DecryptText = Decrypt(by, ivPassword)
        Catch ex As Exception

        End Try
    End Function
End Module
