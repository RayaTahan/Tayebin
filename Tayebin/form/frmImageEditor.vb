﻿Imports System.Drawing.Drawing2D
Imports System.IO

Public Class frmImageEditor
    Dim fileAddress As String
    Dim Job As Integer = 0 ' 1:crop  2:contrast
    Dim timerTik As Boolean = False

    Dim img As New ImageProcessor.ImageFactory

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
            Dim xx As Image
            Using str As Stream = File.OpenRead(FileAddress)
                xx = Image.FromStream(str)
            End Using
            pic.Image = xx
            resizer()
            lblTaqir.Text = ""
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Me.Close()
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

    Private Sub btnCrop_Click(sender As Object, e As EventArgs) Handles btnCrop.Click
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

                    img = New ImageProcessor.ImageFactory
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
            trackContrast.Visible = False
            resizer()
            pic.Refresh()
            preview.Image = Nothing
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Job = 0
        lblTaqir.Text = ""
        trackContrast.Visible = False
        resizer()
        pic.Refresh()
        preview.Image = Nothing

        btnOK.Visible = False
        btnCancel.Visible = False
        Abzar.Enabled = True
        btnTaeed.Enabled = True
    End Sub

    Private Sub btnTaeed_Click(sender As Object, e As EventArgs) Handles btnTaeed.Click
        Try
            pic.Image.Save(fileAddress)
            IMGcache.Remove(fileAddress)

            MessageBox.Show("تصویر با موفقیت ویرایش و ذخیره شد")
            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If timerTik Then
            '    btnOK.BackColor = Color.FromArgb(100, Color.Green)
            '    btnCancel.BackColor = Color.FromArgb(255, Color.Orange)
            GroupBox1.ForeColor = Color.White
        Else
            '    btnOK.BackColor = Color.FromArgb(255, Color.Orange)
            '    btnCancel.BackColor = Color.FromArgb(100, Color.Red)
            GroupBox1.ForeColor = Color.Black
        End If

        If Job > 0 Then
            timerTik = Not timerTik
            GroupBox1.Visible = True
        Else
            'GroupBox1.ForeColor = Color.Black
            GroupBox1.Visible = False
        End If
    End Sub

    Private Sub btnRotateC_Click(sender As Object, e As EventArgs) Handles btnRotateC.Click
        img = New ImageProcessor.ImageFactory
        img.Load(New Bitmap(pic.Image))
        pic.Image = img.Rotate(90).Image
        resizer()
        btnTaeed.Enabled = True
    End Sub

    Private Sub btnRotateAC_Click(sender As Object, e As EventArgs) Handles btnRotateAC.Click
        img = New ImageProcessor.ImageFactory
        img.Load(New Bitmap(pic.Image))
        pic.Image = img.Rotate(-90).Image
        resizer()
        btnTaeed.Enabled = True
    End Sub

    Private Sub btnFilipV_Click(sender As Object, e As EventArgs) Handles btnFilipV.Click
        img = New ImageProcessor.ImageFactory
        img.Load(New Bitmap(pic.Image))
        pic.Image = img.Flip(True, False).Image
        resizer()
        btnTaeed.Enabled = True
    End Sub

    Private Sub btnFilipH_Click(sender As Object, e As EventArgs) Handles btnFilipH.Click
        img = New ImageProcessor.ImageFactory
        img.Load(New Bitmap(pic.Image))
        pic.Image = img.Flip(False, False).Image
        resizer()
        btnTaeed.Enabled = True
    End Sub

    Private Sub btnContrast_Click(sender As Object, e As EventArgs) Handles btnContrast.Click
        Job = 2
        lblTaqir.Tag = 0
        lblTaqir.Text = $"میزان روشنایی : {lblTaqir.Tag}%"
        preview.Image = pic.Image
        img = New ImageProcessor.ImageFactory
        img.Load(pic.Image)

        trackContrast.Value = 0
        trackContrast.Visible = True
        Abzar.Enabled = False
        btnOK.Visible = True
        btnCancel.Visible = True
        btnTaeed.Enabled = False
    End Sub

    Private Sub trackContrast_Scroll(sender As Object, e As EventArgs) Handles trackContrast.Scroll
        img.Reset()
        preview.Image = img.Contrast(trackContrast.Value).Image
        lblTaqir.Tag = trackContrast.Value
        lblTaqir.Text = $"میزان روشنایی : {lblTaqir.Tag}%"
    End Sub
End Class