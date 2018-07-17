<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOzvha
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
        Me.components = New System.ComponentModel.Container()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblAmar = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nam = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Famil = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Pedar = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tavalod = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SalVorud = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.menu1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.نمایشToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ویرایشToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.حذفToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.menu1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Panel1.Controls.Add(Me.lblAmar)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.Button4)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(382, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(198, 324)
        Me.Panel1.TabIndex = 1
        '
        'lblAmar
        '
        Me.lblAmar.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblAmar.Location = New System.Drawing.Point(0, 227)
        Me.lblAmar.Name = "lblAmar"
        Me.lblAmar.Size = New System.Drawing.Size(198, 97)
        Me.lblAmar.TabIndex = 3
        Me.lblAmar.Text = "آمار"
        Me.lblAmar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button1
        '
        Me.Button1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Button1.Location = New System.Drawing.Point(0, 96)
        Me.Button1.Margin = New System.Windows.Forms.Padding(9, 8, 9, 8)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(198, 48)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "افزودن عضو جدید"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Button2.Location = New System.Drawing.Point(0, 48)
        Me.Button2.Margin = New System.Windows.Forms.Padding(9, 8, 9, 8)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(198, 48)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "تازه سازی داده ها"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Button4.Location = New System.Drawing.Point(0, 0)
        Me.Button4.Margin = New System.Windows.Forms.Padding(9, 8, 9, 8)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(198, 48)
        Me.Button4.TabIndex = 6
        Me.Button4.Text = "جستجو"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.Nam, Me.Famil, Me.Pedar, Me.Tavalod, Me.SalVorud})
        Me.DataGridView1.ContextMenuStrip = Me.menu1
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.RowTemplate.Height = 30
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(382, 324)
        Me.DataGridView1.TabIndex = 2
        '
        'ID
        '
        Me.ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.ID.DataPropertyName = "ID"
        Me.ID.HeaderText = "کد"
        Me.ID.Name = "ID"
        Me.ID.ReadOnly = True
        Me.ID.Width = 51
        '
        'Nam
        '
        Me.Nam.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Nam.DataPropertyName = "Nam"
        Me.Nam.HeaderText = "نام"
        Me.Nam.Name = "Nam"
        Me.Nam.ReadOnly = True
        '
        'Famil
        '
        Me.Famil.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Famil.DataPropertyName = "Famil"
        Me.Famil.HeaderText = "نام خانوادگی"
        Me.Famil.Name = "Famil"
        Me.Famil.ReadOnly = True
        '
        'Pedar
        '
        Me.Pedar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Pedar.DataPropertyName = "Pedar"
        Me.Pedar.HeaderText = "نام پدر"
        Me.Pedar.Name = "Pedar"
        Me.Pedar.ReadOnly = True
        '
        'Tavalod
        '
        Me.Tavalod.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Tavalod.DataPropertyName = "Tavalod"
        Me.Tavalod.FillWeight = 50.0!
        Me.Tavalod.HeaderText = "تاریخ تولد"
        Me.Tavalod.Name = "Tavalod"
        Me.Tavalod.ReadOnly = True
        '
        'SalVorud
        '
        Me.SalVorud.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.SalVorud.DataPropertyName = "SalVorud"
        Me.SalVorud.FillWeight = 40.0!
        Me.SalVorud.HeaderText = "سال ورود"
        Me.SalVorud.Name = "SalVorud"
        Me.SalVorud.ReadOnly = True
        '
        'menu1
        '
        Me.menu1.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.menu1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.نمایشToolStripMenuItem, Me.ویرایشToolStripMenuItem, Me.حذفToolStripMenuItem})
        Me.menu1.Name = "menu1"
        Me.menu1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.menu1.Size = New System.Drawing.Size(129, 82)
        '
        'نمایشToolStripMenuItem
        '
        Me.نمایشToolStripMenuItem.Name = "نمایشToolStripMenuItem"
        Me.نمایشToolStripMenuItem.Size = New System.Drawing.Size(128, 26)
        Me.نمایشToolStripMenuItem.Text = "نمایش"
        '
        'ویرایشToolStripMenuItem
        '
        Me.ویرایشToolStripMenuItem.Name = "ویرایشToolStripMenuItem"
        Me.ویرایشToolStripMenuItem.Size = New System.Drawing.Size(128, 26)
        Me.ویرایشToolStripMenuItem.Text = "ویرایش"
        '
        'حذفToolStripMenuItem
        '
        Me.حذفToolStripMenuItem.Name = "حذفToolStripMenuItem"
        Me.حذفToolStripMenuItem.Size = New System.Drawing.Size(128, 26)
        Me.حذفToolStripMenuItem.Text = "حذف"
        '
        'frmOzvha
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(580, 324)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MinimumSize = New System.Drawing.Size(596, 363)
        Me.Name = "frmOzvha"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "مدیریت اعضا"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.menu1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents menu1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ویرایشToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents حذفToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents نمایشToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblAmar As System.Windows.Forms.Label
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents ID As DataGridViewTextBoxColumn
    Friend WithEvents Nam As DataGridViewTextBoxColumn
    Friend WithEvents Famil As DataGridViewTextBoxColumn
    Friend WithEvents Pedar As DataGridViewTextBoxColumn
    Friend WithEvents Tavalod As DataGridViewTextBoxColumn
    Friend WithEvents SalVorud As DataGridViewTextBoxColumn
End Class
