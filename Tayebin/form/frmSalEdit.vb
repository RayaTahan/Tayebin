Imports System.Data.SQLite

Public Class frmSalEdit

    Dim dID As Integer
    Dim data As DataTable

    Sub New(Optional ID As Integer = -1)
        InitializeComponent()

        dID = ID
    End Sub

    Private Sub frmSalEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'fun.ChangeFont(Me, My.MySettings.Default.Context.Item("Font"))

        If dID = -1 Then
            TextBox1.Text = "[جدید]"
            TextBox2.Text = ""
            PersianDateTimePicker1.Value = FreeControls.PersianDate.Now
        Else

            data = SQLiter.Fill("select * from tSal where ID=" & dID)
            TextBox1.Text = dID
            TextBox2.Text = data(0).Item("Onvan")

            PersianDateTimePicker1.Value = fun.strShamsi2PersianDate(data(0).Item("TarikhShoru"))
        End If

        Me.Show()
        TextBox2.Focus()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If dID = -1 Then
                SQLiter.RunCommand("insert into tSal(Onvan,TarikhShoru) values(@0,@1)", {New SQLiteParameter("@0", TextBox2.Text), New SQLiteParameter("@1", PersianDateTimePicker1.Value.ToString("yyyy/MM/dd"))})
            Else
                SQLiter.RunCommand("update tSal set Onvan=@0, TarikhShoru=@1 where ID=@2", {New SQLiteParameter("@0", TextBox2.Text), New SQLiteParameter("@1", PersianDateTimePicker1.Value.ToString("yyyy/MM/dd")), New SQLiteParameter("@2", dID)})
            End If

            Dim own As frmDoreha = Me.Owner
            own.ReloadData()
            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

    End Sub

End Class