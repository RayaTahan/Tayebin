<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmTaqvim
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTaqvim))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.cal = New Tayebin.ucCal()
        Me.txtMonasebat = New Tayebin.ucTextBox()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        resources.ApplyResources(Me.TableLayoutPanel1, "TableLayoutPanel1")
        Me.TableLayoutPanel1.Controls.Add(Me.cal, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtMonasebat, 0, 1)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        '
        'cal
        '
        Me.cal.BackColor = System.Drawing.Color.GhostWhite
        resources.ApplyResources(Me.cal, "cal")
        Me.cal.inNamayeshBold = ""
        Me.cal.Name = "cal"
        '
        'txtMonasebat
        '
        Me.txtMonasebat.BackColor = System.Drawing.Color.White
        resources.ApplyResources(Me.txtMonasebat, "txtMonasebat")
        Me.txtMonasebat.Name = "txtMonasebat"
        Me.txtMonasebat.ReadOnly = True
        '
        'frmTaqvim
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "frmTaqvim"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents cal As ucCal
    Friend WithEvents txtMonasebat As ucTextBox
End Class
