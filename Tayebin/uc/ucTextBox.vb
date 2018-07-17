Public Class ucTextBox
    Inherits TextBox

    Sub New()
        Me.Font = New Font("Segeo UI", 14)
        Me.BackColor = Color.White
    End Sub

    Protected Overrides Sub OnGotFocus(ByVal e As System.EventArgs)
        Me.BackColor = Color.Yellow
        Me.SelectAll()
        MyBase.OnGotFocus(e)
    End Sub

    Protected Overrides Sub OnLostFocus(ByVal e As System.EventArgs)
        Me.BackColor = Color.White
        Me.SelectionLength = 0
        MyBase.OnLostFocus(e)
    End Sub

    Private Sub InitializeComponent()
        Me.SuspendLayout()
        '
        'ucTextBox
        '
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ResumeLayout(False)

    End Sub

End Class
