Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Public NotInheritable Class SQLget
    '"Data Source=(LocalDB)\v11.0;AttachDbFilename=G:\Kanoon\Tayebin2\Tayebbin1-BackUp-13950324\Debug\[DATA]\db.mdf;Integrated Security=True;Connect Timeout=30"
    Private Shared SQ As New SqlConnection("")
    'Private Shared SQ As SqlConnection
    Private Shared Cmd As New SqlCommand("", SQ)
    Private Shared DA As New SqlDataAdapter("", SQ)

    Public Shared Sub SetConnectionString(strCS As String)
        SQ.ConnectionString = strCS
    End Sub

    Public Shared Function RunCommand(ByVal CommandText As String) As Integer
        Dim tmp As Integer
        If SQ.State <> ConnectionState.Open Then SQ.Open()
        Cmd.CommandText = CommandText
        tmp = Cmd.ExecuteNonQuery()
        SQ.Close()
        Return tmp
    End Function

    Public Shared Function RunCommand(ByVal CommandText As String, ByVal Parametrs() As SqlParameter) As Integer
        Dim tmp As Integer
        If SQ.State <> ConnectionState.Open Then SQ.Open()
        Cmd = SQ.CreateCommand
        Cmd.Parameters.Clear()
        Cmd.CommandText = CommandText
        Cmd.Parameters.AddRange(Parametrs)

        tmp = Cmd.ExecuteNonQuery()
        SQ.Close()
        Return tmp
    End Function

    Public Shared Function RunCommandScaler(ByVal CommandText As String) As String
        Dim tmp As String
        If SQ.State <> ConnectionState.Open Then SQ.Open()
        Cmd.CommandText = CommandText
        tmp = ""

        Try
            tmp = Cmd.ExecuteScalar().ToString
        Catch ex As Exception
            tmp = ""
        End Try

        SQ.Close()
        Return tmp
    End Function

    Public Shared Function RunCommandScaler(ByVal CommandText As String, ByVal Parametrs() As SqlParameter) As String
        Dim tmp As String
        If SQ.State <> ConnectionState.Open Then SQ.Open()
        Cmd = SQ.CreateCommand
        Cmd.Parameters.Clear()
        Cmd.CommandText = CommandText
        Cmd.Parameters.AddRange(Parametrs)

        Try
            tmp = Cmd.ExecuteScalar().ToString
        Catch ex As Exception
            tmp = ""
        End Try

        SQ.Close()
        Return tmp
    End Function

    Public Shared Function Fill(CommandText As String) As DataTable
        Dim tmp As New DataTable
        DA.SelectCommand.CommandText = CommandText
        DA.Fill(tmp)
        Return tmp
    End Function

    Public Shared Function Fill(CommandText As String, ByVal Parametrs() As SqlParameter) As DataTable
        Dim tmp As New DataTable
        DA.SelectCommand = SQ.CreateCommand
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

    Public Shared Sub Fill(ByRef DataSet As DataSet, ByVal TableName As String, ByVal CommandText As String, ByVal Parametrs() As SqlParameter)
        DA.SelectCommand = SQ.CreateCommand
        DA.SelectCommand.CommandText = CommandText
        DA.SelectCommand.Parameters.Clear()
        DA.SelectCommand.Parameters.AddRange(Parametrs)
        If DataSet.Tables.Contains(TableName) Then
            DataSet.Tables.Remove(TableName)
        End If
        DA.Fill(DataSet, TableName)
    End Sub

    Public Shared Function useStoredProcedure(ByVal Name As String, ByVal Parametrs() As SqlParameter, Optional ByVal Out As String = "") As String
        Dim ret As String
        Cmd.CommandText = Name
        Cmd.CommandType = CommandType.StoredProcedure
        Cmd.Parameters.AddRange(Parametrs)
        If SQ.State <> ConnectionState.Open Then SQ.Open()
        Cmd.ExecuteNonQuery()
        SQ.Close()
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
