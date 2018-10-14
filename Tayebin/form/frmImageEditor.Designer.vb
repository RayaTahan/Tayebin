<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmImageEditor
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmImageEditor))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.panel = New System.Windows.Forms.Panel()
        Me.preview = New System.Windows.Forms.PictureBox()
        Me.btnTaeed = New System.Windows.Forms.Button()
        Me.btnEnseraf = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.picPanel = New System.Windows.Forms.Panel()
        Me.pic = New System.Windows.Forms.PictureBox()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.panel.SuspendLayout()
        CType(Me.preview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.picPanel.SuspendLayout()
        CType(Me.pic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.panel, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.picPanel, 1, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(727, 471)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'panel
        '
        Me.panel.Controls.Add(Me.preview)
        Me.panel.Controls.Add(Me.btnTaeed)
        Me.panel.Controls.Add(Me.btnEnseraf)
        Me.panel.Controls.Add(Me.Button1)
        Me.panel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panel.Location = New System.Drawing.Point(610, 3)
        Me.panel.Name = "panel"
        Me.panel.Padding = New System.Windows.Forms.Padding(7)
        Me.panel.Size = New System.Drawing.Size(114, 465)
        Me.panel.TabIndex = 0
        '
        'preview
        '
        Me.preview.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.preview.Location = New System.Drawing.Point(7, 278)
        Me.preview.Name = "preview"
        Me.preview.Size = New System.Drawing.Size(100, 100)
        Me.preview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.preview.TabIndex = 3
        Me.preview.TabStop = False
        '
        'btnTaeed
        '
        Me.btnTaeed.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnTaeed.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.btnTaeed.Enabled = False
        Me.btnTaeed.FlatAppearance.BorderColor = System.Drawing.Color.Green
        Me.btnTaeed.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTaeed.Location = New System.Drawing.Point(7, 378)
        Me.btnTaeed.Name = "btnTaeed"
        Me.btnTaeed.Size = New System.Drawing.Size(100, 40)
        Me.btnTaeed.TabIndex = 2
        Me.btnTaeed.Text = "تایید"
        Me.btnTaeed.UseVisualStyleBackColor = False
        '
        'btnEnseraf
        '
        Me.btnEnseraf.BackColor = System.Drawing.Color.Red
        Me.btnEnseraf.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnEnseraf.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.btnEnseraf.Enabled = False
        Me.btnEnseraf.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnEnseraf.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEnseraf.Location = New System.Drawing.Point(7, 418)
        Me.btnEnseraf.Name = "btnEnseraf"
        Me.btnEnseraf.Size = New System.Drawing.Size(100, 40)
        Me.btnEnseraf.TabIndex = 1
        Me.btnEnseraf.Text = "انصراف"
        Me.btnEnseraf.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Button1.Location = New System.Drawing.Point(7, 7)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(100, 40)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "برش"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'picPanel
        '
        Me.picPanel.BackColor = System.Drawing.Color.WhiteSmoke
        Me.picPanel.Controls.Add(Me.pic)
        Me.picPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.picPanel.Location = New System.Drawing.Point(3, 3)
        Me.picPanel.Name = "picPanel"
        Me.picPanel.Size = New System.Drawing.Size(601, 465)
        Me.picPanel.TabIndex = 1
        '
        'pic
        '
        Me.pic.BackColor = System.Drawing.Color.Transparent
        Me.pic.Location = New System.Drawing.Point(114, 72)
        Me.pic.Name = "pic"
        Me.pic.Size = New System.Drawing.Size(368, 291)
        Me.pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pic.TabIndex = 4
        Me.pic.TabStop = False
        '
        'frmImageEditor
        '
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.CancelButton = Me.btnEnseraf
        Me.ClientSize = New System.Drawing.Size(727, 471)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmImageEditor"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Text = "ویراستار تصویر"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.panel.ResumeLayout(False)
        CType(Me.preview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.picPanel.ResumeLayout(False)
        CType(Me.pic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents panel As Panel
    Friend WithEvents Button1 As Button
    Friend WithEvents btnTaeed As Button
    Friend WithEvents btnEnseraf As Button
    Friend WithEvents preview As PictureBox
    Friend WithEvents picPanel As Panel
    Friend WithEvents pic As PictureBox
End Class
