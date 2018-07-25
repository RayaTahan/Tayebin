Public Class frmOnvanList

    Public Enum eKodum As Integer
        Karname = 1
        Madrak = 2
    End Enum

    Dim dKodum As eKodum

    Sub New(Kodum As eKodum)
        InitializeComponent()

        dKodum = Kodum
    End Sub

    Public Sub ReloadData()
        Select Case dKodum
            Case eKodum.Karname
                DataGridView1.DataSource = SQLiter.Fill("select * from tRizKarname")
            Case eKodum.Madrak
                DataGridView1.DataSource = SQLiter.Fill("select * from tNoMadrak")
        End Select

    End Sub
    Private Sub frmOnvanList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'fun.ChangeFont(Me, My.MySettings.Default.Context.Item("Font"))

        ReloadData()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ReloadData()
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
            Select Case dKodum
                Case eKodum.Karname
                    Dim frm As New frmOnvanEdit(frmOnvanEdit.KodumOnvan.Karname, DataGridView1.SelectedRows(0).Cells("ID").Value)
                    frm.ShowDialog(Me)
                Case eKodum.Madrak
                    If DataGridView1.SelectedRows(0).Cells("ID").Value = 1 Then
                        MessageBox.Show("ویرایش این گزینه ممکن نیست!")
                    Else
                        Dim frm As New frmOnvanEdit(frmOnvanEdit.KodumOnvan.Madrak, DataGridView1.SelectedRows(0).Cells("ID").Value)
                        frm.ShowDialog(Me)
                    End If
            End Select
        Catch ex As Exception

        End Try
    End Sub


    Private Sub حذفToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles حذفToolStripMenuItem.Click

        Select Case dKodum
            Case eKodum.Karname
                Dim Count As Integer = Val(SQLiter.RunCommandScaler("select count(*) from tKarname where IDRizKarname =" & DataGridView1.SelectedRows(0).Cells("ID").Value))

                If Count > 0 Then
                    MessageBox.Show("به این دلیل که در حال حاضر این اطلاعات در قسمتی از نرم افزار در حال استفاده است امکان حذف آن وجود ندارد.")
                Else
                    SQLiter.RunCommand("delete from tRizKarname where ID =" & DataGridView1.SelectedRows(0).Cells("ID").Value)
                    ReloadData()
                    MessageBox.Show("اطلاعات مورد نظر با موفقیت حذف گردید.")
                End If
            Case eKodum.Madrak
                If DataGridView1.SelectedRows(0).Cells("ID").Value = 1 Then
                    MessageBox.Show("حذف این گزینه ممکن نیست!")
                Else
                    Dim Count As Integer = Val(SQLiter.RunCommandScaler("select count(*) from tMadrak where IDNoMadrak =" & DataGridView1.SelectedRows(0).Cells("ID").Value))

                    If Count > 0 Then
                        MessageBox.Show("به این دلیل که در حال حاضر این اطلاعات در قسمتی از نرم افزار در حال استفاده است امکان حذف آن وجود ندارد.")
                    Else
                        SQLiter.RunCommand("delete from tNoMadrak where ID =" & DataGridView1.SelectedRows(0).Cells("ID").Value)
                        ReloadData()
                        MessageBox.Show("اطلاعات مورد نظر با موفقیت حذف گردید.")
                    End If
                End If
        End Select

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Select Case dKodum
            Case eKodum.Karname
                Dim frm As New frmOnvanEdit(frmOnvanEdit.KodumOnvan.Karname)
                frm.ShowDialog(Me)
            Case eKodum.Madrak
                Dim frm As New frmOnvanEdit(frmOnvanEdit.KodumOnvan.Madrak)
                frm.ShowDialog(Me)
        End Select
    End Sub

End Class