
Imports TWSClassLibrary.LoggingManagement
Public Class UcSingleLogHolder

    Private UcStatus As String = "Small"
    Public Event ContentClick(ByVal ContentString As String)




#Region "Sub And Function"
    Public Sub SetOld()
        LblNew.Text = ""
        LblNew2.Text = ""
    End Sub
    Public Sub SetColored(ByVal Color As Color)
        PnlColered.BackColor = Color
    End Sub
    Public Sub ShowInf(ByVal LogS As StandardLogStructure)
        Try
            LblAckSignal.Text = LogS.AckSignal
            LblSystemStatus.Text = LogS.SystemStatus
            LblSyncCounting.Text = LogS.SyncCounting
            LblDateAndTime.Text = LogS.DateAndTime
            LblShamsiDate.Text = LogS.ShDate
            LblTime.Text = LogS.Time
            LblLogId.Text = LogS.LogId
            LblLogSource.Text = LogS.LogSource
            LblTDB.Text = LogS.TDB
            LblTDBObject.Text = LogS.TDBObject
            LblTerminal.Text = LogS.Terminal
            LblUserName.Text = LogS.UserName
            LblMethodName.Text = LogS.MethodName
            LblAuthenticationResult.Text = LogS.AuthenticationResult
            LblAId.Text = LogS.AuthenticationId
            LblTrucksInTotal.Text = LogS.TrucksInTotal
            LblTrucksInContent.Text = LogS.TrucksInContent
            LblTrucksOutTotal.Text = LogS.TrucksOutTotal
            LblTrucksOutContent.Text = LogS.TrucksOutContent
            LblNobatsInAddTotal.Text = LogS.NobatsInAddTotal
            LblNobatsInAddContent.Text = LogS.NobatsInAddContent
            LblNobatsInDelTotal.Text = LogS.NobatsInDelTotal
            LblNobatsInDelContent.Text = LogS.NobatsInDelContent
            LblNobatsInSodoorTotal.Text = LogS.NobatsInSodoorTotal
            LblNobatsInSodoorContent.Text = LogS.NobatsInSodoorContent
            LblNobatsInTotal.Text = Convert.ToInt16(LblNobatsInAddTotal.Text) + Convert.ToInt16(LblNobatsInDelTotal.Text) + Convert.ToInt16(LblNobatsInSodoorTotal.Text)
            LblNobatsOutAddTotal.Text = LogS.NobatsOutAddTotal
            LblNobatsOutAddContent.Text = LogS.NobatsOutAddContent
            LblNobatsOutDelTotal.Text = LogS.NobatsOutDelTotal
            LblNobatsOutDelContent.Text = LogS.NobatsOutDelContent
            LblNobatsOutSodoorTotal.Text = LogS.NobatsOutSodoorTotal
            LblNobatsOutSodoorContent.Text = LogS.NobatsOutSodoorContent
            LblNobatsOutTotal.Text = Convert.ToInt16(LblNobatsOutAddTotal.Text) + Convert.ToInt16(LblNobatsOutDelTotal.Text) + Convert.ToInt16(LblNobatsOutSodoorTotal.Text)
            LblNobatsEndTravelTimeTotal.Text = LogS.NobatsEndTravelTimeTotal
            LblNobatsEndTravelTimeContent.Text = LogS.NobatsEndTravelTimeContent
            LblTerminalsOutTotal.Text = LogS.TerminalsOutTotal
            LblTerminalsOutContent.Text = LogS.TerminalsOutContent
            LblLogNote.Text = LogS.LogNote
            PicReport.BackColor = Color.Violet
            If LogS.LogId.Trim = "ErrorLog" Then
                PicReport.BackColor = Color.Red
            ElseIf LogS.LogId.Trim = "SyncTrucks" Then
                PicReport.BackColor = Color.Yellow
            ElseIf LogS.LogId.Trim = "SyncAll" Then
                PicReport.BackColor = Color.Green
            ElseIf LogS.LogId.Trim = "Warning" Then
                PicReport.BackColor = Color.Red
            ElseIf LogS.LogId.Trim = "ServerWinServiceGarbageTimerElapsed" Then
                PicReport.BackColor = Color.Chocolate
            ElseIf LogS.LogId.Trim = "NoneOrMsg" Then
                PicReport.BackColor = Color.Blue
            End If
            LblNew.Text = "New"
            LblNew2.Text = "New"
        Catch ex As Exception
            Throw New Exception("UcSingleLogHolder.ShowInf()." + ex.Message.ToString)
        End Try
    End Sub
#End Region
#Region "Event Management"
    Private Sub MinimizeMaximize()
        Try
            If UcStatus = "Small" Then
                UcStatus = "Big"
                PicSize.Image = ImageList.Images.Item(1)
                Me.Size = New Size(Me.Size.Width, 320)
            ElseIf UcStatus = "Big" Then
                UcStatus = "Small"
                PicSize.Image = ImageList.Images.Item(0)
                Me.Size = New Size(Me.Size.Width, 136)
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message.ToString)
        End Try
    End Sub
    Private Sub PnlMain_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PnlMain.Click
        Try
            MinimizeMaximize()
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub
    Private Sub PicSize_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PicSize.Click
        Try
            MinimizeMaximize()
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub
    Private Sub LblLogNote_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LblLogNote.Click
        RaiseEvent ContentClick(LblLogNote.Text)
    End Sub
    Private Sub LblTDBObject_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LblTDBObject.Click
        RaiseEvent ContentClick(LblTDBObject.Text)
    End Sub
    Private Sub LblTrucksInContent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LblTrucksInContent.Click
        RaiseEvent ContentClick(LblTrucksInContent.Text)
    End Sub
    Private Sub LblTrucksOutContent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LblTrucksOutContent.Click
        RaiseEvent ContentClick(LblTrucksOutContent.Text)
    End Sub
    Private Sub LblNobatsInAddContent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LblNobatsInAddContent.Click
        RaiseEvent ContentClick(LblNobatsInAddContent.Text)
    End Sub
    Private Sub LblNobatsInDelContent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LblNobatsInDelContent.Click
        RaiseEvent ContentClick(LblNobatsInDelContent.Text)
    End Sub
    Private Sub LblNobatsInSodoorContent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LblNobatsInSodoorContent.Click
        RaiseEvent ContentClick(LblNobatsInSodoorContent.Text)
    End Sub
    Private Sub LblNobatsOutAddContent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LblNobatsOutAddContent.Click
        RaiseEvent ContentClick(LblNobatsOutAddContent.Text)
    End Sub
    Private Sub LblNobatsOutDelContent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LblNobatsOutDelContent.Click
        RaiseEvent ContentClick(LblNobatsOutDelContent.Text)
    End Sub
    Private Sub LblNobatsOutSodoorContent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LblNobatsOutSodoorContent.Click
        RaiseEvent ContentClick(LblNobatsOutSodoorContent.Text)
    End Sub
    Private Sub LblNobatsEndTravelTimeContent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LblNobatsEndTravelTimeContent.Click
        RaiseEvent ContentClick(LblNobatsEndTravelTimeContent.Text)
    End Sub
    Private Sub LblTerminalsOutContent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LblTerminalsOutContent.Click
        RaiseEvent ContentClick(LblTerminalsOutContent.Text)
    End Sub
    Private Sub PicReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicReport.Click
        Try
            MinimizeMaximize()
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub
#End Region





   
End Class
