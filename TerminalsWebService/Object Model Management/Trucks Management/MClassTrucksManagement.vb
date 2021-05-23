
Imports System.Globalization

Imports TWSClassLibrary
Imports TWSClassLibrary.TrucksManagement
Imports TWSClassLibrary.TrucksManagement.TWSClassTrucksManagement
Imports TWSClassLibrary.TerminalsManagement.TWSClassTerminalsManagement
Imports TWSClassLibrary.DatabaseManagement.TWSClassDatabaseManagement
Imports TWSClassLibrary.ConfigurationManagement

Public MustInherit Class MClassTrucksManagement

    Public Shared Sub UpdateFromClientNewTrucks(ByVal ClientNewTrucks As DataSet)
        Dim CmdSql As New SqlClient.SqlCommand
        CmdSql.Connection = New SqlClient.SqlConnection(TWSClassConfigurationManagement.GetTDBServerConnectionString)
        Try
            Dim myNewTruckID As Int32
            CmdSql.Connection.Open()
            CmdSql.Transaction = CmdSql.Connection.BeginTransaction(System.Data.IsolationLevel.Serializable)
            For loopx = 0 To ClientNewTrucks.Tables(0).Rows.Count - 1
                Dim myPelak As String = ClientNewTrucks.Tables(0).Rows(loopx).Item(0)
                Dim mySerial As String = ClientNewTrucks.Tables(0).Rows(loopx).Item(1)
                If ExistTruck(myPelak, mySerial, CmdSql) = False Then
                    CmdSql.CommandText = "select TruckID from TblTrucks order by TruckID desc"
                    If CmdSql.ExecuteScalar = System.TypeCode.Empty Then
                        myNewTruckID = 1
                    Else
                        myNewTruckID = CmdSql.ExecuteScalar + 1
                    End If
                    CmdSql.CommandText = "insert into TblTrucks(Pelak,Serial,TruckID,CreateTime) values('" & myPelak & "','" & mySerial & "'," & myNewTruckID & ",'" & Date.Now.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture) & "')"
                    CmdSql.ExecuteNonQuery()
                    Dim mySyncDS As DataSet = GetTerminalsIDList(TWSClassConfigurationManagement.GetTDBServerConnectionString)
                    For loopAddToSync As Int16 = 0 To mySyncDS.Tables(0).Rows.Count - 1
                        CmdSql.CommandText = "insert into TblSyncChangedTrucks(TruckID,Status,SyncTerminalID,DelFlag) values(" & myNewTruckID & "," & TrucksStatus.Added & "," & mySyncDS.Tables(0).Rows(loopAddToSync).Item(0) & ",0)"
                        CmdSql.ExecuteNonQuery()
                    Next
                End If
            Next
            CmdSql.Transaction.Commit() : CmdSql.Connection.Close()
        Catch ex As Exception
            If CmdSql.Connection.State <> ConnectionState.Closed Then
                CmdSql.Transaction.Rollback() : CmdSql.Connection.Close()
            End If
            Throw New Exception("MclassTrucksManagement.UpdateFromClientNewTrucks()." + ex.Message.ToString)
        End Try
    End Sub
    Public Shared Sub WebServiceClearTrucksBuffer()
        Dim Cmdsql As New SqlClient.SqlCommand
        Cmdsql.Connection = New SqlClient.SqlConnection(TWSClassConfigurationManagement.GetTDBServerConnectionString)
        Try
            Cmdsql.Connection.Open()
            Cmdsql.Transaction = Cmdsql.Connection.BeginTransaction
            Cmdsql.CommandText = "delete TblTrucks" : Cmdsql.ExecuteNonQuery()
            Cmdsql.CommandText = "delete TblSyncChangedTrucks" : Cmdsql.ExecuteNonQuery()
            Cmdsql.Transaction.Commit() : Cmdsql.Connection.Close()
        Catch ex As Exception
            If Cmdsql.Connection.State <> ConnectionState.Closed Then
                Cmdsql.Transaction.Rollback() : Cmdsql.Connection.Close()
            End If
            Throw New Exception("MClassNobatsManagement.WebServiceClearTrucksBuffer()." + ex.Message.ToString)
        End Try
    End Sub
    Public Shared Sub DeleteSyncChangedTrucks(ByVal TerminalID As Int16)
        Dim Cmdsql As New SqlClient.SqlCommand
        Cmdsql.Connection = New SqlClient.SqlConnection(TWSClassConfigurationManagement.GetTDBServerConnectionString)
        Try
            Cmdsql.Connection.Open()
            Cmdsql.CommandText = "delete TblSyncChangedTrucks where (SyncTerminalID=" & TerminalID & ") and (DelFlag=1)"
            Cmdsql.ExecuteNonQuery()
            Cmdsql.Connection.Close()
        Catch ex As Exception
            If Cmdsql.Connection.State <> ConnectionState.Closed Then Cmdsql.Connection.Close()
            Throw New Exception("MClassTrucksManagement.DeleteSyncChangedTrucks()." + ex.Message.ToString)
        End Try
    End Sub
    Public Shared Function GetSyncChangedTrucks(ByVal TerminalID As Int16) As DataSet
        Dim Cmdsql As New SqlClient.SqlCommand
        Cmdsql.Connection = New SqlClient.SqlConnection(TWSClassConfigurationManagement.GetTDBServerConnectionString)
        Try
            Dim daSyncTrucks As New SqlClient.SqlDataAdapter : Dim dsSyncTrucks As New DataSet
            daSyncTrucks.SelectCommand = New SqlClient.SqlCommand("select A.TruckID,A.Status,B.Pelak,B.Serial from TblSyncChangedTrucks as A inner join TblTrucks AS B on A.TruckID=B.TruckID where SyncTerminalID=" & TerminalID & " order by A.truckid,A.status asc")
            daSyncTrucks.SelectCommand.Connection = New SqlClient.SqlConnection(TWSClassConfigurationManagement.GetTDBServerConnectionString)
            dsSyncTrucks.Tables.Clear()
            daSyncTrucks.Fill(dsSyncTrucks)
            Cmdsql.Connection.Open()
            Cmdsql.CommandText = "update TblSyncChangedTrucks set DelFlag=1 where SyncTerminalID=" & TerminalID & ""
            Cmdsql.ExecuteNonQuery()
            Cmdsql.Connection.Close()
            Return dsSyncTrucks
        Catch ex As Exception
            If Cmdsql.Connection.State <> ConnectionState.Closed Then Cmdsql.Connection.Close()
            Throw New Exception("MClassTrucksManagement.GetSyncChangedTrucks()." + ex.Message.ToString)
        End Try
    End Function


End Class
