Imports System.Drawing.Drawing2D

Public Class frmImageEditor
    Dim fileAddress As String
    Dim Job As Integer = 0 ' 1:crop 

    Dim tempCnt As Boolean         'check weather the roller is used or not

    Dim bm_dest As Bitmap
    Dim bm_source As Bitmap
    Dim i As Int16 = 0.5

    Dim cropX As Integer
    Dim cropY As Integer
    Dim cropWidth As Integer
    Dim cropHeight As Integer

    Dim oCropX As Integer
    Dim oCropY As Integer
    Dim cropBitmap As Bitmap

    Public cropPen As Pen
    Public cropPenSize As Integer = 1 '2
    Public cropDashStyle As Drawing2D.DashStyle = DashStyle.Solid
    Public cropPenColor As Color = Color.Yellow
    Dim tmppoint As Point
    Dim isStart As Boolean = False

    Sub New()
        InitializeComponent()
    End Sub

    Sub New(FileAddress As String)
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Me.fileAddress = FileAddress
        Try
            pic.Load(FileAddress)
            resizer()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub frmImageEditor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnOK.BackgroundImage = IMGcache.img($"{Application.StartupPath}\data\app\icon\tick11.png")
        btnCancel.BackgroundImage = IMGcache.img($"{Application.StartupPath}\data\app\icon\cross106.png")
    End Sub

    Private Sub resizer()
        If pic.Image Is Nothing Then Exit Sub

        Dim ix, iy, iw, ih As Double
        If pic.Image.Width / pic.Image.Height > picPanel.Width / picPanel.Height Then
            iw = picPanel.Width
            ih = picPanel.Width / pic.Image.Width * pic.Image.Height
            ix = 0
            iy = (picPanel.Height - ih) / 2
        ElseIf pic.Image.Width / pic.Image.Height < picPanel.Width / picPanel.Height Then
            iw = picPanel.Height / pic.Image.Height * pic.Image.Width
            ih = picPanel.Height
            ix = (picPanel.Width - iw) / 2
            iy = 0
        Else
            iw = picPanel.Width
            ih = picPanel.Height
            ix = 0
            iy = 0
        End If
        pic.Dock = DockStyle.None
        pic.Size = New Size(iw, ih)
        pic.Location = New Point(ix, iy)
    End Sub

    Private Sub btnEnseraf_Click(sender As Object, e As EventArgs) Handles btnEnseraf.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Job = 1
        lblTaqir.Text = "برش"
        Abzar.Enabled = False
        btnOK.Visible = True
        btnCancel.Visible = True
        btnTaeed.Enabled = False
    End Sub


    Private Sub pic_MouseDown(sender As Object, e As MouseEventArgs) Handles pic.MouseDown
        Try
            If Job = 1 Then
                If e.Button = Windows.Forms.MouseButtons.Left Then
                    cropX = e.X
                    cropY = e.Y

                    cropPen = New Pen(cropPenColor, cropPenSize)
                    cropPen.DashStyle = DashStyle.DashDotDot
                    Cursor = Cursors.Cross
                End If
                pic.Refresh()
            End If
        Catch exc As Exception
        End Try
    End Sub

    Private Sub pic_MouseMove(sender As Object, e As MouseEventArgs) Handles pic.MouseMove
        Try
            If Job = 1 Then
                If pic.Image Is Nothing Then Exit Sub

                If e.Button = Windows.Forms.MouseButtons.Left Then
                    isStart = True
                    If Not MouseIsOverControl(pic) Then Exit Sub
                    pic.Refresh()
                    cropWidth = Math.Max(e.X, cropX) - Math.Min(e.X, cropX)
                    cropHeight = Math.Max(e.Y, cropY) - Math.Min(e.Y, cropY)
                    pic.CreateGraphics.DrawRectangle(cropPen, Math.Min(cropX, e.X), Math.Min(cropY, e.Y), cropWidth, cropHeight)
                End If
            End If
        Catch exc As Exception
            If Err.Number = 5 Then Exit Sub
        End Try
    End Sub
    Public Function MouseIsOverControl(ByVal c As Control) As Boolean
        Return c.ClientRectangle.Contains(c.PointToClient(Control.MousePosition))
    End Function

    Private Sub pic_MouseUp(sender As Object, e As MouseEventArgs) Handles pic.MouseUp
        Try
            If Job = 1 Then
                Cursor = Cursors.Default
                Try
                    If cropWidth < 10 Or cropHeight < 10 Or Not isStart Then
                        pic.Refresh()
                        Exit Sub
                    End If
                    isStart = False

                    Dim rect As Rectangle = New Rectangle(Math.Min(cropX, e.X), Math.Min(cropY, e.Y), cropWidth, cropHeight)
                    Dim bit As Bitmap = New Bitmap(pic.Image, pic.Width, pic.Height)

                    'cropBitmap = New Bitmap(cropWidth, cropHeight)
                    'Dim g As Graphics = Graphics.FromImage(cropBitmap)
                    'g.InterpolationMode = InterpolationMode.HighQualityBicubic
                    'g.PixelOffsetMode = PixelOffsetMode.HighQuality
                    'g.CompositingQuality = CompositingQuality.HighQuality

                    'g.DrawImage(bit, 0, 0, rect, GraphicsUnit.Pixel)
                    'preview.Image = cropBitmap

                    Dim img As New ImageProcessor.ImageFactory()
                    img.Quality(100)
                    img.Load(bit)
                    preview.Image = img.Crop(rect).Image
                Catch exc As Exception
                End Try
            End If
        Catch exc As Exception
        End Try
    End Sub

    Private Sub frmImageEditor_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        resizer()
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If preview.Image IsNot Nothing Then
            pic.Image = preview.Image
            resizer()

            btnOK.Visible = False
            btnCancel.Visible = False
            Abzar.Enabled = True
            btnTaeed.Enabled = True

            Job = 0
            lblTaqir.Text = ""
            resizer()
            pic.Refresh()
            preview.Image = Nothing
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Job = 0
        lblTaqir.Text = ""
        resizer()
        pic.Refresh()
        preview.Image = Nothing

        btnOK.Visible = False
        btnCancel.Visible = False
        Abzar.Enabled = True
        btnTaeed.Enabled = True
    End Sub

    Private Sub btnTaeed_Click(sender As Object, e As EventArgs) Handles btnTaeed.Click

    End Sub
End Class