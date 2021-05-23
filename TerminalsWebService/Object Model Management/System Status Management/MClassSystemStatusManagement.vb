

Imports TWSClassLibrary.ConfigurationManagement
Imports TWSClassLibrary.DatabaseManagement.TWSClassDatabaseManagement
Imports TWSClassLibrary.SystemStatusManagement

Public NotInheritable Class MClassSystemStatusManagement


    Public Shared Function GetNewSystemStatusCommandId() As String
        Try
            Randomize()
            Dim myNewId As String = Date.Now.ToString("yyyy-MM-dd HH:mm:ss") + Rnd().ToString
            Return myNewId
        Catch ex As Exception
            Throw New Exception("MClassSystemStatusManagement.GetNewSystemStatusCommandId()." + ex.Message.ToString)
        End Try
    End Function
    Public Shared Sub SetSystemStatusInf(ByVal SystemStatus As SystemStatus, ByVal TerminalIdToChangeStatus As Int16, ByVal CommandId As String, ByVal CommandAndValueData As String)
        Dim Cmdsql As New SqlClient.SqlCommand
        Cmdsql.Connection = New SqlClient.SqlConnection(TWSClassConfigurationManagement.GetTDBServerConnectionString)
        Try
            Cmdsql.Connection.Open()
            Cmdsql.CommandText = "Update TblSystemStatus set systemstatus=" & SystemStatus & ",terminalidtochangestatus=" & TerminalIdToChangeStatus & ",commandid='" & CommandId & "',CommandOrvaluedata='" & CommandAndValueData & "'"
            Cmdsql.ExecuteNonQuery()
            Cmdsql.Connection.Close()
        Catch ex As Exception
            If Cmdsql.Connection.State <> ConnectionState.Closed Then Cmdsql.Connection.Close()
            Throw New Exception("MClassSystemStatusManagement.SetSystemStatusInf()." + ex.Message.ToString)
        End Try
    End Sub
    Public Shared Sub GetSystemStatusInf(ByRef SystemStatus As SystemStatus, ByRef TerminalIdToChangeStatus As Int16, ByRef CommandId As String, ByRef CommandOrValueData As String)
        Try
            Dim da As New SqlClient.SqlDataAdapter : Dim ds As New DataSet
            da.SelectCommand = New SqlClient.SqlCommand("select * from tblsystemstatus")
            da.SelectCommand.Connection = New SqlClient.SqlConnection(TWSClassConfigurationManagement.GetTDBServerConnectionString)
            ds.Tables.Clear()
            da.Fill(ds)
            SystemStatus = ds.Tables(0).Rows(0).Item("SystemStatus")
            TerminalIdToChangeStatus = ds.Tables(0).Rows(0).Item("TerminalIdToChangeStatus")
            CommandId = ds.Tables(0).Rows(0).Item("CommandId").trim
            CommandOrValueData = ds.Tables(0).Rows(0).Item("CommandOrValueData").trim
        Catch ex As Exception
            Throw New Exception("MClassSystemStatusManagement.GetSystemStatusInf()." + ex.Message.ToString)
        End Try
    End Sub
    Public Shared Function GetSystemStatus() As SystemStatus
        Try
            Dim da As New SqlClient.SqlDataAdapter : Dim ds As New DataSet
            da.SelectCommand = New SqlClient.SqlCommand("select * from tblsystemstatus")
            da.SelectCommand.Connection = New SqlClient.SqlConnection(TWSClassConfigurationManagement.GetTDBServerConnectionString)
            ds.Tables.Clear()
            da.Fill(ds)
            Return ds.Tables(0).Rows(0).Item("SystemStatus")
        Catch ex As Exception
            Throw New Exception("MClassSystemStatusManagement.GetSystemStatus()." + ex.Message.ToString)
        End Try
    End Function



End Class
