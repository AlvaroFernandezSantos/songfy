Public Class Artist

    Public Property IDArtist As Integer
    Public Property aName As String
    Public Property country As String
    Public Property image As String
    Public ReadOnly Property ArtDAO As ArtistDAO

    Public Sub New()
        Me.ArtDAO = New ArtistDAO
    End Sub

    Public Sub New(id As Integer)
        Me.ArtDAO = New ArtistDAO
        Me.IDArtist = id
    End Sub

    Public Sub ReadAllArtists(path As String)
        Me.ArtDAO.ReadAll(path)
    End Sub

    Public Sub ReadArtist()
        Me.ArtDAO.Read(Me)
    End Sub

    Public Function InsertArtist() As Integer
        Return Me.ArtDAO.Insert(Me)
    End Function

    Public Function UpdateArtist() As Integer
        Return Me.ArtDAO.Update(Me)
    End Function

    Public Function DeleteArtist() As Integer
        Return Me.ArtDAO.Delete(Me)
    End Function

End Class
