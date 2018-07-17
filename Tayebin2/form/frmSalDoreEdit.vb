Public Class frmSalDoreEdit

    Dim dID As Integer
    Dim data As DataTable

    Sub New(Optional ID As Integer = -1)
        InitializeComponent()

        dID = ID
    End Sub

    Private Sub frmSalDoreEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'fun.ChangeFont(Me, My.MySettings.Default.Context.Item("Font"))

        ComboBox1.DataSource = SQL.Fill("select * from tSal")
        ComboBox1.ValueMember = "ID"
        ComboBox1.DisplayMember = "Onvan"

        ComboBox2.DataSource = SQL.Fill("select * from tDore")
        ComboBox2.ValueMember = "ID"
        ComboBox2.DisplayMember = "Onvan"

        ComboBox3.DataSource = SQL.Fill("select * from tMorabbi")
        ComboBox3.ValueMember = "ID"
        ComboBox3.DisplayMember = "Onvan"

        If ComboBox1.Items.Count = 0 Or ComboBox2.Items.Count = 0 Or ComboBox3.Items.Count = 0 Then
            MessageBox.Show("اطلاعات اولیه مورد نیاز شامل سال، دوره و مربی باید وجود داشته باشد!")
            Me.Close()
        End If

        If dID = -1 Then
            TextBox1.Text = "[جدید]"
        Else

            data = SQL.Fill("select * from tSalDore where ID=" & dID)
            TextBox1.Text = dID
            ComboBox1.SelectedValue = data(0).Item("IDSal")
            ComboBox2.SelectedValue = data(0).Item("IDDore")
            ComboBox3.SelectedValue = data(0).Item("IDMorabbi")
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If dID = -1 Then
                SQL.RunCommand("insert into tSalDore(IDSal,IDDore,IDMorabbi) values(@0,@1,@2)", {New SqlClient.SqlParameter("@0", ComboBox1.SelectedValue), New SqlClient.SqlParameter("@1", ComboBox2.SelectedValue), New SqlClient.SqlParameter("@2", ComboBox3.SelectedValue)})
            Else
                SQL.RunCommand("update tSalDore set IDSal=@0, IDDore=@1, IDMorabbi=@2 where ID=@3", {New SqlClient.SqlParameter("@0", ComboBox1.SelectedValue), New SqlClient.SqlParameter("@1", ComboBox2.SelectedValue), New SqlClient.SqlParameter("@2", ComboBox3.SelectedValue), New SqlClient.SqlParameter("@3", dID)})
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