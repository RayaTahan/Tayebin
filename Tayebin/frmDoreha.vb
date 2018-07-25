Public Class frmDoreha

    Dim LastRC As DataGridView

    Public Sub ReloadData()
        DataGridView1.DataSource = SQLiter.Fill("select * from tDore")
        DataGridView2.DataSource = SQLiter.Fill("select * from tMorabbi")
        DataGridView3.DataSource = SQLiter.Fill("select SalDoreID,SalOnvan,DoreOnvan,MorabbiOnvan from vSalDore")
        DataGridView4.DataSource = SQLiter.Fill("select * from tSal")

        ListView1.Items.Clear()
        For Each row In SQLiter.Fill("select SalDoreID,SalOnvan,DoreOnvan,MorabbiOnvan from vSalDore").Rows()
            Dim item As New ListViewItem()
            item.Tag = row("SalDoreID")
            item.Text = row("DoreOnvan")
            item.SubItems.Add(row("MorabbiOnvan"))
            ListView1.Groups.Add(New ListViewGroup(row("SalOnvan").ToString, row("SalOnvan").ToString))
            item.Group = ListView1.Groups(row("SalOnvan"))
            ListView1.Items.Add(item)
        Next
    End Sub

    Private Sub rsize()
        Dim w As Integer = ListView1.Width - 50
        ListView1.Columns(0).Width = w * 40 / 100
        ListView1.Columns(1).Width = w * 60 / 100

    End Sub
    Private Sub frmDoreha_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'fun.ChangeFont(Me, My.MySettings.Default.Context.Item("Font"))
        ReloadData()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ReloadData()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim frm As New frmOnvanEdit(frmOnvanEdit.KodumOnvan.Dore)
        frm.ShowDialog(Me)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim frm As New frmOnvanEdit(frmOnvanEdit.KodumOnvan.Morabbi)
        frm.ShowDialog(Me)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim frm As New frmSalDoreEdit
        frm.ShowDialog(Me)
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim frm As New frmSalEdit
        frm.ShowDialog(Me)
    End Sub

    Private Sub DataGridView1_MouseClick(sender As Object, e As MouseEventArgs) Handles DataGridView1.MouseClick
        LastRC = DataGridView1
        Try
            DataGridView1.ClearSelection()
            DataGridView1.Rows(DataGridView1.HitTest(e.X, e.Y).RowIndex).Selected = True
        Catch ex As Exception
            menu1.Hide()
        End Try
    End Sub

    Private Sub DataGridView2_MouseClick(sender As Object, e As MouseEventArgs) Handles DataGridView2.MouseClick
        LastRC = DataGridView2
        Try
            DataGridView2.ClearSelection()
            DataGridView2.Rows(DataGridView2.HitTest(e.X, e.Y).RowIndex).Selected = True
        Catch ex As Exception
            menu1.Hide()
        End Try
    End Sub

    Private Sub DataGridView3_MouseClick(sender As Object, e As MouseEventArgs) Handles DataGridView3.MouseClick
        LastRC = DataGridView3
        Try
            DataGridView3.ClearSelection()
            DataGridView3.Rows(DataGridView3.HitTest(e.X, e.Y).RowIndex).Selected = True
        Catch ex As Exception
            menu1.Hide()
        End Try
    End Sub

    Private Sub DataGridView4_MouseClick(sender As Object, e As MouseEventArgs) Handles DataGridView4.MouseClick
        LastRC = DataGridView4
        Try
            DataGridView4.ClearSelection()
            DataGridView4.Rows(DataGridView4.HitTest(e.X, e.Y).RowIndex).Selected = True
        Catch ex As Exception
            menu1.Hide()
        End Try
    End Sub

    Private Sub ویرایشToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ویرایشToolStripMenuItem.Click

        Try
            Select Case LastRC.Name
                Case "DataGridView1"
                    If LastRC.SelectedRows(0).Cells(0).Value = 1 Then
                        MessageBox.Show("ویرایش این گزینه ممکن نیست!")
                    Else
                        Dim frm As New frmOnvanEdit(frmOnvanEdit.KodumOnvan.Dore, LastRC.SelectedRows(0).Cells(0).Value)
                        frm.ShowDialog(Me)
                    End If
                Case "DataGridView2"
                    Dim frm As New frmOnvanEdit(frmOnvanEdit.KodumOnvan.Morabbi, LastRC.SelectedRows(0).Cells(0).Value)
                    frm.ShowDialog(Me)
                Case "DataGridView3"
                    If ListView1.SelectedItems.Count = 1 Then
                        Dim frm As New frmSalDoreEdit(ListView1.SelectedItems(0).Tag)
                        frm.ShowDialog(Me)
                    End If
                Case "DataGridView4"
                    Dim frm As New frmSalEdit(LastRC.SelectedRows(0).Cells(0).Value)
                    frm.ShowDialog(Me)
            End Select

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub حذفToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles حذفToolStripMenuItem.Click

        Select Case LastRC.Name
            Case "DataGridView1"
                If LastRC.SelectedRows(0).Cells(0).Value = 1 Then
                    MessageBox.Show("حذف این گزینه ممکن نیست!")
                Else
                    Dim Count As Integer = Val(SQLiter.RunCommandScaler("select count(*) from tSalDore where IDDore =" & LastRC.SelectedRows(0).Cells(0).Value))

                    If Count > 0 Then
                        MessageBox.Show("به این دلیل که در حال حاضر این اطلاعات در قسمتی از نرم افزار در حال استفاده است امکان حذف آن وجود ندارد.")
                    Else
                        SQLiter.RunCommand("delete from tDore where ID =" & LastRC.SelectedRows(0).Cells(0).Value)
                        ReloadData()
                        MessageBox.Show("اطلاعات مورد نظر با موفقیت حذف گردید.")
                    End If
                End If

            Case "DataGridView2"
                Dim Count As Integer = Val(SQLiter.RunCommandScaler("select count(*) from tSalDore where IDMorabbi =" & LastRC.SelectedRows(0).Cells(0).Value))

                If Count > 0 Then
                    MessageBox.Show("به این دلیل که در حال حاضر این اطلاعات در قسمتی از نرم افزار در حال استفاده است امکان حذف آن وجود ندارد.")
                Else
                    SQLiter.RunCommand("delete from tMorabbi where ID =" & LastRC.SelectedRows(0).Cells(0).Value)
                    ReloadData()
                    MessageBox.Show("اطلاعات مورد نظر با موفقیت حذف گردید.")
                End If
            Case "DataGridView3"
                If ListView1.SelectedItems.Count = 1 Then
                    Dim Count As Integer = Val(SQLiter.RunCommandScaler("select count(*) from tOzvSalDore where IDSalDore =" & ListView1.SelectedItems(0).Tag))

                    If Count > 0 Then
                        MessageBox.Show("به این دلیل که در حال حاضر این اطلاعات در قسمتی از نرم افزار در حال استفاده است امکان حذف آن وجود ندارد.")
                    Else
                        SQLiter.RunCommand("delete from tSalDore where ID =" & ListView1.SelectedItems(0).Tag)
                        MessageBox.Show("اطلاعات مورد نظر با موفقیت حذف گردید.")
                        ReloadData()
                    End If
                End If
            Case "DataGridView4"
                Dim Count As Integer = Val(SQLiter.RunCommandScaler("select count(*) from tSalDore where IDSal =" & DataGridView4.SelectedRows(0).Cells(0).Value))

                If Count > 0 Then
                    MessageBox.Show("به این دلیل که در این سال دوره ای ثبت شده امکان حذف این سال وجود ندارد.")
                Else
                    SQLiter.RunCommand("delete from tSal where ID =" & DataGridView4.SelectedRows(0).Cells(0).Value)
                    ReloadData()
                    MessageBox.Show("اطلاعات مورد نظر با موفقیت حذف گردید.")
                End If
        End Select

    End Sub

    Private Sub DataGridView4_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView4.CellContentClick

    End Sub

    Private Sub DataGridView4_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles DataGridView4.MouseDoubleClick
        Try
            Dim frm As New frmSalEdit(DataGridView4.SelectedRows(0).Cells(0).Value)
            frm.ShowDialog(Me)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub DataGridView3_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles DataGridView3.MouseDoubleClick
        Try
            Dim frm As New frmSalDoreEdit(DataGridView3.SelectedRows(0).Cells(0).Value)
            frm.ShowDialog(Me)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub DataGridView2_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles DataGridView2.MouseDoubleClick
        Try
            Dim frm As New frmOnvanEdit(frmOnvanEdit.KodumOnvan.Morabbi, DataGridView2.SelectedRows(0).Cells(0).Value)
            frm.ShowDialog(Me)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub DataGridView1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles DataGridView1.MouseDoubleClick
        If DataGridView1.SelectedRows(0).Cells(0).Value = 1 Then
            MessageBox.Show("ویرایش این گزینه ممکن نیست!")
        Else
            Dim frm As New frmOnvanEdit(frmOnvanEdit.KodumOnvan.Dore, DataGridView1.SelectedRows(0).Cells(0).Value)
            frm.ShowDialog(Me)
        End If
    End Sub

    Private Sub ListView1_Resize(sender As Object, e As EventArgs) Handles ListView1.Resize
        rsize()
    End Sub

    Private Sub ListView1_MouseClick(sender As Object, e As MouseEventArgs) Handles ListView1.MouseClick
        LastRC = DataGridView3
        Try
            'DataGridView3.ClearSelection()
            'DataGridView3.Rows(DataGridView3.HitTest(e.X, e.Y).RowIndex).Selected = True
        Catch ex As Exception
            menu1.Hide()
        End Try
    End Sub

    Private Sub ListView1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles ListView1.MouseDoubleClick
        Try
            Dim frm As New frmSalDoreEdit(ListView1.SelectedItems(0).Tag)
            frm.ShowDialog(Me)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class