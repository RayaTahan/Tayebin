Imports System.ComponentModel

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

    Private _isPhoneNumber As Boolean


    <Browsable(True)>
    <DefaultValue(False)>
    Public Property isPhoneNumber As Boolean
        Set(value As Boolean)
            _isPhoneNumber = value
            If value Then
                Me.RightToLeft = RightToLeft.Yes
            Else
                Me.RightToLeft = RightToLeft.No
            End If
        End Set
        Get
            Return _isPhoneNumber
        End Get
    End Property

    'Public OrginalText As String = Me.Text
    Protected Overrides Sub OnTextChanged(e As EventArgs)
        If _isPhoneNumber And Me.ReadOnly Then
            'Dim tmp = ucFun.str2Phone(Me.Text)
            'If tmp = Me.Text Then
            '    'OrginalText = Me.Text
            'Else
            '    OrginalText = Me.Text
            '    Me.Text = tmp
            'End If
            Me.Text = ucFun.str2Phone(Me.Text)
            Me.SelectionStart = Me.TextLength
            Me.SelectionLength = 0
        End If
        MyBase.OnTextChanged(e)
    End Sub

    'Public Property Text As String
    '    Set(value As String)
    '        Me.Text = value
    '    End Set
    '    Get
    '        If Me.Text = Me.OrginalText Then
    '            Return Me.Text
    '        Else
    '            Return Me.OrginalText
    '        End If
    '    End Get
    'End Property

    'Private Property Text(Optional inner As Boolean = False) As String
    '    Set(value As String)
    '        If inner Then
    '            OriginalText = value
    '        End If
    '    End Set
    '    Get
    '        Return OriginalText
    '    End Get
    'End Property
End Class
