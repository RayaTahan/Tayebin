Imports System.Drawing.Drawing2D
Imports Kaliko.ImageLibrary

Public Class frmImageEditor
    Dim fileAddress As String

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
        If preview.Image IsNot Nothing Then
            pic.Image = preview.Image
            pic.BackColor = Color.Pink
            resizer()
        End If
    End Sub


    Private Sub pic_MouseDown(sender As Object, e As MouseEventArgs) Handles pic.MouseDown
        Try
            If e.Button = Windows.Forms.MouseButtons.Left Then
                cropX = e.X
                cropY = e.Y

                cropPen = New Pen(cropPenColor, cropPenSize)
                cropPen.DashStyle = DashStyle.DashDotDot
                Cursor = Cursors.Cross
            End If
            pic.Refresh()
        Catch exc As Exception
        End Try
    End Sub

    Private Sub pic_MouseMove(sender As Object, e As MouseEventArgs) Handles pic.MouseMove
        Try
            If pic.Image Is Nothing Then Exit Sub

            If e.Button = Windows.Forms.MouseButtons.Left Then
                isStart = True
                'If e.X < pic.Left Or e.X > pic.Left + pic.Width Or e.Y < pic.Top Or e.Y > pic.Top + pic.Height Then Exit Sub
                If Not MouseIsOverControl(pic) Then Exit Sub
                pic.Refresh()
                cropWidth = Math.Max(e.X, cropX) - Math.Min(e.X, cropX)
                cropHeight = Math.Max(e.Y, cropY) - Math.Min(e.Y, cropY)
                pic.CreateGraphics.DrawRectangle(cropPen, Math.Min(cropX, e.X), Math.Min(cropY, e.Y), cropWidth, cropHeight)
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
        Catch exc As Exception
        End Try
    End Sub

    Private Sub frmImageEditor_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        resizer()
    End Sub
End Class