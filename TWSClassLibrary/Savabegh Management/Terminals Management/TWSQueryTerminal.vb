

Imports TWSClassLibrary.TWSPublicEnums
Public Class TWSQueryTerminal
    Inherits TWSQueryGeneral


    Private myTerminalsArray As TWSStandardTerminalStructure()

#Region "Public Fields"
    Public Function TerminalId(ByVal index As Int64) As String
        Try
            Return myTerminalsArray(index).OCode.Trim
        Catch ex As Exception
            Throw New Exception("TWSQueryTerminal.TerminalId()." + ex.Message.ToString)
        End Try
    End Function
    Public Function TerminalName(ByVal index As Int64) As String
        Try
            Return myTerminalsArray(index).OName.Trim
        Catch ex As Exception
            Throw New Exception("TWSQueryTerminal.TerminalName()." + ex.Message.ToString)
        End Try
    End Function
    Public Function TerminalName(ByVal TerminalIdd As String) As String
        Try
            For loopx As Int32 = 0 To Teadad - 1
                If (myTerminalsArray(loopx).OCode.Trim = TerminalIdd.Trim) Then
                    Return myTerminalsArray(loopx).OName.Trim
                End If
            Next
        Catch ex As Exception
            Throw New Exception("TWSQueryTerminal.TerminalName()." + ex.Message.ToString)
        End Try
    End Function
#End Region
#Region "Public Overrides"
    Public Overrides Function ExistInQueryOCode(ByVal Ocode As String) As Boolean
        Try
            For loopx As Int64 = 0 To Teadad - 1
                If myTerminalsArray(loopx).OCode.Trim = Ocode.Trim Then
                    Return True
                End If
            Next
            Return False
        Catch ex As Exception
            Throw New Exception("TWSQueryTerminal.ExistInQueryOCode(Ocode)." + ex.Message.ToString)
        End Try
    End Function
    Public Overrides Function ExistInQueryOName(ByVal OName As String) As Boolean
        Try
            For loopx As Int64 = 0 To Teadad - 1
                If myTerminalsArray(loopx).OName.Trim = OName.Trim Then
                    Return True
                End If
            Next
            Return False
        Catch ex As Exception
            Throw New Exception("TWSQueryTerminal.ExistInQueryOName(Ocode)." + ex.Message.ToString)
        End Try
    End Function
    Public Overrides Function Getindex(ByVal OCode As String) As Long
        Try
            Dim myOcode As String = OCode.Trim
            For loopx As Int64 = 0 To Teadad - 1
                If myTerminalsArray(loopx).OCode.Trim = myOcode Then
                    Return loopx
                End If
            Next
        Catch ex As Exception
            Throw New Exception("TWSQueryTerminal.Getindex()." + ex.Message.ToString)
        End Try
    End Function
    Public Overrides Function GetIndexBySearchStrInStartCharacters(ByVal SearchStr As String) As Integer
        Try
            Dim mySearchStr As String = SearchStr.Trim
            For loopx As Int64 = 0 To Teadad - 1
                If Mid(myTerminalsArray(loopx).OName.Trim, 1, mySearchStr.Length) = mySearchStr Then Return loopx
            Next
            Return -1
        Catch ex As Exception
            Throw New Exception("TWSQueryTerminal.GetIndexBySearchStrInStartCharacters()." + ex.Message.ToString)
        End Try
    End Function
    Public Overrides Function GetValidOCodeFromOName(ByVal ONamee As String) As String
        Try
            For loopx As Int16 = 0 To Teadad - 1
                If myTerminalsArray(loopx).OName.Trim = ONamee.Trim Then Return myTerminalsArray(loopx).OCode.Trim
            Next
            Throw New Exception("OName Is Not Valid")
        Catch ex As Exception
            Throw New Exception("TWSQueryTerminal.GetValidOCodeFromOName()." + ex.Message.ToString)
        End Try
    End Function
    Public Overrides Function GetValidONameFromOCode(ByVal OCodee As String) As String
        Try
            For loopx As Int16 = 0 To Teadad - 1
                If myTerminalsArray(loopx).OCode.Trim = OCodee.Trim Then Return myTerminalsArray(loopx).OName.Trim
            Next
            Throw New Exception("OCode Is Not Valid")
        Catch ex As Exception
            Throw New Exception("TWSQueryTerminal.GetValidONameFromOCode()." + ex.Message.ToString)
        End Try
    End Function
    Public Overrides Function IsValidOCode(ByVal OCodee As String) As Boolean
        Try
            For loopx As Int16 = 0 To Teadad - 1
                If myTerminalsArray(loopx).OCode.Trim = OCodee.Trim Then Return True
            Next
            Return False
        Catch ex As Exception
            Throw New Exception("TWSQueryTerminal.IsValidOCode()." + ex.Message.ToString)
        End Try
    End Function
    Public Overrides Function IsValidOName(ByVal ONamee As String) As Boolean
        Try
            For loopx As Int16 = 0 To Teadad - 1
                If myTerminalsArray(loopx).OName.Trim = ONamee.Trim Then Return True
            Next
            Return False
        Catch ex As Exception
            Throw New Exception("TWSQueryTerminal.IsValidOName()." + ex.Message.ToString)
        End Try
    End Function
    Public Overrides Sub Preparing(ByVal TDBConnectionString As String, ByVal PrepareCode As Short, ByVal SortOrder As CodeNameSortOrder, Optional ByVal SearchStr As Object = "", Optional ByVal Param1 As Object = "", Optional ByVal Param2 As Object = "", Optional ByVal Param3 As Object = "", Optional ByVal Param4 As Long = -1)
        Try
            TeadadSet = 0
            Dim da As New SqlClient.SqlDataAdapter : Dim ds As New DataSet
            da.SelectCommand = New SqlClient.SqlCommand
            da.SelectCommand.Connection = New SqlClient.SqlConnection(TDBConnectionString)
            ds.Tables.Clear()

            Dim myOrderBy As String = IIf(SortOrder = CodeNameSortOrder.Code, " order by TerminalId", " order by TerminalName")
            Select Case PrepareCode
                Case 1
                    da.SelectCommand.CommandText = "select * from tblterminals " + myOrderBy
                    da.Fill(ds)
                Case 2
                    If SearchStr.trim = "" Then
                        da.SelectCommand.CommandText = "select * from tblterminals " + myOrderBy
                        da.Fill(ds)
                    Else
                        da.SelectCommand.CommandText = "select * from tblterminals where  ltrim(rtrim(Terminalname)) like '%" & Trim(SearchStr.trim) & "%'   " + myOrderBy
                        da.Fill(ds)
                    End If
            End Select
            If ds.Tables(0).Rows.Count <> 0 Then
                TeadadSet = ds.Tables(0).Rows.Count
                ReDim myTerminalsArray(ds.Tables(0).Rows.Count)
                For loopx As Int64 = 0 To ds.Tables(0).Rows.Count - 1
                    myTerminalsArray(loopx) = New TWSStandardTerminalStructure(ds.Tables(0).Rows(loopx).Item("terminalid"), Trim(ds.Tables(0).Rows(loopx).Item("terminalname")), Trim(ds.Tables(0).Rows(loopx).Item("rndcode")))
                Next
            End If
        Catch ex As Exception
            Throw New Exception("TWSQueryTerminal.Preparing()." + ex.Message.ToString)
        End Try
    End Sub
#End Region

End Class
