
Imports Microsoft.Win32

Public Class RegisterApp
    Private Sub BtnCreateRegistery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCreateRegistery.Click
        Try
            Registry.CurrentUser.CreateSubKey("TWS")
            Registry.CurrentUser.CreateSubKey("TWS\GarbageTimerInterval")
            Registry.SetValue("HKEY_CURRENT_USER\TWS\GarbageTimerInterval", "GarbageTimerInterval", "60000")
            Registry.CurrentUser.CreateSubKey("TWS\SyncCounting")
            Registry.SetValue("HKEY_CURRENT_USER\TWS\SyncCounting", "SyncCounting", "1")
            Registry.CurrentUser.CreateSubKey("TWS\TerminalId")
            Registry.SetValue("HKEY_CURRENT_USER\TWS\TerminalId", "TerminalId", "2")
            Registry.CurrentUser.CreateSubKey("TWS\TimerInterval")
            Registry.SetValue("HKEY_CURRENT_USER\TWS\TimerInterval", "TimerInterval", "60000")
            Registry.CurrentUser.CreateSubKey("TWS\TWSConnectionString")
            Registry.SetValue("HKEY_CURRENT_USER\TWS\TWSConnectionString", "TWSClientConnectionString", "")
            MessageBox.Show("All Registry Keys Created ...")
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub
    Private Sub BtnSubMit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSubMit.Click
        Try
            Registry.SetValue("HKEY_CURRENT_USER\TWS\TWSConnectionString", "TWSClientConnectionString", TxtCNN.Text.Trim)
            MessageBox.Show("All Registry Keys Submitted ...")
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub
End Class
