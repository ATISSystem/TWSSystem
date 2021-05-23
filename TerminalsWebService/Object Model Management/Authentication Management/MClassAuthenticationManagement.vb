Imports TWSClassLibrary.LoggingManagement
Imports TWSClassLibrary.LoggingManagement.TWSClassLoggingManagement
Imports TWSClassLibrary.DatabaseManagement
Imports TWSClassLibrary.SystemStatusManagement
Imports TWSClassLibrary.ConfigurationManagement

Public Class MClassAuthenticationManagement

    Public Shared Function AuthenticationId() As String
        Try
            Return "Biinfo878"
        Catch ex As Exception
            Throw New Exception("MClassAuthenticationManagement.AuthenticationId()." + ex.Message.ToString)
        End Try
    End Function
    Public Shared Function IsAuthenticationIdValid(ByVal AId As String) As Boolean
        Try
            If AId.Trim = AuthenticationId() Then
                Return True
            Else
                LoggingMessageSabt(Logging.Warning, LogSource.ServerWebService, Database.None, "", 0, "", "", False, AId, TWSClassLibrary.AckSignalManagement.ACKSignal.NoneOrMsg, Nothing, SystemStatus.None, 0, "Warning")
                Return False
            End If
        Catch ex As Exception
            Throw New Exception("MClassAuthenticationManagement.IsAuthenticationIdValid():" + ex.Message.ToString)
        End Try
    End Function
    Public Shared Function IsUserAuthenticationInfValid(ByVal UserId As String, ByVal UserPassword As String) As Boolean
        Try
            Dim da As New SqlClient.SqlDataAdapter : Dim ds As New DataSet
            da.SelectCommand = New SqlClient.SqlCommand("select Id from tblusers where (ltrim(rtrim(userid))='" & UserId & "') and (ltrim(rtrim(userpassword))='" & UserPassword & "')")
            da.SelectCommand.Connection = New SqlClient.SqlConnection(TWSClassConfigurationManagement.GetTDBServerConnectionString)
            ds.Tables.Clear()
            If da.Fill(ds) <> 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw New Exception("MClassAuthenticationManagement.IsUserAuthenticationInfValid():" + ex.Message.ToString)
        End Try
    End Function


End Class
