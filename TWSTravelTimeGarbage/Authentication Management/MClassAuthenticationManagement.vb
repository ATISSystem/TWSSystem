

Public Class MClassAuthenticationManagement

    Public Shared Function AuthenticationId() As String
        Try
            Return "Biinfo878"
        Catch ex As Exception
            Throw New Exception("MClassAuthenticationManagement.AuthenticationId()." + ex.Message.ToString)
        End Try
    End Function

End Class
