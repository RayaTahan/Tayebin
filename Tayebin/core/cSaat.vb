Imports Microsoft.VisualBasic

Public Class cSaat

    Public Enum No
        h24Bozorg
        h24Kuchik
        h12Bozorg
        h12Kuchik
        h12SABozorg
        h12SABozorgBiSanieh
        h12SABozorg2BiSanieh
        h12SAKuchik
        h12SAKuchikBiSanieh
    End Enum

    Dim localDateTime As DateTime

    Public Sub New()
        'localDateTime = Now.AddMinutes(-System.Configuration.ConfigurationSettings.AppSettings("Ekhtelaf"))
        localDateTime = Now
    End Sub

    Public Sub New(Miladi As DateTime)
        localDateTime = Miladi
    End Sub

    Public ReadOnly Property Saat() As Integer
        Get
            Return localDateTime.Hour
        End Get
    End Property

    Public ReadOnly Property Daqiqe() As Integer
        Get
            Return localDateTime.Minute
        End Get
    End Property

    Public ReadOnly Property Sanie() As Integer
        Get
            Return localDateTime.Second
        End Get
    End Property

    Public Overrides Function ToString() As String
        Dim tmp As String
        tmp = Strings.Right("00" & Saat.ToString, 2) & ":" & Strings.Right("00" & Daqiqe.ToString, 2) & ":" & Strings.Right("00" & Sanie.ToString, 2)
        Return tmp
    End Function

    Public Overloads Function ToString(ByVal No As No) As String
        Dim tmp As String = ""
        Dim h As Integer = Saat
        Dim s As String = "صبح"
        If Saat > 12 Then
            h = Saat - 12
            s = "بعد از ظهر"
        End If

        Select Case No
            Case cSaat.No.h24Bozorg
                tmp = Strings.Right("00" & Saat.ToString, 2) & ":" & Strings.Right("00" & Daqiqe.ToString, 2) & ":" & Strings.Right("00" & Sanie.ToString, 2)
            Case cSaat.No.h24Kuchik
                tmp = Saat.ToString & ":" & Daqiqe.ToString & ":" & Sanie.ToString
            Case cSaat.No.h12Bozorg
                tmp = Strings.Right("00" & h.ToString, 2) & ":" & Strings.Right("00" & Daqiqe.ToString, 2) & ":" & Strings.Right("00" & Sanie.ToString, 2)
            Case cSaat.No.h12Kuchik
                tmp = h.ToString & ":" & Daqiqe.ToString & ":" & Sanie.ToString
            Case cSaat.No.h12SABozorg
                tmp = ToString(No.h12Bozorg)
                tmp += " " & s
            Case cSaat.No.h12SABozorgBiSanieh
                tmp = Strings.Right("00" & h.ToString, 2) & ":" & Strings.Right("00" & Daqiqe.ToString, 2)
                tmp += " " & s
            Case cSaat.No.h12SABozorg2BiSanieh
                tmp = h.ToString & ":" & Strings.Right("00" & Daqiqe.ToString, 2)
                tmp += " " & s
            Case cSaat.No.h12SAKuchik
                tmp = ToString(No.h12Kuchik)
                tmp += " " & s
            Case cSaat.No.h12SAKuchikBiSanieh
                tmp = h.ToString & ":" & Daqiqe.ToString
                tmp += " " & s
        End Select
        Return tmp
    End Function

End Class
