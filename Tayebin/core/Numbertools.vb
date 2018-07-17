Imports Microsoft.VisualBasic

Namespace Core



    Public NotInheritable Class Numbertools

        'Private Shared x10tbl() As String = {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9"}
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

End Namespace