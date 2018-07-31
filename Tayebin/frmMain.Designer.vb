<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.lblKanunOnvan = New System.Windows.Forms.Label()
        Me.table = New System.Windows.Forms.TableLayoutPanel()
        Me.lblSaat = New System.Windows.Forms.Label()
        Me.lblTarikh = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblKanunOnvan
        '
        Me.lblKanunOnvan.BackColor = System.Drawing.Color.Transparent
        Me.lblKanunOnvan.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblKanunOnvan.Font = New System.Drawing.Font("Segoe UI Semibold", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblKanunOnvan.ForeColor = System.Drawing.Color.Lime
        Me.lblKanunOnvan.Location = New System.Drawing.Point(45, 0)
        Me.lblKanunOnvan.Name = "lblKanunOnvan"
        Me.lblKanunOnvan.Size = New System.Drawing.Size(737, 100)
        Me.lblKanunOnvan.TabIndex = 2
        Me.lblKanunOnvan.Text = "کانون"
        Me.lblKanunOnvan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'table
        '
        Me.table.ColumnCount = 3
        Me.table.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.table.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.table.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.table.Dock = System.Windows.Forms.DockStyle.Fill
        Me.table.Location = New System.Drawing.Point(45, 100)
        Me.table.Name = "table"
        Me.table.RowCount = 3
        Me.table.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.table.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.table.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.table.Size = New System.Drawing.Size(737, 322)
        Me.table.TabIndex = 4
        Me.table.Visible = False
        '
        'lblSaat
        '
        Me.lblSaat.BackColor = System.Drawing.Color.Transparent
        Me.lblSaat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblSaat.Font = New System.Drawing.Font("Segoe UI Semibold", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblSaat.ForeColor = System.Drawing.Color.Yellow
        Me.lblSaat.Location = New System.Drawing.Point(3, 0)
        Me.lblSaat.Name = "lblSaat"
        Me.lblSaat.Size = New System.Drawing.Size(363, 40)
        Me.lblSaat.TabIndex = 5
        Me.lblSaat.Text = "19:30:29"
        Me.lblSaat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTarikh
        '
        Me.lblTarikh.BackColor = System.Drawing.Color.Transparent
        Me.lblTarikh.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTarikh.Font = New System.Drawing.Font("Segoe UI Semibold", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblTarikh.ForeColor = System.Drawing.Color.Yellow
        Me.lblTarikh.Location = New System.Drawing.Point(372, 0)
        Me.lblTarikh.Name = "lblTarikh"
        Me.lblTarikh.Size = New System.Drawing.Size(362, 40)
        Me.lblTarikh.TabIndex = 6
        Me.lblTarikh.Text = "1396/04/20"
        Me.lblTarikh.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1000
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.lblTarikh, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblSaat, 1, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(45, 422)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(737, 40)
        Me.TableLayoutPanel1.TabIndex = 7
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Teal
        Me.ClientSize = New System.Drawing.Size(827, 462)
        Me.Controls.Add(Me.table)
        Me.Controls.Add(Me.lblKanunOnvan)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MinimumSize = New System.Drawing.Size(587, 371)
        Me.Name = "frmMain"
        Me.Opacity = 0R
        Me.Padding = New System.Windows.Forms.Padding(45, 0, 45, 0)
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "طیبین"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblKanunOnvan As Label
    Friend WithEvents table As TableLayoutPanel
    Friend WithEvents lblSaat As Label
    Friend WithEvents lblTarikh As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
End Class
