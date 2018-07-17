Public Class ucIcon
    Inherits Panel

    Dim pic As New PictureBox
    Dim lbl As New Label
    Dim target As Form
    Dim _Hobab As Integer = 0
    Dim lblHobab As New Label
    Dim myFontFamily As FontFamily = New fun.FontStruct(fun.appFont.SegeoUI).FontFamily

    Dim R As New Random

    Sub New()
        Me.Size = New Size(250, 200)
        Me.BackColor = Color.FromArgb(255, 100 + R.Next(155), 100 + R.Next(155), 100 + R.Next(155))

        With pic
            .Size = New Size(230, 150)
            If Image Is Nothing Then
                .Image = IMGcache.img("data\app\icon\drawing15.png")
            Else
                .Image = Image
            End If
            .SizeMode = PictureBoxSizeMode.Zoom
            .Location = New Point(10, 10)
        End With
        Me.Controls.Add(pic)
        AddHandler pic.Click, AddressOf iclick

        With lbl
            .AutoSize = False
            .Size = New Size(230, 30)
            .TextAlign = ContentAlignment.MiddleCenter
            .Location = New Point(10, 165)
            .BackColor = Color.FromArgb(100, Color.White)
        End With
        Me.Controls.Add(lbl)
        AddHandler lbl.Click, AddressOf iclick

        With lblHobab
            .AutoSize = False
            .Size = New Size(50, 50)
            .TextAlign = ContentAlignment.MiddleCenter
            .Text = ""
            .Location = New Point(0, 0)
            .BackColor = Color.Yellow
            .Visible = False
        End With
        Me.Controls.Add(lblHobab)
        AddHandler lblHobab.Click, AddressOf iclick


        'target = TargetForm
    End Sub

    Sub New(Onvan As String, Image As Image, TargetForm As Object)
        Me.Size = New Size(250, 200)
        Me.BackColor = Color.FromArgb(255, 100 + R.Next(155), 100 + R.Next(155), 100 + R.Next(155))

        With pic
            .Size = New Size(230, 150)
            If Image Is Nothing Then
                .Image = IMGcache.img("data\app\icon\drawing15.png")
            Else
                .Image = Image
            End If
            .SizeMode = PictureBoxSizeMode.Zoom
            .Location = New Point(10, 10)
        End With
        Me.Controls.Add(pic)
        AddHandler pic.Click, AddressOf iclick

        With lbl
            .AutoSize = False
            .Size = New Size(230, 30)
            .TextAlign = ContentAlignment.MiddleCenter
            .Text = Onvan
            .Location = New Point(10, 165)
            .Font = New Font(myFontFamily, 12)
            .BackColor = Color.FromArgb(100, Color.White)
        End With
        Me.Controls.Add(lbl)
        AddHandler lbl.Click, AddressOf iclick

        With lblHobab
            .AutoSize = False
            .Size = New Size(50, 50)
            .TextAlign = ContentAlignment.MiddleCenter
            .Text = ""
            .Location = New Point(0, 0)
            .BackColor = Color.Yellow
            .Visible = False
        End With
        Me.Controls.Add(lblHobab)
        AddHandler lblHobab.Click, AddressOf iclick


        target = TargetForm
    End Sub


    Public Property Image As Image
        Get
            Return pic.Image
        End Get
        Set(value As Image)
            If value Is Nothing Then
                pic.Image = IMGcache.img("data\app\icon\drawing15.png")
            Else
                pic.Image = value
            End If
        End Set
    End Property

    Public Property Onvan As String
        Get
            Return lbl.Text
        End Get
        Set(value As String)
            lbl.Text = value
        End Set
    End Property

    Public Property TedadHobab As Integer
        Get
            Return _Hobab
        End Get
        Set(value As Integer)
            _Hobab = value
            lblHobab.Text = _Hobab
            If value > 0 Then
                lblHobab.Visible = True
            Else
                lblHobab.Visible = False
            End If
        End Set
    End Property


    Public Property TargetForm As Object
        Get
            Return target
        End Get
        Set(value As Object)
            target = TargetForm
        End Set
    End Property

    Protected Overrides Sub OnClick(ByVal e As System.EventArgs)
        MyBase.OnClick(e)
        iclick(Nothing, Nothing)
    End Sub
    Sub iclick(sender As Object, e As EventArgs)
        If Not IsNothing(target) Then
            Dim frm = My.Application.OpenForms(target.Name)
            If frm Is Nothing Then
                Select Case target.Name
                    Case "frmDoreha"
                        frm = New frmDoreha
                        frm.Show(My.Application.OpenForms("frmMain"))
                    Case "frmOzvha"
                        frm = New frmOzvha
                        frm.Show(My.Application.OpenForms("frmMain"))
                    Case "frmGozareshHa"
                        frm = New frmGozareshHa
                        frm.Show(My.Application.OpenForms("frmMain"))
                    Case "frmTanzimat"
                        frm = New frmTanzimat
                        frm.Show(My.Application.OpenForms("frmMain"))
                    Case "frmTaqvim"
                        frm = New frmTaqvim
                        frm.Show(My.Application.OpenForms("frmMain"))
                    Case "frmLogin"
                        frm = New frmLogin
                        frm.ShowDialog(My.Application.OpenForms("frmMain"))
                    Case Else
                        MessageBox.Show(target.Name)
                End Select
            Else
                frm.Focus()
            End If
        End If
    End Sub

    Private Sub ucIcon_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Try
            Dim _w As Integer = Me.Width
            Dim _h As Integer = Me.Height
            With pic
                .Size = New Size(230 / 250 * _w, 150 / 200 * _h)
                .Location = New Point(10 / 250 * _w, 10 / 200 * _h)
            End With
            With lbl
                '.Font.Dispose()
                .Size = New Size(230 / 250 * _w, 30 / 200 * _h)
                .Location = New Point(10 / 250 * _w, 165 / 200 * _h)
                .Font = New Font(myFontFamily, 13.5 / 200 * _h)
            End With
            With lblHobab
                '.Font.Dispose()
                .BringToFront()
                .Size = New Size(50 / 250 * _w, 50 / 200 * _h)
                .Location = New Point(0 / 250 * _w, 0 / 200 * _h)
                .Font = New Font(myFontFamily, 18 / 200 * _h)
            End With
        Catch ex As Exception

        End Try

    End Sub

    Private Sub ucIcon_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        lbl.Font.Dispose()
        lblHobab.Font.Dispose()
    End Sub
End Class
