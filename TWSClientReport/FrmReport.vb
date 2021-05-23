

Imports TWSClassLibrary.LoggingManagement
Imports TWSClassLibrary.DatabaseManagement
Imports TWSClassLibrary.AckSignalManagement
Imports TWSClassLibrary.SystemStatusManagement
Imports TWSClassLibrary.NobatsManagement
Imports TWSClassLibrary.PublicSubsAndFunctions


Public Class FrmReport

    Private TWS As TerminalsWebService.TerminalsWebServiceSoap = New TerminalsWebService.TerminalsWebServiceSoapClient

#Region "FrmReport"
    Private Sub FrmReport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        PnlUcLogHolder.VerticalScroll.Enabled = True
    End Sub
    Private Sub PicEnd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicEnd.Click
        End
    End Sub
    Private Sub LblMin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LblMin.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
    Private Sub TxtPelak_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtPelak.GotFocus
        Try
            PublicSubsAndFunctions.SetKeyboardLayout("Persian")
            TxtPelak.Clear()
            TxtPelak.ForeColor = Color.Black
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub
    Private Sub TxtPelak_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPelak.KeyPress
        If Asc(e.KeyChar) = 13 Then TxtSerial.Focus()
    End Sub
    Private Sub TxtPelak_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtPelak.LostFocus
        If TxtPelak.Text.Trim = "" Then
            TxtPelak.Text = "پلاک ناوگان را وارد نماييد"
            TxtPelak.ForeColor = Color.Silver
        End If
    End Sub
    Private Sub TxtSerial_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtSerial.GotFocus
        Try
            TxtSerial.Clear()
            TxtSerial.ForeColor = Color.Black
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub
    Private Sub TxtSerial_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtSerial.KeyPress
        If Asc(e.KeyChar) = 13 Then BtnView.Focus()
    End Sub
    Private Sub TxtSerial_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtSerial.LostFocus
        If TxtSerial.Text.Trim = "" Then
            TxtSerial.Text = "سريال ناوگان را وارد نماييد"
            TxtSerial.ForeColor = Color.Silver
        End If
    End Sub

    Private Sub BtnView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnView.Click
        Try
            PnlUcLogHolder.Controls.Clear()
            LblTruckId.Text = ""
            If (TxtPelak.Text.Trim = "") Or (TxtSerial.Text.Trim = "") Then
                MessageBox.Show("لطفا پلاک و سريال ناوگان مورد نظر را به طور کامل وارد نماييد", "TWSClientOfflineReport", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            Dim myTotalRec As Int16 = 10
            If TxtTotalRec.Text.Trim <> "" Then
                myTotalRec = TxtTotalRec.Text
            End If
            ViewReport(myTotalRec)
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "TWSClientOfflineReport", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
#End Region

#Region "Subs And Functions Other Events"
    Private Sub ViewReport(ByVal TotalRec As Int16)
        Try
            PnlUcLogHolder.Visible = False
            Me.Cursor = Cursors.WaitCursor
            Dim myData As New DataSet
            Dim myTruckTrace As TruckTrace = TWS.WebMethodGetTruckTrace(MClassAuthenticationManagement.AuthenticationId, TxtPelak.Text, TxtSerial.Text, TotalRec, myData)
            If myTruckTrace = TruckTrace.NoPelakSerialFound Then
                MessageBox.Show("پلاک و سريال مورد نظر در سيستم ثبت نشده است", "TWSServerMessage", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Try
            ElseIf myTruckTrace = TruckTrace.NoRecordFound Then
                MessageBox.Show("رکوردي يافت نشد", "TWSServerMessage", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Try
            ElseIf myTruckTrace = TruckTrace.OK Then
                LblTruckId.Text = myData.Tables(0).Rows(0).Item("truckid")
                For loopx As Int32 = myData.Tables(0).Rows.Count - 1 To 0 Step -1
                    Dim myUC As UcSingleLogHolder = New UcSingleLogHolder
                    Dim myTruckId As String = myData.Tables(0).Rows(loopx).Item("truckid")
                    Dim myStatus As NobatsStatus = myData.Tables(0).Rows(loopx).Item("status")
                    Dim myTravelTime As Int16 = myData.Tables(0).Rows(loopx).Item("TravelTime")
                    Dim mySodoorTime As DateTime = myData.Tables(0).Rows(loopx).Item("sodoortime")
                    Dim myDateReal As DateTime = myData.Tables(0).Rows(loopx).Item("DateReal")
                    Dim myTerminalName As String = myData.Tables(0).Rows(loopx).Item("TerminalName")
                    Dim myTraceWriter As String = myData.Tables(0).Rows(loopx).Item("TraceWriter")
                    myUC.ShowInf(New StandardTruckTraceStructure(myTruckId, myStatus, myTravelTime, mySodoorTime, myDateReal, myTerminalName, myTraceWriter))
                    PnlUcLogHolder.Controls.Add(myUC)
                    myUC.Dock = DockStyle.Top
                    AddHandler myUC.UCClicked, AddressOf UCsUCClicked_Handler
                Next
                Exit Try
            End If
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            Throw New Exception("ViewReport()." + ex.Message.ToString)
        End Try
        Me.Cursor = Cursors.Default
        PnlUcLogHolder.Visible = True
    End Sub
#End Region

#Region "Setting"
    Private Sub PicExitPnlSetting_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicExitPnlSetting.Click
        PnlSetting.Visible = False
    End Sub
    Private Sub BtnSetting_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSetting.Click
        PnlSetting.Visible = True
        PnlSetting.BringToFront()
    End Sub
#End Region

  
   
    Private SelectedTruckTrace As StandardTruckTraceStructure
    Private Sub UCsUCClicked_Handler(ByVal TruckTrace As StandardTruckTraceStructure)
        SelectedTruckTrace = TruckTrace
        LblSelectedTerminal.Text = SelectedTruckTrace.TerminalName.Trim
    End Sub
    Private Sub BtnOnLineEbtal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOnLineEbtal.Click
        Try
            If (TxtPelak.Text.Trim = "") Or (TxtSerial.Text.Trim = "") Then
                MessageBox.Show("لطفا پلاک و سريال ناوگان مورد نظر را به طور کامل وارد نماييد", "TWSClientOfflineReport", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            Dim TruckId As Int16
            If TWS.WebMethodTrucksExist(MClassAuthenticationManagement.AuthenticationId, TxtPelak.Text, TxtSerial.Text, TruckId) = False Then
                MessageBox.Show("پلاک و سريال مورد نظر در سيستم ثبت نشده است", "TWSServerMessage", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            Dim syncTerminalId As Int16 = TWS.WebMethodTerminalIdFromTerminalName(MClassAuthenticationManagement.AuthenticationId, SelectedTruckTrace.TerminalName)
            TWS.WebMethodDelNobatUserRequest(MClassAuthenticationManagement.AuthenticationId, MClassConfigurationManagement.GetTerminalId(), syncTerminalId, TxtPelak.Text, TxtSerial.Text)
            MessageBox.Show("درخواست ابطال با موفقيت ارسال شد")
        Catch ex As Exception
            MessageBox.Show("FrmReport.BtnOnLineEbtal_Click" + vbCrLf + ex.Message)
        End Try
    End Sub
End Class