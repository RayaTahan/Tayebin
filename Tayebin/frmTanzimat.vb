Imports CodeHollow.FeedReader
Imports RestSharp

Public Class frmTanzimat
    Dim curUser As String
    Dim curPass As String
    Dim AboutHTML As String = ""

    Private Sub frmTanzimat_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtKanunNam.Text = AppMan.TanzimGet("KanunNam")

        Dim up As DataTable = SQLiter.Fill("select * from tKarbari")
        If up.Rows.Count = 0 Then
            lblKarbariTozih.Text = "هنوز اطلاعات ورودی ثبت نشده است. لطفا اطلاعات را وارد کنید."
            lblKarbariTozih.Tag = 0
            txtUser.Enabled = False
            txtPass1.Enabled = False
        Else
            lblKarbariTozih.Text = "جهت ویرایش کلمه عبور اطلاعات زیر را وارد کنید. در غیر این صورت کادر های زیر را خالی رها کنید."
            lblKarbariTozih.Tag = 1
            curUser = up.Rows(0)("u")
            curPass = up.Rows(0)("p")
        End If
        AboutHTML = "<html><head>"
        AboutHTML += "<meta charset=""UTF-8""><style>"
        AboutHTML += "* {direction:rtl; font-family:tahoma; -webkit-touch-callout: none; -webkit-user-select: none; -khtml-user-select: none; -moz-user-select: none; -ms-user-select: none; user-select: none;}"
        AboutHTML += "a{text-decoration: none;}"
        AboutHTML += "</style></head><body>"

        AboutHTML += "<p>" & "بسم الله الرحمن الرحیم" & "</p>"
        AboutHTML += "<p>" & "پروژه طیبین یک پروژه منبع باز است. شما نیز جهت مشارکت در پروژه می‌توانید به آدرس گیت هاب پروژه رجوع کنید." & "</p>"
        AboutHTML += "<p><a href=""https://github.com/PurTahan/Tayebin"" >https://github.com/PurTahan/Tayebin</a></p>"
        AboutHTML += "<p>" & "جهت تعجیل در امر فرج حضرت صاحب الزمان صلوات!" & "</p>"
        AboutHTML += "<p>" & "اللهم صل علی محمد و آل محمد و عجل فرجهم" & "</p>"
        AboutHTML += "<hr /><p style='text-align:center;'><a href=""" & AppMan.AppURL & """>" & String.Format("نرم افزار {1} نسخه {2} | {0}", AppMan.AppURL, AppMan.AppName, AppMan.AppVer) & "</a></p>"
        AboutHTML += "</body></html>"

        WebBrowser1.DocumentText = AboutHTML

        Dim feedHTML As String = ""
        feedHTML = "<html><head>"
        feedHTML += "<meta charset=""UTF-8""><style>"
        feedHTML += "* {direction:rtl; font-family:tahoma; -webkit-touch-callout: none; -webkit-user-select: none; -khtml-user-select: none; -moz-user-select: none; -ms-user-select: none; user-select: none;}"
        feedHTML += "a{text-decoration: none;}"
        feedHTML += "</style></head><body>"
        WebBrowser2.DocumentText = feedHTML & "<p>در حال لود...</p></body></html>"

        Dim client = New RestClient("http://tayebin.blog.ir/rss/")
        Dim request = New RestRequest(Method.GET)
        client.ExecuteAsync(request, Sub(res)
                                         If res.IsSuccessful AndAlso Not IsNothing(res.Content) Then
                                             Dim feed = FeedReader.ReadFromString(res.Content)
                                             feedHTML += String.Format("<p><b>{0}:</b></p>", feed.Title)
                                             Dim prov As New Globalization.CultureInfo("en-US")
                                             For Each row In feed.Items
                                                 feedHTML += String.Format("<p>[{2}] :<a href=""{0}"" > <b>{1}</b></a></p>", row.Link, row.Title, New cTarikh(DateTime.Parse(row.PublishingDateString, prov)))
                                             Next

                                         Else
                                             AboutHTML += "<p>خطا</p>"
                                         End If
                                         AboutHTML += "</body></html>"
                                         Try
                                             WebBrowser2.DocumentText = feedHTML
                                         Catch ex As Exception

                                         End Try
                                     End Sub)
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Me.Close()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim Kamel As Boolean = True
        AppMan.TanzimatSet("KanunNam", txtKanunNam.Text)

        If txtUser.TextLength > 0 AndAlso txtPass1.TextLength > 0 AndAlso txtPass2.TextLength > 0 AndAlso txtPass3.TextLength > 0 Then
            If txtUser.Text = curUser And txtPass1.Text = curPass Then
                If txtPass2.Text = txtPass3.Text Then
                    SQLiter.RunCommand(String.Format("update tKarbari set p='{0}' where u like '{1}'", txtPass3.Text, curUser))
                Else
                    MessageBox.Show("کلمه عبور جدید و تکرار آن با هم برابر نیست!")
                    Kamel = False
                End If
            Else
                MessageBox.Show("نام کاربری و یا کلمه عبور فعلی درست وارد نشده است.")
                Kamel = False
            End If
        End If

        If Kamel Then
            MessageBox.Show("تغییرات با موفقیت ثبت شد!")
            Dim frm As frmMain = Me.Owner
            frm.reLoad()
            Me.Close()
        End If

    End Sub


    Private Sub WebBrowser1_Navigating(sender As Object, e As WebBrowserNavigatingEventArgs) Handles WebBrowser1.Navigating, WebBrowser2.Navigating
        If e.Url.ToString.StartsWith("http") Then
            e.Cancel = True 'Cancel the event to avoid default behavior
            Process.Start(e.Url.ToString()) 'Open the link in the default browser
        End If
    End Sub
End Class