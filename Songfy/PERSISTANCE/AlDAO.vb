Public Class AlbumDAO

    Public ReadOnly Property Albums As Collection

    Public Sub New()
        Me.Albums = New Collection
    End Sub

    Public Sub ReadAll(path As String)
        Dim a As Album
        Dim col, aux As Collection
        col = DBBroker.GetBroker(path).Read("SELECT * FROM Persons ORDER BY PersonID;")
        For Each aux In col
            a = New Album(aux(1).ToString)
            a.Name = aux(2).ToString
            a.releaseDate = aux(3).ToString
            a.artist = aux(4).ToString
            a.cover = aux(5).ToString 'Podría ser null, tener en cuenta

        Next
    End Sub

    Public Function Insert(ByVal a As Album) As Integer
        Return DBBroker.GetBroker.Change("STRING SQL Inserting")
    End Function

    Public Function Read(ByVal a As Album) As Integer
        Dim col As Collection : Dim aux As Collection
        col = DBBroker.GetBroker.Read("STRING SQL Reading ")
        For Each aux In col
            a.Name = aux(2).ToString 'Incluir numero entre parentesis
        Next
    End Function

    Public Function Delete(ByVal a As Album) As Integer
        Return DBBroker.GetBroker.Change("STRING SQL Deleting")
    End Function

    Public Function Update(ByVal a As Album) As Integer
        Return DBBroker.GetBroker.Change("STRING SQL Updating")
    End Function
End Class
