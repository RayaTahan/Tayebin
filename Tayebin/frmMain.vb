Public Class frmMain
    Dim frmSplash As New frmSplash
    Dim TarikhQabl As String

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Setup()
        Me.Hide()
        frmSplash.Close()

        AppMan.Start()

        My.Settings.Save()

        Dim frm As New frmLogin
        frm.ShowDialog(Me)
        Me.Show()
        Me.Activate()
        'reLoad()
        'fun.ChangeFont(Me, My.MySettings.Default.Context.Item("Font"))


    End Sub

    Public Sub reLoad()
        Try
            lblKanunOnvan.Text = AppMan.Tanzimat("KanunNam")
            icons()

            With CType(table.Controls(4), ucIcon) ' Icon Taqvim
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

            '0,0

            table.Controls.Add(New ucIcon("نسخه " & Application.ProductVersion, IMGcache.img("data\logo.png"), Nothing, Color.Transparent), 1, 0)
            table.Controls.Add(New ucIcon("قفل", IMGcache.img("data\app\icon\padlock67.png"), frmLogin), 2, 0)

            table.Controls.Add(New ucIcon("مدیریت اعضا", IMGcache.img("data\app\icon\add199.png"), frmOzvha), 0, 1)
            table.Controls.Add(New ucIcon("پیامک", IMGcache.img("data\app\icon\message27.png"), frmSMS), 1, 1)
            table.Controls.Add(New ucIcon("تقویم", IMGcache.img("data\app\icon\cake19.png"), frmTaqvim), 2, 1)

            table.Controls.Add(New ucIcon("مدیریت دوره ها", IMGcache.img("data\app\icon\briefcase61.png"), frmDoreha), 0, 2)
            table.Controls.Add(New ucIcon("تهیه گزارش", IMGcache.img("data\app\icon\sheet.png"), frmGozareshHa), 1, 2)
            table.Controls.Add(New ucIcon("تنظیمات", IMGcache.img("data\app\icon\settings60.png"), frmTanzimat), 2, 2)


            For Each item As Control In table.Controls
                item.Dock = DockStyle.Fill
            Next
        End If


        table.Visible = True
    End Sub

    Private Sub frmMain_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        reLoad()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim Alan As New cTarikh
        Dim Saat As New cSaat
        lblSaat.Text = Saat.ToString(No:=cSaat.No.h12SABozorg2BiSanieh)
        lblTarikh.Text = Alan.ToString(No:=cTarikh.No.S0D0m0YYYY)
        If TarikhQabl <> lblTarikh.Text Then
            reLoad()
        End If
        TarikhQabl = lblTarikh.Text
    End Sub

    Private Sub frmMain_HandleCreated(sender As Object, e As EventArgs) Handles Me.HandleCreated
        Me.Hide()
        frmSplash.Show()
    End Sub

    Private Sub frmMain_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Me.BringToFront()
    End Sub
End Class
