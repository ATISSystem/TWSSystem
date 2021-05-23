
Imports TWSClassLibrary.TWSPublicEnums

Public Class TWSQueryTruck
    Inherits TWSQueryGeneral


    Private myTrucksArray As TWSStandardTruckStructure()

#Region "Public Fields"
    Public Function TruckId(ByVal index As Int64) As String
        Try
            Return myTrucksArray(index).OCode.Trim
        Catch ex As Exception
            Throw New Exception("TWSQueryTRuck.TruckId()." + ex.Message.ToString)
        End Try
    End Function
    Public Function TruckName(ByVal index As Int64) As String
        Try
            Return myTrucksArray(index).OName.Trim
        Catch ex As Exception
            Throw New Exception("TWSQueryTRuck.TruckName()." + ex.Message.ToString)
        End Try
    End Function
    Public Function TruckName(ByVal TruckIdd As String) As String
        Try
            For loopx As Int32 = 0 To Teadad - 1
                If (myTrucksArray(loopx).OCode.Trim = TruckIdd.Trim) Then
                    Return myTrucksArray(loopx).OName.Trim
                End If
            Next
            Throw New Exception("Invalid TruckId=" + TruckIdd.ToString)
        Catch ex As Exception
            Throw New Exception("TWSQueryTRuck.TruckName()." + ex.Message.ToString)
        End Try
    End Function
    Public Function Pelak(ByVal index As Int64) As String
        Try
            Return myTrucksArray(index).Pelak.Trim
        Catch ex As Exception
            Throw New Exception("TWSQueryTRuck.Pelak()." + ex.Message.ToString)
        End Try
    End Function
    Public Function Pelak(ByVal TruckIdd As String) As String
        Try
            For loopx As Int32 = 0 To Teadad - 1
                If (myTrucksArray(loopx).OCode.Trim = TruckIdd.Trim) Then
                    Return myTrucksArray(loopx).Pelak.Trim
                End If
            Next
            Throw New Exception("Invalid TruckId=" + TruckIdd.ToString)
        Catch ex As Exception
            Throw New Exception("TWSQueryTRuck.Pelak()." + ex.Message.ToString)
        End Try
    End Function
    Public Function Serial(ByVal index As Int64) As String
        Try
            Return myTrucksArray(index).Serial.Trim
        Catch ex As Exception
            Throw New Exception("TWSQueryTRuck.Serial()." + ex.Message.ToString)
        End Try
    End Function
    Public Function Serial(ByVal TruckIdd As String) As String
        Try
            For loopx As Int32 = 0 To Teadad - 1
                If (myTrucksArray(loopx).OCode.Trim = TruckIdd.Trim) Then
                    Return myTrucksArray(loopx).Serial.Trim
                End If
            Next
            Throw New Exception("Invalid TruckId=" + TruckIdd.ToString)
        Catch ex As Exception
            Throw New Exception("TWSQueryTRuck.Serial()." + ex.Message.ToString)
        End Try
    End Function

#End Region
#Region "Public Overrides"
    Public Overrides Function ExistInQueryOCode(ByVal Ocode As String) As Boolean
        Try
            For loopx As Int64 = 0 To Teadad - 1
                If myTrucksArray(loopx).OCode.Trim = Ocode.Trim Then
                    Return True
                End If
            Next
            Return False
        Catch ex As Exception
            Throw New Exception("TWSQueryTruck.ExistInQueryOCode(Ocode)." + ex.Message.ToString)
        End Try
    End Function
    Public Overrides Function ExistInQueryOName(ByVal OName As String) As Boolean
        Try
            For loopx As Int64 = 0 To Teadad - 1
                If myTrucksArray(loopx).OName.Trim = OName.Trim Then
                    Return True
                End If
            Next
            Return False
        Catch ex As Exception
            Throw New Exception("TWSQueryTruck.ExistInQueryOName(Ocode)." + ex.Message.ToString)
        End Try
    End Function
    Public Overrides Function Getindex(ByVal OCode As String) As Long
        Try
            Dim myOcode As String = OCode.Trim
            For loopx As Int64 = 0 To Teadad - 1
                If myTrucksArray(loopx).OCode.Trim = myOcode Then
                    Return loopx
                End If
            Next
        Catch ex As Exception
            Throw New Exception("TWSQueryTruck.Getindex()." + ex.Message.ToString)
        End Try
    End Function
    Public Overrides Function GetIndexBySearchStrInStartCharacters(ByVal SearchStr As String) As Integer
        Try
            Dim mySearchStr As String = SearchStr.Trim
            For loopx As Int64 = 0 To Teadad - 1
                If Mid(myTrucksArray(loopx).OName.Trim, 1, mySearchStr.Length) = mySearchStr Then Return loopx
            Next
            Return -1
        Catch ex As Exception
            Throw New Exception("TWSQueryTruck.GetIndexBySearchStrInStartCharacters()." + ex.Message.ToString)
        End Try
    End Function
    Public Overrides Function GetValidOCodeFromOName(ByVal ONamee As String) As String
        Try
            For loopx As Int16 = 0 To Teadad - 1
                If myTrucksArray(loopx).OName.Trim = ONamee.Trim Then Return myTrucksArray(loopx).OCode.Trim
            Next
            Throw New Exception("OName Is Not Valid")
        Catch ex As Exception
            Throw New Exception("TWSQueryTruck.GetValidOCodeFromOName()." + ex.Message.ToString)
        End Try
    End Function
    Public Overrides Function GetValidONameFromOCode(ByVal OCodee As String) As String
        Try
            For loopx As Int16 = 0 To Teadad - 1
                If myTrucksArray(loopx).OCode.Trim = OCodee.Trim Then Return myTrucksArray(loopx).OName.Trim
            Next
            Throw New Exception("OCode Is Not Valid")
        Catch ex As Exception
            Throw New Exception("TWSQueryTruck.GetValidONameFromOCode()." + ex.Message.ToString)
        End Try
    End Function
    Public Overrides Function IsValidOCode(ByVal OCodee As String) As Boolean
        Try
            For loopx As Int16 = 0 To Teadad - 1
                If myTrucksArray(loopx).OCode.Trim = OCodee.Trim Then Return True
            Next
            Return False
        Catch ex As Exception
            Throw New Exception("TWSQueryTruck.IsValidOCode()." + ex.Message.ToString)
        End Try
    End Function
    Public Overrides Function IsValidOName(ByVal ONamee As String) As Boolean
        Try
            For loopx As Int16 = 0 To Teadad - 1
                If myTrucksArray(loopx).OName.Trim = ONamee.Trim Then Return True
            Next
            Return False
        Catch ex As Exception
            Throw New Exception("TWSQueryTruck.IsValidOName()." + ex.Message.ToString)
        End Try
    End Function
    Public Overrides Sub Preparing(ByVal TDBConnectionString As String, ByVal PrepareCode As Short, ByVal SortOrder As CodeNameSortOrder, Optional ByVal SearchStr As Object = "", Optional ByVal Param1 As Object = "", Optional ByVal Param2 As Object = "", Optional ByVal Param3 As Object = "", Optional ByVal Param4 As Long = -1)
        Try
            TeadadSet = 0
            Dim da As New SqlClient.SqlDataAdapter : Dim ds As New DataSet
            da.SelectCommand = New SqlClient.SqlCommand
            da.SelectCommand.Connection = New SqlClient.SqlConnection(TDBConnectionString)
            ds.Tables.Clear()

            Dim myOrderBy As String = IIf(SortOrder = CodeNameSortOrder.Code, " order by Truckid", " order by Pelak")
            Select Case PrepareCode
                Case 1
                    da.SelectCommand.CommandText = "select * from TblTrucks " + myOrderBy
                    da.Fill(ds)
                Case 2
                    If SearchStr.trim = "" Then
                        da.SelectCommand.CommandText = "select * from TblTrucks " + myOrderBy
                        da.Fill(ds)
                    Else
                        da.SelectCommand.CommandText = "select * from TblTrucks where  ltrim(rtrim(Pelak)) like '%" & Trim(SearchStr.trim) & "%'   " + myOrderBy
                        da.Fill(ds)
                    End If
            End Select
            If ds.Tables(0).Rows.Count <> 0 Then
                TeadadSet = ds.Tables(0).Rows.Count
                ReDim myTrucksArray(ds.Tables(0).Rows.Count)
                For loopx As Int64 = 0 To ds.Tables(0).Rows.Count - 1
                    myTrucksArray(loopx) = New TWSStandardTruckStructure(ds.Tables(0).Rows(loopx).Item("truckid"), Trim(ds.Tables(0).Rows(loopx).Item("pelak")), Trim(ds.Tables(0).Rows(loopx).Item("serial")))
                Next
            End If
        Catch ex As Exception
            Throw New Exception("TWSQueryTruck.Preparing()." + ex.Message.ToString)
        End Try
    End Sub
#End Region

End Class
