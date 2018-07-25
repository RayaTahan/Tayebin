Public Class AppMan
    Public Shared VersionInt As Integer = 1

    Public Shared ReadOnly Property dbVer As Integer
        Get
            Try
                Dim dbCurrentVer As Integer = 0
                Integer.TryParse(SQLiter.RunCommandScaler("select Meqdar from tTanzimat where Onvan like N'dbVer'"), dbCurrentVer)
                Return dbCurrentVer
            Catch ex As Exception
                Return 0
            End Try
        End Get
    End Property

    Private Shared _ConnectionString As String = "Data Source=db.sqlite;Version=3;"
    Public Shared ReadOnly Property ConnectionString As String
        Get
            If _ConnectionString = "" Then
                _ConnectionString = IO.File.ReadAllText(Application.StartupPath & "\data\ConnectionString.txt")
            End If
            Return _ConnectionString
        End Get
    End Property

    Public Shared ReadOnly Property AppVer As String
        Get
            Return Application.ProductVersion
        End Get
    End Property

    Public Shared ReadOnly Property AppName As String
        Get
            Return Application.ProductName
        End Get
    End Property

    Public Shared ReadOnly Property AppURL As String
        Get
            Return "http://Tayebin.blog.ir"
        End Get
    End Property

    Public Shared Function isDbUpToDate() As Boolean
        Try
            Dim dbCurrentVer As Integer = dbVer

            If dbCurrentVer < VersionInt Then
                Return False
            End If

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function UpDateDb() As Boolean
        Dim cmdIns As String = "insert into tTanzimat(Onvan,Meqdar) values(N'{0}',N'{1}')"
        Dim cmdUpd As String = "update tTanzimat set Meqdar=N'{1}' where Onvan like N'{0}'"

        Try
            Dim dbCurrentVer As Integer = dbVer

            If dbVer = 0 Then
                SQLiter.CreateFile("db.sqlite")

                SQLiter.RunCommand("create table IF NOT EXISTS tDore(ID INTEGER PRIMARY KEY, Onvan text)")
                SQLiter.RunCommand("insert into tDore(ID,Onvan) values(1,'تقسیم نشده')")

                SQLiter.RunCommand("create table IF NOT EXISTS tKarbari(u NOT NULL text PRIMARY KEY, p text)")

                SQLiter.RunCommand("create table IF NOT EXISTS tKarname(ID INTEGER PRIMARY KEY, IDOzvSalDore int, IDRizKarname int, Meqdar int)")
                SQLiter.RunCommand("insert into tKarbari(u,p) values('1','1')")

                SQLiter.RunCommand("create table IF NOT EXISTS tMadrak(ID INTEGER PRIMARY KEY, IDOzv int, IDNoMadrak int, Onvan text, FileEXT text, FileSize int, Tarikh text, Zaman text)")

                SQLiter.RunCommand("create table IF NOT EXISTS tMorabbi(ID INTEGER PRIMARY KEY, Onvan text)")

                SQLiter.RunCommand("create table IF NOT EXISTS tNoMadrak(ID INTEGER PRIMARY KEY, Onvan text)")
                SQLiter.RunCommand("insert into tNoMadrak(ID,Onvan) values(1,'عکس پرسنلی')")

                SQLiter.RunCommand("create table IF NOT EXISTS tOzv(ID INTEGER PRIMARY KEY, Nam text, Famil text, Pedar text, Tavalod text, Vafat text, Zende text, CodeMelli text, Tel text, Mob text, MobPedar text, MobMadar text, Tahsil text, MahalTahsil text, Shoql text, MahalKar text, ShoqlPedar text, ShoqlMadar text, Adres text, Tozih text, TarikhSabt text, ZamanSabt text, TarikhVirayesh text, ZamanVirayesh text, TedadVirayesh int, AxID int, SalVorud text)")

                SQLiter.RunCommand("create table IF NOT EXISTS tOzvSalDore(ID INTEGER PRIMARY KEY, IDOzv int, IDSalDore int, TarikhSabt text, ZamanSabt text)")

                SQLiter.RunCommand("create table IF NOT EXISTS tRizKarname(ID INTEGER PRIMARY KEY, Onvan text)")

                SQLiter.RunCommand("create table IF NOT EXISTS tSal(ID INTEGER PRIMARY KEY, Onvan text, TarikhShoru text)")

                SQLiter.RunCommand("create table IF NOT EXISTS tSalDore(ID INTEGER PRIMARY KEY, IDSal int, IDDore int, IDMorabbi int)")

                SQLiter.RunCommand("create table IF NOT EXISTS tTanzimat(Onvan NOT NULL text PRIMARY KEY, Meqdar NOT NULL text)")
                SQLiter.RunCommand(String.Format(cmdIns, "KanunNam", "نام کانون"))
                SQLiter.RunCommand(String.Format(cmdIns, "dbVer", "1"))

                SQLiter.RunCommand("CREATE VIEW IF NOT EXISTS vKarname AS SELECT tKarname.* , tRizKarname.Onvan as RizKarnameOnvan FROM tKarname , tRizKarname where tKarname.IDRizKarname=tRizKarname.ID")
                SQLiter.RunCommand("CREATE VIEW IF NOT EXISTS vMadrak AS SELECT tNoMadrak.Onvan as NoMadrakOnvan , tMadrak.ID , tMadrak.IDNoMadrak , tMadrak.Onvan ,tMadrak.Tarikh , tMadrak.IDOzv , tMadrak.FileEXT   FROM tMadrak , tNoMadrak where tMadrak.IDNoMadrak=tNoMadrak.ID")
                SQLiter.RunCommand("CREATE VIEW IF NOT EXISTS vSalDore 	AS SELECT tSal.ID as SalID, tSal.Onvan as SalOnvan,	 tDore.ID as DoreID, tDore.Onvan as DoreOnvan, tMorabbi.ID as MorabbiID, tMorabbi.Onvan as MorabbiOnvan, tSalDore.ID as SalDoreID FROM tSalDore, tSal, tDore, tMorabbi where tSalDore.IDDore=tDore.ID and tSalDore.IDMorabbi=tMorabbi.ID and tSalDore.IDSal=tSal.ID")
                SQLiter.RunCommand("CREATE VIEW IF NOT EXISTS vOzvSalDore AS SELECT tOzvSalDore.* , vSalDore.* FROM tOzvSalDore, vSalDore where tOzvSalDore.IDSalDore=vSalDore.SalDoreID")
            End If

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function TanzimGet(Onvan As String)
        Try
            Return SQLiter.RunCommandScaler(String.Format("select Meqdar from tTanzimat where Onvan like N'{0}'", Onvan))
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Shared Sub TanzimatSet(Onvan As String, Meqdar As String)
        Try
            Dim cmdUpd As String = "update tTanzimat set Meqdar=N'{1}' where Onvan like N'{0}'"
            SQLiter.RunCommand(String.Format(cmdUpd, Onvan, Meqdar))
        Catch ex As Exception

        End Try
    End Sub

    Public Shared Icon As Icon = CType((New System.Resources.ResourceManager(GetType(frmMain))).GetObject("$this.Icon"), System.Drawing.Icon)
End Class
