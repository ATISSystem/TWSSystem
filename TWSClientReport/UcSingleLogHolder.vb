
Imports TWSClassLibrary.LoggingManagement
Imports TWSClassLibrary.DateAndTimeManagement
Imports TWSClassLibrary.NobatsManagement
Public Class UcSingleLogHolder

    Public Event UCClicked(ByVal CurrentTruckTrace As StandardTruckTraceStructure)
    Private CurrentTruckTrace As StandardTruckTraceStructure
#Region "Sub And Function"
    Public Sub ShowInf(ByVal TruckTrace As StandardTruckTraceStructure)
        Try
            CurrentTruckTrace = TruckTrace
            Dim myStatus As NobatsStatus = TruckTrace.Status
            LblStatus.Text = TWSClassNobatsManagement.GetStatusNameByCode(myStatus)
            If (myStatus = NobatsStatus.Added) Or (myStatus = NobatsStatus.Sodoor) Then
                LblShamsiDate.Text = TWSClassDateAndTimeManagement.ConvertToShamsiDate(TruckTrace.SodoorTime)
                LblTime.Text = TWSClassDateAndTimeManagement.GetTimeOfDate(TruckTrace.SodoorTime)
            ElseIf myStatus = NobatsStatus.Deleted Then
                If TruckTrace.TraceWriter.Trim = "WebService" Then
                    LblShamsiDate.Text = TWSClassDateAndTimeManagement.ConvertToShamsiDate(TruckTrace.SodoorTime)
                    LblTime.Text = TWSClassDateAndTimeManagement.GetTimeOfDate(TruckTrace.SodoorTime)
                Else
                    LblShamsiDate.Text = TWSClassDateAndTimeManagement.ConvertToShamsiDate(TruckTrace.DateReal)
                    LblTime.Text = TWSClassDateAndTimeManagement.GetTimeOfDate(TruckTrace.DateReal)
                End If
            ElseIf (myStatus = NobatsStatus.DelNobatBarnamehOnline) Or (myStatus = NobatsStatus.DelNobatOverOne1) Or (myStatus = NobatsStatus.DelNobatUserRequest) Then
                LblShamsiDate.Text = TWSClassDateAndTimeManagement.ConvertToShamsiDate(TruckTrace.DateReal)
                LblTime.Text = TWSClassDateAndTimeManagement.GetTimeOfDate(TruckTrace.DateReal)
            End If
            LblTerminal.Text = TruckTrace.TerminalName
            LblTraceWriter.Text = TruckTrace.TraceWriter
            If myStatus = NobatsStatus.Added Then
                PnlMain.BackColor = Color.Green
                LblTravelTime.Text = ""
            ElseIf myStatus = NobatsStatus.Deleted Then
                PnlMain.BackColor = Color.Red
                LblTravelTime.Text = ""
            ElseIf myStatus = NobatsStatus.Sodoor Then
                PnlMain.BackColor = Color.Blue
                LblTravelTime.Text = TruckTrace.TravelTime
            ElseIf myStatus = NobatsStatus.DelNobatBarnamehOnline Then
                PnlMain.BackColor = Color.Crimson
                LblTravelTime.Text = ""
            ElseIf myStatus = NobatsStatus.DelNobatOverOne1 Then
                PnlMain.BackColor = Color.DeepPink
                LblTravelTime.Text = ""
            ElseIf myStatus = NobatsStatus.DelNobatUserRequest Then
                PnlMain.BackColor = Color.Magenta
                LblTravelTime.Text = ""
            ElseIf myStatus = NobatsStatus.None Then
                PnlMain.BackColor = Color.White
                LblTravelTime.Text = ""
            End If
        Catch ex As Exception
            Throw New Exception("UcSingleLogHolder.ShowInf()." + ex.Message.ToString)
        End Try
    End Sub
#End Region
#Region "Event Management"
    Private Sub LblsClicked_Handler(ByVal sender As Object, ByVal e As EventArgs) Handles LblShamsiDate.Click, LblStatus.Click, LblTerminal.Click, LblTime.Click, LblTraceWriter.Click, LblTravelTime.Click
        Try
            RaiseEvent UCClicked(CurrentTruckTrace)
        Catch ex As Exception
            MessageBox.Show("UcSingleLogHolder.LblsClicked_Handler" + vbCrLf + ex.Message)
        End Try
    End Sub

#End Region






End Class
