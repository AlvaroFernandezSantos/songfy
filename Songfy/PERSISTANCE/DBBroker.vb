Public Class DBBroker

    Private Shared _Instance As DBBroker
    Private Shared connection As OleDb.OleDbConnection
    Private Shared connectionString As String

    Private Sub New() 'Singleton
        DBBroker.connection = New OleDb.OleDbConnection(DBBroker.connectionString)
    End Sub

    Public Shared Function GetBroker() As DBBroker
        If DBBroker._Instance Is Nothing Then
            DBBroker._Instance = New DBBroker
        End If
        Return DBBroker._Instance
    End Function

    Public Shared Function GetBroker(path As String) As DBBroker
        DBBroker.connectionString = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" & path 'donde está la base de datos'
        DBBroker.connection = New OleDb.OleDbConnection(DBBroker.connectionString)
        Return DBBroker.GetBroker
    End Function

    Public Function Read(sql As String) As Collection
        Dim result As New Collection
        Dim row As Collection
        Dim i As Integer
        Dim reader As OleDb.OleDbDataReader
        Dim com As New OleDb.OleDbCommand(sql, DBBroker.connection)
        Connect()
        reader = com.ExecuteReader
        While reader.Read 'Si es verdadero es que hay valor, por lo que cuando sea falso se terminará 
            row = New Collection
            For i = 0 To reader.FieldCount - 1
                row.Add(reader(i).ToString)
            Next
            result.Add(row)
        End While
        Disconnect()
        Return result
    End Function

    Public Function Change(sql As String) As Integer
        Dim com As New OleDb.OleDbCommand(sql, DBBroker.connection) 'para aplicar el String sql 
        Dim result As Integer
        Connect()
        result = com.ExecuteNonQuery
        Disconnect()
        Return result
    End Function

    Private Sub Connect()
        If DBBroker.connection.State = ConnectionState.Closed Then
            DBBroker.connection.Open()
        End If
    End Sub

    Private Sub Disconnect()
        If DBBroker.connection.State = ConnectionState.Open Then
            DBBroker.connection.Close()
        End If
    End Sub

End Class