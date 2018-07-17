Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'MsgBox(SQLget.RunCommandScaler("select count(*) from [Aza-Main]"))
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim CSFormat1 As String = "Data Source=(LocalDB)\v11.0;AttachDbFilename={0}\[DATA]\db.mdf;Integrated Security=True;Connect Timeout=10;Database=db;"
        Dim CSFormat2 As String = "Data Source=(LocalDB)\v11.0;AttachDbFilename={0}\data\database.mdf;Integrated Security=True;Connect Timeout=10;Database=database;"

        Dim AppGetPath As String = TextBox1.Text
        Dim AppSetPath As String = TextBox2.Text

        SQLget.SetConnectionString(String.Format(CSFormat1, AppGetPath))
        SQLset.SetConnectionString(String.Format(CSFormat2, AppSetPath))

        For Each rowAza As DataRow In SQLget.Fill("select * from [Aza-Main]").Rows

            Dim AlanTarikh As String = (New cTarikh).ToString
            Dim AlanSaat As String = (New cSaat).ToString


            Dim NewOzvID As Integer = SQLset.RunCommandScaler("insert into tOzv(Nam,Famil,Pedar,Tavalod,Vafat,Zende,CodeMelli,Tel,Mob,MobPedar,MobMadar,Tahsil,MahalTahsil,Shoql,MahalKar,ShoqlPedar,ShoqlMadar,Adres,Tozih,TarikhSabt,ZamanSabt,TarikhVirayesh,ZamanVirayesh,TedadVirayesh,AxID) values(@0,@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12,@13,@14,@15,@16,@17,@18,@19,@20,@21,@22,@23,-1) ; select scope_identity()", _
                               { _
    New SqlClient.SqlParameter("@0", rowAza.Item("Nam")), _
    New SqlClient.SqlParameter("@1", rowAza.Item("Famil")), _
    New SqlClient.SqlParameter("@2", rowAza.Item("Pedar")), _
    New SqlClient.SqlParameter("@3", rowAza.Item("Tavallod")), _
    New SqlClient.SqlParameter("@4", ""), _
    New SqlClient.SqlParameter("@5", "z"), _
    New SqlClient.SqlParameter("@6", rowAza.Item("Melli")), _
    New SqlClient.SqlParameter("@7", rowAza.Item("Tel")), _
    New SqlClient.SqlParameter("@8", rowAza.Item("Mob")), _
    New SqlClient.SqlParameter("@9", rowAza.Item("MobPedar")), _
    New SqlClient.SqlParameter("@10", rowAza.Item("MobMadar")), _
    New SqlClient.SqlParameter("@11", rowAza.Item("MizanTahsil")), _
    New SqlClient.SqlParameter("@12", rowAza.Item("MahalTahsil")), _
    New SqlClient.SqlParameter("@13", ""), _
    New SqlClient.SqlParameter("@14", ""), _
    New SqlClient.SqlParameter("@15", rowAza.Item("ShoqlPedar")), _
    New SqlClient.SqlParameter("@16", rowAza.Item("ShoqlMadar")), _
    New SqlClient.SqlParameter("@17", rowAza.Item("Adres")), _
    New SqlClient.SqlParameter("@18", "انتقالی از نسخه 1"), _
    New SqlClient.SqlParameter("@19", AlanTarikh), _
    New SqlClient.SqlParameter("@20", AlanSaat), _
    New SqlClient.SqlParameter("@21", ""), _
    New SqlClient.SqlParameter("@22", ""), _
    New SqlClient.SqlParameter("@23", 0) _
                               })

            For Each rowMadrak As DataRow In SQLget.Fill("select [Aza-ID],ID,[Madarek-No],FileName,FileFormat,FileSize from [Aza-Madarek] where [Aza-ID]=" & rowAza.Item("ID")).Rows

                Dim FileEXT As String
                Dim FileSize As Integer
                FileEXT = "." & rowMadrak.Item("FileFormat")
                FileSize = rowMadrak.Item("FileSize")

                Dim FileID As Integer = SQLset.RunCommandScaler("insert into tMadrak(IDOzv,IDNoMadrak,Onvan,FileEXT,FileSize,Tarikh,Zaman) values(@0,@1,@2,@3,@4,@5,@6) ; select scope_identity()", {New SqlClient.SqlParameter("@0", NewOzvID), New SqlClient.SqlParameter("@1", 1), New SqlClient.SqlParameter("@2", "انتقالی از نسخه 1"), New SqlClient.SqlParameter("@3", FileEXT), New SqlClient.SqlParameter("@4", FileSize), New SqlClient.SqlParameter("@5", AlanTarikh), New SqlClient.SqlParameter("@6", AlanSaat)})

                Dim oldFileAddress As String = AppGetPath & "\[DataFiles]\" & rowMadrak.Item("Aza-ID") & "\" & rowMadrak.Item("FileName")

                Try
                    Dim newFileAddress As String = String.Format("{0}\data\madarek\{1}\{1}-{2}{3}", AppSetPath, NewOzvID, FileID, FileEXT)

                    FileIO.FileSystem.CreateDirectory(newFileAddress.Substring(0, newFileAddress.LastIndexOf("\")))

                    FileIO.FileSystem.CopyFile(oldFileAddress, newFileAddress, showUI:=FileIO.UIOption.AllDialogs, onUserCancel:=FileIO.UICancelOption.ThrowException)

                Catch ex2 As Exception
                    MessageBox.Show(ex2.Message)
                End Try

            Next

        Next
        MsgBox("انجام شد")
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim resualt = OpenFileDialog1.ShowDialog()
        If resualt = DialogResult.OK Then
            Dim file As New IO.FileInfo(OpenFileDialog1.FileName)
            Dim cs As String = String.Format("Data Source=(LocalDB)\v11.0;AttachDbFilename={0}\data\database.mdf;Integrated Security=True;Connect Timeout=10;Database=database;", file.Directory)
            SQLget.SetConnectionString(cs)
            SQLget.RunCommand("ALTER TABLE tOzv ADD SalVorud nvarchar(4) NULL")
            MsgBox("انجام شد") ')cs)
        End If
    End Sub
End Class
