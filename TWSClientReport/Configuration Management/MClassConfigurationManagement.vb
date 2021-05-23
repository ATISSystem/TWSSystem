
Imports Microsoft.Win32
Imports System.Reflection

Imports TWSClassLibrary.ConfigurationManagement

Public MustInherit Class MClassConfigurationManagement

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

End Class
