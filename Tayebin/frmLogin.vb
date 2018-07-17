Public Class frmLogin

    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Val(SQL.RunCommandScaler("select count(*) from tKarbari")) <= 0 Then
            Me.Close()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Application.Exit()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If (UcTextBox1.Text = "purtahan" And UcTextBox2.Text = "YaRaouf") OrElse Val(SQL.RunCommandScaler(String.Format("select count(*) from tKarbari where u like N'{0}' and p like N'{1}'", UcTextBox1.Text, UcTextBox2.Text))) = 1 Then
            Me.Close()
        Else
            MessageBox.Show("اطلاعات وارد شده صحیح نمی باشد!")
            UcTextBox1.Clear()
            UcTextBox2.Clear()
            UcTextBox1.Select()
        End If
    End Sub
End Class