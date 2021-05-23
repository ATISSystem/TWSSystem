
Public Class FrmApp

    Private Sub BtnCenterControl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCenterControl.Click
        Try
            Dim myFrmCenterControl As New FrmCenterControl
            myFrmCenterControl.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub

    Private Sub BtnOnlineReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOnlineReport.Click
        Try
            Dim myFrmOnLineReport As New FrmReport
            myFrmOnLineReport.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub

    Private Sub BtnOffLineReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim myFrmOffLineReport As New FrmReport
            myFrmOffLineReport.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub

   
End Class
