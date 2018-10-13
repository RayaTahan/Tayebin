<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDoreha
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDoreha))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.DataGridView3 = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IDDore = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IDMorabbi = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.menu1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ویرایشToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.حذفToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.DataGridView4 = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TarikhShoru = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Onvan = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1.SuspendLayout()
        CType(Me.DataGridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.menu1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.DataGridView4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Panel1.Controls.Add(Me.DataGridView3)
        Me.Panel1.Controls.Add(Me.Button4)
        Me.Panel1.Controls.Add(Me.Button3)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.Button5)
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(566, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(198, 461)
        Me.Panel1.TabIndex = 1
        '
        'DataGridView3
        '
        Me.DataGridView3.AllowUserToAddRows = False
        Me.DataGridView3.AllowUserToDeleteRows = False
        Me.DataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView3.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.IDDore, Me.IDMorabbi})
        Me.DataGridView3.ContextMenuStrip = Me.menu1
        Me.DataGridView3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView3.Location = New System.Drawing.Point(0, 240)
        Me.DataGridView3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.DataGridView3.Name = "DataGridView3"
        Me.DataGridView3.ReadOnly = True
        Me.DataGridView3.RowHeadersVisible = False
        Me.DataGridView3.RowTemplate.Height = 30
        Me.DataGridView3.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView3.Size = New System.Drawing.Size(198, 221)
        Me.DataGridView3.TabIndex = 6
        Me.DataGridView3.Visible = False
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "SalDoreID"
        Me.DataGridViewTextBoxColumn1.HeaderText = "کد"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 51
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "SalOnvan"
        Me.DataGridViewTextBoxColumn2.HeaderText = "سال"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'IDDore
        '
        Me.IDDore.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.IDDore.DataPropertyName = "DoreOnvan"
        Me.IDDore.HeaderText = "دوره"
        Me.IDDore.Name = "IDDore"
        Me.IDDore.ReadOnly = True
        '
        'IDMorabbi
        '
        Me.IDMorabbi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.IDMorabbi.DataPropertyName = "MorabbiOnvan"
        Me.IDMorabbi.HeaderText = "مربی"
        Me.IDMorabbi.Name = "IDMorabbi"
        Me.IDMorabbi.ReadOnly = True
        '
        'menu1
        '
        Me.menu1.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.menu1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ویرایشToolStripMenuItem, Me.حذفToolStripMenuItem})
        Me.menu1.Name = "menu1"
        Me.menu1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.menu1.Size = New System.Drawing.Size(129, 56)
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
        'Button4
        '
        Me.Button4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Button4.Location = New System.Drawing.Point(0, 192)
        Me.Button4.Margin = New System.Windows.Forms.Padding(9, 8, 9, 8)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(198, 48)
        Me.Button4.TabIndex = 4
        Me.Button4.Text = "افزودن سال-دوره"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Button3.Location = New System.Drawing.Point(0, 144)
        Me.Button3.Margin = New System.Windows.Forms.Padding(9, 8, 9, 8)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(198, 48)
        Me.Button3.TabIndex = 3
        Me.Button3.Text = "افزودن مربی"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Button1.Location = New System.Drawing.Point(0, 96)
        Me.Button1.Margin = New System.Windows.Forms.Padding(9, 8, 9, 8)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(198, 48)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "افزودن دوره"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Button5.Location = New System.Drawing.Point(0, 48)
        Me.Button5.Margin = New System.Windows.Forms.Padding(9, 8, 9, 8)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(198, 48)
        Me.Button5.TabIndex = 5
        Me.Button5.Text = "افزودن سال"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Button2.Location = New System.Drawing.Point(0, 0)
        Me.Button2.Margin = New System.Windows.Forms.Padding(9, 8, 9, 8)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(198, 48)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "تازه سازی داده ها"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.ListView1, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.DataGridView4, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.DataGridView2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.DataGridView1, 1, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(566, 461)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'ListView1
        '
        Me.ListView1.AllowColumnReorder = True
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.ListView1.ContextMenuStrip = Me.menu1
        Me.ListView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListView1.FullRowSelect = True
        Me.ListView1.Location = New System.Drawing.Point(3, 233)
        Me.ListView1.MultiSelect = False
        Me.ListView1.Name = "ListView1"
        Me.ListView1.RightToLeftLayout = True
        Me.ListView1.Size = New System.Drawing.Size(277, 225)
        Me.ListView1.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.ListView1.TabIndex = 6
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "دوره"
        Me.ColumnHeader1.Width = 100
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "مربی"
        Me.ColumnHeader2.Width = 100
        '
        'DataGridView4
        '
        Me.DataGridView4.AllowUserToAddRows = False
        Me.DataGridView4.AllowUserToDeleteRows = False
        Me.DataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView4.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn6, Me.TarikhShoru})
        Me.DataGridView4.ContextMenuStrip = Me.menu1
        Me.DataGridView4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView4.Location = New System.Drawing.Point(286, 2)
        Me.DataGridView4.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.DataGridView4.Name = "DataGridView4"
        Me.DataGridView4.ReadOnly = True
        Me.DataGridView4.RowHeadersVisible = False
        Me.DataGridView4.RowTemplate.Height = 30
        Me.DataGridView4.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView4.Size = New System.Drawing.Size(277, 226)
        Me.DataGridView4.TabIndex = 9
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "ID"
        Me.DataGridViewTextBoxColumn3.HeaderText = "کد"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 51
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "Onvan"
        Me.DataGridViewTextBoxColumn6.FillWeight = 70.0!
        Me.DataGridViewTextBoxColumn6.HeaderText = "عنوان سال"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        '
        'TarikhShoru
        '
        Me.TarikhShoru.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.TarikhShoru.DataPropertyName = "TarikhShoru"
        Me.TarikhShoru.FillWeight = 30.0!
        Me.TarikhShoru.HeaderText = "تاریخ شروع"
        Me.TarikhShoru.Name = "TarikhShoru"
        Me.TarikhShoru.ReadOnly = True
        '
        'DataGridView2
        '
        Me.DataGridView2.AllowUserToAddRows = False
        Me.DataGridView2.AllowUserToDeleteRows = False
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5})
        Me.DataGridView2.ContextMenuStrip = Me.menu1
        Me.DataGridView2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView2.Location = New System.Drawing.Point(286, 232)
        Me.DataGridView2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.ReadOnly = True
        Me.DataGridView2.RowHeadersVisible = False
        Me.DataGridView2.RowTemplate.Height = 30
        Me.DataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView2.Size = New System.Drawing.Size(277, 227)
        Me.DataGridView2.TabIndex = 8
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "ID"
        Me.DataGridViewTextBoxColumn4.HeaderText = "کد"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 51
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "Onvan"
        Me.DataGridViewTextBoxColumn5.FillWeight = 70.0!
        Me.DataGridViewTextBoxColumn5.HeaderText = "عنوان مربی"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.Onvan})
        Me.DataGridView1.ContextMenuStrip = Me.menu1
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(3, 2)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.RowTemplate.Height = 30
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(277, 226)
        Me.DataGridView1.TabIndex = 5
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
        'Onvan
        '
        Me.Onvan.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Onvan.DataPropertyName = "Onvan"
        Me.Onvan.FillWeight = 70.0!
        Me.Onvan.HeaderText = "عنوان دوره"
        Me.Onvan.Name = "Onvan"
        Me.Onvan.ReadOnly = True
        '
        'frmDoreha
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(764, 461)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.Panel1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MinimumSize = New System.Drawing.Size(596, 363)
        Me.Name = "frmDoreha"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "مدیریت دوره ها"
        Me.Panel1.ResumeLayout(False)
        CType(Me.DataGridView3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.menu1.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.DataGridView4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents menu1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ویرایشToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents حذفToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Onvan As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridView3 As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IDDore As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IDMorabbi As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridView4 As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TarikhShoru As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ListView1 As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
End Class
