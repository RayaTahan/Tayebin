Public Class ucFun
    Public Shared Function str2Phone(str As String) As String
        str = str.Replace(" ", "")
        If str.StartsWith("+98") Then
            str = "0" & str.Substring(3)
        End If
        If str.StartsWith("0098") Then
            str = "0" & str.Substring(4)
        End If
        Try
            If IsNumeric(str) Then
                If str.StartsWith("09") Then
                    'Return Regex.Replace(str, "", "$1 $2 $3")
                    Return String.Format("0{0:### ### ####}", Long.Parse(str))
                Else
                    Select Case str.Length
                        Case 11
                            Return String.Format("0{0:## ## ## ## ##}", Long.Parse(str))
                        Case 10
                            Return String.Format("0{0:## ## ## ###}", Long.Parse(str))
                        Case 9
                            Return String.Format("0{0:## ## ## ##}", Long.Parse(str))
                        Case 8
                            Return String.Format("0{0:## ## ###}", Long.Parse(str))
                        Case 7
                            Return String.Format("0{0:## ## ##}", Long.Parse(str))
                        Case 6
                            Return String.Format("0{0:## ###}", Long.Parse(str))
                        Case 5
                            Return String.Format("{0:## ##}", Long.Parse(str))
                        Case Else
                            Return str
                    End Select
                    'Return Regex.Replace(str, "", "$1 $2 $3 $4 $5")
                End If
            Else
                Return str
            End If
        Catch ex As Exception
            Return str
        End Try
    End Function
End Class
