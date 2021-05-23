
Imports TWSClassLibrary
Imports TWSClassLibrary.ConfigurationManagement
Imports TWSClassLibrary.DatabaseManagement.TWSClassDatabaseManagement
Public MustInherit Class MClassTerminalsManagement

    Public Shared Sub DeleteSyncChangedTerminals(ByVal TerminalID As Int16)
        Dim Cmdsql As New SqlClient.SqlCommand
        Cmdsql.Connection = New SqlClient.SqlConnection(TWSClassConfigurationManagement.GetTDBServerConnectionString)
        Try
            Cmdsql.Connection.Open()
            Cmdsql.CommandText = "delete TblSyncChangedTerminals where (SyncTerminalID=" & TerminalID & ") and (DelFlag=1)"
            Cmdsql.ExecuteNonQuery()
            Cmdsql.Connection.Close()
        Catch ex As Exception
            If Cmdsql.Connection.State <> ConnectionState.Closed Then Cmdsql.Connection.Close()
            Throw New Exception("MClassTerminalsManagement.DeleteSyncChangedTerminals()." + ex.Message.ToString)
        End Try
    End Sub
    Public Shared Function GetSyncChangedTerminals(ByVal TerminalID As Int16)
        Dim Cmdsql As New SqlClient.SqlCommand
        Cmdsql.Connection = New SqlClient.SqlConnection(TWSClassConfigurationManagement.GetTDBServerConnectionString)
        Try
            Dim daSyncTerminals As New SqlClient.SqlDataAdapter : Dim dsSyncTerminals As New DataSet
            daSyncTerminals.SelectCommand = New SqlClient.SqlCommand("select A.TerminalID,B.TerminalName,A.Status from TblSyncChangedTerminals as A inner join TblTerminals AS B on A.TerminalID=B.TerminalID where SyncTerminalID=" & TerminalID & " order by A.TerminalId,A.Status")
            daSyncTerminals.SelectCommand.Connection = New SqlClient.SqlConnection(TWSClassConfigurationManagement.GetTDBServerConnectionString)
            dsSyncTerminals.Tables.Clear()
            daSyncTerminals.Fill(dsSyncTerminals)
            Cmdsql.Connection.Open()
            Cmdsql.CommandText = "update TblSyncChangedTerminals set Delflag=1 where SyncTerminalID=" & TerminalID & ""
            Cmdsql.ExecuteNonQuery()
            Cmdsql.Connection.Close()
            Return dsSyncTerminals
        Catch ex As Exception
            If Cmdsql.Connection.State <> ConnectionState.Closed Then Cmdsql.Connection.Close()
            Throw New Exception("MClassTerminalsManagement.GetSyncChangedTerminals()." + ex.Message.ToString)
        End Try
    End Function

End Class
