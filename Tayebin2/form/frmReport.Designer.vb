<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReport
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
        Me.Viewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.SuspendLayout()
        '
        'Viewer
        '
        Me.Viewer.ActiveViewIndex = -1
        Me.Viewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Viewer.Cursor = System.Windows.Forms.Cursors.Default
        Me.Viewer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Viewer.Font = New System.Drawing.Font("B Roya", 14.25!)
        Me.Viewer.Location = New System.Drawing.Point(0, 0)
        Me.Viewer.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Viewer.Name = "Viewer"
        Me.Viewer.ShowLogo = False
        Me.Viewer.ShowParameterPanelButton = False
        Me.Viewer.Size = New System.Drawing.Size(476, 422)
        Me.Viewer.TabIndex = 0
        Me.Viewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'frmReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(476, 422)
        Me.Controls.Add(Me.Viewer)
        Me.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "frmReport"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ShowIcon = False
        Me.Text = "گزارش"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Viewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
