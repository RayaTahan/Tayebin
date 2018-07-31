<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTanzimat
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTanzimat))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.comShahr = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.comOstan = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtKanunTel = New Tayebin.ucTextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtKarbarMob = New Tayebin.ucTextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtKarbarNam = New Tayebin.ucTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtKanunNam = New Tayebin.ucTextBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtPass3 = New Tayebin.ucTextBox()
        Me.txtPass2 = New Tayebin.ucTextBox()
        Me.txtPass1 = New Tayebin.ucTextBox()
        Me.txtUser = New Tayebin.ucTextBox()
        Me.lblKarbariTozih = New System.Windows.Forms.Label()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.WebBrowser2 = New System.Windows.Forms.WebBrowser()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.ItemSize = New System.Drawing.Size(80, 31)
        Me.TabControl1.Location = New System.Drawing.Point(12, 11)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.RightToLeftLayout = True
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(560, 377)
        Me.TabControl1.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight
        Me.TabControl1.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.txtKanunNam)
        Me.TabPage1.Location = New System.Drawing.Point(4, 35)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TabPage1.Size = New System.Drawing.Size(552, 338)
        Me.TabPage1.TabIndex = 3
        Me.TabPage1.Text = "مشخصات کانون"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.comShahr)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.comOstan)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txtKanunTel)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtKarbarMob)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtKarbarNam)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 40)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(540, 293)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "اطلاعات پشتیبانی"
        '
        'Label11
        '
        Me.Label11.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(3, 212)
        Me.Label11.Name = "Label11"
        Me.Label11.Padding = New System.Windows.Forms.Padding(10)
        Me.Label11.Size = New System.Drawing.Size(534, 78)
        Me.Label11.TabIndex = 12
        Me.Label11.Text = "شما در پر کردن اطلاعات پشتیبانی مختارید، اما می‌توانید با ثبت آن در جهت سرویس‌دهی" &
    " بهتر و رفع ایرادات نرم‌افزار در نسخه‌های بعد ما را یاری کنید."
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(356, 171)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(122, 21)
        Me.Label10.TabIndex = 11
        Me.Label10.Text = "شهر محل استقرار"
        '
        'comShahr
        '
        Me.comShahr.CausesValidation = False
        Me.comShahr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comShahr.FormattingEnabled = True
        Me.comShahr.Location = New System.Drawing.Point(6, 168)
        Me.comShahr.Name = "comShahr"
        Me.comShahr.Size = New System.Drawing.Size(344, 29)
        Me.comShahr.TabIndex = 10
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(356, 136)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(131, 21)
        Me.Label9.TabIndex = 9
        Me.Label9.Text = "استان محل استقرار"
        '
        'comOstan
        '
        Me.comOstan.CausesValidation = False
        Me.comOstan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comOstan.FormattingEnabled = True
        Me.comOstan.Location = New System.Drawing.Point(6, 133)
        Me.comOstan.Name = "comOstan"
        Me.comOstan.Size = New System.Drawing.Size(344, 29)
        Me.comOstan.TabIndex = 8
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(356, 103)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(179, 21)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "شماره تماس دفتر مجموعه"
        '
        'txtKanunTel
        '
        Me.txtKanunTel.BackColor = System.Drawing.Color.White
        Me.txtKanunTel.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!)
        Me.txtKanunTel.Location = New System.Drawing.Point(6, 98)
        Me.txtKanunTel.MaxLength = 15
        Me.txtKanunTel.Name = "txtKanunTel"
        Me.txtKanunTel.Size = New System.Drawing.Size(344, 29)
        Me.txtKanunTel.TabIndex = 6
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(356, 68)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(131, 21)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "شماره موبایل کاربر"
        '
        'txtKarbarMob
        '
        Me.txtKarbarMob.BackColor = System.Drawing.Color.White
        Me.txtKarbarMob.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!)
        Me.txtKarbarMob.Location = New System.Drawing.Point(6, 63)
        Me.txtKarbarMob.MaxLength = 15
        Me.txtKarbarMob.Name = "txtKarbarMob"
        Me.txtKarbarMob.Size = New System.Drawing.Size(344, 29)
        Me.txtKarbarMob.TabIndex = 4
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(356, 33)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(160, 21)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "نام و نام خانوادگی کاربر"
        '
        'txtKarbarNam
        '
        Me.txtKarbarNam.BackColor = System.Drawing.Color.White
        Me.txtKarbarNam.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!)
        Me.txtKarbarNam.Location = New System.Drawing.Point(6, 28)
        Me.txtKarbarNam.MaxLength = 100
        Me.txtKarbarNam.Name = "txtKarbarNam"
        Me.txtKarbarNam.Size = New System.Drawing.Size(344, 29)
        Me.txtKarbarNam.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(362, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 21)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "عنوان"
        '
        'txtKanunNam
        '
        Me.txtKanunNam.BackColor = System.Drawing.Color.White
        Me.txtKanunNam.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!)
        Me.txtKanunNam.Location = New System.Drawing.Point(6, 5)
        Me.txtKanunNam.MaxLength = 100
        Me.txtKanunNam.Name = "txtKanunNam"
        Me.txtKanunNam.Size = New System.Drawing.Size(350, 29)
        Me.txtKanunNam.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TabPage2.Controls.Add(Me.Label5)
        Me.TabPage2.Controls.Add(Me.Label4)
        Me.TabPage2.Controls.Add(Me.Label3)
        Me.TabPage2.Controls.Add(Me.Label2)
        Me.TabPage2.Controls.Add(Me.txtPass3)
        Me.TabPage2.Controls.Add(Me.txtPass2)
        Me.TabPage2.Controls.Add(Me.txtPass1)
        Me.TabPage2.Controls.Add(Me.txtUser)
        Me.TabPage2.Controls.Add(Me.lblKarbariTozih)
        Me.TabPage2.Location = New System.Drawing.Point(4, 35)
        Me.TabPage2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TabPage2.Size = New System.Drawing.Size(552, 338)
        Me.TabPage2.TabIndex = 4
        Me.TabPage2.Text = "اطلاعات ورود"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(362, 186)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(141, 21)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "تکرار کلمه عبور جدید"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(362, 151)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(107, 21)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "کلمه عبور جدید"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(362, 116)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 21)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "کلمه عبور فعلی"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(362, 81)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 21)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "نام کاربری"
        '
        'txtPass3
        '
        Me.txtPass3.BackColor = System.Drawing.Color.White
        Me.txtPass3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!)
        Me.txtPass3.Location = New System.Drawing.Point(6, 181)
        Me.txtPass3.Name = "txtPass3"
        Me.txtPass3.PasswordChar = Global.Microsoft.VisualBasic.ChrW(215)
        Me.txtPass3.Size = New System.Drawing.Size(350, 29)
        Me.txtPass3.TabIndex = 4
        Me.txtPass3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtPass2
        '
        Me.txtPass2.BackColor = System.Drawing.Color.White
        Me.txtPass2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!)
        Me.txtPass2.Location = New System.Drawing.Point(6, 146)
        Me.txtPass2.Name = "txtPass2"
        Me.txtPass2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(215)
        Me.txtPass2.Size = New System.Drawing.Size(350, 29)
        Me.txtPass2.TabIndex = 3
        Me.txtPass2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtPass1
        '
        Me.txtPass1.BackColor = System.Drawing.Color.White
        Me.txtPass1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!)
        Me.txtPass1.Location = New System.Drawing.Point(6, 111)
        Me.txtPass1.Name = "txtPass1"
        Me.txtPass1.PasswordChar = Global.Microsoft.VisualBasic.ChrW(215)
        Me.txtPass1.Size = New System.Drawing.Size(350, 29)
        Me.txtPass1.TabIndex = 2
        Me.txtPass1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtUser
        '
        Me.txtUser.BackColor = System.Drawing.Color.White
        Me.txtUser.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!)
        Me.txtUser.Location = New System.Drawing.Point(6, 76)
        Me.txtUser.Name = "txtUser"
        Me.txtUser.Size = New System.Drawing.Size(350, 29)
        Me.txtUser.TabIndex = 1
        Me.txtUser.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblKarbariTozih
        '
        Me.lblKarbariTozih.Location = New System.Drawing.Point(13, 12)
        Me.lblKarbariTozih.Margin = New System.Windows.Forms.Padding(10)
        Me.lblKarbariTozih.Name = "lblKarbariTozih"
        Me.lblKarbariTozih.Size = New System.Drawing.Size(518, 51)
        Me.lblKarbariTozih.TabIndex = 0
        Me.lblKarbariTozih.Text = "توضیحات"
        Me.lblKarbariTozih.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TabPage4
        '
        Me.TabPage4.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TabPage4.Controls.Add(Me.WebBrowser2)
        Me.TabPage4.Location = New System.Drawing.Point(4, 35)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(552, 338)
        Me.TabPage4.TabIndex = 6
        Me.TabPage4.Text = "تازه ها"
        '
        'WebBrowser2
        '
        Me.WebBrowser2.AllowWebBrowserDrop = False
        Me.WebBrowser2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WebBrowser2.IsWebBrowserContextMenuEnabled = False
        Me.WebBrowser2.Location = New System.Drawing.Point(3, 3)
        Me.WebBrowser2.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser2.Name = "WebBrowser2"
        Me.WebBrowser2.ScriptErrorsSuppressed = True
        Me.WebBrowser2.ScrollBarsEnabled = False
        Me.WebBrowser2.Size = New System.Drawing.Size(546, 332)
        Me.WebBrowser2.TabIndex = 1
        Me.WebBrowser2.WebBrowserShortcutsEnabled = False
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TabPage3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TabPage3.Controls.Add(Me.WebBrowser1)
        Me.TabPage3.Location = New System.Drawing.Point(4, 35)
        Me.TabPage3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TabPage3.Size = New System.Drawing.Size(552, 338)
        Me.TabPage3.TabIndex = 5
        Me.TabPage3.Text = "درباره"
        '
        'WebBrowser1
        '
        Me.WebBrowser1.AllowWebBrowserDrop = False
        Me.WebBrowser1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WebBrowser1.IsWebBrowserContextMenuEnabled = False
        Me.WebBrowser1.Location = New System.Drawing.Point(3, 2)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.ScriptErrorsSuppressed = True
        Me.WebBrowser1.ScrollBarsEnabled = False
        Me.WebBrowser1.Size = New System.Drawing.Size(542, 330)
        Me.WebBrowser1.TabIndex = 0
        Me.WebBrowser1.WebBrowserShortcutsEnabled = False
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(152, 410)
        Me.Button6.Margin = New System.Windows.Forms.Padding(3, 20, 3, 2)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(135, 40)
        Me.Button6.TabIndex = 3
        Me.Button6.Text = "ثبت"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button7.Location = New System.Drawing.Point(12, 410)
        Me.Button7.Margin = New System.Windows.Forms.Padding(3, 20, 3, 2)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(135, 40)
        Me.Button7.TabIndex = 4
        Me.Button7.Text = "انصراف"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'frmTanzimat
        '
        Me.AcceptButton = Me.Button6
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Teal
        Me.CancelButton = Me.Button7
        Me.ClientSize = New System.Drawing.Size(584, 461)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.TabControl1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTanzimat"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "تنظیمات"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents Button6 As Button
    Friend WithEvents Button7 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents txtKanunNam As ucTextBox
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents lblKarbariTozih As Label
    Friend WithEvents txtUser As ucTextBox
    Friend WithEvents txtPass1 As ucTextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtPass3 As ucTextBox
    Friend WithEvents txtPass2 As ucTextBox
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents WebBrowser1 As WebBrowser
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents WebBrowser2 As WebBrowser
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtKanunTel As ucTextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtKarbarMob As ucTextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtKarbarNam As ucTextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents comShahr As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents comOstan As ComboBox
    Friend WithEvents Label11 As Label
End Class
