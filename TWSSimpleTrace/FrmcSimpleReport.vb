
Imports System.Globalization

Public Class FrmcSimpleReport

    Private TWS As TerminalsWebService.TerminalsWebServiceSoap = New TerminalsWebService.TerminalsWebServiceSoapClient
    Private myStartDateTime As DateTime = Nothing
    Private WithEvents SimpleReportTimer As System.Windows.Forms.Timer = New System.Windows.Forms.Timer



    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Try
            If myStartDateTime = Nothing Then
                myStartDateTime = Date.Now
            End If
            SimpleReportTimer.Interval = 5000
            SimpleReportTimer.Enabled = True
            SimpleReportTimer.Start()
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub

    Private Sub FrmcSimpleReport_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        SimpleReportTimer.Stop()
        SimpleReportTimer.Dispose()
    End Sub

    Private Sub SimpleReportTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleReportTimer.Tick
        Try
            Dim myData As New DataSet
            If PnlMain.Controls.Count > 100 Then
                PnlMain.Controls.Clear()
            End If
            myData.Tables.Clear()
            If TWS.WebMethodLoggingReport(MClassManagement.AuthenticationId, myStartDateTime.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture), myData) <> 0 Then
                For Each UC As UcSingleLogHolder In PnlMain.Controls
                    UC.SetOld()
                Next
                ViewReport(myData)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
            SimpleReportTimer.Stop 
        End Try
    End Sub

    Private Sub ViewReport(ByVal Data As DataSet)
        Try
            For loopx As Int32 = 0 To Data.Tables(0).Rows.Count - 1
                'If Data.Tables(0).Rows(loopx).Item("logid").ToString.Trim = "3" Or Data.Tables(0).Rows(loopx).Item("logid").ToString.Trim = "2" Or Data.Tables(0).Rows(loopx).Item("logid").ToString.Trim = "0" Then
                Dim myUC As UcSingleLogHolder = New UcSingleLogHolder
                Dim myTerminal As String = Data.Tables(0).Rows(loopx).Item("TerminalName")
                Dim myDataAndTime As String = Data.Tables(0).Rows(loopx).Item("DateTimeMilladi")
                Dim myShDate As String = Data.Tables(0).Rows(loopx).Item("ShDate")
                Dim myTime As String = Data.Tables(0).Rows(loopx).Item("Time")
                Dim myLogNote As String = Data.Tables(0).Rows(loopx).Item("LogNote")
                myUC.ShowInf(New MClassManagement.StandardLogStructure(myTerminal, myDataAndTime, myShDate, myTime, myLogNote))
                myUC.Dock = DockStyle.Top
                PnlMain.Controls.Add(myUC)
                'End If
            Next
            myStartDateTime = Data.Tables(0).Rows(Data.Tables(0).Rows.Count - 1).Item("DateTimeMilladi")
        Catch ex As Exception
            Throw New Exception("ViewReport()." + ex.Message.ToString)
        End Try
    End Sub

    Private Sub LblMin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LblMin.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub PicEnd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicEnd.Click
        End
    End Sub

    Private Sub PicRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        SimpleReportTimer.Start()
    End Sub
End Class
