Public Class frmTaqvim
    Dim EmRuz As cTarikh
    Private Sub frmTaqvim_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        EmRuz = New cTarikh
        'cal.Namayesh(Emruz.Sal, Emruz.Mah)
    End Sub

    Private Sub cal_QablNamayeshMah(Sal As Integer, Mah As Integer) Handles cal.QablNamayeshMah
        Dim RuzHa As String = ""
        For Each item As DataRow In SQLiter.Fill(String.Format("select * from tOzv where Tavalod like '%/{0}/%' or Vafat like '%/{0}/%'", Strings.Right("00" & Mah, 2))).Rows
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
        events.Controls.Clear()

        For Each item As DataRow In SQLiter.Fill(String.Format("select * from tOzv where Tavalod like '%/{0}/{1}'", Strings.Right("00" & Mah, 2), Strings.Right("00" & Ruz, 2))).Rows
            Try
                Dim _Sal As Integer = Val(item("Tavalod").ToString.Substring(0, item("Tavalod").ToString.IndexOf("/")))
                If _Sal > Sal Then
                ElseIf _Sal = Sal Then
                    Dim Matn1 As String = String.Format("ولادت {0} {1}", item("Nam"), item("Famil"))
                    Dim t As New cTarikh(item("Tavalod"), cTarikh.NoTaqvim.Shamsi)
                    Dim Matn2 As String = String.Format("در {0} {1} {2} [{3}]", t.Ruz, t.EsmeMah, "سال جاری", item("Tavalod"))
                    Dim AxPath As String = ""
                    If item("AxID") = -1 Then
                        AxPath = String.Format("{0}\data\app\icon\profile27.png", Application.StartupPath)
                    Else
                        Dim AxData = SQLiter.Fill("select * from tMadrak where ID=" & item("AxID"))
                        AxPath = String.Format("{0}\data\madarek\{1}\{1}-{2}{3}", Application.StartupPath, item("ID"), AxData(0).Item("ID"), AxData(0).Item("FileEXT"))
                    End If
                    events.Controls.Add(New ucCalEvent(IMGcache.img(AxPath), Matn1, Matn2, "ozv/" & item("ID"), Color.Lime))
                Else
                    Dim Matn1 As String = String.Format("ولادت {0} {1}", item("Nam"), item("Famil"))
                    Dim t As New cTarikh(item("Tavalod"), cTarikh.NoTaqvim.Shamsi)
                    Dim sl As String = (Sal - _Sal).ToString
                    If Val(sl) = 1 Then
                        sl = ""
                    Else
                        sl = sl & " "
                    End If

                    Dim Matn2 As String = String.Format("در {0} {1} {2} [{3}]", t.Ruz, t.EsmeMah, sl & "سال پیش", item("Tavalod"))
                    Dim AxPath As String = ""
                    If item("AxID") = -1 Then
                        AxPath = String.Format("{0}\data\app\icon\profile27.png", Application.StartupPath)
                    Else
                        Dim AxData = SQLiter.Fill("select * from tMadrak where ID=" & item("AxID"))
                        AxPath = String.Format("{0}\data\madarek\{1}\{1}-{2}{3}", Application.StartupPath, item("ID"), AxData(0).Item("ID"), AxData(0).Item("FileEXT"))
                    End If
                    events.Controls.Add(New ucCalEvent(IMGcache.img(AxPath), Matn1, Matn2, "ozv/" & item("ID"), Color.LimeGreen))
                End If
            Catch ex As Exception

            End Try
        Next

        For Each item As DataRow In SQLiter.Fill(String.Format("select * from tOzv where Vafat like '%/{0}/{1}'", Strings.Right("00" & Mah, 2), Strings.Right("00" & Ruz, 2))).Rows
            Try
                Dim _Sal As Integer = Val(item("Vafat").ToString.Substring(0, item("Vafat").ToString.IndexOf("/")))
                Dim VafatShahadat As String = ""
                If item("Zende") = "z" Then
                Else
                    Dim rang1 As Color
                    Dim rang2 As Color
                    If item("Zende") = "s" Then
                        VafatShahadat = "شهادت"
                        rang1 = Color.FromArgb(255, 0, 0)
                        rang2 = Color.FromArgb(255, 51, 51)
                    ElseIf item("Zende") = "v" Then
                        VafatShahadat = "وفات"
                        rang1 = Color.FromArgb(102, 0, 204)
                        rang2 = Color.FromArgb(153, 51, 255)
                    End If
                    If _Sal > Sal Then
                    ElseIf _Sal = Sal Then
                        Dim Matn1 As String = String.Format("{0} {1} {2}", VafatShahadat, item("Nam"), item("Famil"))
                        Dim t As New cTarikh(item("Vafat"), cTarikh.NoTaqvim.Shamsi)
                        Dim Matn2 As String = String.Format("در {0} {1} {2} [{3}]", t.Ruz, t.EsmeMah, "سال جاری", item("Vafat"))
                        Dim AxPath As String = ""
                        If item("AxID") = -1 Then
                            AxPath = String.Format("{0}\data\app\icon\profile27.png", Application.StartupPath)
                        Else
                            Dim AxData = SQLiter.Fill("select * from tMadrak where ID=" & item("AxID"))
                            AxPath = String.Format("{0}\data\madarek\{1}\{1}-{2}{3}", Application.StartupPath, item("ID"), AxData(0).Item("ID"), AxData(0).Item("FileEXT"))
                        End If
                        events.Controls.Add(New ucCalEvent(IMGcache.img(AxPath), Matn1, Matn2, "ozv/" & item("ID"), rang1))
                    Else
                        Dim Matn1 As String = String.Format("{0} {1} {2}", VafatShahadat, item("Nam"), item("Famil"))
                        Dim t As New cTarikh(item("Vafat"), cTarikh.NoTaqvim.Shamsi)
                        Dim sl As String = (Sal - _Sal).ToString
                        If Val(sl) = 1 Then
                            sl = ""
                        Else
                            sl = sl & " "
                        End If

                        Dim Matn2 As String = String.Format("در {0} {1} {2} [{3}]", t.Ruz, t.EsmeMah, sl & "سال پیش", item("Vafat"))
                        Dim AxPath As String = ""
                        If item("AxID") = -1 Then
                            AxPath = String.Format("{0}\data\app\icon\profile27.png", Application.StartupPath)
                        Else
                            Dim AxData = SQLiter.Fill("select * from tMadrak where ID=" & item("AxID"))
                            AxPath = String.Format("{0}\data\madarek\{1}\{1}-{2}{3}", Application.StartupPath, item("ID"), AxData(0).Item("ID"), AxData(0).Item("FileEXT"))
                        End If
                        events.Controls.Add(New ucCalEvent(IMGcache.img(AxPath), Matn1, Matn2, "ozv/" & item("ID"), rang2))
                    End If
                End If
            Catch ex As Exception

            End Try
        Next
    End Sub

    Private Sub TableLayoutPanel1_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel1.Paint

    End Sub

    Private Sub WebBrowser1_Navigating(sender As Object, e As WebBrowserNavigatingEventArgs)
        If e.Url.ToString.StartsWith("http") Then
            e.Cancel = True 'Cancel the event to avoid default behavior
            Process.Start(e.Url.ToString()) 'Open the link in the default browser
        ElseIf e.Url.ToString.StartsWith("tayebin://") Then
            e.Cancel = True 'Cancel the event to avoid default behavior
            Dim link As String = e.Url.ToString.Substring("tayebin://".Length)
            Dim data = link.Split("/")
            Select Case data(0)
                Case "ozv"
                    Dim frm As New frmOzvView(data(1))
                    frm.ShowDialog(Me)
            End Select
        End If
    End Sub
End Class