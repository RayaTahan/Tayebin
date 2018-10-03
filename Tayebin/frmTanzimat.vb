Imports CodeHollow.FeedReader
Imports RestSharp

Public Class frmTanzimat
    Dim curUser As String
    Dim curPass As String
    Dim AboutHTML As String = ""
    Dim Shahrha() As cOstan = Newtonsoft.Json.JsonConvert.DeserializeObject(Of cOstan())(FileIO.FileSystem.ReadAllText("data\ShahrHa.json"))
    Dim LoadNum As Integer = 0

    Private Sub frmTanzimat_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtKanunNam.Text = AppMan.Tanzimat("KanunNam")
        txtKanunTel.Text = AppMan.Tanzimat("KanunTel")
        txtKarbarNam.Text = AppMan.Tanzimat("KarbarNam")
        txtKarbarMob.Text = AppMan.Tanzimat("KarbarMob")

        comOstan.ValueMember = "ID"
        comShahr.ValueMember = "ID"
        comOstan.DisplayMember = "Name"
        comShahr.DisplayMember = "Name"

        comOstan.DataSource = Shahrha
        Integer.TryParse(AppMan.Tanzimat("KanunOstanID"), comOstan.SelectedValue)
        comOstan.DisplayMember = "Name"
        comOstan.ValueMember = "ID"


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
        AboutHTML += "<p><a href=""https://github.com/RayaTahan/Tayebin"" >https://github.com/RayaTahan/Tayebin</a></p>"
        AboutHTML += "<p>" & "جهت تعجیل در امر فرج حضرت صاحب الزمان صلوات!" & "</p>"
        AboutHTML += "<p>" & "اللهم صل علی محمد و آل محمد و عجل فرجهم" & "</p>"
        AboutHTML += "<hr /><p style='text-align:center;'><a href=""" & AppMan.AppURL & """>" & String.Format("نرم افزار {1} نسخه {2} | {0}", AppMan.AppURL, AppMan.AppName, AppMan.AppVer) & "</a></p>"
        AboutHTML += "</body></html>"

        WebBrowser1.DocumentText = AboutHTML


        Dim th As New Threading.Thread(AddressOf ReadRSS)
        th.Start()

    End Sub

    Public Sub ReadRSS()
        Dim prov As New Globalization.CultureInfo("en-US")
        Dim feedHTML As String = ""
        feedHTML = "<html><head>"
        feedHTML += "<meta charset=""UTF-8""><style>"
        feedHTML += "* {direction:rtl; font-family:tahoma; -webkit-touch-callout: none; -webkit-user-select: none; -khtml-user-select: none; -moz-user-select: none; -ms-user-select: none; user-select: none;}"
        feedHTML += "a{text-decoration: none;}"
        feedHTML += "</style></head><body>"
        WebBrowser2.DocumentText = feedHTML & "<p>در حال لود...</p></body></html>"
        Dim hasError As Boolean = False
        Try
            Dim rss = FeedReader.Read("http://tayebin.blog.ir/rss/")
            For Each row In rss.Items
                feedHTML += String.Format("<p>[{2}] :<a href=""{0}"" > <b>{1}</b></a></p>", row.Link, row.Title, New cTarikh(DateTime.Parse(row.PublishingDateString, prov)))
            Next
        Catch ex As Exception
        hasError = True
        End Try
        feedHTML += "</body></html>"
        If hasError Then
            WebBrowser2.DocumentText = feedHTML & "<p>اتصال به سرور امکانپذیر نیست!</p></body></html>"
        Else
            WebBrowser2.DocumentText = feedHTML
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Me.Close()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim Kamel As Boolean = True
        AppMan.Tanzimat("KanunNam") = txtKanunNam.Text
        AppMan.Tanzimat("KanunTel") = txtKanunTel.Text
        AppMan.Tanzimat("KanunOstanID") = comOstan.SelectedValue
        AppMan.Tanzimat("KanunShahrID") = comShahr.SelectedValue
        AppMan.Tanzimat("KarbarNam") = txtKarbarNam.Text
        AppMan.Tanzimat("KarbarMob") = txtKarbarMob.Text

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

    Private Sub comOstan_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comOstan.SelectedIndexChanged
        If Not IsNothing(comOstan.SelectedItem) Then
            comShahr.DataSource = CType(comOstan.SelectedItem, cOstan).Cities
            Integer.TryParse(AppMan.Tanzimat("KanunShahrID"), comShahr.SelectedValue)
        End If
    End Sub
End Class