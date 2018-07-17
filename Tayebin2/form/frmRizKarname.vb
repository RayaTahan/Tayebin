Public Class frmRizKarname

    Dim dID As Integer
    Dim OzvSalDoreID As Integer
    Dim data As DataTable


    Sub New(OzvSalDore As Integer, Optional ID As Integer = -1)
        InitializeComponent()

        dID = ID
        OzvSalDoreID = OzvSalDore
    End Sub

    Private Sub frmRizKarname_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'fun.ChangeFont(Me, My.MySettings.Default.Context.Item("Font"))

        Try
            ComboBox1.ValueMember = "ID"
            ComboBox1.DisplayMember = "Onvan"
            ComboBox1.DataSource = SQL.Fill("select * from tRizKarname")
            ComboBox1.SelectedItem = Nothing

            If dID = -1 Then
                ComboBox1.SelectedItem = ComboBox1.Items(0)
                TextBox1.Text = "[جدید]"
            Else
                data = SQL.Fill("select * from tKarname where ID=" & dID)
                TextBox1.Text = dID
                ComboBox1.SelectedValue = data(0).Item("IDRizKarname")
                NumericUpDown1.Value = data(0).Item("Meqdar")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Me.Close()
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If dID = -1 Then
                SQL.RunCommand("insert into tKarname(IDOzvSalDore,IDRizKarname,Meqdar) values(@0,@1,@2)", {New SqlClient.SqlParameter("@0", OzvSalDoreID), New SqlClient.SqlParameter("@1", ComboBox1.SelectedValue), New SqlClient.SqlParameter("@2", NumericUpDown1.Value)})
            Else
                SQL.RunCommand("update tKarname set IDOzvSalDore=@0 , IDRizKarname=@1 , Meqdar=@2 where ID=@3", {New SqlClient.SqlParameter("@0", OzvSalDoreID), New SqlClient.SqlParameter("@1", ComboBox1.SelectedValue), New SqlClient.SqlParameter("@2", NumericUpDown1.Value), New SqlClient.SqlParameter("@3", dID)})
            End If

            Dim own As frmKarname = Me.Owner
            own.ReloadData()
            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class