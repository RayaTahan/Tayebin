Public Class cOstan
    Public Property ID As Integer
    Public Property Name As String
    Public Property Cities() As cShahr()
    Sub New(ID As Integer, name As String, cities() As cShahr)
        Me.ID = ID
        Me.Name = name
        Me.Cities = cities
    End Sub
End Class
