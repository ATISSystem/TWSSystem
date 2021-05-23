
Imports System.Timers
Imports Microsoft.Win32
Imports System.Diagnostics
Imports TWSClassLibrary.TDBClientStpType
Imports TWSClassLibrary.DatabaseManagement.TWSClassDatabaseManagement
Imports TWSClassLibrary.SystemStatusManagement
Imports TWSClassLibrary.AckSignalManagement
Imports TWSClassLibrary.LoggingManagement
Imports TWSClassLibrary.DatabaseManagement
Imports TWSClassLibrary.ConfigurationManagement

Public Class TerminalsWinService
    Private SystemStatus As SystemStatus = SystemStatus.SystemIdle
    Private SystemStatusCommandId As String = ""
    Private SyncCounting As Int16 = 0
    Private GarbageCounting As Int16 = 0

    Private WithEvents TimerCallTerminalsWebService As System.Timers.Timer = New System.Timers.Timer
    Private TWS As TerminalsWebService.TerminalsWebServiceSoap = New TerminalsWebService.TerminalsWebServiceSoapClient

    Protected Overrides Sub OnStart(ByVal args() As String)
        Try
            'ايجاد اونت لوگ براي سرويس
            MClassConfigurationManagement.CreateTWSClientLog()

            'تنظيم تعداد بار sync
            SyncCounting = MClassConfigurationManagement.GetSyncCounting

            'دريافت اينتروال از رجيستري و راه اندازي تايمر
            'TimerCallTerminalsWebService.Interval = MClassConfigurationManagement.GetTimerInterval
            TimerCallTerminalsWebService.Interval = 60000
            TimerCallTerminalsWebService.Enabled = True
            TimerCallTerminalsWebService.Start()

            EventLog.WriteEntry("TWSCLTSource", "TwsServiceStart", EventLogEntryType.Warning)
            'TWS.ACKSignalRecived(MClassAuthenticationManagement.AuthenticationId, MClassConfigurationManagement.GetTerminalId, ACKSignal.WinServiceStart, Nothing, " TimerInterval=" + MClassConfigurationManagement.GetTimerInterval.ToString + " SyncCountingRegistry=" + MClassConfigurationManagement.GetSyncCounting.ToString + " TDBClientConnectionString=" + GetTDBClientConnectionString.Replace("'", ""), LogSource.ClientWinService, Database.None, "", "TerminalsWinService.OnStart", SystemStatus, SyncCounting)
        Catch ex As Exception
            EventLog.WriteEntry("TWSCLTSource", ex.Message.ToString, EventLogEntryType.Error)
            TWS.ACKSignalRecived(MClassAuthenticationManagement.AuthenticationId, MClassConfigurationManagement.GetTerminalId, ACKSignal.AckError, Nothing, ex.Message.ToString, LogSource.ClientWinService, Database.None, "", "TerminalsWinService.OnStart", SystemStatus, SyncCounting)
        End Try
    End Sub

    Protected Overrides Sub OnStop()
        Try
            EventLog.WriteEntry("TWSCLTSource", "TwsServiceStop", EventLogEntryType.Warning)
            TWS.ACKSignalRecived(MClassAuthenticationManagement.AuthenticationId, MClassConfigurationManagement.GetTerminalId, ACKSignal.WinServiceStop, Nothing, "", LogSource.ClientWinService, Database.None, "", "TerminalsWinService.OnStop", SystemStatus, SyncCounting)
        Catch ex As Exception
            EventLog.WriteEntry("TWSCLTSource", ex.Message.ToString, EventLogEntryType.Error)
            TWS.ACKSignalRecived(MClassAuthenticationManagement.AuthenticationId, MClassConfigurationManagement.GetTerminalId, ACKSignal.AckError, Nothing, ex.Message.ToString, LogSource.ClientWinService, Database.None, "", "TerminalsWinService.OnStop", SystemStatus, SyncCounting)
        End Try
    End Sub

    Private Sub WinServiceTimer() Handles TimerCallTerminalsWebService.Elapsed
        Try
            'بررسي فرمان جديد سيستم
            Dim myNewSystemCommandId As String
            Dim mySystemStatusTerminalId As Int16
            Dim myCommandOrData As String
            Dim myNewSystemStatus As SystemStatus = TWS.WebMethodGetNewSystemStatus(MClassAuthenticationManagement.AuthenticationId, mySystemStatusTerminalId, myNewSystemCommandId, myCommandOrData)
            If myNewSystemCommandId.Trim <> SystemStatusCommandId.Trim Then
                'فرمان پخشي کد ترمينال معادل صفر است
                If (mySystemStatusTerminalId = 0) Or (mySystemStatusTerminalId = MClassConfigurationManagement.GetTerminalId) Then
                    If myNewSystemStatus = SystemStatus.SystemGeneral Then
                        Try
                            SyncCounting = 0
                            MClassConfigurationManagement.ActiveFlagForStps(TDBClientStpType.Add, True)
                            MClassConfigurationManagement.ActiveFlagForStps(TDBClientStpType.Del, True)
                            MClassConfigurationManagement.ActiveFlagForStps(TDBClientStpType.Exist, True)
                            MClassConfigurationManagement.ActiveFlagForStps(TDBClientStpType.Sodoor, True)
                            TWS.ACKSignalRecived(MClassAuthenticationManagement.AuthenticationId, MClassConfigurationManagement.GetTerminalId, ACKSignal.SystemStatusChangedToSystemGeneral, Nothing, "ChangeStatus:SystemGeneral(ActiveAllStp)", LogSource.ClientWinService, Database.TDBClient, "", "TerminalsWinService.WinServiceTimer", SystemStatus, SyncCounting)
                        Catch ex As Exception
                            Throw New Exception("TerminalsWinService.SystemGeneral:" + ex.Message.ToString)
                        End Try
                    ElseIf myNewSystemStatus = SystemStatus.SystemFullSilent Then
                        Try
                            MClassConfigurationManagement.ActiveFlagForStps(TDBClientStpType.Add, False)
                            MClassConfigurationManagement.ActiveFlagForStps(TDBClientStpType.Del, False)
                            MClassConfigurationManagement.ActiveFlagForStps(TDBClientStpType.Exist, False)
                            MClassConfigurationManagement.ActiveFlagForStps(TDBClientStpType.Sodoor, False)
                            TWS.ACKSignalRecived(MClassAuthenticationManagement.AuthenticationId, MClassConfigurationManagement.GetTerminalId, ACKSignal.SystemStatusChangedToSystemFullSilent, Nothing, "ChangeStatus:SystemFullSilent(DeactiveAllStp)", LogSource.ClientWinService, Database.TDBClient, "", "TerminalsWinService.WinServiceTimer", SystemStatus, SyncCounting)
                        Catch ex As Exception
                            Throw New Exception("TerminalsWinService.SystemFullSilent:" + ex.Message.ToString)
                        End Try
                    ElseIf myNewSystemStatus = SystemStatus.StpExistNobatSilent Then
                        Try
                            MClassConfigurationManagement.ActiveFlagForStps(TDBClientStpType.Exist, False)
                            TWS.ACKSignalRecived(MClassAuthenticationManagement.AuthenticationId, MClassConfigurationManagement.GetTerminalId, ACKSignal.SystemStatusChangedToStpExistNobatSilent, Nothing, "ChangeStatus:StpExistNobatSilent(DeactiveStpExistNobat)", LogSource.ClientWinService, Database.TDBClient, "", "TerminalsWinService.WinServiceTimer", SystemStatus, SyncCounting)
                        Catch ex As Exception
                            Throw New Exception("TerminalsWinService.StpExistNobatSilent:" + ex.Message.ToString)
                        End Try
                    ElseIf myNewSystemStatus = SystemStatus.WinServiceSilent Then
                        Try
                            TWS.ACKSignalRecived(MClassAuthenticationManagement.AuthenticationId, MClassConfigurationManagement.GetTerminalId, ACKSignal.SystemStatusChangedToWinServiceSilent, Nothing, "ChangeStatus:WinServiceSilent", LogSource.ClientWinService, Database.None, "", "TerminalsWinService.WinServiceTimer", SystemStatus, SyncCounting)
                        Catch ex As Exception
                            Throw New Exception("TerminalsWinService.WinServiceSilent:" + ex.Message.ToString)
                        End Try
                    ElseIf myNewSystemStatus = SystemStatus.SystemClearNobatsTrucksBufferAndSilent Then
                        Try
                            MClassConfigurationManagement.ActiveFlagForStps(TDBClientStpType.Add, False)
                            MClassConfigurationManagement.ActiveFlagForStps(TDBClientStpType.Del, False)
                            MClassConfigurationManagement.ActiveFlagForStps(TDBClientStpType.Exist, False)
                            MClassConfigurationManagement.ActiveFlagForStps(TDBClientStpType.Sodoor, False)
                            MClassNobatsManagement.WinServiceClearNobatsBuffer()
                            MClassTrucksManagement.WinServiceClearTrucksBuffer()
                            TWS.ACKSignalRecived(MClassAuthenticationManagement.AuthenticationId, MClassConfigurationManagement.GetTerminalId, ACKSignal.SystemStatusChangedToSystemClearNobatsTrucksBufferAndSilent, Nothing, "ChangeStatus:SystemClearNobatsTrucksBufferAndSilent(DeactiveAllStp)", LogSource.ClientWinService, Database.TDBClient, "", "TerminalsWinService.WinServiceTimer", SystemStatus, SyncCounting)
                        Catch ex As Exception
                            Throw New Exception("TerminalsWinService.SystemClearNobatsTrucksBufferAndSilent:" + ex.Message.ToString)
                        End Try
                    ElseIf myNewSystemStatus = SystemStatus.ExecuteNonOutputSqlCommand Then
                        Dim Cmdsql As New SqlClient.SqlCommand
                        Cmdsql.Connection = New SqlClient.SqlConnection(TWSClassConfigurationManagement.GetTDBClientConnectionString)
                        Try
                            Cmdsql.Connection.Open()
                            Cmdsql.CommandText = myCommandOrData
                            Cmdsql.ExecuteNonQuery()
                            Cmdsql.Connection.Close()
                            TWS.ACKSignalRecived(MClassAuthenticationManagement.AuthenticationId, MClassConfigurationManagement.GetTerminalId, ACKSignal.SystemStatusChangedToExecuteNonOutputSqlCommand, Nothing, myCommandOrData.Trim, LogSource.ClientWinService, Database.TDBClient, "", "TerminalsWinService.WinServiceTimer", SystemStatus, SyncCounting)
                        Catch ex As Exception
                            If Cmdsql.Connection.State <> ConnectionState.Closed Then Cmdsql.Connection.Close()
                            Throw New Exception("TerminalsWinService.ExecuteNonOutputSqlCommand:" + ex.Message.ToString)
                        End Try
                    ElseIf myNewSystemStatus = SystemStatus.ExecuteWithOutputSqlCommand Then
                        Try
                            Dim da As New SqlClient.SqlDataAdapter : Dim ds As New DataSet
                            da.SelectCommand = New SqlClient.SqlCommand(myCommandOrData)
                            da.SelectCommand.Connection = New SqlClient.SqlConnection(TWSClassConfigurationManagement.GetTDBClientConnectionString)
                            ds.Tables.Clear()
                            da.Fill(ds)
                            TWS.ACKSignalRecived(MClassAuthenticationManagement.AuthenticationId, MClassConfigurationManagement.GetTerminalId, ACKSignal.SystemStatusChangedToExecuteWithOutputSqlCommand, ds, myCommandOrData.Trim, LogSource.ClientWinService, Database.TDBClient, "", "TerminalsWinService.WinServiceTimer", SystemStatus, SyncCounting)
                        Catch ex As Exception
                            Throw New Exception("TerminalsWinService.ExecuteWithOutputSqlCommand:" + ex.Message.ToString)
                        End Try
                    ElseIf myNewSystemStatus = SystemStatus.SendCurrentStatus Then
                        Try
                            TWS.ACKSignalRecived(MClassAuthenticationManagement.AuthenticationId, MClassConfigurationManagement.GetTerminalId, ACKSignal.SendCurrentStatus, Nothing, "ChangeStatus:SendCurrentStatus CurrentStatus=" + [Enum].GetName(GetType(SystemStatus), SystemStatus), LogSource.ClientWinService, Database.None, "", "TerminalsWinService.WinServiceTimer", SystemStatus, SyncCounting)
                        Catch ex As Exception
                            Throw New Exception("TerminalsWinService.SendCurrentStatus:" + ex.Message.ToString)
                        End Try
                    ElseIf myNewSystemStatus = SystemStatus.SetWinServiceSyncCounting Then
                        Try
                            MClassConfigurationManagement.CreateSyncCountingRegistry(myCommandOrData)
                            SyncCounting = myCommandOrData
                            TWS.ACKSignalRecived(MClassAuthenticationManagement.AuthenticationId, MClassConfigurationManagement.GetTerminalId, ACKSignal.SetWinServiceSyncCounting, Nothing, "ChangeStatus:SetWinServiceSyncCounting NewSyncCounting=" + MClassConfigurationManagement.GetSyncCounting.ToString, LogSource.ClientWinService, Database.None, "", "TerminalsWinService.WinServiceTimer", SystemStatus, SyncCounting)
                        Catch ex As Exception
                            Throw New Exception("TerminalsWinService.SetWinServiceSyncCounting:" + ex.Message.ToString)
                        End Try
                    ElseIf myNewSystemStatus = SystemStatus.SetWinServiceTimerInterval Then
                        Try
                            MClassConfigurationManagement.CreateTimerIntervalRegistry(myCommandOrData)
                            TimerCallTerminalsWebService.Interval = myCommandOrData
                            TimerCallTerminalsWebService.Stop()
                            TimerCallTerminalsWebService.Start()
                            TWS.ACKSignalRecived(MClassAuthenticationManagement.AuthenticationId, MClassConfigurationManagement.GetTerminalId, ACKSignal.SetWinServiceTimerInterval, Nothing, "ChangeStatus:SetWinServiceTimerInterval NewTimerInterval=" + MClassConfigurationManagement.GetTimerInterval.ToString, LogSource.ClientWinService, Database.None, "", "TerminalsWinService.WinServiceTimer", SystemStatus, SyncCounting)
                        Catch ex As Exception
                            Throw New Exception("TerminalsWinService.SetWinServiceTimerInterval:" + ex.Message.ToString)
                        End Try
                    ElseIf myNewSystemStatus = SystemStatus.GetWinServiceConnectionString Then
                        Try
                            TWS.ACKSignalRecived(MClassAuthenticationManagement.AuthenticationId, MClassConfigurationManagement.GetTerminalId, ACKSignal.GetWinServiceConnectionString, Nothing, "ChangeStatus:GetWinServiceConnectionString ConnectionString=" + TWSClassConfigurationManagement.GetTDBClientConnectionString(), LogSource.ClientWinService, Database.TDBClient, "", "TerminalsWinService.WinServiceTimer", SystemStatus, SyncCounting)
                        Catch ex As Exception
                            Throw New Exception("TerminalsWinService.GetWinServiceConnectionString:" + ex.Message.ToString)
                        End Try
                    ElseIf myNewSystemStatus = SystemStatus.GetWinServiceTerminalId Then
                        Try
                            TWS.ACKSignalRecived(MClassAuthenticationManagement.AuthenticationId, MClassConfigurationManagement.GetTerminalId, ACKSignal.GetWinServiceTerminalId, Nothing, "ChangeStatus:GetWinServiceTerminalId TerminalId=" + MClassConfigurationManagement.GetTerminalId.ToString, LogSource.ClientWinService, Database.None, "", "TerminalsWinService.WinServiceTimer", SystemStatus, SyncCounting)
                        Catch ex As Exception
                            Throw New Exception("TerminalsWinService.GetWinServiceTerminalId:" + ex.Message.ToString)
                        End Try
                    ElseIf myNewSystemStatus = SystemStatus.GetWinServiceDateTime Then
                        Try
                            TWS.ACKSignalRecived(MClassAuthenticationManagement.AuthenticationId, MClassConfigurationManagement.GetTerminalId, ACKSignal.GetWinServiceDateTime, Nothing, "ChangeStatus:GetWinServiceDateTime DateTime=" + Date.Now.ToString("yyyy-MM-dd HH:mm:ss"), LogSource.ClientWinService, Database.None, "", "TerminalsWinService.WinServiceTimer", SystemStatus, SyncCounting)
                        Catch ex As Exception
                            Throw New Exception("TerminalsWinService.GetWinServiceDateTime:" + ex.Message.ToString)
                        End Try
                    ElseIf myNewSystemStatus = SystemStatus.GetWinServiceComputerInfo Then
                        Try
                            Dim myAvailablePhysicalMemory As String = " AvailablePhysicalMemory=" + My.Computer.Info.AvailablePhysicalMemory.ToString
                            Dim myAvailableVirtualMemory As String = " AvailableVirtualMemory=" + My.Computer.Info.AvailableVirtualMemory.ToString
                            Dim myInstalledUICulture As String = " InstalledUICulture=" + My.Computer.Info.InstalledUICulture.ToString
                            Dim myOSFullName As String = " OSFullName=" + My.Computer.Info.OSFullName
                            Dim myOSPlatform As String = " OSPlatform=" + My.Computer.Info.OSPlatform
                            Dim myOSVersion As String = " OSVersion=" + My.Computer.Info.OSVersion
                            Dim myTotalPhysicalMemory As String = " TotalPhysicalMemory=" + My.Computer.Info.TotalPhysicalMemory.ToString
                            Dim myTotalVirtualMemory As String = " TotalVirtualMemory=" + My.Computer.Info.TotalVirtualMemory.ToString
                            Dim myComputerName As String = " ComputerName=" + My.Computer.Name
                            Dim myDisplayResolution As String = " DisplayResolution=" + My.Computer.Screen.Bounds.ToString
                            Dim myNote As String = myAvailablePhysicalMemory + myAvailableVirtualMemory + myInstalledUICulture + myOSFullName + myOSPlatform + myOSVersion + myTotalPhysicalMemory + myTotalVirtualMemory + myComputerName + myDisplayResolution
                            TWS.ACKSignalRecived(MClassAuthenticationManagement.AuthenticationId, MClassConfigurationManagement.GetTerminalId, ACKSignal.GetWinServiceComputerInfo, Nothing, "ChangeStatus:GetWinServiceComputerInfo ComputerInfo=" + myNote, LogSource.ClientWinService, Database.None, "", "TerminalsWinService.WinServiceTimer", SystemStatus, SyncCounting)
                        Catch ex As Exception
                            Throw New Exception("TerminalsWinService.GetWinServiceComputerInfo:" + ex.Message.ToString)
                        End Try
                    ElseIf myNewSystemStatus = SystemStatus.GetExistNobatsInOtherData Then
                        Try
                            Dim da As New SqlClient.SqlDataAdapter : Dim ds As New DataSet
                            da.SelectCommand = New SqlClient.SqlCommand(myCommandOrData) 'دستور خاص براي دريافت اطلاعات از جدول مذکور
                            da.SelectCommand.Connection = New SqlClient.SqlConnection(TWSClassConfigurationManagement.GetTDBClientConnectionString)
                            ds.Tables.Clear()
                            da.Fill(ds)
                            TWS.ACKSignalRecived(MClassAuthenticationManagement.AuthenticationId, MClassConfigurationManagement.GetTerminalId, ACKSignal.GetExistNobatsInOtherData, ds, myCommandOrData.Trim, LogSource.ClientWinService, Database.TDBClient, "", "TerminalsWinService.WinServiceTimer", SystemStatus, SyncCounting)
                        Catch ex As Exception
                            Throw New Exception("TerminalsWinService.GetExistNobatsInOtherData:" + ex.Message.ToString)
                        End Try
                    ElseIf myNewSystemStatus = SystemStatus.GetSTPsTblConfigurationData Then
                        Try
                            Dim da As New SqlClient.SqlDataAdapter : Dim ds As New DataSet
                            da.SelectCommand = New SqlClient.SqlCommand(myCommandOrData) 'دستور خاص براي دريافت اطلاعات از جدول مذکور
                            da.SelectCommand.Connection = New SqlClient.SqlConnection(TWSClassConfigurationManagement.GetTDBClientConnectionString)
                            ds.Tables.Clear()
                            da.Fill(ds)
                            TWS.ACKSignalRecived(MClassAuthenticationManagement.AuthenticationId, MClassConfigurationManagement.GetTerminalId, ACKSignal.GetSTPsTblConfigurationData, ds, "ChangeStatus:GetSTPsTblConfigurationData", LogSource.ClientWinService, Database.TDBClient, "", "TerminalsWinService.WinServiceTimer", SystemStatus, SyncCounting)
                        Catch ex As Exception
                            Throw New Exception("TerminalsWinService.GetSTPsTblConfigurationData:" + ex.Message.ToString)
                        End Try
                    End If
                    SystemStatusCommandId = myNewSystemCommandId.Trim
                    SystemStatus = myNewSystemStatus
                    'TWS.ACKSignalRecived(MClassAuthenticationManagement.AuthenticationId, MClassConfigurationManagement.GetTerminalId, ACKSignal.NoneOrMsg, Nothing, "ChangeStatus:CommandId=" + SystemStatusCommandId, LogSource.ClientWinService, Database.None, "", "TerminalsWinService.WinServiceTimer", SystemStatus, SyncCounting)
                End If
            End If

            'Garbage
            If GarbageCounting = 10 Then
                Dim CmdSqlGarbage As New SqlClient.SqlCommand
                CmdSqlGarbage.Connection = New SqlClient.SqlConnection(TWSClassConfigurationManagement.GetTDBClientConnectionString())
                Try
                    Dim daGarbage As New SqlClient.SqlDataAdapter : Dim dsGarbage As New DataSet
                    daGarbage.SelectCommand = New SqlClient.SqlCommand("select count(*) as TrucksDeletedLocaly  from TblsyncserverNobats where (TravelTime<>0) and (DATEDIFF(HOUR,SodoorTime,GETDATE())>=TravelTime)")
                    daGarbage.SelectCommand.Connection = New SqlClient.SqlConnection(TWSClassConfigurationManagement.GetTDBClientConnectionString())
                    dsGarbage.Tables.Clear()
                    daGarbage.Fill(dsGarbage)
                    Dim myTrucksDeletedLocaly As Int16 = dsGarbage.Tables(0).Rows(0).Item("TrucksDeletedLocaly")
                    CmdSqlGarbage.Connection.Open()
                    CmdSqlGarbage.CommandText = "delete from TblsyncserverNobats where (TravelTime<>0) and (DATEDIFF(HOUR,SodoorTime,GETDATE())>=TravelTime)"
                    CmdSqlGarbage.ExecuteNonQuery()
                    CmdSqlGarbage.Connection.Close()
                    GarbageCounting = 0
                    TWS.ACKSignalRecived(MClassAuthenticationManagement.AuthenticationId, MClassConfigurationManagement.GetTerminalId, ACKSignal.NoneOrMsg, Nothing, myTrucksDeletedLocaly.ToString + "  Trucks Deleted By LocalGarbage.", LogSource.ClientWinService, Database.None, "", "TerminalsWinService.WinServiceTimer", SystemStatus, SyncCounting)
                Catch ex As Exception
                    If CmdSqlGarbage.Connection.State <> ConnectionState.Closed Then CmdSqlGarbage.Connection.Close()
                    Throw New Exception("Garbage." + ex.Message.ToString)
                End Try
            Else
                GarbageCounting += 1
            End If

            If SystemStatus = SystemStatus.SystemGeneral Then
                'سرويس بايد فرآيند سنکرون کردن نوبت ها را انجام دهد 
                If SyncCounting >= MClassConfigurationManagement.GetSyncCounting Then
                    Try
                        'فراخواني اول
                        'ارسال ليست ناوگان جديد به سرور و دريافت تغييرات ناوگان از سرور
                        Dim dsSyncChangedTrucks As DataSet = MClassTrucksManagement.GetNewTrucks()
                        If dsSyncChangedTrucks.Tables(0).Rows.Count <> 0 Then
                            Dim dsSyncChangedTrucksFromServer As DataSet = TWS.WebMethodSyncTrucks(MClassAuthenticationManagement.AuthenticationId, MClassConfigurationManagement.GetTerminalId, dsSyncChangedTrucks)
                            MClassTrucksManagement.SetSyncChangedTrucks(dsSyncChangedTrucksFromServer)
                            Dim myDataCollection As New DataSet
                            Dim mydtArray() As DataTable
                            ReDim mydtArray(2)
                            mydtArray(0) = New DataTable : mydtArray(1) = New DataTable
                            dsSyncChangedTrucks.Tables(0).TableName = "1"
                            mydtArray(0) = dsSyncChangedTrucks.Tables(0).Copy
                            dsSyncChangedTrucksFromServer.Tables(0).TableName = "2"
                            mydtArray(1) = dsSyncChangedTrucksFromServer.Tables(0).Copy
                            myDataCollection.Tables.AddRange(mydtArray)
                            TWS.ACKSignalRecived(MClassAuthenticationManagement.AuthenticationId, MClassConfigurationManagement.GetTerminalId, ACKSignal.WebMethodSyncTrucks, myDataCollection, "FirstCall:SyncTrucks", LogSource.ClientWinService, Database.None, "", "TerminalsWinService.WinServiceTimer", SystemStatus, SyncCounting)
                        End If
                    Catch ex As Exception
                        Throw New Exception("TerminalsWinService.FirstCall:" + ex.Message.ToString)
                    End Try
                    Try
                        'فراخواني دوم
                        'ارسال ليست تغييرات نوبت به سرور و دريافت تغييرات و اعمال آنها
                        Dim dsSyncNobats As New DataSet
                        Dim dsSyncTrucks As New DataSet
                        Dim dsSyncTerminals As New DataSet
                        Dim dsSyncNobatsForSendToServer As DataSet = MClassNobatsManagement.GetSyncChangedNobats
                        TWS.WebMethodSyncAll(MClassAuthenticationManagement.AuthenticationId, MClassConfigurationManagement.GetTerminalId, dsSyncNobatsForSendToServer, dsSyncNobats, dsSyncTrucks, dsSyncTerminals)
                        MClassNobatsManagement.DelSyncChangedNobats()
                        MClassTrucksManagement.SetSyncChangedTrucks(dsSyncTrucks)
                        MClassNobatsManagement.SetSyncChangedNobats(dsSyncNobats)
                        MClassTerminalsManagement.SetSyncChangedTerminals(dsSyncTerminals)
                        Dim myDataCollection As New DataSet
                        Dim mydtArray() As DataTable
                        ReDim mydtArray(4)
                        mydtArray(0) = New DataTable : mydtArray(1) = New DataTable : mydtArray(2) = New DataTable : mydtArray(3) = New DataTable
                        dsSyncNobatsForSendToServer.Tables(0).TableName = "1"
                        mydtArray(0) = dsSyncNobatsForSendToServer.Tables(0).Copy
                        dsSyncNobats.Tables(0).TableName = "2"
                        mydtArray(1) = dsSyncNobats.Tables(0).Copy
                        dsSyncTrucks.Tables(0).TableName = "3"
                        mydtArray(2) = dsSyncTrucks.Tables(0).Copy
                        dsSyncTerminals.Tables(0).TableName = "4"
                        mydtArray(3) = dsSyncTerminals.Tables(0).Copy
                        myDataCollection.Tables.AddRange(mydtArray)
                        TWS.ACKSignalRecived(MClassAuthenticationManagement.AuthenticationId, MClassConfigurationManagement.GetTerminalId, ACKSignal.WebMethodSyncAll, myDataCollection, "SecondCall:SyncAll", LogSource.ClientWinService, Database.None, "", "TerminalsWinService.WinServiceTimer", SystemStatus, SyncCounting)
                    Catch ex As Exception
                        Throw New Exception("TerminalsWinService.SecondCall:" + ex.Message.ToString)
                    End Try
                    SyncCounting = 0
                Else
                    SyncCounting += 1
                End If
            End If
        Catch ex As Exception
            EventLog.WriteEntry("TWSCLTSource", ex.Message.ToString, EventLogEntryType.Error)
            TWS.ACKSignalRecived(MClassAuthenticationManagement.AuthenticationId, MClassConfigurationManagement.GetTerminalId, ACKSignal.AckError, Nothing, ex.Message.ToString, LogSource.ClientWinService, Database.None, "", "TerminalsWinService.WinServiceTimer", SystemStatus, SyncCounting)
        End Try
    End Sub

End Class
