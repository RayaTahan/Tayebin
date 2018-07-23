Public Class frmMain
    Dim frmSplash As New frmSplash
    Dim TarikhQabl As String

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Setup()
        Me.Show()
        frmSplash.Close()

        If Not AppMan.isDbUpToDate Then
            If AppMan.UpDateDb() Then
                MessageBox.Show("نرم افزار با موفقیت بروزرسانی شد!")
            Else
                MessageBox.Show("عملیات بروزرسانی نرم افزار با خطا مواجه شد!")
            End If
        End If


        My.Settings.Save()


        Dim frm As New frmLogin
        frm.ShowDialog()
        'reLoad()
        'fun.ChangeFont(Me, My.MySettings.Default.Context.Item("Font"))


    End Sub

    Public Sub reLoad()
        Try
            lblKanunOnvan.Text = AppMan.TanzimGet("KanunNam")
            lblVersion.Text = String.Format("نرم افزار {0} نسخه {1}", AppMan.AppName, AppMan.AppVer)
            icons()

            With CType(table.Controls(3), ucIcon) ' Icon Taqvim
                .TedadHobab = fun.TedadRuydadEmruz
            End With
        Catch ex As Exception

        End Try

    End Sub

    Public Sub Setup()
        For Each file As String In FileIO.FileSystem.GetFiles(Application.StartupPath & "\data\app\font\")
            Try
                FileSystem.FileCopy(file, Environment.GetFolderPath(Environment.SpecialFolder.Fonts) & "\" & file.Substring(file.LastIndexOf("\") + 1))
            Catch ex As Exception

            End Try

        Next
    End Sub

    Sub icons()
        'table.Visible = False
        'table.Controls.Clear()
        If table.Controls.Count < 2 Then
            table.Controls.Add(New ucIcon("مدیریت دوره ها", IMGcache.img("data\app\icon\briefcase61.png"), frmDoreha), 0, 2)
            table.Controls.Add(New ucIcon("مدیریت اعضا", IMGcache.img("data\app\icon\add199.png"), frmOzvha), 0, 1)
            table.Controls.Add(New ucIcon("تهیه گزارش", IMGcache.img("data\app\icon\sheet.png"), frmGozareshHa), 1, 2)
            table.Controls.Add(New ucIcon("تقویم", IMGcache.img("data\app\icon\cake19.png"), frmTaqvim), 1, 1)
            table.Controls.Add(New ucIcon("تنظیمات", IMGcache.img("data\app\icon\settings60.png"), frmTanzimat), 2, 2)
            table.Controls.Add(New ucIcon("قفل", IMGcache.img("data\app\icon\padlock67.png"), frmLogin), 2, 1)


            table.Controls.Add(New PictureBox With {.BorderStyle = BorderStyle.None, .Image = My.Resources.LOGO, .SizeMode = PictureBoxSizeMode.Zoom}, 2, 0)
            'table.Controls.Add(New ucIcon(String.Format("{0} نسخه {1}", Application.ProductName, Application.ProductVersion), My.Resources.LOGO, Nothing))

            For Each item As Control In table.Controls
                item.Dock = DockStyle.Fill
            Next
        End If


        frmMain_Resize(Nothing, Nothing)
        table.Visible = True
    End Sub

    Private Sub frmMain_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Try
            Dim sumW As Integer = lblKanunOnvan.Width + lblVersion.Width
            Dim maxH As Integer = Math.Max(lblKanunOnvan.Height, lblVersion.Height)

            lblKanunOnvan.Location = New Point(Me.Width - ((Width - sumW) / 2) - lblKanunOnvan.Width, table.Top / 2 - maxH / 2)

            lblVersion.Location = New Point(lblKanunOnvan.Left - lblVersion.Width, table.Top / 2 - maxH / 2)

            lblSaat.Location = New Point(table.Left, lblKanunOnvan.Top)
            lblTarikh.Location = New Point(table.Left, lblSaat.Top + lblSaat.Height)
            lblSaat.Size = New Size(table.Width / 3, (table.Top - lblSaat.Top) / 2)
            lblTarikh.Size = New Size(table.Width / 3, (table.Top - lblSaat.Top) / 2)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub frmMain_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus

        reLoad()

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim Alan As New cTarikh
        lblSaat.Text = Now.ToString("HH:mm:ss")
        lblTarikh.Text = Alan.ToString
        If TarikhQabl <> lblTarikh.Text Then
            reLoad()
        End If
        TarikhQabl = lblTarikh.Text
    End Sub

    Private Sub frmMain_HandleCreated(sender As Object, e As EventArgs) Handles Me.HandleCreated
        frmSplash.Show()
        Me.Hide()
    End Sub

End Class
