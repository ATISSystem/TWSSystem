Imports System.Timers
Imports Microsoft.Win32
Imports System.Diagnostics
Imports System.Globalization


Imports TWSClassLibrary
Imports TWSClassLibrary.DatabaseManagement
Imports TWSClassLibrary.DatabaseManagement.TWSClassDatabaseManagement
Imports TWSClassLibrary.TerminalsManagement.TWSClassTerminalsManagement
Imports TWSClassLibrary.NobatsManagement
Imports TWSClassLibrary.SystemStatusManagement
Imports TWSClassLibrary.LoggingManagement
Imports TWSClassLibrary.AckSignalManagement
Imports TWSClassLibrary.ConfigurationManagement

Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim CmdSql As New SqlClient.SqlCommand
        CmdSql.Connection = New SqlClient.SqlConnection(TWSClassConfigurationManagement.GetTDBServerConnectionString)
        Try
            'لیست ناوگانی که برای آنها مجوز صادر شده است و باید کنترل شوند
            Dim DaList As New SqlClient.SqlDataAdapter : Dim DsList As New DataSet
            DaList.SelectCommand = New SqlClient.SqlCommand("select TruckId from TblSyncChangedNobatsTrace where (Status=3) and (DATEDIFF(HOUR,SodoorTime,GETDATE())>=TravelTime) AND TruckID in (select TruckID from TblNobats) group by TruckID ")
            DaList.SelectCommand.Connection = New SqlClient.SqlConnection(TWSClassConfigurationManagement.GetTDBServerConnectionString)
            DsList.Tables.Clear()
            DaList.Fill(DsList)
            'ليست ناوگاني که طول سفرشان به پايان رسيده است و بايد از کل سيستم حذف گردند
            Dim da As New SqlClient.SqlDataAdapter : Dim ds As New DataSet
            da.SelectCommand = New SqlClient.SqlCommand("select TruckId,TerminalId,TravelTime,SodoorTime from TblNobats where (DATEDIFF(HOUR,SodoorTime,GETDATE())>=TravelTime)")
            da.SelectCommand.Connection = New SqlClient.SqlConnection(TWSClassConfigurationManagement.GetTDBServerConnectionString)
            ds.Tables.Clear()
            da.Fill(ds)
            CmdSql.Connection.Open()
            CmdSql.Transaction = CmdSql.Connection.BeginTransaction
            For loopx = 0 To DsList.Tables(0).Rows.Count - 1
                Dim myTruckId As Int32 = DsList.Tables(0).Rows(loopx).Item("TruckId")
                Dim myTerminalId As Int32 = ds.Tables(0).Select("TruckId=" + myTruckId.ToString)(0)(1)
                Dim myTravelTime As Int16 = ds.Tables(0).Select("TruckId=" + myTruckId.ToString)(0)(2)
                Dim mySodoorTime As DateTime = ds.Tables(0).Select("TruckId=" + myTruckId.ToString)(0)(3)
                If DateDiff(DateInterval.Hour, mySodoorTime, Date.Now()) >= myTravelTime Then
                    Dim mySyncDS As DataSet = GetTerminalsIDList(TWSClassConfigurationManagement.GetTDBServerConnectionString)
                    CmdSql.CommandText = "Delete from TblNobats where TruckID=" & myTruckId & " and TerminalID=" & myTerminalId & ""
                    CmdSql.ExecuteNonQuery()
                    CmdSql.CommandText = "insert into TblSyncChangedNobatsTrace(TruckID,TerminalID,Status,TravelTime,SodoorTime,TraceWriter,DateReal) values(" & myTruckId & "," & myTerminalId & "," & NobatsStatus.Deleted & ",0,'','" & [Enum].GetName(GetType(TraceWriter), TraceWriter.Garbage) & "','" & Date.Now.ToString("yyyy-MM-dd HH:mm:ss") & "')"
                    CmdSql.ExecuteNonQuery()
                    For loopAddToSync As Int16 = 0 To mySyncDS.Tables(0).Rows.Count - 1
                        CmdSql.CommandText = "insert into TblSyncChangedNobats(TruckID,TerminalID,Status,SyncTerminalID,TravelTime,SodoorTime,DelFlag) values(" & myTruckId & "," & myTerminalId & "," & NobatsStatus.Deleted & "," & mySyncDS.Tables(0).Rows(loopAddToSync).Item(0) & ",0,'',0)"
                        CmdSql.ExecuteNonQuery()
                    Next
                End If
            Next
            CmdSql.Transaction.Commit() : CmdSql.Connection.Close()
            'If ds.Tables(0).Rows.Count <> 0 Then TWS.ACKSignalRecived(MClassAuthenticationManagement.AuthenticationId, 0, ACKSignal.ServerWinServiceGarbageTimerElapsed, ds, " Garbage Deleted Trucks=" + ds.Tables(0).Rows.Count.ToString, LogSource.ServerWinService, Database.TDBServer, "", "TWSTravelTimeGarbage.GarbageTimerTick", SystemStatus.None, 0)
            'TWS.ACKSignalRecived(MClassAuthenticationManagement.AuthenticationId, 0, ACKSignal.ServerWinServiceGarbageTimerElapsed, ds, " Garbage Deleted Trucks=" + ds.Tables(0).Rows.Count.ToString, LogSource.ServerWinService, Database.TDBServer, "", "TWSTravelTimeGarbage.GarbageTimerTick", SystemStatus.None, 0)

        Catch ex As Exception
            If CmdSql.Connection.State <> ConnectionState.Closed Then
                CmdSql.Transaction.Rollback() : CmdSql.Connection.Close()
            End If
            EventLog.WriteEntry("TWSGarbageSource", ex.Message.ToString, EventLogEntryType.Error)
            'TWS.ACKSignalRecived(MClassAuthenticationManagement.AuthenticationId, 0, ACKSignal.AckError, Nothing, ex.Message.ToString, LogSource.ServerWinService, Database.None, "", "TWSTravelTimeGarbage.GarbageTimerTick", SystemStatus.None, 0)
        End Try

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim CmdSql As New SqlClient.SqlCommand
        CmdSql.Connection = New SqlClient.SqlConnection(TWSClassConfigurationManagement.GetTDBServerConnectionString)
        Try
            'لیست ناوگانی که برای آنها مجوز صادر شده است و باید کنترل شوند
            'Dim DaList As New SqlClient.SqlDataAdapter : Dim DsList As New DataSet
            'DaList.SelectCommand = New SqlClient.SqlCommand("select TruckId from TblSyncChangedNobatsTrace where (Status=3) and (DATEDIFF(HOUR,SodoorTime,GETDATE())>=TravelTime) AND TruckID in (select TruckID from TblNobats) group by TruckID ")
            'DaList.SelectCommand.Connection = New SqlClient.SqlConnection(GetTDBServerConnectionString)
            'DsList.Tables.Clear()
            'DaList.Fill(DsList)
            'ليست ناوگاني که طول سفرشان به پايان رسيده است و بايد از کل سيستم حذف گردند
            Dim da As New SqlClient.SqlDataAdapter : Dim ds As New DataSet
            da.SelectCommand = New SqlClient.SqlCommand("select TruckId,TerminalId,TravelTime,SodoorTime from TblNobats where (DATEDIFF(HOUR,SodoorTime,GETDATE())>=TravelTime) And (TravelTime<>0)")
            da.SelectCommand.Connection = New SqlClient.SqlConnection(TWSClassConfigurationManagement.GetTDBServerConnectionString)
            ds.Tables.Clear()
            da.Fill(ds)
            CmdSql.Connection.Open()
            CmdSql.Transaction = CmdSql.Connection.BeginTransaction
            For loopx = 0 To ds.Tables(0).Rows.Count - 1
                Dim myTruckId As Int32 = ds.Tables(0).Rows(loopx).Item("TruckId")
                Dim myTerminalId As Int32 = ds.Tables(0).Select("TruckId=" + myTruckId.ToString())(0)(1)
                Dim myTravelTime As Int16 = ds.Tables(0).Select("TruckId=" + myTruckId.ToString())(0)(2)
                Dim mySodoorTime As DateTime = ds.Tables(0).Select("TruckId=" + myTruckId.ToString())(0)(3)
                If DateDiff(DateInterval.Hour, mySodoorTime, Date.Now()) >= myTravelTime Then
                    Dim mySyncDS As DataSet = GetTerminalsIDList(TWSClassConfigurationManagement.GetTDBServerConnectionString)
                    CmdSql.CommandText = "Delete from TblNobats where TruckID=" & myTruckId & " and TerminalID=" & myTerminalId & ""
                    CmdSql.ExecuteNonQuery()
                    CmdSql.CommandText = "insert into TblSyncChangedNobatsTrace(TruckID,TerminalID,Status,TravelTime,SodoorTime,TraceWriter,DateReal) values(" & myTruckId & "," & myTerminalId & "," & NobatsStatus.Deleted & ",0,'','" & [Enum].GetName(GetType(TraceWriter), TraceWriter.Garbage) & "','" & Date.Now.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture) & "')"
                    CmdSql.ExecuteNonQuery()
                    For loopAddToSync As Int16 = 0 To mySyncDS.Tables(0).Rows.Count - 1
                        CmdSql.CommandText = "insert into TblSyncChangedNobats(TruckID,TerminalID,Status,SyncTerminalID,TravelTime,SodoorTime,DelFlag) values(" & myTruckId & "," & myTerminalId & "," & NobatsStatus.Deleted & "," & mySyncDS.Tables(0).Rows(loopAddToSync).Item(0) & ",0,'',0)"
                        CmdSql.ExecuteNonQuery()
                    Next
                End If
            Next
            CmdSql.Transaction.Commit() : CmdSql.Connection.Close()
            'If ds.Tables(0).Rows.Count <> 0 Then TWS.ACKSignalRecived(MClassAuthenticationManagement.AuthenticationId, 0, ACKSignal.ServerWinServiceGarbageTimerElapsed, ds, " Garbage Deleted Trucks=" + ds.Tables(0).Rows.Count.ToString, LogSource.ServerWinService, Database.TDBServer, "", "TWSTravelTimeGarbage.GarbageTimerTick", SystemStatus.None, 0)
            'TWS.ACKSignalRecived(MClassAuthenticationManagement.AuthenticationId, 0, ACKSignal.ServerWinServiceGarbageTimerElapsed, ds, " Garbage Deleted Trucks=" + ds.Tables(0).Rows.Count.ToString, LogSource.ServerWinService, Database.TDBServer, "", "TWSTravelTimeGarbage.GarbageTimerTick", SystemStatus.None, 0)

        Catch ex As Exception
            If CmdSql.Connection.State <> ConnectionState.Closed Then
                CmdSql.Transaction.Rollback() : CmdSql.Connection.Close()
            End If
            EventLog.WriteEntry("TWSGarbageSource", ex.Message.ToString, EventLogEntryType.Error)
            'TWS.ACKSignalRecived(MClassAuthenticationManagement.AuthenticationId, 0, ACKSignal.AckError, Nothing, ex.Message.ToString, LogSource.ServerWinService, Database.None, "", "TWSTravelTimeGarbage.GarbageTimerTick", SystemStatus.None, 0)
        End Try

    End Sub
End Class
