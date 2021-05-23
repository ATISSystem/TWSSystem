

Imports TWSClassLibrary.TerminalsManagement.TWSClassTerminalsManagement
Imports TWSClassLibrary.SystemStatusManagement
Imports TWSClassLibrary.AckSignalManagement
Imports TWSClassLibrary.DatabaseManagement
Imports TWSClassLibrary.DatabaseManagement.TWSClassDatabaseManagement
Imports TWSClassLibrary.LoggingManagement
Imports TWSClassLibrary.ConfigurationManagement

Public Class FrmCenterControl

    Private TWS As TerminalsWebService.TerminalsWebServiceSoap = New TerminalsWebService.TerminalsWebServiceSoapClient
    Dim myDataSetTerminalsList As DataSet

    Private Sub FrmCenterControl_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            myDataSetTerminalsList = GetTerminalsList(TWSClassConfigurationManagement.GetTDBServerConnectionString)
            ComboTerminals.Items.Clear()
            For loopx As Int16 = 0 To myDataSetTerminalsList.Tables(0).Rows.Count - 1
                Dim myTerminalId As String = myDataSetTerminalsList.Tables(0).Rows(loopx).Item(0)
                Dim myTerminalName As String = myDataSetTerminalsList.Tables(0).Rows(loopx).Item(1).trim
                ComboTerminals.Items.Add(myTerminalId + "  " + myTerminalName)
            Next
            ComboTerminals.Text = ComboTerminals.Items(0)
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub
    Private Sub BtnSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSubmit.Click
        Try
            Dim myTerminalId As Int16 = IIf(ChkAllTerminals.Checked = True, 0, Convert.ToInt16(Mid(ComboTerminals.Text.Trim, 1, 1)))
            Dim myCommandAndValue As String = TxtCommandAndValue.Text
            Dim mySystemStatusTemp As SystemStatus
            If OpbExecuteNonOutputSqlCommand.Checked = True Then
                TWS.WebMethodSetNewSystemStatus(MClassAuthenticationManagement.AuthenticationId, SystemStatus.ExecuteNonOutputSqlCommand, myTerminalId, myCommandAndValue)
                mySystemStatusTemp = SystemStatus.ExecuteNonOutputSqlCommand
            ElseIf OpbExecuteWithOutputSqlCommand.Checked = True Then
                TWS.WebMethodSetNewSystemStatus(MClassAuthenticationManagement.AuthenticationId, SystemStatus.ExecuteWithOutputSqlCommand, myTerminalId, myCommandAndValue)
                mySystemStatusTemp = SystemStatus.ExecuteWithOutputSqlCommand
            ElseIf OpbGetExistNobatsInOtherData.Checked = True Then
                TWS.WebMethodSetNewSystemStatus(MClassAuthenticationManagement.AuthenticationId, SystemStatus.GetExistNobatsInOtherData, myTerminalId, myCommandAndValue)
                mySystemStatusTemp = SystemStatus.GetExistNobatsInOtherData
            ElseIf OpbGetSTPsTblConfigurationData.Checked = True Then
                TWS.WebMethodSetNewSystemStatus(MClassAuthenticationManagement.AuthenticationId, SystemStatus.GetSTPsTblConfigurationData, myTerminalId, myCommandAndValue)
                mySystemStatusTemp = SystemStatus.GetSTPsTblConfigurationData
            ElseIf OpbGetWinServiceComputerInfo.Checked = True Then
                TWS.WebMethodSetNewSystemStatus(MClassAuthenticationManagement.AuthenticationId, SystemStatus.GetWinServiceComputerInfo, myTerminalId, myCommandAndValue)
                mySystemStatusTemp = SystemStatus.GetWinServiceComputerInfo
            ElseIf OpbGetWinServiceConnectionString.Checked = True Then
                TWS.WebMethodSetNewSystemStatus(MClassAuthenticationManagement.AuthenticationId, SystemStatus.GetWinServiceConnectionString, myTerminalId, myCommandAndValue)
                mySystemStatusTemp = SystemStatus.GetWinServiceConnectionString
            ElseIf OpbGetWinServiceDateTime.Checked = True Then
                TWS.WebMethodSetNewSystemStatus(MClassAuthenticationManagement.AuthenticationId, SystemStatus.GetWinServiceDateTime, myTerminalId, myCommandAndValue)
                mySystemStatusTemp = SystemStatus.GetWinServiceDateTime
            ElseIf OpbGetWinServiceTerminalId.Checked = True Then
                TWS.WebMethodSetNewSystemStatus(MClassAuthenticationManagement.AuthenticationId, SystemStatus.GetWinServiceTerminalId, myTerminalId, myCommandAndValue)
                mySystemStatusTemp = SystemStatus.GetWinServiceTerminalId
            ElseIf OpbSendCurrentStatus.Checked = True Then
                TWS.WebMethodSetNewSystemStatus(MClassAuthenticationManagement.AuthenticationId, SystemStatus.SendCurrentStatus, myTerminalId, myCommandAndValue)
                mySystemStatusTemp = SystemStatus.SendCurrentStatus
            ElseIf OpbSetWinServiceSyncCounting.Checked = True Then
                TWS.WebMethodSetNewSystemStatus(MClassAuthenticationManagement.AuthenticationId, SystemStatus.SetWinServiceSyncCounting, myTerminalId, myCommandAndValue)
                mySystemStatusTemp = SystemStatus.SetWinServiceSyncCounting
            ElseIf OpbSetWinServiceTimerInterval.Checked = True Then
                TWS.WebMethodSetNewSystemStatus(MClassAuthenticationManagement.AuthenticationId, SystemStatus.SetWinServiceTimerInterval, myTerminalId, myCommandAndValue)
                mySystemStatusTemp = SystemStatus.SetWinServiceTimerInterval
            ElseIf OpbStpExistNobatSilent.Checked = True Then
                TWS.WebMethodSetNewSystemStatus(MClassAuthenticationManagement.AuthenticationId, SystemStatus.StpExistNobatSilent, myTerminalId, myCommandAndValue)
                mySystemStatusTemp = SystemStatus.StpExistNobatSilent
            ElseIf OpbSystemClearNobatsTrucksBufferAndSilent.Checked = True Then
                TWS.WebMethodSetNewSystemStatus(MClassAuthenticationManagement.AuthenticationId, SystemStatus.SystemClearNobatsTrucksBufferAndSilent, myTerminalId, myCommandAndValue)
                mySystemStatusTemp = SystemStatus.SystemClearNobatsTrucksBufferAndSilent
            ElseIf OpbSystemFullSilent.Checked = True Then
                TWS.WebMethodSetNewSystemStatus(MClassAuthenticationManagement.AuthenticationId, SystemStatus.SystemFullSilent, myTerminalId, myCommandAndValue)
                mySystemStatusTemp = SystemStatus.SystemFullSilent
            ElseIf OpbSystemGeneral.Checked = True Then
                TWS.WebMethodSetNewSystemStatus(MClassAuthenticationManagement.AuthenticationId, SystemStatus.SystemGeneral, myTerminalId, myCommandAndValue)
                mySystemStatusTemp = SystemStatus.SystemGeneral
            ElseIf OpbWinServiceSilent.Checked = True Then
                TWS.WebMethodSetNewSystemStatus(MClassAuthenticationManagement.AuthenticationId, SystemStatus.WinServiceSilent, myTerminalId, myCommandAndValue)
                mySystemStatusTemp = SystemStatus.WinServiceSilent
            End If
            TWS.ACKSignalRecived(MClassAuthenticationManagement.AuthenticationId, 0, ACKSignal.CenterControlChangeSystemStatus, Nothing, "CenterControl:ChangeStatus", LogSource.ServerWinApplication, Database.None, "", "FrmCenterControl.BtnSubmit_Click", mySystemStatusTemp, 0)
            MessageBox.Show("SystemStatus=" + [Enum].GetName(GetType(SystemStatus), mySystemStatusTemp) + ControlChars.CrLf + "TerminalIdToChangeStatus=" + myTerminalId.ToString + ControlChars.CrLf + "CommandAndValue=" + myCommandAndValue)
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub
    Private Sub BtnGetCurrentSystemStatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGetCurrentSystemStatus.Click
        Try
            Dim TerminalToChangeStatus As Int16
            Dim CommandId As String
            Dim CommandValueOrData As String
            Dim myStatus As SystemStatus = TWS.WebMethodGetNewSystemStatus(MClassAuthenticationManagement.AuthenticationId, TerminalToChangeStatus, CommandId, CommandValueOrData)
            MessageBox.Show("Status=" + [Enum].GetName(GetType(SystemStatus), myStatus) + ControlChars.CrLf + "CommandId=" + CommandId.Trim + ControlChars.CrLf + "CommandValueOrData=" + CommandValueOrData.Trim + ControlChars.CrLf + "TerminalToChangeStatus= " + TerminalToChangeStatus.ToString)
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub

    Private Sub BtnSetSyncChangedTrucks_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSetSyncChangedTrucks.Click
        Dim cmdsql As New SqlClient.SqlCommand
        cmdsql.Connection = New SqlClient.SqlConnection(TWSClassConfigurationManagement.GetTDBServerConnectionString)
        Try
            Dim myTerminalId As Int16 = Mid(ComboTerminals.Text.Trim, 1, 1)
            cmdsql.Connection.Open()
            cmdsql.CommandText = "insert into tblsyncchangedtrucks(truckid,syncterminalid,status,delflag) select truckid," & myTerminalId & ",1,0 from tbltrucks"
        Catch ex As Exception

        End Try
    End Sub


End Class