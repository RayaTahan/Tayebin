Public Class IMGcache
    Public Shared IMGs As New Dictionary(Of String, Image)

    Public Shared Function img(Address As String) As Image
        If Not IMGs.Keys.Contains(Address) Then
            Try
                Dim tmp = Image.FromFile(Address)
                IMGs.Add(Address, tmp)
                Return tmp
            Catch ex As Exception
                Return Nothing
            End Try
        Else
            Return IMGs(Address)
        End If
    End Function
End Class
