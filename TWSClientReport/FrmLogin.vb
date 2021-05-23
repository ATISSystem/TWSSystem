



Public Class FrmLogin

    Private TWS As TerminalsWebService.TerminalsWebServiceSoap = New TerminalsWebService.TerminalsWebServiceSoapClient

#Region "FrmLogin"
    Private Sub FrmReport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    End Sub
    Private Sub BtnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim myAuthenticate As Boolean = TWS.WebMethodUserAuthentication(MClassAuthenticationManagement.AuthenticationId, TxtUserId.Text.Trim, TxtUserPassword.Text.Trim)
            If myAuthenticate = True Then
                Me.Hide()
                Dim myFrm As FrmReport = New FrmReport
                myFrm.Show()
                Exit Try
            Else
                MessageBox.Show("مشخصات کاربري نادرست است", "TWSClientOfflineReport", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Try
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "TWSClientOfflineReport", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        End
    End Sub
    Private Sub TxtUserId_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtUserId.KeyPress
        If Asc(e.KeyChar) = 13 Then TxtUserPassword.Focus()
    End Sub
    Private Sub TxtUserPassword_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtUserPassword.KeyPress
        If Asc(e.KeyChar) = 13 Then BtnOk.Focus()
    End Sub

#End Region

#Region "Subs And Functions Other Events"
#End Region






End Class