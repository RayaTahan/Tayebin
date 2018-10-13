Imports RestSharp

Public Class AppMan
    Public Shared VersionInt As Integer = Val(AppVer.Replace(".", "").Replace(",", ""))

    Public Shared ReadOnly Property dbVer As Integer
        Get
            Try
                Dim dbCurrentVer As Integer = 0
                Integer.TryParse(SQLiter.RunCommandScaler("select Meqdar from tTanzimat where Onvan like 'dbVer'"), dbCurrentVer)
                Return dbCurrentVer
            Catch ex As Exception
                Return 0
            End Try
        End Get
    End Property

    Private Shared _ConnectionString As String = String.Format("Data Source={0}\data\db.sqlite;Version=3;", Application.StartupPath)
    Public Shared ReadOnly Property ConnectionString As String
        Get
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
        Dim cmdIns As String = "insert into tTanzimat(Onvan,Meqdar) values('{0}','{1}')"
        Dim cmdUpd As String = "update tTanzimat set Meqdar='{1}' where Onvan like '{0}'"

        Try
            Dim dbCurrentVer As Integer = dbVer

            If dbVer = 0 Then
                SQLiter.CreateFile("db.sqlite")

                SQLiter.RunCommand("create table IF NOT EXISTS tDore(ID INTEGER PRIMARY KEY AUTOINCREMENT, Onvan text)")
                SQLiter.RunCommand("insert into tDore(ID,Onvan) values(1,'تقسیم نشده')")

                SQLiter.RunCommand("create table IF NOT EXISTS tKarbari(u text PRIMARY KEY, p text)")

                SQLiter.RunCommand("create table IF NOT EXISTS tKarname(ID INTEGER PRIMARY KEY AUTOINCREMENT, IDOzvSalDore int, IDRizKarname int, Meqdar int)")
                SQLiter.RunCommand("insert into tKarbari(u,p) values('1','1')")

                SQLiter.RunCommand("create table IF NOT EXISTS tMadrak(ID INTEGER PRIMARY KEY AUTOINCREMENT, IDOzv int, IDNoMadrak int, Onvan text, FileEXT text, FileSize int, Tarikh text, Zaman text)")

                SQLiter.RunCommand("create table IF NOT EXISTS tMorabbi(ID INTEGER PRIMARY KEY AUTOINCREMENT, Onvan text)")

                SQLiter.RunCommand("create table IF NOT EXISTS tNoMadrak(ID INTEGER PRIMARY KEY AUTOINCREMENT, Onvan text)")
                SQLiter.RunCommand("insert into tNoMadrak(ID,Onvan) values(1,'عکس پرسنلی')")

                SQLiter.RunCommand("create table IF NOT EXISTS tOzv(ID INTEGER PRIMARY KEY AUTOINCREMENT, Nam text, Famil text, Pedar text, Tavalod text, Vafat text, Zende text, CodeMelli text, Tel text, Mob text, MobPedar text, MobMadar text, Tahsil text, MahalTahsil text, Shoql text, MahalKar text, ShoqlPedar text, ShoqlMadar text, Adres text, Tozih text, TarikhSabt text, ZamanSabt text, TarikhVirayesh text, ZamanVirayesh text, TedadVirayesh int, AxID int, SalVorud text)")

                SQLiter.RunCommand("create table IF NOT EXISTS tOzvSalDore(ID INTEGER PRIMARY KEY AUTOINCREMENT, IDOzv int, IDSalDore int, TarikhSabt text, ZamanSabt text)")

                SQLiter.RunCommand("create table IF NOT EXISTS tRizKarname(ID INTEGER PRIMARY KEY AUTOINCREMENT, Onvan text)")

                SQLiter.RunCommand("create table IF NOT EXISTS tSal(ID INTEGER PRIMARY KEY AUTOINCREMENT, Onvan text, TarikhShoru text)")

                SQLiter.RunCommand("create table IF NOT EXISTS tSalDore(ID INTEGER PRIMARY KEY AUTOINCREMENT, IDSal int, IDDore int, IDMorabbi int)")

                SQLiter.RunCommand("create table IF NOT EXISTS tTanzimat(Onvan text PRIMARY KEY, Meqdar text NOT NULL)")
                SQLiter.RunCommand(String.Format(cmdIns, "KanunNam", "نام مجموعه"))

                SQLiter.RunCommand("CREATE VIEW IF NOT EXISTS vKarname AS SELECT tKarname.* , tRizKarname.Onvan as RizKarnameOnvan FROM tKarname , tRizKarname where tKarname.IDRizKarname=tRizKarname.ID")
                SQLiter.RunCommand("CREATE VIEW IF NOT EXISTS vMadrak AS SELECT tNoMadrak.Onvan as NoMadrakOnvan , tMadrak.ID , tMadrak.IDNoMadrak , tMadrak.Onvan ,tMadrak.Tarikh , tMadrak.IDOzv , tMadrak.FileEXT   FROM tMadrak , tNoMadrak where tMadrak.IDNoMadrak=tNoMadrak.ID")
                SQLiter.RunCommand("CREATE VIEW IF NOT EXISTS vSalDore 	AS SELECT tSal.ID as SalID, tSal.Onvan as SalOnvan,	 tDore.ID as DoreID, tDore.Onvan as DoreOnvan, tMorabbi.ID as MorabbiID, tMorabbi.Onvan as MorabbiOnvan, tSalDore.ID as SalDoreID FROM tSalDore, tSal, tDore, tMorabbi where tSalDore.IDDore=tDore.ID and tSalDore.IDMorabbi=tMorabbi.ID and tSalDore.IDSal=tSal.ID")
                SQLiter.RunCommand("CREATE VIEW IF NOT EXISTS vOzvSalDore AS SELECT tOzvSalDore.* , vSalDore.* FROM tOzvSalDore, vSalDore where tOzvSalDore.IDSalDore=vSalDore.SalDoreID")

                SQLiter.RunCommand(String.Format(cmdIns, "dbVer", "1"))
            End If

            If dbVer = 1 Then
                Tanzimat("uniqueAppID") = ""
                Tanzimat("dbVer") = 24
            End If

            If dbVer = 24 Then
                Tanzimat("uniqueAppID") = ""
                Tanzimat("dbVer") = 25
            End If

            If dbVer = 25 Then
                SQLiter.RunCommand("create table IF NOT EXISTS tSentSMS(ID INTEGER PRIMARY KEY AUTOINCREMENT, User int, TT text, SS text, Matn text, Girandegan int)")

                Tanzimat("dbVer") = 26
            End If

            If dbVer = 26 Then
                SQLiter.RunCommand("drop view IF EXISTS vSalDore")
                SQLiter.RunCommand("CREATE VIEW IF NOT EXISTS vSalDore AS SELECT tSal.ID as SalID, tSal.Onvan as SalOnvan, tDore.ID as DoreID, tDore.Onvan as DoreOnvan, tMorabbi.ID as MorabbiID, tMorabbi.Onvan as MorabbiOnvan, tSalDore.ID as SalDoreID FROM tSalDore, tSal, tDore, tMorabbi where tSalDore.IDDore=tDore.ID and tSalDore.IDMorabbi=tMorabbi.ID and tSalDore.IDSal=tSal.ID order by tSal.TarikhShoru desc")

                Tanzimat("dbVer") = 27
            End If

            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        End Try
    End Function

    Public Shared Property Tanzimat(key As String) As String
        Get
            Return SQLiter.RunCommandScaler(String.Format("select Meqdar from tTanzimat where Onvan like '{0}'", key))
        End Get
        Set(value As String)
            Dim cmdUpd As String = "update tTanzimat set Meqdar='{1}' where Onvan like '{0}'"
            Dim cmdInst As String = "insert into tTanzimat(Onvan,Meqdar) values('{0}','{1}')"
            If SQLiter.RunCommand(String.Format(cmdUpd, key, value)) = 0 Then
                SQLiter.RunCommand(String.Format(cmdInst, key, value))
            End If
        End Set
    End Property

    Public Shared Icon As Icon = CType((New System.Resources.ResourceManager(GetType(frmMain))).GetObject("$this.Icon"), System.Drawing.Icon)


    Public Shared Sub UpdateChecker()
        Dim URL As String = "https://api.rayatahan.ir/tayebin/ver"

        Dim client = New RestClient(URL)
        Dim request = New RestRequest(Method.GET)
        request.AddParameter("iv", VersionInt)

        client.ExecuteAsync(request, Sub(res)
                                         If res.IsSuccessful AndAlso Not IsNothing(res.Content) Then
                                             Dim obj = Newtonsoft.Json.JsonConvert.DeserializeObject(res.Content)
                                             If obj("LastVer") > VersionInt Then
                                                 Dim msg As String = ""
                                                 msg += String.Format("نسخه جدید: {0}", obj("LastVer"))
                                                 msg += vbCrLf & String.Format("تاریخ انتشار: {0}", obj("LastVerTarikh"))
                                                 msg += vbCrLf

                                                 Dim ptrn As String = "    {0} : {1}"
                                                 Dim type = {"", "افزودن ویژگی", "حذف ویژگی", "رفع خطا"}

                                                 For Each row In obj("Data")
                                                     msg += vbCrLf & String.Format(ptrn, type(row("Type")), row("Tozih"))
                                                 Next

                                                 msg += vbCrLf
                                                 msg += vbCrLf & "جهت ورود به صفحه دانلود Yes را بزنید."

                                                 If MessageBox.Show(text:=msg, caption:="نسخه جدید طیبین منتشر شد", buttons:=MessageBoxButtons.YesNo, icon:=MessageBoxIcon.Information, defaultButton:=MessageBoxDefaultButton.Button1, options:=MessageBoxOptions.RtlReading + MessageBoxOptions.RightAlign, displayHelpButton:=False) = DialogResult.Yes Then
                                                     Process.Start("https://github.com/RayaTahan/Tayebin/releases/latest")
                                                 End If
                                             End If
                                         End If
                                     End Sub)



    End Sub

    Public Shared Sub Start()
        If Not isDbUpToDate() Then
            If UpDateDb() Then
                MessageBox.Show("پایگاه داده نرم افزار با موفقیت بروزرسانی شد!")
            Else
                MessageBox.Show("عملیات بروزرسانی نرم افزار با خطا مواجه شد!")
            End If
        End If

        UpdateChecker()
        sendStart()

    End Sub

    Public Shared Sub sendStart()
        Dim URL As String = "https://api.rayatahan.ir/tayebin/start"

        Dim client = New RestClient(URL)
        Dim request = New RestRequest(Method.POST)
        Dim uniqueAppID = AppMan.Tanzimat("uniqueAppID")
        request.AddParameter("uniqueAppID", uniqueAppID)
        request.AddParameter("InstalledVersion", VersionInt)

        request.AddParameter("PCName", My.Computer.Name)
        request.AddParameter("InstallDrive", FileIO.FileSystem.GetDriveInfo(Application.ExecutablePath).Name)
        request.AddParameter("OSFullName", My.Computer.Info.OSFullName)
        request.AddParameter("OSPlatform", My.Computer.Info.OSPlatform)
        request.AddParameter("OSVersion", My.Computer.Info.OSVersion)
        request.AddParameter("Screen", String.Format("{0}x{1}", My.Computer.Screen.Bounds.Width, My.Computer.Screen.Bounds.Height))

        request.AddParameter("KanunNam", AppMan.Tanzimat("KanunNam"))
        request.AddParameter("KanunTel", AppMan.Tanzimat("KanunTel"))
        request.AddParameter("KanunOstanID", AppMan.Tanzimat("KanunOstanID"))
        request.AddParameter("KanunShahrID", AppMan.Tanzimat("KanunShahrID"))
        request.AddParameter("KarbarNam", AppMan.Tanzimat("KarbarNam"))
        request.AddParameter("KarbarMob", AppMan.Tanzimat("KarbarMob"))


        client.ExecuteAsync(request, Sub(res)
                                         If res.IsSuccessful AndAlso Not IsNothing(res.Content) Then
                                             Dim obj = Newtonsoft.Json.JsonConvert.DeserializeObject(res.Content)
                                             If uniqueAppID = "" Then
                                                 If obj("status") = 1 Then
                                                     AppMan.Tanzimat("uniqueAppID") = obj("uniqueAppID")
                                                 End If
                                             End If
                                         End If
                                     End Sub)


    End Sub
End Class
