Imports System.Data.SQLite

Public Class frmOzvView


    Dim dID As Integer
    Dim data As DataTable

    Sub New(ID As Integer)
        InitializeComponent()

        dID = ID
    End Sub

    Public Sub ReloadData()
        data = SQLiter.Fill("select * from tOzv where ID=" & dID)
        txtID.Text = dID
        txtNam.Text = data(0).Item("Nam")
        txtFamil.Text = data(0).Item("Famil")
        txtPedar.Text = data(0).Item("Pedar")
        txtTavalod.Text = data(0).Item("Tavalod")
        Select Case data(0).Item("Zende")
            Case "z"
                txtHayat.Text = "زنده"
            Case "v"
                txtHayat.Text = "وفات: " & data(0).Item("Vafat")
            Case "s"
                txtHayat.Text = "شهادت: " & data(0).Item("Vafat")
        End Select
        txtCodeMelli.Text = data(0).Item("CodeMelli")
        txtSalVorud.Text = data(0).Item("SalVorud").ToString
        txtTel.Text = data(0).Item("Tel")
        txtMob.Text = data(0).Item("Mob")
        txtMobPedar.Text = data(0).Item("MobPedar")
        txtMobMadar.Text = data(0).Item("MobMadar")
        txtAdres.Text = data(0).Item("Adres")
        txtTahsil.Text = data(0).Item("Tahsil")
        txtMahalTahsil.Text = data(0).Item("MahalTahsil")
        txtShoql.Text = data(0).Item("Shoql")
        txtMahalKar.Text = data(0).Item("MahalKar")
        txtShoqlPedar.Text = data(0).Item("ShoqlPedar")
        txtShoqlMadar.Text = data(0).Item("ShoqlMadar")
        txtTozih.Text = data(0).Item("Tozih")
        txtZamanSabt.Text = String.Format("{0} - {1}", data(0).Item("ZamanSabt"), data(0).Item("TarikhSabt"))
        txtZamanVirayesh.Text = String.Format("{0} - {1}", data(0).Item("ZamanVirayesh"), data(0).Item("TarikhVirayesh"))
        txtTedadVirayesh.Text = data(0).Item("TedadVirayesh")

        If data(0).Item("AxID") = -1 Then
            picAx.Image = IMGcache.img(String.Format("{0}\data\app\icon\profile27.png", Application.StartupPath))
        Else
            Dim AxData = SQLiter.Fill("select * from tMadrak where ID=" & data(0).Item("AxID"))
            picAx.Image = IMGcache.img(String.Format("{0}\data\madarek\{1}\{1}-{2}{3}", Application.StartupPath, dID, AxData(0).Item("ID"), AxData(0).Item("FileEXT")))
        End If

        DataGridView1.DataSource = SQLiter.Fill("select NoMadrakOnvan,ID,IDNoMadrak,Onvan,Tarikh,FileEXT from vMadrak where IDOzv=" & dID)

        'DataGridView2.DataSource = SQL.Fill("select ID, SalOnvan,DoreOnvan,MorabbiOnvan from vOzvSalDore where IDOzv=" & dID)
        ListView1.Items.Clear()

        Dim grpList As New List(Of ListViewGroup)
        For Each row In SQLiter.Fill("select ID, SalOnvan,DoreOnvan,MorabbiOnvan from vOzvSalDore where IDOzv=" & dID).Rows()
            Dim item As New ListViewItem()
            item.Tag = row("ID")
            item.Text = row("DoreOnvan")
            item.SubItems.Add(row("MorabbiOnvan"))
            ListView1.Groups.Add(New ListViewGroup(row("SalOnvan").ToString, row("SalOnvan").ToString))
            item.Group = ListView1.Groups(row("SalOnvan"))
            ListView1.Items.Add(item)
        Next

        ListView1.BeginUpdate()
        Try
            grpList.AddRange(ListView1.Groups)
            Array.Sort(grpList.ToArray)

        Catch ex As Exception

        End Try

        ListView1.EndUpdate()
    End Sub

    Private Sub frmOzvView_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'fun.ChangeFont(Me, My.MySettings.Default.Context.Item("Font"))

        ReloadData()
        Dim w As Integer = ListView1.Width - 40
        ListView1.Columns(0).Width = w * 40 / 100
        ListView1.Columns(1).Width = w * 60 / 100
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ReloadData()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ReloadData()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim frm As New frmOzvSalDoreEdit(dID)
        frm.ShowDialog(Me)
    End Sub

    Private Sub DataGridView1_MouseClick(sender As Object, e As MouseEventArgs) Handles DataGridView1.MouseClick
        Try
            DataGridView1.ClearSelection()
            DataGridView1.Rows(DataGridView1.HitTest(e.X, e.Y).RowIndex).Selected = True
        Catch ex As Exception
            menu1.Hide()
        End Try
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        ListView1_MouseDoubleClick(sender, Nothing)
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        If ListView1.SelectedItems.Count = 1 Then
            Dim Count As Integer = Val(SQLiter.RunCommandScaler("select count(*) from tKarname where IDOzvSalDore =" & ListView1.SelectedItems(0).Tag))

            If Count > 0 Then
                MessageBox.Show("به این دلیل که در حال حاضر این اطلاعات در قسمتی از نرم افزار در حال استفاده است امکان حذف آن وجود ندارد.")
            Else
                SQLiter.RunCommand("delete from tOzvSalDore where ID =" & ListView1.SelectedItems(0).Tag)

                ReloadData()
                MessageBox.Show("اطلاعات مورد نظر با موفقیت حذف گردید.")
            End If
        End If
    End Sub

    Private Sub کارنامهToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles کارنامهToolStripMenuItem.Click
        Try
            If ListView1.SelectedItems.Count = 1 Then
                Dim frm As New frmKarname(dID, ListView1.SelectedItems(0).Tag)
                frm.ShowDialog(Me)
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim frm As New frmOnvanList(frmOnvanList.eKodum.Madrak)
        frm.ShowDialog(Me)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim frm As New frmMadrak(dID)
        frm.ShowDialog(Me)
    End Sub

    Private Sub نمایشToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles نمایشToolStripMenuItem.Click
        DataGridView1_MouseDoubleClick(Nothing, Nothing)
    End Sub

    Private Sub ویرایشToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ویرایشToolStripMenuItem.Click
        Try
            Dim frm As New frmMadrak(dID, DataGridView1.SelectedRows(0).Cells("IDMadrak").Value)
            frm.ShowDialog(Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub حذفToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles حذفToolStripMenuItem.Click
        Try
            Dim fileEXT As String = DataGridView1.SelectedRows(0).Cells("FileEXT").Value
            Dim fileAdres As String = String.Format("{0}\data\madarek\{1}\{1}-{2}{3}", Application.StartupPath, dID, DataGridView1.SelectedRows(0).Cells("IDMadrak").Value, fileEXT)

            If SQLiter.RunCommandScaler("select AxID from tOzv where ID=" & dID) = DataGridView1.SelectedRows(0).Cells("IDMadrak").Value Then
                If MessageBox.Show("این تصویر به عنوان عکس عضو انتخاب شده است. برای حذف فایل، تایید کنید.", "حذف عکس پروفایل", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                    SQLiter.RunCommand("update tOzv set AxID=-1 where ID=" & dID)
                    SQLiter.RunCommand("delete from tMadrak where ID=" & DataGridView1.SelectedRows(0).Cells("IDMadrak").Value)
                    picAx.Image.Dispose()
                    FileIO.FileSystem.DeleteFile(fileAdres)
                    MessageBox.Show("فایل با موفقیت حذف شد")
                    ReloadData()
                End If
            Else
                SQLiter.RunCommand("delete from tMadrak where ID=" & DataGridView1.SelectedRows(0).Cells("IDMadrak").Value)
                FileIO.FileSystem.DeleteFile(fileAdres)
                MessageBox.Show("فایل با موفقیت حذف شد")
                ReloadData()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ثبتبهعنوانعکسToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ثبتبهعنوانعکسToolStripMenuItem.Click
        Try
            If DataGridView1.SelectedRows(0).Cells("IDNoMadrak").Value = 1 Then ' IDNoMadrak=AxPerseneli
                SQLiter.RunCommand("update tOzv set AXID=@0 where ID=@1", {New SQLiteParameter("@0", DataGridView1.SelectedRows(0).Cells("IDMadrak").Value), New SQLiteParameter("@1", dID)})
                MessageBox.Show("عکس مورد نظر با موفقیت انتخاب شد")
                ReloadData()
            Else
                MessageBox.Show("این امکان فقط برای عکس های پرسنلی می باشد.")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub DataGridView1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles DataGridView1.MouseDoubleClick
        Try
            Dim fileEXT As String = DataGridView1.SelectedRows(0).Cells("FileEXT").Value
            Dim fileAdres As String = String.Format("{0}\data\madarek\{1}\{1}-{2}{3}", Application.StartupPath, dID, DataGridView1.SelectedRows(0).Cells("IDMadrak").Value, fileEXT)

            Dim tfile As String = FileIO.FileSystem.GetTempFileName & fileEXT
            FileIO.FileSystem.CopyFile(fileAdres, tfile, True)

            Shell("explorer " & tfile)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ListView1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles ListView1.MouseDoubleClick
        Try
            Dim frm As New frmOzvSalDoreEdit(dID, ListView1.SelectedItems(0).Tag)
            frm.ShowDialog(Me)
        Catch ex As Exception

        End Try
    End Sub
End Class