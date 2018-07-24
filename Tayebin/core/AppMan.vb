Public Class AppMan
    Public Shared VersionInt As Integer = 2
    Public Shared VersionName As String = "آزمایشی - 2.2"

    Public Shared ReadOnly Property dbVer As Integer
        Get
            Try
                Dim dbCurrentVer As Integer = 0
                Integer.TryParse(SQL.RunCommandScaler("select Meqdar from tTanzimat where Onvan like N'dbVer'"), dbCurrentVer)
                Return dbCurrentVer
            Catch ex As Exception
                Return 0
            End Try
        End Get
    End Property

    Private Shared _ConnectionString As String
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

            If dbCurrentVer < 1 Then
                SQL.RunCommand("CREATE TABLE tTanzimat (Onvan NVARCHAR (50) NOT NULL, Meqdar NVARCHAR (500) NOT NULL, PRIMARY KEY CLUSTERED (Onvan ASC));")
                SQL.RunCommand(String.Format(cmdIns, "dbVer", "1"))
                SQL.RunCommand(String.Format(cmdIns, "KanunNam", "نام کانون"))

                SQL.RunCommand("CREATE TABLE tKarbari (u NVARCHAR (50) NOT NULL, p NVARCHAR (50) NOT NULL, PRIMARY KEY CLUSTERED (u ASC));")
                SQL.RunCommand("insert into tKarbari(u,p) values('1','1')")

            End If

            If dbCurrentVer < 2 Then
                SQL.RunCommand(String.Format(cmdUpd, "dbVer", "2"))
            End If

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Enum TanzimatOnvan
        dbVer
        KanunNam
    End Enum

    Public Shared Function TanzimGet(Onvan As String)
        Try
            Return SQL.RunCommandScaler(String.Format("select Meqdar from tTanzimat where Onvan like N'{0}'", Onvan))
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Shared Sub TanzimatSet(Onvan As String, Meqdar As String)
        Try
            Dim cmdUpd As String = "update tTanzimat set Meqdar=N'{1}' where Onvan like N'{0}'"
            SQL.RunCommand(String.Format(cmdUpd, Onvan, Meqdar))
        Catch ex As Exception

        End Try
    End Sub

    Public Shared Icon As Icon = CType((New System.Resources.ResourceManager(GetType(frmMain))).GetObject("$this.Icon"), System.Drawing.Icon)
End Class
