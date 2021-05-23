

Imports TWSClassLibrary.ConfigurationManagement
Imports TWSClassLibrary.TrucksManagement
Imports TWSClassLibrary.TrucksManagement.TWSClassTrucksManagement
Public MustInherit Class MClassTrucksManagement


    Public Shared Sub SetSyncChangedTrucks(ByVal SyncDS As DataSet)
        Dim Cmdsql As New SqlClient.SqlCommand
        Cmdsql.Connection = New SqlClient.SqlConnection(TWSClassConfigurationManagement.GetTDBClientConnectionString)
        Try
            Cmdsql.Connection.Open()
            Cmdsql.Transaction = Cmdsql.Connection.BeginTransaction
            For loopx As Int32 = 0 To SyncDS.Tables(0).Rows.Count - 1
                Dim myTruckId As Int32 = SyncDS.Tables(0).Rows(loopx).Item(0)
                Dim myPelak As String = SyncDS.Tables(0).Rows(loopx).Item(2).trim
                Dim mySerial As String = SyncDS.Tables(0).Rows(loopx).Item(3).trim
                If ExistTruck(myPelak, mySerial, Cmdsql) = False Then
                    If SyncDS.Tables(0).Rows(loopx).Item(1) = TrucksStatus.Added Then
                        Cmdsql.CommandText = "insert into TblTrucks(TruckId,Pelak,Serial) values(" & myTruckId & ",'" & myPelak & "','" & mySerial & "')"
                        Cmdsql.ExecuteNonQuery()
                    ElseIf SyncDS.Tables(0).Rows(loopx).Item(1) = TrucksStatus.Deleted Then
                        Cmdsql.CommandText = "delete from TblTrucks where Truckid=" & myTruckId & ""
                        Cmdsql.ExecuteNonQuery()
                    End If
                End If
            Next
            Cmdsql.Transaction.Commit() : Cmdsql.Connection.Close()
        Catch ex As Exception
            If Cmdsql.Connection.State <> ConnectionState.Closed Then
                Cmdsql.Transaction.Rollback() : Cmdsql.Connection.Close()
            End If
            Throw New Exception("MClassTrucksManagement.SetSyncChangedTrucks()." + ex.Message.ToString)
        End Try
    End Sub
    Public Shared Function GetNewTrucks() As DataSet
        Try
            Dim daNewTrucks As New SqlClient.SqlDataAdapter : Dim dsNewTrucks As New DataSet
            daNewTrucks.SelectCommand = New SqlClient.SqlCommand("select ltrim(rtrim(pelak)),ltrim(rtrim(serial)) from TblSyncChangedNobats where ltrim(rtrim(pelak))+ltrim(rtrim(serial)) not in (select ltrim(rtrim(pelak))+ltrim(rtrim(serial)) from TblTrucks)")
            daNewTrucks.SelectCommand.Connection = New SqlClient.SqlConnection(TWSClassConfigurationManagement.GetTDBClientConnectionString)
            dsNewTrucks.Tables.Clear()
            daNewTrucks.Fill(dsNewTrucks)
            Return dsNewTrucks
        Catch ex As Exception
            Throw New Exception("MClassTrucksManagement.GetNewTrucks()." + ex.Message.ToString)
        End Try
    End Function
    Public Shared Sub WinServiceClearTrucksBuffer()
        Dim Cmdsql As New SqlClient.SqlCommand
        Cmdsql.Connection = New SqlClient.SqlConnection(TWSClassConfigurationManagement.GetTDBClientConnectionString)
        Try
            Cmdsql.Connection.Open()
            Cmdsql.Transaction = Cmdsql.Connection.BeginTransaction
            Cmdsql.CommandText = "delete TblTrucks" : Cmdsql.ExecuteNonQuery()
            Cmdsql.Transaction.Commit() : Cmdsql.Connection.Close()
        Catch ex As Exception
            If Cmdsql.Connection.State <> ConnectionState.Closed Then
                Cmdsql.Transaction.Rollback() : Cmdsql.Connection.Close()
            End If
            Throw New Exception("MClassNobatsManagement.WinServiceClearTrucksBuffer()." + ex.Message.ToString)
        End Try
    End Sub

End Class
