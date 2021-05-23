
Imports Microsoft.Win32
Imports System.Reflection

Imports TWSClassLibrary.DatabaseManagement.TWSClassDatabaseManagement
Imports TWSClassLibrary.TDBClientStpType
Imports TWSClassLibrary.ConfigurationManagement


Public MustInherit Class MClassConfigurationManagement

#Region "Registry Management"
    Public Shared Sub CreateTimerIntervalRegistry(Optional ByVal TI As Int64 = 60000)  'يک دقيقه
        Try
            Registry.SetValue("HKEY_CURRENT_USER\TWS\TimerInterval", "TimerInterval", TI)
        Catch ex As Exception
            Throw New Exception("MClassConfigurationManagement.CreateTimerIntervalRegistry()." + ex.Message.ToString)
        End Try
    End Sub
    Public Shared Sub CreateSyncCountingRegistry(Optional ByVal SY As Int16 = 5)  '5 دقيقه
        Try
            Registry.SetValue("HKEY_CURRENT_USER\TWS\SyncCounting", "SyncCounting", SY)
        Catch ex As Exception
            Throw New Exception("MClassConfigurationManagement.CreateSyncCountingRegistry()." + ex.Message.ToString)
        End Try
    End Sub
    Public Shared Function GetTimerInterval() As Int32
        Try
            Return TWSClassConfigurationManagement.GetTimerInterval
        Catch ex As Exception
            Throw New Exception(MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name + ex.Message)
        End Try
    End Function
    Public Shared Function GetSyncCounting() As Int16
        Try
            Return TWSClassConfigurationManagement.GetSyncCounting
        Catch ex As Exception
            Throw New Exception(MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name + ex.Message)
        End Try
    End Function
    Public Shared Function GetTerminalId() As Int16
        Try
            Return TWSClassConfigurationManagement.GetTerminalId
        Catch ex As Exception
            Throw New Exception(MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name + ex.Message)
        End Try
    End Function

#End Region
#Region "EventLog Management"
    Public Shared Sub CreateTWSClientLog()
        Try
            If EventLog.Exists("TWSClientLog") = False Then EventLog.CreateEventSource("TWSCLTSource", "TWSClientLog")
        Catch ex As Exception
            Throw New Exception("MClassConfigurationManagement.CreateTWSClientLog()." + ex.Message.ToString)
        End Try
    End Sub
#End Region
#Region "TDBClient Management"
    Public Shared Sub ActiveFlagForStps(ByVal TDBClientStp As TDBClientStpType, ByVal F As Boolean)
        Dim Cmdsql As New SqlClient.SqlCommand
        Cmdsql.Connection = New SqlClient.SqlConnection(TWSClassConfigurationManagement.GetTDBClientConnectionString)
        Try
            Cmdsql.Connection.Open()
            If TDBClientStp = TDBClientStpType.Add Then
                If F = True Then Cmdsql.CommandText = "update TblConfiguration Set Prg='1' where Code='AddNobat'"
                If F = False Then Cmdsql.CommandText = "update TblConfiguration Set Prg='0' where Code='AddNobat'"
            ElseIf TDBClientStp = TDBClientStpType.Del Then
                If F = True Then Cmdsql.CommandText = "update TblConfiguration Set Prg='1' where Code='DelNobat'"
                If F = False Then Cmdsql.CommandText = "update TblConfiguration Set Prg='0' where Code='DelNobat'"
            ElseIf TDBClientStp = TDBClientStpType.Exist Then
                If F = True Then Cmdsql.CommandText = "update TblConfiguration Set Prg='1' where Code='ExistNobat'"
                If F = False Then Cmdsql.CommandText = "update TblConfiguration Set Prg='0' where Code='ExistNobat'"
            ElseIf TDBClientStp = TDBClientStpType.Sodoor Then
                If F = True Then Cmdsql.CommandText = "update TblConfiguration Set Prg='1' where Code='Sodoor'"
                If F = False Then Cmdsql.CommandText = "update TblConfiguration Set Prg='0' where Code='Sodoor'"
            End If
            Cmdsql.ExecuteNonQuery() : Cmdsql.Connection.Close()
        Catch ex As Exception
            If Cmdsql.Connection.State <> ConnectionState.Closed Then Cmdsql.Connection.Close()
            Throw New Exception("MClassConfigurationManagement.ActiveFlagForStps()." + ex.Message.ToString)
        End Try
    End Sub
#End Region

End Class
