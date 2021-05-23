
Imports System.Globalization

Imports TWSClassLibrary
Imports TWSClassLibrary.NobatsManagement
Imports TWSClassLibrary.DatabaseManagement.TWSClassDatabaseManagement
Imports TWSClassLibrary.TerminalsManagement.TWSClassTerminalsManagement
Imports TWSClassLibrary.ConfigurationManagement

Public MustInherit Class MClassNobatsManagement

    Public Shared Sub UpdateFromClientNewNobats(ByVal TerminalID As Int16, ByVal ClientNewNobats As DataSet)
        Dim CmdSql As New SqlClient.SqlCommand
        CmdSql.Connection = New SqlClient.SqlConnection(TWSClassConfigurationManagement.GetTDBServerConnectionString)
        Try
            CmdSql.Connection.Open()
            CmdSql.Transaction = CmdSql.Connection.BeginTransaction(System.Data.IsolationLevel.Serializable)
            For loopx = 0 To ClientNewNobats.Tables(0).Rows.Count - 1
                Dim myTruckID As Int32 = ClientNewNobats.Tables(0).Rows(loopx).Item(0)
                Dim myStatus As NobatsStatus = ClientNewNobats.Tables(0).Rows(loopx).Item(1)
                Dim myTravelTime As Int16 = ClientNewNobats.Tables(0).Rows(loopx).Item(2)
                Dim mySodoorTime As DateTime = ClientNewNobats.Tables(0).Rows(loopx).Item(3)
                If myStatus = NobatsStatus.Added Then
                    'كنترل اين كه ناوگان در پايانه هاي ديگر نوبت نداشته باشد
                    CmdSql.CommandText = "Select Count(*) as CC From TblNobats Where TruckId=" & myTruckID & " and TerminalId<>" & TerminalID & " and TravelTime=0"
                    Dim CC As Int16 = CmdSql.ExecuteScalar
                    If CC <> 0 Then
                        CmdSql.CommandText = "insert into TblSyncChangedNobatsTrace(TruckID,TerminalID,Status,TravelTime,SodoorTime,TraceWriter,DateReal) values(" & myTruckID & "," & 6 & "," & NobatsStatus.DelNobatOverOne1 & ",0,'" & Date.Now.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture) & "','" & [Enum].GetName(GetType(TraceWriter), TraceWriter.WebService) & "','" & Date.Now.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture) & "')"
                        CmdSql.ExecuteNonQuery()
                        CmdSql.CommandText = "insert into TblSyncChangedNobats(TruckID,TerminalID,Status,SyncTerminalID,TravelTime,SodoorTime,DelFlag) values(" & myTruckID & "," & 6 & "," & NobatsStatus.DelNobatOverOne1 & "," & TerminalID & ",0,'" & Date.Now.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture) & "',0)"
                        CmdSql.ExecuteNonQuery()
                    Else
                        CmdSql.CommandText = "insert into TblNobats(TruckID,TerminalID,TravelTime,SodoorTime) values(" & myTruckID & "," & TerminalID & "," & myTravelTime & ",'" & mySodoorTime.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture) & "')"
                        CmdSql.ExecuteNonQuery()
                        CmdSql.CommandText = "insert into TblSyncChangedNobatsTrace(TruckID,TerminalID,Status,TravelTime,SodoorTime,TraceWriter,DateReal) values(" & myTruckID & "," & TerminalID & "," & NobatsStatus.Added & "," & myTravelTime & ",'" & mySodoorTime.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture) & "','" & [Enum].GetName(GetType(TraceWriter), TraceWriter.WebService) & "','" & Date.Now.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture) & "')"
                        CmdSql.ExecuteNonQuery()
                        Dim mySyncDS As DataSet = GetTerminalsIDList(TerminalID, TWSClassConfigurationManagement.GetTDBServerConnectionString)
                        For loopAddToSync As Int16 = 0 To mySyncDS.Tables(0).Rows.Count - 1
                            CmdSql.CommandText = "insert into TblSyncChangedNobats(TruckID,TerminalID,Status,SyncTerminalID,TravelTime,SodoorTime,DelFlag) values(" & myTruckID & "," & TerminalID & "," & NobatsStatus.Added & "," & mySyncDS.Tables(0).Rows(loopAddToSync).Item(0) & "," & myTravelTime & ",'" & mySodoorTime.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture) & "',0)"
                            CmdSql.ExecuteNonQuery()
                        Next
                    End If
                ElseIf myStatus = NobatsStatus.Deleted Then
                    If myTravelTime = 0 Then
                        CmdSql.CommandText = "Delete from TblNobats where TruckID=" & myTruckID & " and TerminalID=" & TerminalID & ""
                        CmdSql.ExecuteNonQuery()
                    End If
                    CmdSql.CommandText = "insert into TblSyncChangedNobatsTrace(TruckID,TerminalID,Status,TravelTime,SodoorTime,TraceWriter,DateReal) values(" & myTruckID & "," & TerminalID & "," & NobatsStatus.Deleted & "," & myTravelTime & ",'" & mySodoorTime.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture) & "','" & [Enum].GetName(GetType(TraceWriter), TraceWriter.WebService) & "','" & Date.Now.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture) & "')"
                    CmdSql.ExecuteNonQuery()
                    Dim mySyncDS As DataSet = GetTerminalsIDList(TerminalID, TWSClassConfigurationManagement.GetTDBServerConnectionString)
                    If myTravelTime = 0 Then
                        For loopDelToSync As Int16 = 0 To mySyncDS.Tables(0).Rows.Count - 1
                            CmdSql.CommandText = "insert into TblSyncChangedNobats(TruckID,TerminalID,Status,SyncTerminalID,TravelTime,SodoorTime,DelFlag) values(" & myTruckID & "," & TerminalID & "," & NobatsStatus.Deleted & "," & mySyncDS.Tables(0).Rows(loopDelToSync).Item(0) & "," & myTravelTime & ",'" & mySodoorTime.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture) & "',0)"
                            CmdSql.ExecuteNonQuery()
                        Next
                    End If
                ElseIf myStatus = NobatsStatus.Sodoor Then
                    CmdSql.CommandText = "insert into TblSyncChangedNobatsTrace(TruckID,TerminalID,Status,TravelTime,SodoorTime,TraceWriter,DateReal) values(" & myTruckID & "," & TerminalID & "," & NobatsStatus.Sodoor & "," & myTravelTime & ",'" & mySodoorTime.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture) & "','" & [Enum].GetName(GetType(TraceWriter), TraceWriter.WebService) & "','" & Date.Now.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture) & "')"
                    CmdSql.ExecuteNonQuery()
                    If myTravelTime <> 0 Then
                        CmdSql.CommandText = "update TblNobats set TravelTime=" & myTravelTime & ",SodoorTime='" & mySodoorTime.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture) & "' where TruckID=" & myTruckID & " and TerminalID=" & TerminalID & ""
                        CmdSql.ExecuteNonQuery()
                        Dim mySyncDS As DataSet = GetTerminalsIDList(TerminalID, TWSClassConfigurationManagement.GetTDBServerConnectionString)
                        For loopAddToSync As Int16 = 0 To mySyncDS.Tables(0).Rows.Count - 1
                            CmdSql.CommandText = "insert into TblSyncChangedNobats(TruckID,TerminalID,Status,SyncTerminalID,TravelTime,SodoorTime,DelFlag) values(" & myTruckID & "," & TerminalID & "," & NobatsStatus.Sodoor & "," & mySyncDS.Tables(0).Rows(loopAddToSync).Item(0) & "," & myTravelTime & ",'" & mySodoorTime.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture) & "',0)"
                            CmdSql.ExecuteNonQuery()
                        Next
                    Else
                        Threading.Thread.Sleep(10)
                        'وقتي مجوز با طول سفر 0 صادر مي گردد دستور حذف نوبت بلافاصله به طور پخشي در سيستم ايجاد مي شود
                        'ايجاد تريس حذف نوبت
                        CmdSql.CommandText = "insert into TblSyncChangedNobatsTrace(TruckID,TerminalID,Status,TravelTime,SodoorTime,TraceWriter,DateReal) values(" & myTruckID & "," & TerminalID & "," & NobatsStatus.Deleted & "," & myTravelTime & ",'" & mySodoorTime.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture) & "','" & [Enum].GetName(GetType(TraceWriter), TraceWriter.WebService) & "','" & Date.Now.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture) & "')"
                        CmdSql.ExecuteNonQuery()
                        CmdSql.CommandText = "Delete from TblNobats where TruckID=" & myTruckID & " and TerminalID=" & TerminalID & ""
                        CmdSql.ExecuteNonQuery()
                        Dim mySyncDS As DataSet = GetTerminalsIDList(TerminalID, TWSClassConfigurationManagement.GetTDBServerConnectionString)
                        For loopDelToSync As Int16 = 0 To mySyncDS.Tables(0).Rows.Count - 1
                            CmdSql.CommandText = "insert into TblSyncChangedNobats(TruckID,TerminalID,Status,SyncTerminalID,TravelTime,SodoorTime,DelFlag) values(" & myTruckID & "," & TerminalID & "," & NobatsStatus.Deleted & "," & mySyncDS.Tables(0).Rows(loopDelToSync).Item(0) & "," & myTravelTime & ",'" & mySodoorTime.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture) & "',0)"
                            CmdSql.ExecuteNonQuery()
                        Next
                    End If
                End If
            Next
            CmdSql.Transaction.Commit() : CmdSql.Connection.Close()
        Catch ex As Exception
            If CmdSql.Connection.State <> ConnectionState.Closed Then
                CmdSql.Transaction.Rollback() : CmdSql.Connection.Close()
            End If
            Throw New Exception("MClassNobatsManagement.UpdateFromClientNewNobats()." + ex.Message.ToString)
        End Try
    End Sub
    Public Shared Sub DeleteSyncChangedNobats(ByVal TerminalID As Int16)
        Dim Cmdsql As New SqlClient.SqlCommand
        Cmdsql.Connection = New SqlClient.SqlConnection(TWSClassConfigurationManagement.GetTDBServerConnectionString)
        Try
            Cmdsql.Connection.Open()
            Cmdsql.CommandText = "delete TblSyncChangedNobats where (SyncTerminalID=" & TerminalID & ") and (DelFlag=1)"
            Cmdsql.ExecuteNonQuery()
            Cmdsql.Connection.Close()
        Catch ex As Exception
            If Cmdsql.Connection.State <> ConnectionState.Closed Then Cmdsql.Connection.Close()
            Throw New Exception("MClassNobatsManagement.DeleteSyncChangedNobats()." + ex.Message.ToString)
        End Try
    End Sub
    Public Shared Function GetSyncChangedNobats(ByVal TerminalID As Int16) As DataSet
        Dim Cmdsql As New SqlClient.SqlCommand
        Cmdsql.Connection = New SqlClient.SqlConnection(TWSClassConfigurationManagement.GetTDBServerConnectionString)
        Try
            Dim daSyncNobats As New SqlClient.SqlDataAdapter : Dim dsSyncNobats As New DataSet
            daSyncNobats.SelectCommand = New SqlClient.SqlCommand("select Truckid,Status,TerminalID,TravelTime,SodoorTime from TblSyncChangedNobats where (SyncTerminalID=" & TerminalID & ") order by truckid,sodoortime asc")
            'daSyncNobats.SelectCommand = New SqlClient.SqlCommand("select Truckid,Status,TerminalID,TravelTime,SodoorTime from TblSyncChangedNobats where (SyncTerminalID=" & TerminalID & ") order by truckid,sodoortime asc")
            daSyncNobats.SelectCommand.Connection = New SqlClient.SqlConnection(TWSClassConfigurationManagement.GetTDBServerConnectionString)
            dsSyncNobats.Tables.Clear()
            daSyncNobats.Fill(dsSyncNobats)
            Cmdsql.Connection.Open()
            Cmdsql.CommandText = "update TblSyncChangedNobats set delflag=1 where SyncTerminalID=" & TerminalID & ""
            Cmdsql.ExecuteNonQuery()
            Cmdsql.Connection.Close()
            Return dsSyncNobats
        Catch ex As Exception
            If Cmdsql.Connection.State <> ConnectionState.Closed Then Cmdsql.Connection.Close()
            Throw New Exception("MClassNobatsManagement.GetSyncChangedNobats()." + ex.Message.ToString)
        End Try
    End Function
    Public Shared Sub WebServiceClearNobatsBuffer()
        Dim Cmdsql As New SqlClient.SqlCommand
        Cmdsql.Connection = New SqlClient.SqlConnection(TWSClassConfigurationManagement.GetTDBServerConnectionString)
        Try
            Cmdsql.Connection.Open()
            Cmdsql.Transaction = Cmdsql.Connection.BeginTransaction
            Cmdsql.CommandText = "delete TblNobats" : Cmdsql.ExecuteNonQuery()
            Cmdsql.CommandText = "delete TblSyncChangedNobats" : Cmdsql.ExecuteNonQuery()
            Cmdsql.CommandText = "delete TblSyncChangedNobatsTrace" : Cmdsql.ExecuteNonQuery()
            Cmdsql.Transaction.Commit() : Cmdsql.Connection.Close()
        Catch ex As Exception
            If Cmdsql.Connection.State <> ConnectionState.Closed Then
                Cmdsql.Transaction.Rollback() : Cmdsql.Connection.Close()
            End If
            Throw New Exception("MClassNobatsManagement.WebServiceClearNobatsBuffer()." + ex.Message.ToString)
        End Try
    End Sub

End Class
