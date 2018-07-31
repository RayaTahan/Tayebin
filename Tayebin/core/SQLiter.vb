Imports System.Data.SQLite

Public NotInheritable Class SQLiter
    Private Shared con As New SQLiteConnection(AppMan.ConnectionString, True)
    Private Shared Cmd As New SQLiteCommand("", con)
    Private Shared DA As New SQLiteDataAdapter("", con)

    Public Shared Sub CreateFile(Name As String)
        SQLiteConnection.CreateFile("data/" & Name)
    End Sub

    Public Shared Function RunCommand(ByVal CommandText As String) As Integer
        Dim tmp As Integer
        If con.State <> ConnectionState.Open Then con.Open()
        Cmd.CommandText = CommandText
        tmp = Cmd.ExecuteNonQuery()
        con.Close()
        Return tmp
    End Function

    Public Shared Function RunCommand(ByVal CommandText As String, ByVal Parametrs() As SQLiteParameter) As Integer
        Dim tmp As Integer
        If con.State <> ConnectionState.Open Then con.Open()
        Cmd = con.CreateCommand
        Cmd.Parameters.Clear()
        Cmd.CommandText = CommandText
        Cmd.Parameters.AddRange(Parametrs)

        tmp = Cmd.ExecuteNonQuery()
        con.Close()
        Return tmp
    End Function

    Public Shared Function RunCommandScaler(ByVal CommandText As String) As String
        Dim tmp As String
        If con.State <> ConnectionState.Open Then con.Open()
        Cmd.CommandText = CommandText
        tmp = ""

        Try
            tmp = Cmd.ExecuteScalar().ToString
        Catch ex As Exception
            tmp = ""
        End Try

        con.Close()
        Return tmp
    End Function

    Public Shared Function RunCommandScaler(ByVal CommandText As String, ByVal Parametrs() As SQLiteParameter) As String
        Dim tmp As String
        Try
            con.Close()
        Catch ex As Exception

        End Try
        If con.State <> ConnectionState.Open Then con.Open()
        Cmd = con.CreateCommand
        Cmd.Parameters.Clear()
        Cmd.CommandText = CommandText
        Cmd.Parameters.AddRange(Parametrs)

        Try
            tmp = Cmd.ExecuteScalar().ToString
        Catch ex As Exception
            tmp = ""
        End Try

        con.Close()
        Return tmp
    End Function

    Public Shared Function Fill(CommandText As String) As DataTable
        Dim tmp As New DataTable
        DA.SelectCommand.CommandText = CommandText
        DA.Fill(tmp)
        Return tmp
    End Function

    Public Shared Function Fill(CommandText As String, ByVal Parametrs() As SQLiteParameter) As DataTable
        Dim tmp As New DataTable
        DA.SelectCommand = con.CreateCommand
        DA.SelectCommand.CommandText = CommandText
        DA.SelectCommand.Parameters.Clear()
        DA.SelectCommand.Parameters.AddRange(Parametrs)
        DA.Fill(tmp)
        Return tmp
    End Function

    Public Shared Sub Fill(ByRef DataSet As DataSet, ByVal TableName As String, ByVal CommandText As String)
        DA.SelectCommand.CommandText = CommandText
        If DataSet.Tables.Contains(TableName) Then
            DataSet.Tables.Remove(TableName)
        End If
        DA.Fill(DataSet, TableName)
    End Sub

    Public Shared Sub Fill(ByRef DataSet As DataSet, ByVal TableName As String, ByVal CommandText As String, ByVal Parametrs() As SQLiteParameter)
        DA.SelectCommand = con.CreateCommand
        DA.SelectCommand.CommandText = CommandText
        DA.SelectCommand.Parameters.Clear()
        DA.SelectCommand.Parameters.AddRange(Parametrs)
        If DataSet.Tables.Contains(TableName) Then
            DataSet.Tables.Remove(TableName)
        End If
        DA.Fill(DataSet, TableName)
    End Sub

    Public Shared Function useStoredProcedure(ByVal Name As String, ByVal Parametrs() As SQLiteParameter, Optional ByVal Out As String = "") As String
        Dim ret As String
        Cmd.CommandText = Name
        Cmd.CommandType = CommandType.StoredProcedure
        Cmd.Parameters.AddRange(Parametrs)
        If con.State <> ConnectionState.Open Then con.Open()
        Cmd.ExecuteNonQuery()
        con.Close()
        If Out = "" Then
            ret = ""
        Else
            Try
                ret = Cmd.Parameters(Out).Value.ToString
            Catch ex As Exception
                ret = ""
            End Try
        End If

        Return ret
    End Function

End Class
