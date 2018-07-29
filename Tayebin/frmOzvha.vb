Public Class frmOzvha
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Public Sub ReloadData(Optional Shart() As String = Nothing, Optional SalDore As String = "", Optional UseAnd As Boolean = False)
        ''''''''''''''''''''''''''''''''''''''''''''''''''''
        ''      Test Mode                  v2 -> v2.1     ''
        ''''''''''''''''''''''''''''''''''''''''''''''''''''
        'Try
        '    SQL.RunCommand("ALTER TABLE tOzv ADD SalVorud nvarchar(4) NULL")
        'Catch ex As Exception

        'End Try
        ''''''''''''''''''''''''''''''''''''''''''''''''''''

        Dim CMD As String = "select ID,Nam,Famil,Pedar,Tavalod,SalVorud from tOzv"
        Dim where As String = ""

        Dim AndOr As String = "or"
        If UseAnd Then AndOr = "And"

        If Shart IsNot Nothing Then
            For Each item In Shart
                where += String.Format(" {0} {1} ", AndOr, item)
            Next
        End If

        If where <> "" Then
            If SalDore <> "" Then
                where = "where " & "(" & where.Substring(3) & ") and  " & SalDore
            Else
                where = "where " & where.Substring(3)
            End If
        Else
            If SalDore <> "" Then
                where = "where " & SalDore
            End If
        End If

        CMD += " " & where
        CMD += " order by Famil,Nam,Pedar,Tavalod"

        CMD = CMD.Replace("%%", "%")

        DataGridView1.DataSource = SQLiter.Fill(CMD)
        Amar()
    End Sub

    Private Sub Amar()
        Dim tmp As String = String.Format("{0}", "آمار")
        Dim them As String = vbCrLf & "{0,-15} {1,15}"
        tmp += String.Format(them, "تعداد حاضر", DataGridView1.RowCount)
        tmp += String.Format(them, "تعداد کل اعضا", SQLiter.RunCommandScaler("select count(*) from tOzv"))
        lblAmar.Text = tmp
    End Sub
    Private Sub frmOzvha_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            'fun.ChangeFont(Me, My.MySettings.Default.Context.Item("Font"))
            ReloadData()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ReloadData()
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick

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
            Dim frm As New frmOzvEdit(DataGridView1.SelectedRows(0).Cells("ID").Value)
            frm.ShowDialog(Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub حذفToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles حذفToolStripMenuItem.Click
        Dim Count As Integer = Val(SQLiter.RunCommandScaler("select count(*) from tOzvSalDore where IDOzv =" & DataGridView1.SelectedRows(0).Cells("ID").Value))

        If Count > 0 Then
            MessageBox.Show("به این دلیل که در حال حاضر این اطلاعات در قسمتی از نرم افزار در حال استفاده است امکان حذف آن وجود ندارد.")
        Else
            Dim OzvID As Integer = DataGridView1.SelectedRows(0).Cells("ID").Value

            SQLiter.RunCommand("delete from tOzv where ID =" & OzvID)
            SQLiter.RunCommand("delete from tMadrak where IDOzv =" & OzvID)

            Dim DIR As String = Application.StartupPath & "\data\madarek\" & OzvID
            Try
                IO.Directory.Delete(DIR, True)
            Catch ex As Exception

            End Try

            ReloadData()
            MessageBox.Show("اطلاعات مورد نظر با موفقیت حذف گردید.")
        End If
    End Sub


    Private Sub نمایشToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles نمایشToolStripMenuItem.Click
        Try
            Dim frm As New frmOzvView(DataGridView1.SelectedRows(0).Cells("ID").Value)
            frm.ShowDialog(Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim frm As New frmOzvEdit
        frm.ShowDialog(Me)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim frm As New frmOzvJostoju
        frm.ShowDialog(Me)
    End Sub

    Private Sub DataGridView1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles DataGridView1.MouseDoubleClick
        Try
            Dim frm As New frmOzvView(DataGridView1.SelectedRows(0).Cells("ID").Value)
            frm.ShowDialog(Me)
        Catch ex As Exception
            'MsgBox(ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub
End Class