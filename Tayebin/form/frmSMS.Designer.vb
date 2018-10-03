<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSMS
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSMS))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.UcTextBox2 = New Tayebin.ucTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.UcTextBox1 = New Tayebin.ucTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.UcTextBox3 = New Tayebin.ucTextBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.CheckBox3 = New System.Windows.Forms.CheckBox()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Matn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Girandegancc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.RightToLeftLayout = True
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(668, 445)
        Me.TabControl1.TabIndex = 8
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TabPage1.Controls.Add(Me.LinkLabel2)
        Me.TabPage1.Controls.Add(Me.GroupBox3)
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 30)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TabPage1.Size = New System.Drawing.Size(660, 411)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "وضعیت"
        '
        'LinkLabel2
        '
        Me.LinkLabel2.Font = New System.Drawing.Font("Segoe UI Semilight", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.LinkLabel2.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel2.LinkColor = System.Drawing.Color.Yellow
        Me.LinkLabel2.Location = New System.Drawing.Point(337, 233)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(315, 170)
        Me.LinkLabel2.TabIndex = 15
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "جهت هرگونه تغییر در اطلاعات کاربری، افزایش اعتبار و خرید خط لطفا به سایت" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "irSMS.n" &
    "et" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "رجوع کنید"
        Me.LinkLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.LinkLabel2.VisitedLinkColor = System.Drawing.Color.Yellow
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.ListBox1)
        Me.GroupBox3.Location = New System.Drawing.Point(8, 130)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(323, 273)
        Me.GroupBox3.TabIndex = 13
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "لیست خطوط در دسترس"
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 21
        Me.ListBox1.Location = New System.Drawing.Point(6, 28)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ListBox1.Size = New System.Drawing.Size(311, 235)
        Me.ListBox1.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Location = New System.Drawing.Point(337, 130)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(315, 100)
        Me.GroupBox2.TabIndex = 12
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "اعتبار باقی مانده"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(6, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(303, 72)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "بررسی"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.LinkLabel1)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.UcTextBox2)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.UcTextBox1)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(644, 119)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "اطلاعات ورود به پنل پیامک"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(160, 27)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(106, 29)
        Me.Button2.TabIndex = 15
        Me.Button2.Text = "ثبت"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'LinkLabel1
        '
        Me.LinkLabel1.Font = New System.Drawing.Font("Segoe UI Semibold", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.LinkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel1.LinkColor = System.Drawing.Color.Yellow
        Me.LinkLabel1.Location = New System.Drawing.Point(6, 68)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(632, 43)
        Me.LinkLabel1.TabIndex = 14
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "جهت تهیه پنل پیامک به سایت irSMS.net مراجعه فرمایید"
        Me.LinkLabel1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.LinkLabel1.VisitedLinkColor = System.Drawing.Color.Yellow
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(6, 27)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(148, 29)
        Me.Button1.TabIndex = 13
        Me.Button1.Text = "پاک کردن اطلاعات"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'UcTextBox2
        '
        Me.UcTextBox2.BackColor = System.Drawing.Color.White
        Me.UcTextBox2.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.UcTextBox2.Location = New System.Drawing.Point(272, 27)
        Me.UcTextBox2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.UcTextBox2.Name = "UcTextBox2"
        Me.UcTextBox2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(8226)
        Me.UcTextBox2.Size = New System.Drawing.Size(121, 29)
        Me.UcTextBox2.TabIndex = 11
        Me.UcTextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(399, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(32, 21)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "رمز"
        '
        'UcTextBox1
        '
        Me.UcTextBox1.BackColor = System.Drawing.Color.White
        Me.UcTextBox1.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.UcTextBox1.Location = New System.Drawing.Point(437, 27)
        Me.UcTextBox1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.UcTextBox1.Name = "UcTextBox1"
        Me.UcTextBox1.Size = New System.Drawing.Size(121, 29)
        Me.UcTextBox1.TabIndex = 9
        Me.UcTextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(564, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 21)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "نام کاربری"
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TabPage2.Controls.Add(Me.GroupBox7)
        Me.TabPage2.Controls.Add(Me.GroupBox6)
        Me.TabPage2.Controls.Add(Me.GroupBox5)
        Me.TabPage2.Controls.Add(Me.GroupBox4)
        Me.TabPage2.Location = New System.Drawing.Point(4, 30)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(660, 411)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "ارسال"
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.Button3)
        Me.GroupBox7.Controls.Add(Me.Label6)
        Me.GroupBox7.Controls.Add(Me.Label7)
        Me.GroupBox7.Controls.Add(Me.Label5)
        Me.GroupBox7.Controls.Add(Me.Label4)
        Me.GroupBox7.Location = New System.Drawing.Point(8, 311)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(409, 92)
        Me.GroupBox7.TabIndex = 10
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "امکانات"
        '
        'Button3
        '
        Me.Button3.Enabled = False
        Me.Button3.Location = New System.Drawing.Point(6, 17)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(201, 69)
        Me.Button3.TabIndex = 4
        Me.Button3.Text = "ارسال"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(213, 53)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(17, 21)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "0"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(213, 25)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(17, 21)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "0"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(311, 53)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(92, 21)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "تعداد صفحه:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(297, 25)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(106, 21)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "تعداد گیرندگان:"
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.UcTextBox3)
        Me.GroupBox6.Location = New System.Drawing.Point(8, 78)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(409, 227)
        Me.GroupBox6.TabIndex = 9
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "متن پیام"
        '
        'UcTextBox3
        '
        Me.UcTextBox3.BackColor = System.Drawing.Color.White
        Me.UcTextBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!)
        Me.UcTextBox3.Location = New System.Drawing.Point(6, 28)
        Me.UcTextBox3.MaxLength = 330
        Me.UcTextBox3.Multiline = True
        Me.UcTextBox3.Name = "UcTextBox3"
        Me.UcTextBox3.Size = New System.Drawing.Size(397, 193)
        Me.UcTextBox3.TabIndex = 0
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.ComboBox1)
        Me.GroupBox5.Location = New System.Drawing.Point(8, 6)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(409, 66)
        Me.GroupBox5.TabIndex = 8
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "انتخاب شماره فرستنده"
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(6, 28)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ComboBox1.Size = New System.Drawing.Size(397, 29)
        Me.ComboBox1.TabIndex = 0
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.CheckBox3)
        Me.GroupBox4.Controls.Add(Me.CheckBox2)
        Me.GroupBox4.Controls.Add(Me.CheckBox1)
        Me.GroupBox4.Controls.Add(Me.TreeView1)
        Me.GroupBox4.Location = New System.Drawing.Point(423, 6)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(229, 397)
        Me.GroupBox4.TabIndex = 7
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "گیرندگان"
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.Location = New System.Drawing.Point(70, 366)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(153, 25)
        Me.CheckBox3.TabIndex = 10
        Me.CheckBox3.Text = "ارسال به مادر اعضا"
        Me.CheckBox3.UseVisualStyleBackColor = True
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Location = New System.Drawing.Point(78, 335)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(145, 25)
        Me.CheckBox2.TabIndex = 9
        Me.CheckBox2.Text = "ارسال به پدر اعضا"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(73, 304)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(150, 25)
        Me.CheckBox1.TabIndex = 8
        Me.CheckBox1.Text = "ارسال به خود اعضا"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'TreeView1
        '
        Me.TreeView1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TreeView1.CheckBoxes = True
        Me.TreeView1.Location = New System.Drawing.Point(6, 27)
        Me.TreeView1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.RightToLeftLayout = True
        Me.TreeView1.Size = New System.Drawing.Size(217, 272)
        Me.TreeView1.TabIndex = 7
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TabPage3.Controls.Add(Me.DataGridView1)
        Me.TabPage3.Location = New System.Drawing.Point(4, 30)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(660, 411)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "ارسال شده‌ها"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.TT, Me.SS, Me.Matn, Me.Girandegancc})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(3, 3)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.RowTemplate.Height = 30
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(654, 405)
        Me.DataGridView1.TabIndex = 3
        '
        'ID
        '
        Me.ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.ID.DataPropertyName = "ID"
        Me.ID.FillWeight = 50.0!
        Me.ID.HeaderText = "کد"
        Me.ID.Name = "ID"
        Me.ID.ReadOnly = True
        Me.ID.Width = 51
        '
        'TT
        '
        Me.TT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.TT.DataPropertyName = "TT"
        Me.TT.HeaderText = "تاریخ"
        Me.TT.Name = "TT"
        Me.TT.ReadOnly = True
        '
        'SS
        '
        Me.SS.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.SS.DataPropertyName = "SS"
        Me.SS.HeaderText = "ساعت"
        Me.SS.Name = "SS"
        Me.SS.ReadOnly = True
        '
        'Matn
        '
        Me.Matn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Matn.DataPropertyName = "Matn"
        Me.Matn.FillWeight = 350.0!
        Me.Matn.HeaderText = "متن"
        Me.Matn.Name = "Matn"
        Me.Matn.ReadOnly = True
        '
        'Girandegancc
        '
        Me.Girandegancc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Girandegancc.DataPropertyName = "Girandegan"
        Me.Girandegancc.HeaderText = "گیرندگان"
        Me.Girandegancc.Name = "Girandegancc"
        Me.Girandegancc.ReadOnly = True
        '
        'frmSMS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Teal
        Me.ClientSize = New System.Drawing.Size(668, 445)
        Me.Controls.Add(Me.TabControl1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSMS"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "پیامک (آزمایشی: جهت حصول اطمینان پس از ارسال در سایت irSMS.net نتیجه را بررسی کنی" &
    "د.)"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents UcTextBox1 As Tayebin.ucTextBox
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents Button1 As Button
    Friend WithEvents UcTextBox2 As ucTextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents LinkLabel2 As LinkLabel
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents TreeView1 As TreeView
    Friend WithEvents CheckBox3 As CheckBox
    Friend WithEvents CheckBox2 As CheckBox
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents GroupBox7 As GroupBox
    Friend WithEvents Button3 As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents UcTextBox3 As ucTextBox
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents ID As DataGridViewTextBoxColumn
    Friend WithEvents TT As DataGridViewTextBoxColumn
    Friend WithEvents SS As DataGridViewTextBoxColumn
    Friend WithEvents Matn As DataGridViewTextBoxColumn
    Friend WithEvents Girandegancc As DataGridViewTextBoxColumn
End Class
