Imports Microsoft.VisualBasic

Public Class AdadHa
    Public Shared Function AdadBeHoruf(Adad As Int64) As String
        Dim ret As String = ""
        Dim manfi As Boolean = False
        If Adad < 0 Then
            Adad *= -1
            manfi = True
        End If

        Try
            If Adad = 0 Then Return "صفر"
            If Adad >= 10 ^ 15 Then Return "عدد بسیار بزرگ است"
            If Adad >= 10 ^ 12 Then
                ret += Sad2Adad(Adad \ 10 ^ 12) & " تریلیون"
                Adad -= (Adad \ 10 ^ 12) * 10 ^ 12
            End If
            If Adad >= 10 ^ 9 Then
                If ret <> "" Then ret += " و "
                ret += Sad2Adad(Adad \ 10 ^ 9) & " میلیارد"
                Adad -= (Adad \ 10 ^ 9) * 10 ^ 9
            End If
            If Adad >= 10 ^ 6 Then
                If ret <> "" Then ret += " و "
                ret += Sad2Adad(Adad \ 10 ^ 6) & " میلیون"
                Adad -= (Adad \ 10 ^ 6) * 10 ^ 6
            End If
            If Adad >= 10 ^ 3 Then
                If ret <> "" Then ret += " و "
                ret += Sad2Adad(Adad \ 10 ^ 3) & " هزار"
                Adad -= (Adad \ 10 ^ 3) * 10 ^ 3
            End If
            If Adad <> 0 Then
                If ret <> "" Then ret += " و "
                ret += Sad2Adad(Adad)
            End If
        Catch ex As Exception
            ret = ""
        End Try

        Return IIf(manfi, "منفی ", "") & ret.Replace(" ", "‌")
    End Function

    Private Shared Function Sad2Adad(Adad As Integer) As String
        Dim ret As String = ""
        Dim sad, dah, yek As Integer
        If Adad >= 100 Then
            sad = Adad \ 100
            Select Case sad
                Case 1
                    ret = "صد"
                Case 2
                    ret = "دویست"
                Case 3
                    ret = "سیصد"
                Case 4
                    ret = "چهارصد"
                Case 5
                    ret = "پانصد"
                Case 6
                    ret = "ششصد"
                Case 7
                    ret = "هفتصد"
                Case 8
                    ret = "هشتصد"
                Case 9
                    ret = "نهصد"
                Case Else
                    Return "خطا!"
            End Select
            Adad -= sad * 100
        End If

        If Adad >= 10 Then
            dah = Adad \ 10
            If ret <> "" Then ret += " و "
            Select Case dah
                Case 0
                    Select Case Adad
                        Case 1
                            ret += "یک"
                        Case 2
                            ret += "دو"
                        Case 3
                            ret += "سه"
                        Case 4
                            ret += "چهار"
                        Case 5
                            ret += "پنج"
                        Case 6
                            ret += "شش"
                        Case 7
                            ret += "هفت"
                        Case 8
                            ret += "هشت"
                        Case 9
                            ret += "نه"
                    End Select
                    Return ret
                Case 1
                    Select Case Adad
                        Case 10
                            ret += "ده"
                        Case 11
                            ret += "یازده"
                        Case 12
                            ret += "دوازده"
                        Case 13
                            ret += "سیزده"
                        Case 14
                            ret += "چهارده"
                        Case 15
                            ret += "پانزده"
                        Case 16
                            ret += "شانزده"
                        Case 17
                            ret += "هفده"
                        Case 18
                            ret += "هجده"
                        Case 19
                            ret += "نوزده"
                    End Select
                    Return ret
                Case 2
                    ret += "بیست"
                Case 3
                    ret += "سی"
                Case 4
                    ret += "چهل"
                Case 5
                    ret += "پنجاه"
                Case 6
                    ret += "شصت"
                Case 7
                    ret += "هفتاد"
                Case 8
                    ret += "هشتاد"
                Case 9
                    ret += "نود"
            End Select
            yek = Adad - dah * 10
            If yek <> 0 Then
                If ret <> "" Then ret += " و "
                Select Case yek
                    Case 1
                        ret += "یک"
                    Case 2
                        ret += "دو"
                    Case 3
                        ret += "سه"
                    Case 4
                        ret += "چهار"
                    Case 5
                        ret += "پنج"
                    Case 6
                        ret += "شش"
                    Case 7
                        ret += "هفت"
                    Case 8
                        ret += "هشت"
                    Case 9
                        ret += "نه"
                End Select
            End If
        Else
            Select Case Adad
                Case 1
                    ret += "یک"
                Case 2
                    ret += "دو"
                Case 3
                    ret += "سه"
                Case 4
                    ret += "چهار"
                Case 5
                    ret += "پنج"
                Case 6
                    ret += "شش"
                Case 7
                    ret += "هفت"
                Case 8
                    ret += "هشت"
                Case 9
                    ret += "نه"
            End Select
        End If
        Return ret
    End Function

    Public Shared Function FaghatAdad(strAdad As String) As String
        Dim tmp As String = ""
        For i As Integer = 0 To strAdad.Length - 1
            If IsNumeric(strAdad(i)) Then
                tmp += "" & strAdad(i)
            End If
        Next
        If tmp = "" Then tmp = 0
        Return tmp
    End Function

    Public Shared Function HezarTaHezarTa(Adad As Int64) As String
        Dim manfi As Boolean = False
        If Adad < 0 Then
            manfi = True
            Adad *= -1
        End If
        Dim tmp As String = Adad.ToString
        Dim tmp2 As String = ""
        For i As Integer = 0 To tmp.Length - 1
            If IsNumeric(tmp(i)) Then
                tmp2 += "" & tmp(i)
            End If
        Next
        Dim is3 As Boolean = False
        Dim mpt As String = Strings.StrReverse(tmp2)
        Dim mpt2 As String = ""
        For i As Integer = 0 To mpt.Length - 1
            If i Mod 3 = 0 And i > 0 Then
                mpt2 += ","
                is3 = True
            End If
            mpt2 += "" & mpt(i)
        Next
        Return IIf(manfi, "منفی ", "") & Strings.StrReverse(mpt2)
    End Function

    Private Shared x62tbl() As String = {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9",
                                   "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m",
                                   "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z",
                                   "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M",
                                   "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"
                                   }
    Private Shared x36tbl() As String = {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9",
                                       "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m",
                                       "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"
                                       }
    Public Shared Function x10b62(x10 As String) As String
        Dim ret As String = ""

        Dim z10 As Int64
        Try
            z10 = Int64.Parse(x10)
        Catch ex As Exception
            Return "-"
        End Try

        While z10 >= 62
            ret = x62tbl(z10 Mod 62) & ret
            z10 \= 62
        End While
        ret = x62tbl(z10) & ret

        Return ret
    End Function

    Public Shared Function x62b10(x62 As String) As String
        Dim ret As String = ""
        Dim ret64 As Int64 = 0

        Dim z62 As String = x62

        Dim n As Integer
        For i As Integer = 0 To z62.Length - 1
            If isx62(z62(i)) = False Then Return "-"
            n = z62.Length - i - 1

            Select Case Asc(z62(i))
                Case Is <= 58 ' 0 ~ 9
                    ret64 += (Asc(z62(i)) - 48) * 62 ^ n
                Case Is <= 90 ' A ~ Z
                    ret64 += (Asc(z62(i)) - 29) * 62 ^ n
                Case Is <= 122 ' a ~ z
                    ret64 += (Asc(z62(i)) - 87) * 62 ^ n
            End Select
        Next

        ret = ret64.ToString
        Return ret
    End Function

    Public Shared Function isx62(x62 As String) As Boolean
        Dim a As Integer
        For Each c As Char In x62
            a = Asc(c)
            If a >= 48 And a <= 57 Then

            ElseIf a >= 65 And a <= 90 Then

            ElseIf a >= 97 And a <= 122 Then

            Else
                Return False
            End If
        Next
        Return True
    End Function

    Public Shared Function x10b36(x10 As String) As String
        Dim ret As String = ""

        Dim z10 As Int64
        Try
            z10 = Int64.Parse(x10)
        Catch ex As Exception
            Return "-"
        End Try

        While z10 >= 36
            ret = x36tbl(z10 Mod 36) & ret
            z10 \= 36
        End While
        ret = x36tbl(z10) & ret

        Return ret
    End Function

    Public Shared Function x36b10(x36 As String) As String
        Dim ret As String = ""
        Dim ret64 As Int64 = 0

        Dim z36 As String = x36

        Dim n As Integer
        For i As Integer = 0 To z36.Length - 1
            If isx36(z36(i)) = False Then Return "-"
            n = z36.Length - i - 1

            Select Case Asc(z36(i))
                Case Is <= 58 ' 0 ~ 9
                    ret64 += (Asc(z36(i)) - 48) * 36 ^ n
                Case Is <= 122 ' a ~ z
                    ret64 += (Asc(z36(i)) - 87) * 36 ^ n
            End Select
        Next

        ret = ret64.ToString
        Return ret
    End Function

    Public Shared Function isx36(x36 As String) As Boolean
        Dim a As Integer
        For Each c As Char In x36
            a = Asc(c)
            If a >= 48 And a <= 57 Then

            ElseIf a >= 97 And a <= 122 Then

            Else
                Return False
            End If
        Next
        Return True
    End Function
End Class
