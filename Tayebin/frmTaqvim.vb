Public Class frmTaqvim
    Dim EmRuz As cTarikh
    Private Sub frmTaqvim_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        EmRuz = New cTarikh
        'cal.Namayesh(Emruz.Sal, Emruz.Mah)
    End Sub

    Private Sub cal_QablNamayeshMah(Sal As Integer, Mah As Integer) Handles cal.QablNamayeshMah
        Dim RuzHa As String = ""
        For Each item As DataRow In SQL.Fill(String.Format("select * from tOzv where Tavalod like N'%/{0}/%' or Vafat like N'%/{0}/%'", Strings.Right("00" & Mah, 2))).Rows
            Try
                Dim _Sal As Integer = Val(item("Tavalod").ToString.Substring(0, item("Tavalod").ToString.IndexOf("/")))
                If _Sal <= Sal Then
                    RuzHa += String.Format("[{0}]", Val(item("Tavalod").ToString.Substring(item("Tavalod").ToString.LastIndexOf("/") + 1)))
                End If
            Catch ex As Exception

            End Try
            Try
                Dim _Sal As Integer = Val(item("Vafat").ToString.Substring(0, item("Vafat").ToString.IndexOf("/")))
                If _Sal <= Sal Then
                    RuzHa += String.Format("[{0}]", Val(item("Vafat").ToString.Substring(item("Vafat").ToString.LastIndexOf("/") + 1)))
                End If
            Catch ex As Exception

            End Try
        Next

        cal.inNamayeshBold = RuzHa
    End Sub

    Private Sub cal_Entekhab(Sal As Integer, Mah As Integer, Ruz As Integer) Handles cal.Entekhab
        Dim str As String = String.Format("رویداد های {0}/{1}/{2}", Sal, Mah, Ruz) & vbCrLf

        For Each item As DataRow In SQL.Fill(String.Format("select * from tOzv where Tavalod like N'%/{0}/{1}'", Strings.Right("00" & Mah, 2), Strings.Right("00" & Ruz, 2))).Rows
            Try
                Dim _Sal As Integer = Val(item("Tavalod").ToString.Substring(0, item("Tavalod").ToString.IndexOf("/")))
                If _Sal > Sal Then
                ElseIf _Sal = Sal Then
                    str += vbCrLf & String.Format("ولادت {0} {1} به کد ملی {2} در {3}", item("Nam"), item("Famil"), item("CodeMelli"), item("Tavalod"))
                Else
                    str += vbCrLf & String.Format("{4} مین سالگرد ولادت {0} {1} به کد ملی {2} در {3}", item("Nam"), item("Famil"), item("CodeMelli"), item("Tavalod"), Sal - _Sal)
                End If
            Catch ex As Exception

            End Try
        Next

        For Each item As DataRow In SQL.Fill(String.Format("select * from tOzv where Vafat like N'%/{0}/{1}'", Strings.Right("00" & Mah, 2), Strings.Right("00" & Ruz, 2))).Rows
            Try
                Dim _Sal As Integer = Val(item("Vafat").ToString.Substring(0, item("Vafat").ToString.IndexOf("/")))
                Dim VafatShahadat As String = ""
                If item("Zende") = "z" Then
                Else
                    If item("Zende") = "s" Then
                        VafatShahadat = "شهادت"
                    ElseIf item("Zende") = "v" Then
                        VafatShahadat = "وفات"
                    End If
                    If _Sal > Sal Then
                    ElseIf _Sal = Sal Then
                        str += vbCrLf & String.Format("{4} {0} {1} به کد ملی {2} در {3}", item("Nam"), item("Famil"), item("CodeMelli"), item("Vafat"), VafatShahadat)
                    Else
                        str += vbCrLf & String.Format("{4} مین سالگرد {5} {0} {1} به کد ملی {2} در {3}", item("Nam"), item("Famil"), item("CodeMelli"), item("Vafat"), Sal - _Sal, VafatShahadat)
                    End If
                End If
            Catch ex As Exception

            End Try
        Next

        txtMonasebat.Text = str
    End Sub


End Class