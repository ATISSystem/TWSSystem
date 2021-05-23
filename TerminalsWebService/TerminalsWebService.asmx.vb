
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.IO
Imports System.Globalization

Imports TWSClassLibrary
Imports TWSClassLibrary.AckSignalManagement
Imports TWSClassLibrary.LoggingManagement
Imports TWSClassLibrary.LoggingManagement.TWSClassLoggingManagement
Imports TWSClassLibrary.DatabaseManagement
Imports TWSClassLibrary.DatabaseManagement.TWSClassDatabaseManagement
Imports TWSClassLibrary.TerminalsManagement.TWSClassTerminalsManagement
Imports TWSClassLibrary.DateAndTimeManagement.TWSClassDateAndTimeManagement
Imports TWSClassLibrary.SystemStatusManagement
Imports TWSClassLibrary.SystemStatusManagement.TWSClassSystemStatusManagement
Imports TWSClassLibrary.TrucksManagement.TWSClassTrucksManagement
Imports TWSClassLibrary.ConfigurationManagement


' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://localhost/")>
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)>
<ToolboxItem(False)>
Public Class TerminalsWebService
    Inherits System.Web.Services.WebService




#Region "System Status"
    <WebMethod()>
    Public Sub WebMethodSetNewSystemStatus(ByVal AId As String, ByVal Status As SystemStatus, ByVal TerminalId As Int16, ByVal CommandValueData As String)
        Try
            If MClassAuthenticationManagement.IsAuthenticationIdValid(AId) = False Then Exit Sub
            MClassSystemStatusManagement.SetSystemStatusInf(Status, TerminalId, MClassSystemStatusManagement.GetNewSystemStatusCommandId, CommandValueData)
            Select Case Status
                Case SystemStatus.SystemClearNobatsTrucksBufferAndSilent
                    MClassNobatsManagement.WebServiceClearNobatsBuffer()
                    MClassTrucksManagement.WebServiceClearTrucksBuffer()
                Case SystemStatus.SystemGeneral
                Case SystemStatus.SystemFullSilent
                Case SystemStatus.WinServiceSilent
                Case SystemStatus.StpExistNobatSilent
                Case SystemStatus.ExecuteNonOutputSqlCommand
                Case SystemStatus.ExecuteWithOutputSqlCommand
                Case SystemStatus.SendCurrentStatus
                Case SystemStatus.SetWinServiceTimerInterval
                Case SystemStatus.SetWinServiceSyncCounting
                Case SystemStatus.GetWinServiceConnectionString
                Case SystemStatus.GetWinServiceTerminalId
                Case SystemStatus.GetWinServiceDateTime
                Case SystemStatus.GetWinServiceComputerInfo
                Case SystemStatus.GetExistNobatsInOtherData
                Case SystemStatus.GetSTPsTblConfigurationData
            End Select
            Dim mySystemStatus As SystemStatus
            Dim myTerminalIdToChangeStatus As Int16
            Dim myCommandId As String
            Dim myCommandOrValueData As String
            MClassSystemStatusManagement.GetSystemStatusInf(mySystemStatus, myTerminalIdToChangeStatus, myCommandId, myCommandOrValueData)
            LoggingMessageSabt(Logging.WebMethodSetNewSystemStatus, LogSource.ServerWebService, Database.None, "", 0, "", "WebMethodSetNewSystemStatus", True, AId, ACKSignal.NoneOrMsg, Nothing, SystemStatus.None, 0, "SystemStatus=" + [Enum].GetName(GetType(SystemStatus), mySystemStatus) + " SystemStatusCommandId=" + myCommandId.Trim + " TerminalIdToChangeStatus=" + myTerminalIdToChangeStatus.ToString + " CommandValueData=" + myCommandOrValueData.Trim)
        Catch ex As Exception
            EventLog.WriteEntry("TWSServerSource", "TerminalsWebService.WebMethodSetNewSystemStatus()." + ex.Message.ToString, EventLogEntryType.Error)
            LoggingMessageSabt(Logging.ErrorLog, LogSource.ServerWebService, Database.None, "", 0, "", "WebMethodSetNewSystemStatus", False, AId, ACKSignal.NoneOrMsg, Nothing, MClassSystemStatusManagement.GetSystemStatus, 0, ex.Message.ToString)
            Throw New Exception("TerminalsWebService.WebMethodSetNewSystemStatus()." + ex.Message.ToString)
        End Try
    End Sub
    <WebMethod()>
    Public Function WebMethodGetNewSystemStatus(ByVal AId As String, ByRef TerminalIdToChangeStatuss As Int16, ByRef CommandId As String, ByRef CommandValueData As String) As SystemStatus
        Try
            If MClassAuthenticationManagement.IsAuthenticationIdValid(AId) = False Then Exit Function
            Dim mySystemStatus As SystemStatus
            MClassSystemStatusManagement.GetSystemStatusInf(mySystemStatus, TerminalIdToChangeStatuss, CommandId, CommandValueData)
            LoggingMessageSabt(Logging.WebMethodGetNewSystemStatus, LogSource.ServerWebService, Database.None, "", 0, "", "WebMethodGetNewSystemStatus", True, AId, ACKSignal.NoneOrMsg, Nothing, MClassSystemStatusManagement.GetSystemStatus, 0, "SystemStatus=" + [Enum].GetName(GetType(SystemStatus), mySystemStatus) + " SystemStatusCommandId=" + CommandId.Trim + " TerminalIdToChangeStatus=" + TerminalIdToChangeStatuss.ToString + " CommandValueData=" + CommandValueData)
            Return mySystemStatus
        Catch ex As Exception
            EventLog.WriteEntry("TWSServerSource", "TerminalsWebService.WebMethodGetNewSystemStatus()." + ex.Message.ToString, EventLogEntryType.Error)
            LoggingMessageSabt(Logging.ErrorLog, LogSource.ServerWebService, Database.None, "", 0, "", "WebMethodGetNewSystemStatus", False, AId, ACKSignal.NoneOrMsg, Nothing, MClassSystemStatusManagement.GetSystemStatus, 0, ex.Message.ToString)
            Throw New Exception("TerminalsWebService.WebMethodGetNewSystemStatus()." + ex.Message.ToString)
        End Try
    End Function
#End Region
#Region "AckSignal"
    <WebMethod()>
    Public Sub ACKSignalRecived(ByVal AId As String, ByVal TerminalId As Int16, ByVal ACKSignall As ACKSignal, ByVal Data As DataSet, ByVal AckNoteString As String, ByVal LogSource As LogSource, ByVal TDB As Database, ByVal UserName As String, ByVal MethodName As String, ByVal SystemStatuss As SystemStatus, ByVal SyncCounting As Byte)
        Try
            If MClassAuthenticationManagement.IsAuthenticationIdValid(AId) = False Then Exit Sub
            Select Case ACKSignall
                Case ACKSignal.NoneOrMsg
                    LoggingMessageSabt(Logging.NoneOrMsg, LogSource, TDB, "", TerminalId, UserName, MethodName, True, AId, ACKSignall, Data, SystemStatuss, SyncCounting, AckNoteString)
                Case ACKSignal.AckError
                    LoggingMessageSabt(Logging.ErrorLog, LogSource, TDB, "", TerminalId, UserName, MethodName, True, AId, ACKSignall, Data, SystemStatuss, SyncCounting, AckNoteString)
                Case ACKSignal.WebMethodSyncTrucks
                    MClassTrucksManagement.DeleteSyncChangedTrucks(TerminalId)
                    LoggingMessageSabt(Logging.SyncTrucks, LogSource, TDB, "", TerminalId, UserName, MethodName, True, AId, ACKSignall, Data, SystemStatuss, SyncCounting, AckNoteString)
                Case ACKSignal.WebMethodSyncAll
                    MClassNobatsManagement.DeleteSyncChangedNobats(TerminalId)
                    MClassTerminalsManagement.DeleteSyncChangedTerminals(TerminalId)
                    MClassTrucksManagement.DeleteSyncChangedTrucks(TerminalId)
                    LoggingMessageSabt(Logging.SyncAll, LogSource, TDB, "", TerminalId, UserName, MethodName, True, AId, ACKSignall, Data, SystemStatuss, SyncCounting, AckNoteString)
                Case ACKSignal.SystemStatusChangedToSystemGeneral
                    LoggingMessageSabt(Logging.SystemStatusChangedToSystemGeneral, LogSource, TDB, "", TerminalId, UserName, MethodName, True, AId, ACKSignall, Data, SystemStatuss, SyncCounting, AckNoteString)
                Case ACKSignal.SystemStatusChangedToSystemClearNobatsTrucksBufferAndSilent
                    LoggingMessageSabt(Logging.SystemStatusChangedToSystemClearNobatsTrucksBufferAndSilent, LogSource, TDB, "", TerminalId, UserName, MethodName, True, AId, ACKSignall, Data, SystemStatuss, SyncCounting, AckNoteString)
                Case ACKSignal.SystemStatusChangedToSystemFullSilent
                    LoggingMessageSabt(Logging.SystemStatusChangedToSystemFullSilent, LogSource, TDB, "", TerminalId, UserName, MethodName, True, AId, ACKSignall, Data, SystemStatuss, SyncCounting, AckNoteString)
                Case ACKSignal.SystemStatusChangedToWinServiceSilent
                    LoggingMessageSabt(Logging.SystemStatusChangedToWinServiceSilent, LogSource, TDB, "", TerminalId, UserName, MethodName, True, AId, ACKSignall, Data, SystemStatuss, SyncCounting, AckNoteString)
                Case ACKSignal.SystemStatusChangedToStpExistNobatSilent
                    LoggingMessageSabt(Logging.SystemStatusChangedToStpExistNobatSilent, LogSource, TDB, "", TerminalId, UserName, MethodName, True, AId, ACKSignall, Data, SystemStatuss, SyncCounting, AckNoteString)
                Case ACKSignal.SystemStatusChangedToExecuteNonOutputSqlCommand
                    LoggingMessageSabt(Logging.SystemStatusChangedToExecuteNonOutputSqlCommand, LogSource, TDB, "", TerminalId, UserName, MethodName, True, AId, ACKSignall, Data, SystemStatuss, SyncCounting, AckNoteString)
                Case ACKSignal.SystemStatusChangedToExecuteWithOutputSqlCommand
                    Data.WriteXml("c:\TWSLog\TWSDataRecived.txt")
                    LoggingMessageSabt(Logging.SystemStatusChangedToExecuteWithOutputSqlCommand, LogSource, TDB, "", TerminalId, UserName, MethodName, True, AId, ACKSignall, Data, SystemStatuss, SyncCounting, AckNoteString + ControlChars.CrLf + Data.GetXml())
                Case ACKSignal.WinServiceStart
                    LoggingMessageSabt(Logging.WinServiceStart, LogSource, TDB, "", TerminalId, UserName, MethodName, True, AId, ACKSignall, Data, SystemStatuss, SyncCounting, AckNoteString)
                Case ACKSignal.WinServiceStop
                    LoggingMessageSabt(Logging.WinServiceStop, LogSource, TDB, "", TerminalId, UserName, MethodName, True, AId, ACKSignall, Data, SystemStatuss, SyncCounting, AckNoteString)
                Case ACKSignal.SendCurrentStatus
                    LoggingMessageSabt(Logging.SendCurrentStatus, LogSource, TDB, "", TerminalId, UserName, MethodName, True, AId, ACKSignall, Data, SystemStatuss, SyncCounting, AckNoteString)
                Case ACKSignal.SetWinServiceTimerInterval
                    LoggingMessageSabt(Logging.SetWinServiceTimerInterval, LogSource, TDB, "", TerminalId, UserName, MethodName, True, AId, ACKSignall, Data, SystemStatuss, SyncCounting, AckNoteString)
                Case ACKSignal.SetWinServiceSyncCounting
                    LoggingMessageSabt(Logging.SetWinServiceSyncCounting, LogSource, TDB, "", TerminalId, UserName, MethodName, True, AId, ACKSignall, Data, SystemStatuss, SyncCounting, AckNoteString)
                Case ACKSignal.GetWinServiceConnectionString
                    LoggingMessageSabt(Logging.GetWinServiceConnectionString, LogSource, TDB, "", TerminalId, UserName, MethodName, True, AId, ACKSignall, Data, SystemStatuss, SyncCounting, AckNoteString)
                Case ACKSignal.GetWinServiceTerminalId
                    LoggingMessageSabt(Logging.GetWinServiceTerminalId, LogSource, TDB, "", TerminalId, UserName, MethodName, True, AId, ACKSignall, Data, SystemStatuss, SyncCounting, AckNoteString)
                Case ACKSignal.GetWinServiceDateTime
                    LoggingMessageSabt(Logging.GetWinServiceDateTime, LogSource, TDB, "", TerminalId, UserName, MethodName, True, AId, ACKSignall, Data, SystemStatuss, SyncCounting, AckNoteString)
                Case ACKSignal.GetWinServiceComputerInfo
                    LoggingMessageSabt(Logging.GetWinServiceComputerInfo, LogSource, TDB, "", TerminalId, UserName, MethodName, True, AId, ACKSignall, Data, SystemStatuss, SyncCounting, AckNoteString)
                Case ACKSignal.GetExistNobatsInOtherData
                    Data.WriteXml("c:\TWSLog\TWSClientExistNobatsInOther.txt")
                    LoggingMessageSabt(Logging.GetExistNobatsInOtherData, LogSource, TDB, "", TerminalId, UserName, MethodName, True, AId, ACKSignall, Data, SystemStatuss, SyncCounting, AckNoteString)
                Case ACKSignal.GetSTPsTblConfigurationData
                    Data.WriteXml("c:\TWSLog\TWSClientSTPsTblConfiguration.txt")
                    LoggingMessageSabt(Logging.GetSTPsTblConfigurationData, LogSource, TDB, "", TerminalId, UserName, MethodName, True, AId, ACKSignall, Data, SystemStatuss, SyncCounting, AckNoteString + ControlChars.CrLf + Data.GetXml())
                Case ACKSignal.IdentifyTerminal
                    LoggingMessageSabt(Logging.IdentifyTerminal, LogSource, TDB, "", TerminalId, UserName, MethodName, True, AId, ACKSignall, Data, SystemStatuss, SyncCounting, AckNoteString)
                Case ACKSignal.ClientWinAppSettingSqlServerAdmin
                    LoggingMessageSabt(Logging.ClientWinAppSettingSqlServerAdmin, LogSource, TDB, "", TerminalId, UserName, MethodName, True, AId, ACKSignall, Data, SystemStatuss, SyncCounting, AckNoteString)
                Case ACKSignal.ClientWinAppServiceStart
                    LoggingMessageSabt(Logging.ClientWinAppServiceStart, LogSource, TDB, "", TerminalId, UserName, MethodName, True, AId, ACKSignall, Data, SystemStatuss, SyncCounting, AckNoteString)
                Case ACKSignal.ServerWinServiceStart
                    LoggingMessageSabt(Logging.ServerWinServiceStart, LogSource, TDB, "", TerminalId, UserName, MethodName, True, AId, ACKSignall, Data, SystemStatuss, SyncCounting, AckNoteString)
                Case ACKSignal.ServerWinServiceStop
                    LoggingMessageSabt(Logging.ServerWinServiceStop, LogSource, TDB, "", TerminalId, UserName, MethodName, True, AId, ACKSignall, Data, SystemStatuss, SyncCounting, AckNoteString)
                Case ACKSignal.ServerWinServiceGarbageTimerElapsed
                    Data.WriteXml("c:\TWSLog\TWSServerWinServiceGarbageTimerElapsed.txt")
                    LoggingMessageSabt(Logging.ServerWinServiceGarbageTimerElapsed, LogSource, TDB, "", TerminalId, UserName, MethodName, True, AId, ACKSignall, Data, SystemStatuss, SyncCounting, AckNoteString + ControlChars.CrLf + Data.GetXml())
                Case ACKSignal.ServerWinAppCreateTerminal
                    LoggingMessageSabt(Logging.ServerWinAppCreateTerminal, LogSource, TDB, "", TerminalId, UserName, MethodName, True, AId, ACKSignall, Data, SystemStatuss, SyncCounting, AckNoteString)
                Case ACKSignal.ClientWinReportAppTimerStart
                    LoggingMessageSabt(Logging.ClientWinReportAppTimerStart, LogSource, TDB, "", TerminalId, UserName, MethodName, True, AId, ACKSignall, Data, SystemStatuss, SyncCounting, AckNoteString)
                Case ACKSignal.ClientWinReportAppPassOk
                    LoggingMessageSabt(Logging.ClientWinReportAppPassOk, LogSource, TDB, "", TerminalId, UserName, MethodName, True, AId, ACKSignall, Data, SystemStatuss, SyncCounting, AckNoteString)
                Case ACKSignal.CenterControlChangeSystemStatus
                    LoggingMessageSabt(Logging.CenterControlChangeSystemStatus, LogSource, TDB, "", TerminalId, UserName, MethodName, True, AId, ACKSignall, Data, SystemStatuss, SyncCounting, AckNoteString)
            End Select
        Catch ex As Exception
            EventLog.WriteEntry("TWSServerSource", "TerminalsWebService.ACKSignalRecived()." + ex.Message.ToString, EventLogEntryType.Error)
            LoggingMessageSabt(Logging.ErrorLog, LogSource.ServerWebService, Database.None, "", 0, "", "ACKSignalRecived", False, AId, ACKSignal.NoneOrMsg, Nothing, MClassSystemStatusManagement.GetSystemStatus, 0, ex.Message.ToString)
            Throw New Exception("TerminalsWebService.ACKSignalRecived()." + ex.Message.ToString)
        End Try
    End Sub
#End Region
#Region "Sync Trucks And Nobats And Terminals"
    <WebMethod()>
    Public Function WebMethodSyncTrucks(ByVal AId As String, ByVal TerminalID As Int16, ByVal ClientNewTrucks As DataSet) As DataSet
        Try
            If MClassAuthenticationManagement.IsAuthenticationIdValid(AId) = False Then Exit Function
            'بروز رساني ليست ناوگان جديد از هر پايانه
            MClassTrucksManagement.UpdateFromClientNewTrucks(ClientNewTrucks)
            'بازگشت تغييرات ليست ناوگان به پايانه
            Dim dsTrucks As DataSet = MClassTrucksManagement.GetSyncChangedTrucks(TerminalID)
            Return dsTrucks
        Catch ex As Exception
            EventLog.WriteEntry("TWSServerSource", "TerminalsWebService.WebMethodSyncTrucks()." + ex.Message.ToString, EventLogEntryType.Error)
            LoggingMessageSabt(Logging.ErrorLog, LogSource.ServerWebService, Database.None, "", 0, "", "WebMethodSyncTrucks", False, AId, ACKSignal.NoneOrMsg, Nothing, MClassSystemStatusManagement.GetSystemStatus, 0, ex.Message.ToString)
            Throw New Exception("TerminalsWebService.WebMethodSyncTrucks()." + ex.Message.ToString)
        End Try
    End Function
    <WebMethod()> _
    Public Sub WebMethodSyncAll(ByVal AId As String, ByVal TerminalID As Int16, ByVal ClientNewNobats As DataSet, ByRef SyncNobats As DataSet, ByRef SyncTrucks As DataSet, ByRef SyncTerminals As DataSet)
        Try
            If MClassAuthenticationManagement.IsAuthenticationIdValid(AId) = False Then Exit Sub
            ' بروز رساني تغييرات نوبت از پايانه 
            MClassNobatsManagement.UpdateFromClientNewNobats(TerminalID, ClientNewNobats)
            'ارسال تغييرات به پايانه
            SyncNobats = MClassNobatsManagement.GetSyncChangedNobats(TerminalID)
            SyncTrucks = MClassTrucksManagement.GetSyncChangedTrucks(TerminalID)
            SyncTerminals = MClassTerminalsManagement.GetSyncChangedTerminals(TerminalID)
        Catch ex As Exception
            EventLog.WriteEntry("TWSServerSource", "TerminalsWebService.WebMethodSyncAll()." + ex.Message.ToString, EventLogEntryType.Error)
            LoggingMessageSabt(Logging.ErrorLog, LogSource.ServerWebService, Database.None, "", 0, "", "WebMethodSyncAll", False, AId, ACKSignal.NoneOrMsg, Nothing, MClassSystemStatusManagement.GetSystemStatus, 0, ex.Message.ToString)
            Throw New Exception("TerminalsWebService.WebMethodSyncAll()." + ex.Message.ToString)
        End Try
    End Sub

#End Region
#Region "Identify And Create New Terminals"
    <WebMethod()> _
    Public Function WebMethodIdentifyTerminal(ByVal AId As String, ByVal IdentifyCode As String) As Int16
        Try
            If MClassAuthenticationManagement.IsAuthenticationIdValid(AId) = False Then Exit Function
            Dim da As New SqlClient.SqlDataAdapter : Dim ds As New DataSet
            da.SelectCommand = New SqlClient.SqlCommand("select TerminalId from TblTerminals where ltrim(rtrim(RndCode))='" & IdentifyCode.Trim & "'")
            da.SelectCommand.Connection = New SqlClient.SqlConnection(TWSClassConfigurationManagement.GetTDBServerConnectionString)
            ds.Tables.Clear()
            If da.Fill(ds) <> 0 Then
                Return ds.Tables(0).Rows(0).Item(0)
            Else
                Throw New Exception("Non Standard IdentifyCode")
            End If
        Catch ex As Exception
            EventLog.WriteEntry("TWSServerSource", "TerminalsWebService.WebMethodIdentifyTerminal()." + ex.Message.ToString, EventLogEntryType.Error)
            LoggingMessageSabt(Logging.ErrorLog, LogSource.ServerWebService, Database.None, "", 0, "", "WebMethodIdentifyTerminal", False, AId, ACKSignal.NoneOrMsg, Nothing, MClassSystemStatusManagement.GetSystemStatus, 0, ex.Message.ToString)
            Throw New Exception("TerminalsWebService.WebMethodIdentifyTerminal()." + ex.Message.ToString)
        End Try
    End Function
    <WebMethod()> _
    Public Sub WebMethodCreateNewterminal(ByVal AId As String, ByVal TerminalName As String, ByRef TerminalId As Int16, ByRef IdentifyCode As String)
        Try
            If MClassAuthenticationManagement.IsAuthenticationIdValid(AId) = False Then Exit Sub
            AddTerminal(TerminalName, IdentifyCode, TerminalId)
        Catch ex As Exception
            EventLog.WriteEntry("TWSServerSource", "TerminalsWebService.WebMethodCreateNewterminal()." + ex.Message.ToString, EventLogEntryType.Error)
            LoggingMessageSabt(Logging.ErrorLog, LogSource.ServerWebService, Database.None, "", 0, "", "WebMethodCreateNewterminal", False, AId, ACKSignal.NoneOrMsg, Nothing, MClassSystemStatusManagement.GetSystemStatus, 0, ex.Message.ToString)
            Throw New Exception("TerminalsWebService.WebMethodCreateNewterminal()." + ex.Message.ToString)
        End Try
    End Sub
    <WebMethod()> _
    Public Function WebMethodTerminalIdFromTerminalName(ByVal AId As String, ByVal TerminalName As String) As Int16
        Try
            If MClassAuthenticationManagement.IsAuthenticationIdValid(AId) = False Then Exit Function
            Dim da As New SqlClient.SqlDataAdapter : Dim ds As New DataSet
            da.SelectCommand = New SqlClient.SqlCommand("select TerminalId from TblTerminals where ltrim(rtrim(TerminalName))='" & TerminalName & "'")
            da.SelectCommand.Connection = New SqlClient.SqlConnection(TWSClassConfigurationManagement.GetTDBServerConnectionString)
            ds.Tables.Clear()
            da.Fill(ds)
            Return ds.Tables(0).Rows(0).Item(0)
        Catch ex As Exception
            EventLog.WriteEntry("TWSServerSource", "TerminalsWebService.WebMethodTerminalIdFromTerminalName()." + ex.Message.ToString, EventLogEntryType.Error)
            LoggingMessageSabt(Logging.ErrorLog, LogSource.ServerWebService, Database.None, "", 0, "", "WebMethodTerminalIdFromTerminalName", False, AId, ACKSignal.NoneOrMsg, Nothing, MClassSystemStatusManagement.GetSystemStatus, 0, ex.Message.ToString)
            Throw New Exception("TerminalsWebService.WebMethodTerminalIdFromTerminalName()." + ex.Message.ToString)
        End Try
    End Function


#End Region
#Region "Reporting"
    <WebMethod()> _
    Public Function WebMethodLoggingReport(ByVal AId As String, ByVal DateAndTime As DateTime, ByRef Data As DataSet) As Int16
        Try
            If MClassAuthenticationManagement.IsAuthenticationIdValid(AId) = False Then Exit Function
            Data = GetLoggingReport(DateAndTime)
            Return Data.Tables(0).Rows.Count
        Catch ex As Exception
            EventLog.WriteEntry("TWSServerSource", "TerminalsWebService.WebMethodLoggingReport()." + ex.Message.ToString, EventLogEntryType.Error)
            LoggingMessageSabt(Logging.ErrorLog, LogSource.ServerWebService, Database.None, "", 0, "", "WebMethodLoggingReport", False, AId, ACKSignal.NoneOrMsg, Nothing, MClassSystemStatusManagement.GetSystemStatus, 0, ex.Message.ToString)
            Throw New Exception("TerminalsWebService.WebMethodLoggingReport()." + ex.Message.ToString)
        End Try
    End Function
    <WebMethod()> _
    Public Function WebMethodGetTruckTrace(ByVal AId As String, ByVal Pelak As String, ByVal Serial As String, ByVal TotalRec As Int16, ByRef Data As DataSet) As TruckTrace
        Try
            If MClassAuthenticationManagement.IsAuthenticationIdValid(AId) = False Then Exit Function
            Dim myTruckid As Int16
            If ExistTruck(Pelak, Serial, New SqlClient.SqlConnection(TWSClassConfigurationManagement.GetTDBServerConnectionString), myTruckid) = False Then
                Return TruckTrace.NoPelakSerialFound
            End If
            Data = GetTruckTrace(myTruckid, TotalRec)
            If Data.Tables(0).Rows.Count = 0 Then
                Return TruckTrace.NoRecordFound
            End If
            Return TruckTrace.OK
        Catch ex As Exception
            EventLog.WriteEntry("TWSServerSource", "TerminalsWebService.WebMethodGetTruckTrace()." + ex.Message.ToString, EventLogEntryType.Error)
            LoggingMessageSabt(Logging.ErrorLog, LogSource.ServerWebService, Database.None, "", 0, "", "WebMethodGetTruckTrace", False, AId, ACKSignal.NoneOrMsg, Nothing, MClassSystemStatusManagement.GetSystemStatus, 0, ex.Message.ToString)
            Throw New Exception("TerminalsWebService.WebMethodGetTruckTrace()." + ex.Message.ToString)
        End Try
    End Function
    <WebMethod()> _
    Public Function WebMethodGetLastNobatInOnlineifExist(ByVal AId As String, ByVal Pelak As String, ByVal Serial As String, ByVal TerminalID As Int16, ByRef NobatDateTime As DateTime) As Boolean
        Try
            If MClassAuthenticationManagement.IsAuthenticationIdValid(AId) = False Then
                Return False
            End If
            Dim myTruckId As Int16
            If TWSClassLibrary.TrucksManagement.TWSClassTrucksManagement.ExistTruck(Pelak, Serial, New SqlClient.SqlConnection(TWSClassConfigurationManagement.GetTDBServerConnectionString), myTruckId) = False Then
                Return False
            Else
                Dim Da As New SqlClient.SqlDataAdapter : Dim Ds As New DataSet
                Da.SelectCommand = New SqlClient.SqlCommand("Select SodoorTime From TblNobats Where TruckId=" & myTruckId & " and TerminalId=" & TerminalID & " and TravelTime=0")
                Da.SelectCommand.Connection = New SqlClient.SqlConnection(TWSClassConfigurationManagement.GetTDBServerConnectionString())
                Ds.Tables.Clear()
                If Da.Fill(Ds) <> 0 Then
                    NobatDateTime = Ds.Tables(0).Rows(0).Item("SodoorTime")
                    Return True
                Else
                    Return False
                End If
            End If
        Catch ex As Exception
            EventLog.WriteEntry("TWSServerSource", "TerminalsWebService.WebMethodGetLastNobatInOnlineifExist()." + ex.Message.ToString, EventLogEntryType.Error)
            Throw New Exception("TerminalsWebService.WebMethodGetLastNobatInOnlineifExist()." + ex.Message.ToString)
        End Try
    End Function


#End Region
#Region "Date And Time"
    <WebMethod()> _
    Public Function WebMethodCurrentShamsiDate() As String
        Try
            Return GetCurrentShamsiDate(TWSClassConfigurationManagement.GetTDBServerConnectionString)
        Catch ex As Exception
            EventLog.WriteEntry("TWSServerSource", "TerminalsWebService.WebMethodCurrentShamsiDate()." + ex.Message.ToString, EventLogEntryType.Error)
            LoggingMessageSabt(Logging.ErrorLog, LogSource.ServerWebService, Database.None, "", 0, "", "WebMethodCurrentShamsiDate", False, "", ACKSignal.NoneOrMsg, Nothing, MClassSystemStatusManagement.GetSystemStatus, 0, ex.Message.ToString)
            Throw New Exception("TerminalsWebService.WebMethodCurrentShamsiDate()." + ex.Message.ToString)
        End Try
    End Function
    <WebMethod()> _
    Public Function WebMethodCurrentTime() As String
        Try
            Return Date.Now.TimeOfDay.ToString("yyyy-MM-dd HH:mm:ss")
        Catch ex As Exception
            EventLog.WriteEntry("TWSServerSource", "TerminalsWebService.WebMethodCurrentTime()." + ex.Message.ToString, EventLogEntryType.Error)
            LoggingMessageSabt(Logging.ErrorLog, LogSource.ServerWebService, Database.None, "", 0, "", "WebMethodCurrentTime", False, "", ACKSignal.NoneOrMsg, Nothing, MClassSystemStatusManagement.GetSystemStatus, 0, ex.Message.ToString)
            Throw New Exception("TerminalsWebService.WebMethodCurrentTime()." + ex.Message.ToString)
        End Try
    End Function
#End Region
#Region "Security"
    <WebMethod()> _
    Public Function WebMethodUserAuthentication(ByVal AId As String, ByVal UserId As String, ByVal UserPassword As String) As Boolean
        Try
            If MClassAuthenticationManagement.IsAuthenticationIdValid(AId) = False Then Exit Function
            If MClassAuthenticationManagement.IsUserAuthenticationInfValid(UserId, UserPassword) = True Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            EventLog.WriteEntry("TWSServerSource", "TerminalsWebService.WebMethodUserAuthentication()." + ex.Message.ToString, EventLogEntryType.Error)
            LoggingMessageSabt(Logging.ErrorLog, LogSource.ServerWebService, Database.None, "", 0, "", "WebMethodUserAuthentication", False, AId, ACKSignal.NoneOrMsg, Nothing, MClassSystemStatusManagement.GetSystemStatus, 0, ex.Message.ToString)
            Throw New Exception("TerminalsWebService.WebMethodUserAuthentication()." + ex.Message.ToString)
        End Try
    End Function
#End Region

#Region "DelNobatBarnamehOnLine And DelNobatUserRequest"
    <WebMethod()> _
    Public Sub WebMethodDelNobatBarnameOnline(ByVal AId As String, ByVal TerminalID As Int16, ByVal SyncTerminalID As Int16, ByVal Pelak As String, ByVal Serial As String)
        Dim CmdSql As New SqlClient.SqlCommand
        CmdSql.Connection = New SqlClient.SqlConnection(TWSClassConfigurationManagement.GetTDBServerConnectionString)
        Try
            If MClassAuthenticationManagement.IsAuthenticationIdValid(AId) = False Then Exit Sub
            Dim myTruckId As Int16
            If TWSClassLibrary.TrucksManagement.TWSClassTrucksManagement.ExistTruck(Pelak, Serial, New SqlClient.SqlConnection(TWSClassConfigurationManagement.GetTDBServerConnectionString), myTruckId) = False Then
                LoggingMessageSabt(Logging.WebMethodDelNobatBarnameOnline, LogSource.ServerWebService, Database.None, "", 0, "", "WebMethodDelNobatBarnameOnline", True, AId, ACKSignal.NoneOrMsg, Nothing, SystemStatus.None, 0, "WebMethodDelNobatBarnameOnline:(Pelak Not Exist) " + Pelak.Trim + " " + Serial.Trim)
            Else
                CmdSql.Connection.Open()
                CmdSql.Transaction = CmdSql.Connection.BeginTransaction(System.Data.IsolationLevel.Serializable)
                CmdSql.CommandText = "insert into TblSyncChangedNobatsTrace(TruckID,TerminalID,Status,TravelTime,SodoorTime,TraceWriter,DateReal) values(" & myTruckId & "," & TerminalID & "," & TWSClassLibrary.NobatsManagement.NobatsStatus.DelNobatBarnamehOnline & "," & 0 & ",'" & Date.Now.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture) & "','" & [Enum].GetName(GetType(TraceWriter), TraceWriter.WebService) & "','" & Date.Now.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture) & "')"
                CmdSql.ExecuteNonQuery()
                CmdSql.CommandText = "insert into TblSyncChangedNobats(TruckID,TerminalID,Status,SyncTerminalID,TravelTime,SodoorTime,DelFlag) values(" & myTruckId & "," & TerminalID & "," & TWSClassLibrary.NobatsManagement.NobatsStatus.DelNobatBarnamehOnline & "," & SyncTerminalID & ",0,'" & Date.Now.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture) & "',0)"
                CmdSql.ExecuteNonQuery()
                CmdSql.CommandText = "delete TblNobats Where (TruckId=" & myTruckId & ") and (TerminalId =" & SyncTerminalID & ") and (TravelTime=0)"
                CmdSql.ExecuteNonQuery()
                Dim mySyncDS As DataSet = GetTerminalsIDList(TerminalID, TWSClassConfigurationManagement.GetTDBServerConnectionString)
                For loopDelToSync As Int16 = 0 To mySyncDS.Tables(0).Rows.Count - 1
                    CmdSql.CommandText = "insert into TblSyncChangedNobats(TruckID,TerminalID,Status,SyncTerminalID,TravelTime,SodoorTime,DelFlag) values(" & myTruckId & "," & TerminalID & "," & TWSClassLibrary.NobatsManagement.NobatsStatus.Deleted & "," & mySyncDS.Tables(0).Rows(loopDelToSync).Item(0) & ",0,'" & Date.Now.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture) & "',0)"
                    CmdSql.ExecuteNonQuery()
                Next
                CmdSql.Transaction.Commit() : CmdSql.Connection.Close()
                LoggingMessageSabt(Logging.WebMethodDelNobatBarnameOnline, LogSource.ServerWebService, Database.None, "", 0, "", "WebMethodDelNobatBarnameOnline", True, AId, ACKSignal.NoneOrMsg, Nothing, SystemStatus.None, 0, "WebMethodDelNobatBarnameOnline:" + Pelak.Trim + " " + Serial.Trim)
            End If
        Catch ex As Exception
            EventLog.WriteEntry("TWSServerSource", "TerminalsWebService.WebMethodDelNobatBarnameOnline()." + ex.Message.ToString, EventLogEntryType.Error)
            LoggingMessageSabt(Logging.ErrorLog, LogSource.ServerWebService, Database.None, "", 0, "", "WebMethodDelNobatBarnameOnline", False, AId, ACKSignal.NoneOrMsg, Nothing, MClassSystemStatusManagement.GetSystemStatus, 0, ex.Message.ToString)
            Throw New Exception("TerminalsWebService.WebMethodDelNobatBarnameOnline()." + ex.Message.ToString)
        End Try
    End Sub

    <WebMethod()> _
    Public Sub WebMethodDelNobatUserRequest(ByVal AId As String, ByVal TerminalID As Int16, ByVal SyncTerminalID As Int16, ByVal Pelak As String, ByVal Serial As String)
        Dim CmdSql As New SqlClient.SqlCommand
        CmdSql.Connection = New SqlClient.SqlConnection(TWSClassConfigurationManagement.GetTDBServerConnectionString)
        Try
            If MClassAuthenticationManagement.IsAuthenticationIdValid(AId) = False Then Exit Sub
            Dim myTruckId As Int16
            If TWSClassLibrary.TrucksManagement.TWSClassTrucksManagement.ExistTruck(Pelak, Serial, New SqlClient.SqlConnection(TWSClassConfigurationManagement.GetTDBServerConnectionString), myTruckId) = False Then
                LoggingMessageSabt(Logging.WebMethodDelNobatUserRequest, LogSource.ServerWebService, Database.None, "", 0, "", "WebMethodDelNobatUserRequest", True, AId, ACKSignal.NoneOrMsg, Nothing, SystemStatus.None, 0, "WebMethodDelNobatUserRequest:(Pelak Not Exist) " + Pelak.Trim + " " + Serial.Trim)
            Else
                CmdSql.Connection.Open()
                CmdSql.Transaction = CmdSql.Connection.BeginTransaction(System.Data.IsolationLevel.Serializable)
                CmdSql.CommandText = "insert into TblSyncChangedNobatsTrace(TruckID,TerminalID,Status,TravelTime,SodoorTime,TraceWriter,DateReal) values(" & myTruckId & "," & TerminalID & "," & TWSClassLibrary.NobatsManagement.NobatsStatus.DelNobatUserRequest & "," & 0 & ",'" & Date.Now.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture) & "','" & [Enum].GetName(GetType(TraceWriter), TraceWriter.WebService) & "','" & Date.Now.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture) & "')"
                CmdSql.ExecuteNonQuery()
                CmdSql.CommandText = "insert into TblSyncChangedNobats(TruckID,TerminalID,Status,SyncTerminalID,TravelTime,SodoorTime,DelFlag) values(" & myTruckId & "," & TerminalID & "," & TWSClassLibrary.NobatsManagement.NobatsStatus.DelNobatUserRequest & "," & SyncTerminalID & ",0,'" & Date.Now.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture) & "',0)"
                CmdSql.ExecuteNonQuery()
                CmdSql.CommandText = "delete TblNobats Where (TruckId=" & myTruckId & ") and (TerminalId =" & SyncTerminalID & ") and (TravelTime=0)"
                CmdSql.ExecuteNonQuery()
                Dim mySyncDS As DataSet = GetTerminalsList(TWSClassConfigurationManagement.GetTDBServerConnectionString)
                For loopDelToSync As Int16 = 0 To mySyncDS.Tables(0).Rows.Count - 1
                    CmdSql.CommandText = "insert into TblSyncChangedNobats(TruckID,TerminalID,Status,SyncTerminalID,TravelTime,SodoorTime,DelFlag) values(" & myTruckId & "," & SyncTerminalID & "," & TWSClassLibrary.NobatsManagement.NobatsStatus.Deleted & "," & mySyncDS.Tables(0).Rows(loopDelToSync).Item(0) & ",0,'" & Date.Now.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture) & "',0)"
                    CmdSql.ExecuteNonQuery()
                Next
                CmdSql.Transaction.Commit() : CmdSql.Connection.Close()
                LoggingMessageSabt(Logging.WebMethodDelNobatUserRequest, LogSource.ServerWebService, Database.None, "", 0, "", "WebMethodDelNobatUserRequest", True, AId, ACKSignal.NoneOrMsg, Nothing, SystemStatus.None, 0, "WebMethodDelNobatUserRequest:" + Pelak.Trim + " " + Serial.Trim)
            End If
        Catch ex As Exception
            EventLog.WriteEntry("TWSServerSource", "TerminalsWebService.WebMethodDelNobatUserRequest()." + ex.Message.ToString, EventLogEntryType.Error)
            LoggingMessageSabt(Logging.ErrorLog, LogSource.ServerWebService, Database.None, "", 0, "", "WebMethodDelNobatUserRequest", False, AId, ACKSignal.NoneOrMsg, Nothing, MClassSystemStatusManagement.GetSystemStatus, 0, ex.Message.ToString)
            Throw New Exception("TerminalsWebService.WebMethodDelNobatUserRequest()." + ex.Message.ToString)
        End Try
    End Sub

#End Region



End Class