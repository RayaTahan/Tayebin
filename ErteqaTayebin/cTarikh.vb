Imports Microsoft.VisualBasic
Imports System.Globalization

Public Class cTarikh
    Dim PC As New PersianCalendar
    Dim SourceDate As New Date

    Public Sub New()
        'SourceDate = Now.AddMinutes(-System.Configuration.ConfigurationSettings.AppSettings("Ekhtelaf"))
        SourceDate = Now
    End Sub

    Public Sub New(ByVal Miladi As Date)
        SourceDate = Miladi
    End Sub

    Public ReadOnly Property Sal() As Integer
        Get
            Return PC.GetYear(SourceDate)
        End Get
    End Property

    Public ReadOnly Property Mah() As Integer
        Get
            Return PC.GetMonth(SourceDate)
        End Get
    End Property

    Public ReadOnly Property EsmeMah() As String
        Get
            Return EsmeMahha(Mah)
        End Get
    End Property

    Public ReadOnly Property Ruz() As Integer
        Get
            Return PC.GetDayOfMonth(SourceDate)
        End Get
    End Property

    Public Enum No
        YYYY1MM1DD
        YY1M1D
        D0m0YY
        D0m0YYYY
        D0m
        MM1DD
    End Enum

    Public EsmeMahha() As String = {"", "فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند"}

    Public Overrides Function ToString() As String
        Dim tmp As String
        tmp = Strings.Right("0000" & Sal.ToString, 4)
        tmp += "/" & Strings.Right("00" & Mah.ToString, 2)
        tmp += "/" & Strings.Right("00" & Ruz.ToString, 2)
        Return tmp
    End Function

    Public Overloads Function ToString(ByVal No As No) As String
        Dim tmp As String = ""
        Select Case No
            Case cTarikh.No.YYYY1MM1DD
                tmp = Strings.Right("0000" & Sal.ToString, 4)
                tmp += "/" & Strings.Right("00" & Mah.ToString, 2)
                tmp += "/" & Strings.Right("00" & Ruz.ToString, 2)
            Case cTarikh.No.YY1M1D
                tmp = Strings.Right("00" & Sal.ToString, 2) & "/" & Mah.ToString & "/" & Ruz.ToString
            Case cTarikh.No.D0m0YYYY
                tmp = Ruz.ToString
                tmp += " " & EsmeMah & " " & Sal.ToString
            Case cTarikh.No.MM1DD
                tmp = Strings.Right("00" & Mah.ToString, 2)
                tmp += "/" & Strings.Right("00" & Ruz.ToString, 2)
            Case cTarikh.No.D0m
                tmp = Ruz.ToString
                tmp += " " & EsmeMah
        End Select
        Return tmp
    End Function

    Public Function Tabdil(ByVal Shamsi As String, ByVal no As No) As String
        Dim ret As String = ""
        Dim tt() As String = Shamsi.Split("/")
        Dim s, m, r As Integer
        S = tt(0)
        m = tt(1)
        r = tt(2)
        Select Case no
            Case cTarikh.No.YYYY1MM1DD
                ret = Strings.Right("0000" & s.ToString, 4)
                ret += "/" & Strings.Right("00" & m.ToString, 2)
                ret += "/" & Strings.Right("00" & r.ToString, 2)
            Case cTarikh.No.YY1M1D
                ret = Strings.Right(s.ToString, 2) & "/" & m.ToString & "/" & r.ToString
            Case cTarikh.No.D0m0YY
                ret = r.ToString & " " & EsmeMahha(m) & " " & Strings.Right("00" & s.ToString, 2)
            Case cTarikh.No.D0m0YYYY
                ret = r.ToString & " " & EsmeMahha(m) & " " & Strings.Right("0000" & s.ToString, 4)
        End Select
        Return ret
    End Function

    Public Function isDorost(Shamsi As String) As Boolean
        Dim tt() As String = Shamsi.Split("/")
        If tt.Length <> 3 Then Return False
        If tt(1) < 1 Or tt(1) > 12 Then Return False
        If tt(2) < 1 Or tt(2) > 31 Then Return False
        If tt(1) > 6 And tt(2) > 30 Then Return False

        Dim bm As Integer = tt(0) Mod 33


        Dim hast As Boolean = False
        If bm = 1 Then hast = True
        If bm = 5 Then hast = True
        If bm = 9 Then hast = True
        If bm = 13 Then hast = True

        If tt(0) >= 1244 And tt(0) <= 1342 Then
            If bm = 17 Then hast = True ' 1244 - 1342
        ElseIf tt(0) >= 1343 And tt(0) <= 1472 Then
            If bm = 18 Then hast = True ' 1343 - 1472
        End If

        If bm = 22 Then hast = True
        If bm = 26 Then hast = True
        If bm = 30 Then hast = True

        If tt(1) = 12 And tt(2) = 30 Then Return hast

        Return True
    End Function
End Class
