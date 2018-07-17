Public Class ucCalCel
    Dim _text As Integer = 0
    Shadows Property Text As Integer
        Get
            Return _text
        End Get
        Set(value As Integer)
            'If value >= 1 And value <= 31 Then
            _text = value
            lbl.Text = _text
            'End If
        End Set
    End Property

    Dim _selected As Boolean = False
    Shadows Property Selected As Boolean
        Get
            Return _selected
        End Get
        Set(value As Boolean)
            _selected = value
            If _selected Then
                Me.BackgroundImage = IMGcache.img("data\app\icon\mark.png")
            Else
                Me.BackgroundImage = Nothing
            End If
        End Set
    End Property

    Dim _bolded As Boolean = False
    Shadows Property Boldeded As Boolean
        Get
            Return _bolded
        End Get
        Set(value As Boolean)
            _bolded = value
            Dim tFont As New Font(lbl.Font, FontStyle.Regular)
            If _bolded Then
                tFont = New Font(tFont, FontStyle.Bold)
            End If
            lbl.Font = tFont
            If _bolded Then
                lbl.ForeColor = Color.Blue
            Else
                lbl.ForeColor = DefaultForeColor
            End If
        End Set
    End Property

    Public Shadows Event Click(sender As Object, e As EventArgs)

    Private Sub lbl_Click(sender As Object, e As EventArgs) Handles lbl.Click
        RaiseEvent Click(sender, e)
    End Sub

End Class
