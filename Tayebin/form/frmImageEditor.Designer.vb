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
        Me.Abzar = New System.Windows.Forms.GroupBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblTaqir = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.preview = New System.Windows.Forms.PictureBox()
        Me.btnTaeed = New System.Windows.Forms.Button()
        Me.btnEnseraf = New System.Windows.Forms.Button()
        Me.picPanel = New System.Windows.Forms.Panel()
        Me.pic = New System.Windows.Forms.PictureBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.panel.SuspendLayout()
        Me.Abzar.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.preview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.picPanel.SuspendLayout()
        CType(Me.pic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150.0!))
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
        Me.panel.Controls.Add(Me.Abzar)
        Me.panel.Controls.Add(Me.GroupBox1)
        Me.panel.Controls.Add(Me.GroupBox2)
        Me.panel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panel.Location = New System.Drawing.Point(580, 3)
        Me.panel.Name = "panel"
        Me.panel.Padding = New System.Windows.Forms.Padding(7)
        Me.panel.Size = New System.Drawing.Size(144, 465)
        Me.panel.TabIndex = 0
        '
        'Abzar
        '
        Me.Abzar.Controls.Add(Me.Panel1)
        Me.Abzar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Abzar.Location = New System.Drawing.Point(7, 189)
        Me.Abzar.Name = "Abzar"
        Me.Abzar.Size = New System.Drawing.Size(130, 159)
        Me.Abzar.TabIndex = 5
        Me.Abzar.TabStop = False
        Me.Abzar.Text = "ابزار"
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 25)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(124, 131)
        Me.Panel1.TabIndex = 2
        '
        'Button1
        '
        Me.Button1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Button1.Location = New System.Drawing.Point(0, 0)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(124, 40)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "برش"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblTaqir)
        Me.GroupBox1.Controls.Add(Me.btnCancel)
        Me.GroupBox1.Controls.Add(Me.btnOK)
        Me.GroupBox1.Controls.Add(Me.preview)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(7, 7)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(130, 182)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "تغییرات"
        '
        'lblTaqir
        '
        Me.lblTaqir.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblTaqir.Location = New System.Drawing.Point(3, 26)
        Me.lblTaqir.Name = "lblTaqir"
        Me.lblTaqir.Size = New System.Drawing.Size(124, 29)
        Me.lblTaqir.TabIndex = 7
        Me.lblTaqir.Text = "lblTaqir"
        Me.lblTaqir.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.Red
        Me.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.Green
        Me.btnCancel.FlatAppearance.BorderSize = 0
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Location = New System.Drawing.Point(5, 1)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(22, 22)
        Me.btnCancel.TabIndex = 6
        Me.btnCancel.UseVisualStyleBackColor = False
        Me.btnCancel.Visible = False
        '
        'btnOK
        '
        Me.btnOK.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnOK.FlatAppearance.BorderColor = System.Drawing.Color.Green
        Me.btnOK.FlatAppearance.BorderSize = 0
        Me.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOK.Location = New System.Drawing.Point(35, 1)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(22, 22)
        Me.btnOK.TabIndex = 5
        Me.btnOK.UseVisualStyleBackColor = False
        Me.btnOK.Visible = False
        '
        'preview
        '
        Me.preview.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.preview.Location = New System.Drawing.Point(3, 55)
        Me.preview.Name = "preview"
        Me.preview.Size = New System.Drawing.Size(124, 124)
        Me.preview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.preview.TabIndex = 4
        Me.preview.TabStop = False
        '
        'btnTaeed
        '
        Me.btnTaeed.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnTaeed.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.btnTaeed.Enabled = False
        Me.btnTaeed.FlatAppearance.BorderColor = System.Drawing.Color.Green
        Me.btnTaeed.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTaeed.Location = New System.Drawing.Point(3, 27)
        Me.btnTaeed.Name = "btnTaeed"
        Me.btnTaeed.Size = New System.Drawing.Size(124, 40)
        Me.btnTaeed.TabIndex = 2
        Me.btnTaeed.Text = "ذخیره و خروج"
        Me.btnTaeed.UseVisualStyleBackColor = False
        '
        'btnEnseraf
        '
        Me.btnEnseraf.BackColor = System.Drawing.Color.Red
        Me.btnEnseraf.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnEnseraf.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.btnEnseraf.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnEnseraf.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEnseraf.Location = New System.Drawing.Point(3, 67)
        Me.btnEnseraf.Name = "btnEnseraf"
        Me.btnEnseraf.Size = New System.Drawing.Size(124, 40)
        Me.btnEnseraf.TabIndex = 1
        Me.btnEnseraf.Text = "انصراف"
        Me.btnEnseraf.UseVisualStyleBackColor = False
        '
        'picPanel
        '
        Me.picPanel.BackColor = System.Drawing.Color.WhiteSmoke
        Me.picPanel.Controls.Add(Me.pic)
        Me.picPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.picPanel.Location = New System.Drawing.Point(3, 3)
        Me.picPanel.Name = "picPanel"
        Me.picPanel.Size = New System.Drawing.Size(571, 465)
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
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnTaeed)
        Me.GroupBox2.Controls.Add(Me.btnEnseraf)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox2.Location = New System.Drawing.Point(7, 348)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(130, 110)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "خروجی"
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
        Me.Abzar.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.preview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.picPanel.ResumeLayout(False)
        CType(Me.pic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents panel As Panel
    Friend WithEvents btnTaeed As Button
    Friend WithEvents btnEnseraf As Button
    Friend WithEvents picPanel As Panel
    Friend WithEvents pic As PictureBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnOK As Button
    Friend WithEvents preview As PictureBox
    Friend WithEvents lblTaqir As Label
    Friend WithEvents Abzar As GroupBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Button1 As Button
    Friend WithEvents GroupBox2 As GroupBox
End Class
