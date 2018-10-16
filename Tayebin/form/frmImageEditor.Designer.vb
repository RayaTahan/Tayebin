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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmImageEditor))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.panel = New System.Windows.Forms.Panel()
        Me.Abzar = New System.Windows.Forms.GroupBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnContrast = New System.Windows.Forms.Button()
        Me.btnFilipH = New System.Windows.Forms.Button()
        Me.btnFilipV = New System.Windows.Forms.Button()
        Me.btnRotateAC = New System.Windows.Forms.Button()
        Me.btnRotateC = New System.Windows.Forms.Button()
        Me.btnCrop = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblTaqir = New System.Windows.Forms.Label()
        Me.trackContrast = New System.Windows.Forms.TrackBar()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.preview = New System.Windows.Forms.PictureBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnTaeed = New System.Windows.Forms.Button()
        Me.btnEnseraf = New System.Windows.Forms.Button()
        Me.picPanel = New System.Windows.Forms.Panel()
        Me.pic = New System.Windows.Forms.PictureBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.tlpRotates = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.panel.SuspendLayout()
        Me.Abzar.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.trackContrast, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.preview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.picPanel.SuspendLayout()
        CType(Me.pic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tlpRotates.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200.0!))
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
        Me.panel.Location = New System.Drawing.Point(530, 3)
        Me.panel.Name = "panel"
        Me.panel.Padding = New System.Windows.Forms.Padding(7)
        Me.panel.Size = New System.Drawing.Size(194, 465)
        Me.panel.TabIndex = 0
        '
        'Abzar
        '
        Me.Abzar.Controls.Add(Me.Panel1)
        Me.Abzar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Abzar.Location = New System.Drawing.Point(7, 208)
        Me.Abzar.Name = "Abzar"
        Me.Abzar.Size = New System.Drawing.Size(180, 140)
        Me.Abzar.TabIndex = 5
        Me.Abzar.TabStop = False
        Me.Abzar.Text = "ابزار"
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.Controls.Add(Me.btnContrast)
        Me.Panel1.Controls.Add(Me.tlpRotates)
        Me.Panel1.Controls.Add(Me.btnCrop)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 25)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(174, 112)
        Me.Panel1.TabIndex = 2
        '
        'btnContrast
        '
        Me.btnContrast.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnContrast.Location = New System.Drawing.Point(0, 81)
        Me.btnContrast.Name = "btnContrast"
        Me.btnContrast.Size = New System.Drawing.Size(157, 40)
        Me.btnContrast.TabIndex = 10
        Me.btnContrast.Text = "تنظیم روشنایی"
        Me.btnContrast.UseVisualStyleBackColor = True
        '
        'btnFilipH
        '
        Me.btnFilipH.Font = New System.Drawing.Font("Segoe UI", 25.0!)
        Me.btnFilipH.Location = New System.Drawing.Point(80, 1)
        Me.btnFilipH.Margin = New System.Windows.Forms.Padding(1)
        Me.btnFilipH.Name = "btnFilipH"
        Me.btnFilipH.Size = New System.Drawing.Size(37, 39)
        Me.btnFilipH.TabIndex = 10
        Me.btnFilipH.Text = "⇆"
        Me.btnFilipH.UseCompatibleTextRendering = True
        Me.btnFilipH.UseVisualStyleBackColor = True
        '
        'btnFilipV
        '
        Me.btnFilipV.Font = New System.Drawing.Font("Segoe UI", 25.0!)
        Me.btnFilipV.Location = New System.Drawing.Point(119, 1)
        Me.btnFilipV.Margin = New System.Windows.Forms.Padding(1)
        Me.btnFilipV.Name = "btnFilipV"
        Me.btnFilipV.Size = New System.Drawing.Size(37, 39)
        Me.btnFilipV.TabIndex = 9
        Me.btnFilipV.Text = "⇅"
        Me.btnFilipV.UseCompatibleTextRendering = True
        Me.btnFilipV.UseVisualStyleBackColor = True
        '
        'btnRotateAC
        '
        Me.btnRotateAC.Font = New System.Drawing.Font("Segoe UI", 25.0!)
        Me.btnRotateAC.Location = New System.Drawing.Point(1, 1)
        Me.btnRotateAC.Margin = New System.Windows.Forms.Padding(1)
        Me.btnRotateAC.Name = "btnRotateAC"
        Me.btnRotateAC.Size = New System.Drawing.Size(38, 39)
        Me.btnRotateAC.TabIndex = 8
        Me.btnRotateAC.Text = "⟲"
        Me.btnRotateAC.UseCompatibleTextRendering = True
        Me.btnRotateAC.UseVisualStyleBackColor = True
        '
        'btnRotateC
        '
        Me.btnRotateC.Font = New System.Drawing.Font("Segoe UI", 25.0!)
        Me.btnRotateC.Location = New System.Drawing.Point(41, 1)
        Me.btnRotateC.Margin = New System.Windows.Forms.Padding(1)
        Me.btnRotateC.Name = "btnRotateC"
        Me.btnRotateC.Size = New System.Drawing.Size(37, 39)
        Me.btnRotateC.TabIndex = 7
        Me.btnRotateC.Text = "⟳"
        Me.btnRotateC.UseCompatibleTextRendering = True
        Me.btnRotateC.UseVisualStyleBackColor = True
        '
        'btnCrop
        '
        Me.btnCrop.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnCrop.Location = New System.Drawing.Point(0, 0)
        Me.btnCrop.Name = "btnCrop"
        Me.btnCrop.Size = New System.Drawing.Size(157, 40)
        Me.btnCrop.TabIndex = 2
        Me.btnCrop.Text = "برش"
        Me.btnCrop.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblTaqir)
        Me.GroupBox1.Controls.Add(Me.trackContrast)
        Me.GroupBox1.Controls.Add(Me.btnCancel)
        Me.GroupBox1.Controls.Add(Me.btnOK)
        Me.GroupBox1.Controls.Add(Me.preview)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(7, 7)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(180, 201)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "تغییرات"
        Me.GroupBox1.Visible = False
        '
        'lblTaqir
        '
        Me.lblTaqir.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblTaqir.Location = New System.Drawing.Point(3, 27)
        Me.lblTaqir.Name = "lblTaqir"
        Me.lblTaqir.Size = New System.Drawing.Size(174, 29)
        Me.lblTaqir.TabIndex = 7
        Me.lblTaqir.Text = "lblTaqir"
        Me.lblTaqir.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'trackContrast
        '
        Me.trackContrast.AutoSize = False
        Me.trackContrast.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.trackContrast.LargeChange = 20
        Me.trackContrast.Location = New System.Drawing.Point(3, 56)
        Me.trackContrast.Maximum = 100
        Me.trackContrast.Minimum = -100
        Me.trackContrast.Name = "trackContrast"
        Me.trackContrast.Size = New System.Drawing.Size(174, 18)
        Me.trackContrast.SmallChange = 5
        Me.trackContrast.TabIndex = 10
        Me.trackContrast.TickFrequency = 10
        Me.trackContrast.TickStyle = System.Windows.Forms.TickStyle.None
        Me.trackContrast.Visible = False
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
        Me.preview.Location = New System.Drawing.Point(3, 74)
        Me.preview.Name = "preview"
        Me.preview.Size = New System.Drawing.Size(174, 124)
        Me.preview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.preview.TabIndex = 4
        Me.preview.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnTaeed)
        Me.GroupBox2.Controls.Add(Me.btnEnseraf)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox2.Location = New System.Drawing.Point(7, 348)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(180, 110)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "خروجی"
        '
        'btnTaeed
        '
        Me.btnTaeed.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnTaeed.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnTaeed.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.btnTaeed.Enabled = False
        Me.btnTaeed.FlatAppearance.BorderColor = System.Drawing.Color.Green
        Me.btnTaeed.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTaeed.Location = New System.Drawing.Point(3, 27)
        Me.btnTaeed.Name = "btnTaeed"
        Me.btnTaeed.Size = New System.Drawing.Size(174, 40)
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
        Me.btnEnseraf.Size = New System.Drawing.Size(174, 40)
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
        Me.picPanel.Size = New System.Drawing.Size(521, 465)
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
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 500
        '
        'tlpRotates
        '
        Me.tlpRotates.ColumnCount = 4
        Me.tlpRotates.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpRotates.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpRotates.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpRotates.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpRotates.Controls.Add(Me.btnRotateC, 0, 0)
        Me.tlpRotates.Controls.Add(Me.btnRotateAC, 0, 0)
        Me.tlpRotates.Controls.Add(Me.btnFilipV, 0, 0)
        Me.tlpRotates.Controls.Add(Me.btnFilipH, 0, 0)
        Me.tlpRotates.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlpRotates.Location = New System.Drawing.Point(0, 40)
        Me.tlpRotates.Margin = New System.Windows.Forms.Padding(0)
        Me.tlpRotates.Name = "tlpRotates"
        Me.tlpRotates.RowCount = 1
        Me.tlpRotates.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpRotates.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpRotates.Size = New System.Drawing.Size(157, 41)
        Me.tlpRotates.TabIndex = 7
        '
        'frmImageEditor
        '
        Me.AcceptButton = Me.btnTaeed
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
        CType(Me.trackContrast, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.preview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.picPanel.ResumeLayout(False)
        CType(Me.pic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tlpRotates.ResumeLayout(False)
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
    Friend WithEvents btnCrop As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Timer1 As Timer
    Friend WithEvents btnFilipH As Button
    Friend WithEvents btnFilipV As Button
    Friend WithEvents btnRotateAC As Button
    Friend WithEvents btnRotateC As Button
    Friend WithEvents btnContrast As Button
    Friend WithEvents trackContrast As TrackBar
    Friend WithEvents tlpRotates As TableLayoutPanel
End Class
