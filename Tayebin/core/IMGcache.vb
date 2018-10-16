Imports System.IO

Public Class IMGcache
    Public Shared IMGs As New Dictionary(Of String, Image)

    Public Shared Function img(Address As String) As Image
        If Not IMGs.Keys.Contains(Address) Then
            Try
                Dim xx As Image
                Using str As Stream = File.OpenRead(Address)
                    xx = Image.FromStream(str)
                End Using
                IMGs.Add(Address, xx)
                Return xx
            Catch ex As Exception
                Return Nothing
            End Try
        Else
            Return IMGs(Address)
        End If
    End Function

    Public Shared Sub Clear()
        IMGs.Clear()
    End Sub

    Public Shared Sub Remove(Address As String)
        IMGs.Remove(Address)
    End Sub
End Class
