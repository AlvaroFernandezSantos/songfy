Public Class Album

    Public Property AlbumID As String

    Public Property Name As String

    Public Property releaseDate As Date

    Public Property artist As Artist

    Public Property cover As String

    Public ReadOnly Property AlDAO As AlbumDAO

    Public Sub New(id As String)
        Me.AlDAO = AlDAO
        Me.AlbumID = id
    End Sub

    Public Sub ReadAllAlbums(path As String)
        Me.AlDAO.ReadAll(path)
    End Sub

    Public Function InsertAlbum() As Integer
        Return Me.AlDAO.Insert(Me)
    End Function

    Public Function DeleteAlbum() As Integer
        Return Me.AlDAO.Delete(Me)
    End Function

    Public Function ReadAlbum() As Integer
        Return Me.AlDAO.ReadAll(Me)
    End Function
End Class
