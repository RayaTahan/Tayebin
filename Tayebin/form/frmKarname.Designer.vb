﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmKarname
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmKarname))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RizKarnameOnvan = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Meqdar = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IDRizKarname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.menu1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
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
        Me.Panel1.Controls.Add(Me.Button3)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(382, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(198, 324)
        Me.Panel1.TabIndex = 2
        '
        'Button3
        '
        Me.Button3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Button3.Location = New System.Drawing.Point(0, 96)
        Me.Button3.Margin = New System.Windows.Forms.Padding(9, 8, 9, 8)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(198, 48)
        Me.Button3.TabIndex = 3
        Me.Button3.Text = "مدیریت عناوین"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Button1.Location = New System.Drawing.Point(0, 48)
        Me.Button1.Margin = New System.Windows.Forms.Padding(9, 8, 9, 8)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(198, 48)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "افزودن نمره"
        Me.Button1.UseVisualStyleBackColor = True
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
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.RizKarnameOnvan, Me.Meqdar, Me.IDRizKarname})
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
        Me.DataGridView1.TabIndex = 3
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
        'RizKarnameOnvan
        '
        Me.RizKarnameOnvan.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.RizKarnameOnvan.DataPropertyName = "RizKarnameOnvan"
        Me.RizKarnameOnvan.FillWeight = 70.0!
        Me.RizKarnameOnvan.HeaderText = "عنوان"
        Me.RizKarnameOnvan.Name = "RizKarnameOnvan"
        Me.RizKarnameOnvan.ReadOnly = True
        '
        'Meqdar
        '
        Me.Meqdar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Meqdar.DataPropertyName = "Meqdar"
        Me.Meqdar.FillWeight = 30.0!
        Me.Meqdar.HeaderText = "نمره"
        Me.Meqdar.Name = "Meqdar"
        Me.Meqdar.ReadOnly = True
        '
        'IDRizKarname
        '
        Me.IDRizKarname.DataPropertyName = "IDRizKarname"
        Me.IDRizKarname.HeaderText = "IDRizKarname"
        Me.IDRizKarname.Name = "IDRizKarname"
        Me.IDRizKarname.ReadOnly = True
        Me.IDRizKarname.Visible = False
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
        'frmKarname
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(580, 324)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Panel1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(596, 363)
        Me.Name = "frmKarname"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "کارنامه"
        Me.Panel1.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.menu1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RizKarnameOnvan As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Meqdar As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IDRizKarname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents menu1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ویرایشToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents حذفToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Button3 As System.Windows.Forms.Button
End Class
