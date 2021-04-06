Public Class ArtistDAO

    Public ReadOnly Property Artists As Collection

    Public Sub New()
        Me.Artists = New Collection
    End Sub

    Public Sub ReadAll(path As String)
        Dim a As Artist
        Dim col, aux As Collection
        col = DBBroker.GetBroker(path).Read("SELECT * FROM Artists ORDER BY IDArtist")
        For Each aux In col
            a = New Artist(aux(1).ToString)
            a.aName = aux(2).ToString
            Me.Artists.Add(a)
        Next
    End Sub

    Public Sub Read(ByRef a As Artist)
        Dim col As Collection : Dim aux As Collection
        col = DBBroker.GetBroker.Read("SELECT * FROM Artists WHERE IDArtist='" & a.IDArtist & "';")
        For Each aux In col
            a.aName = aux(2).ToString
            a.country = aux(3).ToString
            a.image = aux(4).ToString
        Next
    End Sub

    Public Function Insert(ByVal a As Artist) As Integer
        Return DBBroker.GetBroker.Change("INSERT INTO Artists VALUES ('" & a.IDArtist & "', '" & a.aName & "');")
    End Function

    Public Function Update(ByVal a As Artist) As Integer
        Return DBBroker.GetBroker.Change("UPDATE Artists SET aName='" & a.aName & "' WHERE IDArtist='" & a.IDArtist & "';")
    End Function

    Public Function Delete(ByVal a As Artist) As Integer
        Return DBBroker.GetBroker.Change("DELETE FROM Artists WHERE IDArtist='" & a.IDArtist & "';")
    End Function

End Class
