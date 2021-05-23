

Imports Microsoft.Win32
Imports Microsoft.SqlServer
Imports System.Data
Imports System.ServiceProcess
Imports TWSClassLibrary.LoggingManagement
Imports TWSClassLibrary.DatabaseManagement
Imports TWSClassLibrary.AckSignalManagement
Imports TWSClassLibrary.SystemStatusManagement

Public Class TWSApp
    Private TWS As TerminalsWebService.TerminalsWebServiceSoap = New TerminalsWebService.TerminalsWebServiceSoapClient

    Private Sub BtnIdentify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnIdentify.Click
        Try
            LblError.Text = ""
            Dim myIdentifyCode As String = "0.2150537"
            Dim TerminalId As Int16 = TWS.WebMethodIdentifyTerminal(MClassAuthenticationManagement.AuthenticationId, myIdentifyCode)
            Registry.SetValue("HKEY_CURRENT_USER\TWS\TerminalId", "TerminalId", TerminalId)
            MessageBox.Show("Identify Completed.")
            TWS.ACKSignalRecived(MClassAuthenticationManagement.AuthenticationId, TerminalId, ACKSignal.IdentifyTerminal, Nothing, "IdentifyCode=" + myIdentifyCode, LogSource.ClientWinApplication, Database.None, "", "BtnIdentify_Click", SystemStatus.None, 0)
        Catch ex As Exception
            LblError.Text = ex.Message.ToString
            TWS.ACKSignalRecived(MClassAuthenticationManagement.AuthenticationId, 0, ACKSignal.AckError, Nothing, ex.Message.ToString, LogSource.ClientWinApplication, Database.None, "", "BtnIdentify_Click", SystemStatus.None, 0)
        End Try
    End Sub
    Private Sub BtnSetD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSetD.Click
        Dim Cmdsql As New SqlClient.SqlCommand
        Cmdsql.Connection = New SqlClient.SqlConnection
        LblError.Text = ""
        Try
            Dim myTWSConnectionString As String
            If TxtAdminName.Text.Trim = "" Then
                myTWSConnectionString = "workstation id=SERVER;packet size=4096;integrated security=SSPI;data source='" & TxtServerName.Text.Trim & "' ;persist security info=False;initial catalog=msdb"
                Cmdsql.Connection.ConnectionString = myTWSConnectionString
                Cmdsql.Connection.Open()
                Cmdsql.CommandText = "exec sp_attach_db TDBClient, N'" & Application.StartupPath & "\TDBClient.mdf',N'" & Application.StartupPath & "\TDBClient_log.ldf'"
                Cmdsql.ExecuteNonQuery()
                Cmdsql.Connection.Close()
                myTWSConnectionString = "workstation id=SERVER;packet size=4096;integrated security=SSPI;data source='" & TxtServerName.Text.Trim & "' ;persist security info=False;initial catalog=TDBClient"
            Else
                myTWSConnectionString = "Data Source='" & TxtServerName.Text.Trim & "';Initial Catalog=msdb;Persist Security Info=True;User ID='" & TxtAdminName.Text.Trim & "';Password='" & TxtAdminPass.Text.Trim & "'"
                Cmdsql.Connection.ConnectionString = myTWSConnectionString
                Cmdsql.Connection.Open()
                Cmdsql.CommandText = "exec sp_attach_db TDBClient, N'" & Application.StartupPath & "\TDBClient.mdf',N'" & Application.StartupPath & "\TDBClient_log.ldf'"
                Cmdsql.ExecuteNonQuery()
                Cmdsql.Connection.Close()
                myTWSConnectionString = "Data Source='" & TxtServerName.Text.Trim & "';Initial Catalog=TDBClient;Persist Security Info=True;User ID='" & TxtAdminName.Text.Trim & "';Password='" & TxtAdminPass.Text.Trim & "'"
            End If
            Registry.SetValue("HKEY_CURRENT_USER\TWS\TWSConnectionString", "TWSClientConnectionString", myTWSConnectionString)
            MessageBox.Show("Attach Databse Compeleted.")
            TWS.ACKSignalRecived(MClassAuthenticationManagement.AuthenticationId, MClassConfigurationManagement.GetTerminalId, ACKSignal.ClientWinAppSettingSqlServerAdmin, Nothing, myTWSConnectionString, LogSource.ClientWinApplication, Database.TDBClient, "", "BtnSetD_Click", SystemStatus.None, 0)
        Catch ex As Exception
            If Cmdsql.Connection.State <> ConnectionState.Closed Then Cmdsql.Connection.Close()
            LblError.Text = ex.Message.ToString
            TWS.ACKSignalRecived(MClassAuthenticationManagement.AuthenticationId, MClassConfigurationManagement.GetTerminalId, ACKSignal.AckError, Nothing, ex.Message.ToString, LogSource.ClientWinApplication, Database.TDBClient, "", "BtnSetD_Click", SystemStatus.None, 0)
        End Try
    End Sub
    Private Sub BtnStartService_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnStartService.Click
        Try
            LblError.Text = ""
            Me.Cursor = Cursors.WaitCursor
            Dim TWSStarter As ServiceController = New ServiceController("TWS")
            TWSStarter.Start()
            MessageBox.Show("Service Started Successfully.")
            TWS.ACKSignalRecived(MClassAuthenticationManagement.AuthenticationId, MClassConfigurationManagement.GetTerminalId, ACKSignal.ClientWinAppServiceStart, Nothing, "ServiceStart", LogSource.ClientWinApplication, Database.None, "", "BtnStartService_Click", SystemStatus.None, 0)
        Catch ex As Exception
            LblError.Text = ex.Message.ToString
            TWS.ACKSignalRecived(MClassAuthenticationManagement.AuthenticationId, MClassConfigurationManagement.GetTerminalId, ACKSignal.AckError, Nothing, ex.Message.ToString, LogSource.ClientWinApplication, Database.None, "", "BtnStartService_Click", SystemStatus.None, 0)
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub BtnSetTimerInterval_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSetTimerInterval.Click
        Try
            LblError.Text = ""
            Registry.SetValue("HKEY_CURRENT_USER\TWS\TimerInterval", "TimerInterval", TxtTimerInterval.Text)
            MessageBox.Show("TimerInterval Setting Compelete.")
        Catch ex As Exception
            LblError.Text = ex.Message.ToString
            TWS.ACKSignalRecived(MClassAuthenticationManagement.AuthenticationId, MClassConfigurationManagement.GetTerminalId, ACKSignal.AckError, Nothing, ex.Message.ToString, LogSource.ClientWinApplication, Database.None, "", "BtnSetTimerInterval_Click", SystemStatus.None, 0)
        End Try
    End Sub
    Private Sub BtnSetSyncCounting_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSetSyncCounting.Click
        Try
            LblError.Text = ""
            Registry.SetValue("HKEY_CURRENT_USER\TWS\SyncCounting", "SyncCounting", TxtSyncCounting.Text)
            MessageBox.Show("SyncCounting Compelete.")
        Catch ex As Exception
            LblError.Text = ex.Message.ToString
            TWS.ACKSignalRecived(MClassAuthenticationManagement.AuthenticationId, MClassConfigurationManagement.GetTerminalId, ACKSignal.AckError, Nothing, ex.Message.ToString, LogSource.ClientWinApplication, Database.None, "", "BtnSetSyncCounting_Click", SystemStatus.None, 0)
        End Try
    End Sub

End Class
