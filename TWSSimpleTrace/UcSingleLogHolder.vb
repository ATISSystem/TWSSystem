

Public Class UcSingleLogHolder

#Region "Sub And Function"
    Public Sub SetOld()
        LblNew.Text = ""
    End Sub
    Public Sub ShowInf(ByVal LogS As MClassManagement.StandardLogStructure)
        Try
            LblShamsiDate.Text = LogS.ShDate
            LblTime.Text = LogS.Time
            LblTerminal.Text = LogS.Terminal
            LblLogNote.Text = LogS.LogNote
            LblNew.Text = "جديد"
            If LogS.Terminal.Trim = "درخواست وضعيت" Then LblTerminal.ForeColor = Color.Crimson
        Catch ex As Exception
            Throw New Exception("UcSingleLogHolder.ShowInf()." + ex.Message.ToString)
        End Try
    End Sub
#End Region





   
End Class
