

Imports TWSClassLibrary.ConfigurationManagement
Imports TWSClassLibrary.TerminalsManagement

Public MustInherit Class MClassTerminalsManagement

    Public Shared Sub SetSyncChangedTerminals(ByVal SyncDS As DataSet)
        Dim Cmdsql As New SqlClient.SqlCommand
        Cmdsql.Connection = New SqlClient.SqlConnection(TWSClassConfigurationManagement.GetTDBClientConnectionString)
        Try
            Cmdsql.Connection.Open()
            Cmdsql.Transaction = Cmdsql.Connection.BeginTransaction
            For loopx As Int32 = 0 To SyncDS.Tables(0).Rows.Count - 1
                Dim myTerminalId As Int16 = SyncDS.Tables(0).Rows(loopx).Item(0)
                Dim myTerminalName As String = SyncDS.Tables(0).Rows(loopx).Item(1).trim
                If SyncDS.Tables(0).Rows(loopx).Item(2) = TerminalsStatus.Added Then
                    Cmdsql.CommandText = "insert into TblTerminals(TerminalId,TerminalName) values(" & myTerminalId & ",'" & myTerminalName & "')"
                    Cmdsql.ExecuteNonQuery()
                ElseIf SyncDS.Tables(0).Rows(loopx).Item(2) = TerminalsStatus.Deleted Then
                    Cmdsql.CommandText = "delete from TblTerminals where Terminalid=" & myTerminalId & ""
                    Cmdsql.ExecuteNonQuery()
                End If
            Next
            Cmdsql.Transaction.Commit() : Cmdsql.Connection.Close()
        Catch ex As Exception
            If Cmdsql.Connection.State <> ConnectionState.Closed Then
                Cmdsql.Transaction.Rollback() : Cmdsql.Connection.Close()
                Throw New Exception("MClassTerminalsManagement.SetSyncChangedTerminals()." + ex.Message.ToString)
            End If
        End Try
    End Sub

End Class
