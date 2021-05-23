
Imports System.Reflection
Imports Microsoft.Win32
Public MustInherit Class MClassConfigurationManagement

#Region "Registry Management"
    Public Shared Function GetTerminalId() As Int16
        Try
            Return TWSClassLibrary.ConfigurationManagement.TWSClassConfigurationManagement.GetTerminalId
        Catch ex As Exception
            Throw New Exception(MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name + ex.Message)
        End Try
    End Function
#End Region


End Class
