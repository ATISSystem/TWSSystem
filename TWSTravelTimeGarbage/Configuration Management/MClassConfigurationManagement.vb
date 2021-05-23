
Imports Microsoft.Win32
Public MustInherit Class MClassConfigurationManagement

    Public Shared Sub CreateTWSGarbageLog()
        Try
            If EventLog.Exists("TWSGarbageLog") = False Then EventLog.CreateEventSource("TWSGarbageSource", "TWSGarbageLog")
        Catch ex As Exception
            Throw New Exception("MClassConfigurationManagement.CreateTWSGarbageLog()." + ex.Message.ToString)
        End Try
    End Sub

End Class
