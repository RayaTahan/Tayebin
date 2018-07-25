Imports System.Data.SQLite

Public Class frmMadrak

    Dim dID As Integer
    Dim OzvID As Integer
    Dim data As DataTable

    Sub New(Ozv As Integer, Optional ID As Integer = -1)
        InitializeComponent()

        dID = ID
        OzvID = Ozv
    End Sub

    Private Sub frmMadrak_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'fun.ChangeFont(Me, My.MySettings.Default.Context.Item("Font"))

        Try
            ComboBox1.ValueMember = "ID"
            ComboBox1.DisplayMember = "Onvan"
            ComboBox1.DataSource = SQLiter.Fill("select ID,Onvan from tNoMadrak")
            ComboBox1.SelectedItem = Nothing

            If dID = -1 Then
                ComboBox1.SelectedItem = ComboBox1.Items(0)
                TextBox1.Text = "[جدید]"
                UcTextBox1.Text = "[با جفت کلیک انتخاب]"
                UcTextBox1.Tag = ""
            Else
                data = SQLiter.Fill("select * from tMadrak where ID=" & dID)
                ComboBox1.SelectedValue = data(0).Item("IDNoMadrak")
                UcTextBox1.Text = "[امکان تغییر فایل وجو ندارد]"
                TextBox2.Text = data(0).Item("Onvan")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If dID = -1 Then
                Dim FileEXT As String = ""
                Dim FileSize As Integer
                If UcTextBox1.Tag <> "" Then
                    Dim tFile = FileIO.FileSystem.GetFileInfo(UcTextBox1.Tag)
                    FileEXT = tFile.Extension
                    FileSize = tFile.Length

                    dID = SQLiter.RunCommandScaler("insert into tMadrak(IDOzv,IDNoMadrak,Onvan,FileEXT,FileSize,Tarikh,Zaman) values(@0,@1,@2,@3,@4,@5,@6) ; select last_insert_rowid()", {New SQLiteParameter("@0", OzvID), New SQLiteParameter("@1", ComboBox1.SelectedValue), New SQLiteParameter("@2", TextBox2.Text.Trim), New SQLiteParameter("@3", FileEXT), New SQLiteParameter("@4", FileSize), New SQLiteParameter("@5", (New cTarikh).ToString), New SQLiteParameter("@6", (New cSaat).ToString)})

                    Try
                        Dim newFileAddress As String = String.Format("{0}\data\madarek\{1}\{1}-{2}{3}", Application.StartupPath, OzvID, dID, FileEXT)

                        FileIO.FileSystem.CreateDirectory(newFileAddress.Substring(0, newFileAddress.LastIndexOf("\")))

                        FileIO.FileSystem.CopyFile(UcTextBox1.Tag, newFileAddress, showUI:=FileIO.UIOption.AllDialogs, onUserCancel:=FileIO.UICancelOption.ThrowException)

                        MessageBox.Show("اطلاعات با موفقیت ذخیره شد")

                        Dim ownr As frmOzvView = Me.Owner
                        ownr.ReloadData()
                        Me.Close()
                    Catch ex2 As Exception
                        MessageBox.Show(ex2.Message)
                    End Try
                Else
                    MessageBox.Show("لطفا فایل مورد نظر را انتخاب کنید")
                End If
            Else
                SQLiter.RunCommand("update tMadrak set IDNoMadrak=@0 ,Onvan=@1 where ID=@2", {New SQLiteParameter("@0", ComboBox1.SelectedValue), New SQLiteParameter("@1", TextBox2.Text.Trim), New SQLiteParameter("@2", dID)})

                MessageBox.Show("اطلاعات با موفقیت ذخیره شد")

                Dim ownr As frmOzvView = Me.Owner
                ownr.ReloadData()
                Me.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub OpenFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        If OpenFileDialog1.FileName IsNot Nothing Then
            UcTextBox1.Tag = OpenFileDialog1.FileName
            UcTextBox1.Text = OpenFileDialog1.SafeFileName
        End If
    End Sub

    Private Sub UcTextBox1_DoubleClick(sender As Object, e As EventArgs) Handles UcTextBox1.DoubleClick
        If dID = -1 Then
            OpenFileDialog1.ShowDialog(Me)
        End If
    End Sub
End Class