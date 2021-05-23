
Imports System.Globalization

Imports TWSClassLibrary.LoggingManagement
Imports TWSClassLibrary.DatabaseManagement
Imports TWSClassLibrary.AckSignalManagement
Imports TWSClassLibrary.SystemStatusManagement


Public Class FrmReport

    Private TWS As TerminalsWebService.TerminalsWebServiceSoap = New TerminalsWebService.TerminalsWebServiceSoapClient
    Dim myStartDateTime As DateTime = Nothing
    Dim myColor As Color = Color.Black
    Dim myDontDisplayString As String = ""

#Region "FrmReport"
    Private Sub FrmReport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        PnlUcLogHolder.VerticalScroll.Enabled = True
        BtnDontLogDisplay.PerformClick()

    End Sub
    Private Sub PicEnd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicEnd.Click
        Me.Close()
    End Sub
    Private Sub PicMin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicMin.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

#End Region

#Region "Subs And Functions Other Events"
    Private Sub OpbOffLine_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpbOffLine.CheckedChanged
        If OpbOffLine.Checked = True Then BtnRefresh.Enabled = True Else BtnRefresh.Enabled = False
    End Sub
    Private Sub BtnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRefresh.Click
        Try
            Dim myData As New DataSet
            Dim myDateTime As String = DateTimePicker.Value
            If TWS.WebMethodLoggingReport(MClassAuthenticationManagement.AuthenticationId, myDateTime, myData) <> 0 Then
                PnlUcLogHolder.Controls.Clear()
                ViewReport(myData)
            Else
                PnlUcLogHolder.Controls.Clear()
                MessageBox.Show("در بازه زماني مورد نظر گزارشي وجود ندارد")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub
#End Region
#Region "Timer"
    Private Sub BtnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnStart.Click
        Try
            If myStartDateTime = Nothing Then
                myStartDateTime = Date.Now
            End If
            Timer.Enabled = True
            Timer.Start()
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub
    Private Sub BtnStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnStop.Click
        Timer.Stop()
    End Sub
    Private Sub Timer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer.Tick
        Try
            Dim myData As New DataSet
            If OpbOnline.Checked = True Then
                If PnlUcLogHolder.Controls.Count > 100 Then
                    PnlUcLogHolder.Controls.Clear()
                    LblLogTotal.Text = "0"
                End If
                myData.Tables.Clear()
                If TWS.WebMethodLoggingReport(MClassAuthenticationManagement.AuthenticationId, myStartDateTime.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture), myData) <> 0 Then
                    If HaveLogIdToView(myData) = True Then
                        'خالي کردن ليبل NEW
                        For Each UC As UcSingleLogHolder In PnlUcLogHolder.Controls
                            UC.SetOld()
                        Next
                    End If
                    ViewReport(myData)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub
    Private Function HaveLogIdToView(ByVal Data As DataSet) As Boolean
        Try
            Dim myViewFlag As Boolean = False
            Dim mydata As DataSet = Data
            For loopx As Int32 = 0 To mydata.Tables(0).Rows.Count - 1
                If InStr(myDontDisplayString, "," + mydata.Tables(0).Rows(loopx).Item("logid").ToString.Trim + ",") = 0 Then
                    myViewFlag = True
                    Return True
                End If
            Next
            Return False
        Catch ex As Exception
            Throw New Exception("HaveLogIdToView()." + ex.Message.ToString)
        End Try
    End Function
    Private Sub ViewReport(ByVal Data As DataSet)
        Try

            Dim mydata As DataSet = Data
            For loopx As Int32 = 0 To mydata.Tables(0).Rows.Count - 1
                Dim myLogId As String = [Enum].GetName(GetType(Logging), mydata.Tables(0).Rows(loopx).Item("logid"))
                'آيتم هايي که نبايد نمايش داده شوند
                If InStr(myDontDisplayString, "," + mydata.Tables(0).Rows(loopx).Item("logid").ToString.Trim + ",") = 0 Then
                    Dim myUC As UcSingleLogHolder = New UcSingleLogHolder
                    Dim myLogSource As String = [Enum].GetName(GetType(LogSource), mydata.Tables(0).Rows(loopx).Item("logsource"))
                    Dim myTDB As String = [Enum].GetName(GetType(Database), mydata.Tables(0).Rows(loopx).Item("TDB"))
                    Dim myTDBObject As String = mydata.Tables(0).Rows(loopx).Item("TDBObject")
                    Dim myTerminal As String = mydata.Tables(0).Rows(loopx).Item("TerminalName")
                    Dim myUserName As String = mydata.Tables(0).Rows(loopx).Item("UserName")
                    Dim myDataAndTime As String = mydata.Tables(0).Rows(loopx).Item("DateTimeMilladi")
                    Dim myShDate As String = mydata.Tables(0).Rows(loopx).Item("ShDate")
                    Dim myTime As String = mydata.Tables(0).Rows(loopx).Item("Time")
                    Dim myMethodName As String = mydata.Tables(0).Rows(loopx).Item("MethodName")
                    Dim myAuthenticationResult As String = mydata.Tables(0).Rows(loopx).Item("AuthenticationResult")
                    Dim myAuthenticationId As String = mydata.Tables(0).Rows(loopx).Item("AuthenticationId")
                    Dim myAckSignal As String = [Enum].GetName(GetType(ACKSignal), mydata.Tables(0).Rows(loopx).Item("AckSignal"))
                    Dim myTrucksInTotal As String = mydata.Tables(0).Rows(loopx).Item("TrucksInTotal")
                    Dim myTrucksInContent As String = mydata.Tables(0).Rows(loopx).Item("TrucksInContent")
                    Dim myTrucksOutTotal As String = mydata.Tables(0).Rows(loopx).Item("TrucksOutTotal")
                    Dim myTrucksOutContent As String = mydata.Tables(0).Rows(loopx).Item("TrucksOutContent")
                    Dim myNobatsInAddTotal As String = mydata.Tables(0).Rows(loopx).Item("NobatsInAddTotal")
                    Dim myNobatsInAddContent As String = mydata.Tables(0).Rows(loopx).Item("NobatsInAddContent")
                    Dim myNobatsOutAddTotal As String = mydata.Tables(0).Rows(loopx).Item("NobatsOutAddTotal")
                    Dim myNobatsOutAddContent As String = mydata.Tables(0).Rows(loopx).Item("NobatsOutAddContent")
                    Dim myNobatsInDelTotal As String = mydata.Tables(0).Rows(loopx).Item("NobatsInDelTotal")
                    Dim myNobatsInDelContent As String = mydata.Tables(0).Rows(loopx).Item("NobatsInDelContent")
                    Dim myNobatsOutDelTotal As String = mydata.Tables(0).Rows(loopx).Item("NobatsOutDelTotal")
                    Dim myNobatsOutDelContent As String = mydata.Tables(0).Rows(loopx).Item("NobatsOutDelContent")
                    Dim myNobatsInSodoorTotal As String = mydata.Tables(0).Rows(loopx).Item("NobatsInSodoorTotal")
                    Dim myNobatsInSodoorContent As String = mydata.Tables(0).Rows(loopx).Item("NobatsInSodoorContent")
                    Dim myNobatsOutSodoorTotal As String = mydata.Tables(0).Rows(loopx).Item("NobatsOutSodoorTotal")
                    Dim myNobatsOutSodoorContent As String = mydata.Tables(0).Rows(loopx).Item("NobatsOutSodoorContent")
                    Dim myNobatsEndTravelTimeTotal As String = mydata.Tables(0).Rows(loopx).Item("NobatsEndTravelTimeTotal")
                    Dim myNobatsEndTravelTimeContent As String = mydata.Tables(0).Rows(loopx).Item("NobatsEndTravelTimeContent")
                    Dim myTerminalsOutTotal As String = mydata.Tables(0).Rows(loopx).Item("TerminalsOutTotal")
                    Dim myTerminalsOutContent As String = mydata.Tables(0).Rows(loopx).Item("TerminalsOutContent")
                    Dim mySystemStatus As String = [Enum].GetName(GetType(SystemStatus), mydata.Tables(0).Rows(loopx).Item("systemstatus"))
                    Dim mySyncCounting As String = mydata.Tables(0).Rows(loopx).Item("SyncCounting")
                    Dim myLogNote As String = mydata.Tables(0).Rows(loopx).Item("LogNote")
                    myUC.ShowInf(New StandardLogStructure(myLogId, myLogSource, myTDB, myTDBObject, myTerminal, myUserName, myDataAndTime, myShDate, myTime, myMethodName, myAuthenticationResult, myAuthenticationId, myAckSignal, myTrucksInTotal, myTrucksInContent, myTrucksOutTotal, myTrucksOutContent, myNobatsInAddTotal, myNobatsInAddContent, myNobatsOutAddTotal, myNobatsOutAddContent, myNobatsInDelTotal, myNobatsInDelContent, myNobatsOutDelTotal, myNobatsOutDelContent, myNobatsInSodoorTotal, myNobatsInSodoorContent, myNobatsOutSodoorTotal, myNobatsOutSodoorContent, myNobatsEndTravelTimeTotal, myNobatsEndTravelTimeContent, myTerminalsOutTotal, myTerminalsOutContent, mySystemStatus, mySyncCounting, myLogNote))
                    myUC.SetColored(myColor)
                    PnlUcLogHolder.Controls.Add(myUC)
                    myUC.Dock = DockStyle.Top
                    AddHandler myUC.ContentClick, AddressOf ShowContent
                    If myColor = Color.White Then myColor = Color.Black Else myColor = Color.White
                    myStartDateTime = mydata.Tables(0).Rows(mydata.Tables(0).Rows.Count - 1).Item("DateTimeMilladi")
                    Me.Text = "TWSReport " + PnlUcLogHolder.Controls.Count.ToString + "-Log"
                    LblLogTotal.Text = PnlUcLogHolder.Controls.Count.ToString
                End If
            Next
        Catch ex As Exception
            Throw New Exception("ViewReport()." + ex.Message.ToString)
        End Try
    End Sub
    Private Sub ShowContent(ByVal ContentString As String)
        Try
            MessageBox.Show(ContentString)
        Catch ex As Exception
            Throw New Exception(ex.Message.ToString)
        End Try
    End Sub

#End Region

#Region "Setting"


    Private Sub PicExitPnlSetting_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicExitPnlSetting.Click
        PnlSetting.SendToBack()
    End Sub
    Private Sub BtnDontLogDisplay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDontLogDisplay.Click
        Try
            Dim myCompactString As String = ","
            If ChkAuthentication.Checked = True Then myCompactString = myCompactString + Int(Logging.Authentication).ToString + ","
            If ChkCenterControlChangeSystemStatus.Checked = True Then myCompactString = myCompactString + Int(Logging.CenterControlChangeSystemStatus).ToString + ","
            If ChkClientWinAppServiceStart.Checked = True Then myCompactString = myCompactString + Int(Logging.ClientWinAppServiceStart).ToString + ","
            If ChkClientWinAppSettingSqlServerAdmin.Checked = True Then myCompactString = myCompactString + Int(Logging.ClientWinAppSettingSqlServerAdmin).ToString + ","
            If ChkClientWinReportAppPassOk.Checked = True Then myCompactString = myCompactString + Int(Logging.ClientWinReportAppPassOk).ToString + ","
            If ChkClientWinReportAppTimerStart.Checked = True Then myCompactString = myCompactString + Int(Logging.ClientWinReportAppTimerStart).ToString + ","
            If ChkErrorLog.Checked = True Then myCompactString = myCompactString + Int(Logging.ErrorLog).ToString + ","
            If ChkGetExistNobatsInOtherData.Checked = True Then myCompactString = myCompactString + Int(Logging.GetExistNobatsInOtherData).ToString + ","
            If ChkGetSTPsTblConfigurationData.Checked = True Then myCompactString = myCompactString + Int(Logging.GetSTPsTblConfigurationData).ToString + ","
            If ChkGetWinServiceComputerInfo.Checked = True Then myCompactString = myCompactString + Int(Logging.GetWinServiceComputerInfo).ToString + ","
            If ChkGetWinServiceConnectionString.Checked = True Then myCompactString = myCompactString + Int(Logging.GetWinServiceConnectionString).ToString + ","
            If ChkGetWinServiceDateTime.Checked = True Then myCompactString = myCompactString + Int(Logging.GetWinServiceDateTime).ToString + ","
            If ChkGetWinServiceTerminalId.Checked = True Then myCompactString = myCompactString + Int(Logging.GetWinServiceTerminalId).ToString + ","
            If ChkIdentifyTerminal.Checked = True Then myCompactString = myCompactString + Int(Logging.IdentifyTerminal).ToString + ","
            If ChkSendCurrentStatus.Checked = True Then myCompactString = myCompactString + Int(Logging.SendCurrentStatus).ToString + ","
            If ChkServerWinAppCreateTerminal.Checked = True Then myCompactString = myCompactString + Int(Logging.ServerWinAppCreateTerminal).ToString + ","
            If ChkServerWinServiceGarbageTimerElapsed.Checked = True Then myCompactString = myCompactString + Int(Logging.ServerWinServiceGarbageTimerElapsed).ToString + ","
            If ChkServerWinServiceStart.Checked = True Then myCompactString = myCompactString + Int(Logging.ServerWinServiceStart).ToString + ","
            If ChkServerWinServiceStop.Checked = True Then myCompactString = myCompactString + Int(Logging.ServerWinServiceStop).ToString + ","
            If ChkSetWinServiceSyncCounting.Checked = True Then myCompactString = myCompactString + Int(Logging.SetWinServiceSyncCounting).ToString + ","
            If ChkSetWinServiceTimerInterval.Checked = True Then myCompactString = myCompactString + Int(Logging.SetWinServiceTimerInterval).ToString + ","
            If ChkSyncAll.Checked = True Then myCompactString = myCompactString + Int(Logging.SyncAll).ToString + ","
            If ChkSyncTrucks.Checked = True Then myCompactString = myCompactString + Int(Logging.SyncTrucks).ToString + ","
            If ChkSystemStatusChangedToExecuteNonOutputSqlCommand.Checked = True Then myCompactString = myCompactString + Int(Logging.SystemStatusChangedToExecuteNonOutputSqlCommand).ToString + ","
            If ChkSystemStatusChangedToExecuteWithOutputSqlCommand.Checked = True Then myCompactString = myCompactString + Int(Logging.SystemStatusChangedToExecuteWithOutputSqlCommand).ToString + ","
            If ChkSystemStatusChangedToStpExistNobatSilent.Checked = True Then myCompactString = myCompactString + Int(Logging.SystemStatusChangedToStpExistNobatSilent).ToString + ","
            If ChkSystemStatusChangedToSystemClearNobatsTrucksBufferAndSilent.Checked = True Then myCompactString = myCompactString + Int(Logging.SystemStatusChangedToSystemClearNobatsTrucksBufferAndSilent).ToString + ","
            If ChkSystemStatusChangedToSystemFullSilent.Checked = True Then myCompactString = myCompactString + Int(Logging.SystemStatusChangedToSystemFullSilent).ToString + ","
            If ChkSystemStatusChangedToSystemGeneral.Checked = True Then myCompactString = myCompactString + Int(Logging.SystemStatusChangedToSystemGeneral).ToString + ","
            If ChkSystemStatusChangedToWinServiceSilent.Checked = True Then myCompactString = myCompactString + Int(Logging.SystemStatusChangedToWinServiceSilent).ToString + ","
            If ChkWebMethodGetNewSystemStatus.Checked = True Then myCompactString = myCompactString + Int(Logging.WebMethodGetNewSystemStatus).ToString + ","
            If ChkWebMethodSetNewSystemStatus.Checked = True Then myCompactString = myCompactString + Int(Logging.WebMethodSetNewSystemStatus).ToString + ","
            If ChkWinServiceStart.Checked = True Then myCompactString = myCompactString + Int(Logging.WinServiceStart).ToString + ","
            If ChkWinServiceStop.Checked = True Then myCompactString = myCompactString + Int(Logging.WinServiceStop).ToString + ","
            If ChkWarning.Checked = True Then myCompactString = myCompactString + Int(Logging.Warning).ToString + ","
            myDontDisplayString = myCompactString
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub
    Private Sub BtnSetting_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSetting.Click
        PnlSetting.BringToFront()
    End Sub

#End Region

End Class