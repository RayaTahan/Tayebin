Public Class frmKarname

    Dim dID As Integer
    Dim OID As Integer
    Dim data As DataTable

    Sub New(OzvID As Integer, Optional ID As Integer = -1)
        InitializeComponent()

        dID = ID
    End Sub

    Public Sub ReloadData()
        DataGridView1.DataSource = SQLiter.Fill("select ID,IDRizKarname,RizKarnameOnvan,Meqdar from vKarname where IDOzvSalDore=" & dID)
    End Sub

    Private Sub DataGridView1_MouseClick(sender As Object, e As MouseEventArgs) Handles DataGridView1.MouseClick
        Try
            DataGridView1.ClearSelection()
            DataGridView1.Rows(DataGridView1.HitTest(e.X, e.Y).RowIndex).Selected = True
        Catch ex As Exception
            menu1.Hide()
        End Try
    End Sub


    Private Sub ویرایشToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ویرایشToolStripMenuItem.Click
        Try
            Dim frm As New frmRizKarname(dID, DataGridView1.SelectedRows(0).Cells("ID").Value)
            frm.ShowDialog(Me)
        Catch ex As Exception

        End Try
    End Sub


    Private Sub حذفToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles حذفToolStripMenuItem.Click

        Dim KarnameID As Integer = DataGridView1.SelectedRows(0).Cells("ID").Value

        SQLiter.RunCommand("delete from tKarname where ID =" & KarnameID)


        ReloadData()
        MessageBox.Show("اطلاعات مورد نظر با موفقیت حذف گردید.")

    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ReloadData()
    End Sub

    Private Sub frmKarname_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'fun.ChangeFont(Me, My.MySettings.Default.Context.Item("Font"))
        ReloadData()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim frm As New frmRizKarname(dID)
        frm.ShowDialog(Me)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim frm As New frmOnvanList(frmOnvanList.eKodum.Karname)
        frm.ShowDialog(Me)
    End Sub
End Class