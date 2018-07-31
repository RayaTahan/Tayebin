Public Class ucCalEvent
    Inherits UserControl

    Public WithEvents lbl1 As Label

    Public WithEvents lbl2 As Label

    Public WithEvents Pic As PictureBox

    Public Property Link As String = "ozv/1"

    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(Image As Image, Matn1 As String, Matn2 As String, Link As String, Optional Rang As Color = Nothing)
        If IsNothing(Rang) Then Rang = Color.FromArgb(255, 255, 192)
        InitializeComponent()
        Pic.Image = Image
        lbl1.Text = Matn1
        lbl2.Text = Matn2
        Me.Link = Link
        Me.BackColor = Rang
    End Sub

    Private Sub InitializeComponent()
        Me.lbl1 = New System.Windows.Forms.Label()
        Me.lbl2 = New System.Windows.Forms.Label()
        Me.Pic = New System.Windows.Forms.PictureBox()
        CType(Me.Pic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbl1
        '
        Me.lbl1.BackColor = System.Drawing.Color.Transparent
        Me.lbl1.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lbl1.Location = New System.Drawing.Point(5, 5)
        Me.lbl1.Margin = New System.Windows.Forms.Padding(5)
        Me.lbl1.Name = "lbl1"
        Me.lbl1.Size = New System.Drawing.Size(305, 40)
        Me.lbl1.TabIndex = 1
        Me.lbl1.Text = "عنوان اصلی"
        Me.lbl1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl2
        '
        Me.lbl2.BackColor = System.Drawing.Color.Transparent
        Me.lbl2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lbl2.Location = New System.Drawing.Point(5, 50)
        Me.lbl2.Margin = New System.Windows.Forms.Padding(5, 0, 5, 5)
        Me.lbl2.Name = "lbl2"
        Me.lbl2.Size = New System.Drawing.Size(305, 30)
        Me.lbl2.TabIndex = 2
        Me.lbl2.Text = "توضیحات"
        '
        'Pic
        '
        Me.Pic.BackColor = System.Drawing.Color.Transparent
        Me.Pic.Location = New System.Drawing.Point(320, 5)
        Me.Pic.Margin = New System.Windows.Forms.Padding(5)
        Me.Pic.Name = "Pic"
        Me.Pic.Size = New System.Drawing.Size(75, 75)
        Me.Pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Pic.TabIndex = 0
        Me.Pic.TabStop = False
        '
        'ucCalEvent
        '
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Controls.Add(Me.lbl2)
        Me.Controls.Add(Me.lbl1)
        Me.Controls.Add(Me.Pic)
        Me.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Margin = New System.Windows.Forms.Padding(5)
        Me.Name = "ucCalEvent"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Size = New System.Drawing.Size(400, 85)
        CType(Me.Pic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Private Shadows Sub Click(sender As Object, e As EventArgs) Handles Me.MouseClick, Pic.Click, lbl1.Click, lbl2.Click
        Try
            Dim data() = Link.Split("/")

            Select Case data(0)
                Case "ozv"
                    Dim frm As New frmOzvView(data(1))
                    frm.Show()
            End Select
        Catch ex As Exception

        End Try
    End Sub
End Class
