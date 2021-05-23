
Imports System.Globalization

Imports TWSClassLibrary.TrucksManagement.TWSClassTrucksManagement
Imports TWSClassLibrary.NobatsManagement
Imports TWSClassLibrary.ConfigurationManagement


Public MustInherit Class MClassNobatsManagement

    Public Shared Function GetSyncChangedNobats() As DataSet
        Dim Cmdsql As New SqlClient.SqlCommand
        Cmdsql.Connection = New SqlClient.SqlConnection(TWSClassConfigurationManagement.GetTDBClientConnectionString)
        Try
            Dim da As New SqlClient.SqlDataAdapter : Dim ds As New DataSet
            da.SelectCommand = New SqlClient.SqlCommand("select B.TruckId,A.Status,A.TravelTime,A.SodoorTime from TblSyncChangedNobats as A inner join TblTrucks as B on (A.Pelak=B.Pelak) and (A.Serial=B.Serial) order by truckid,sodoortime asc")
            da.SelectCommand.Connection = New SqlClient.SqlConnection(TWSClassConfigurationManagement.GetTDBClientConnectionString)
            ds.Tables.Clear()
            da.Fill(ds)
            Cmdsql.Connection.Open()
            Cmdsql.CommandText = "update TblSyncChangedNobats set DelFlag=1"
            Cmdsql.ExecuteNonQuery()
            Cmdsql.Connection.Close()
            Return ds
        Catch ex As Exception
            If Cmdsql.Connection.State <> ConnectionState.Closed Then Cmdsql.Connection.Close()
            Throw New Exception("MClassNobatsManagement.GetSyncChangedNobats()." + ex.Message.ToString)
        End Try
    End Function
    Public Shared Sub DelSyncChangedNobats()
        Dim Cmdsql As New SqlClient.SqlCommand
        Cmdsql.Connection = New SqlClient.SqlConnection(TWSClassConfigurationManagement.GetTDBClientConnectionString)
        Try
            Cmdsql.Connection.Open()
            Cmdsql.CommandText = "delete TblSyncChangedNobats where DelFlag=1"
            Cmdsql.ExecuteNonQuery()
            Cmdsql.Connection.Close()
        Catch ex As Exception
            Throw New Exception("MClassNobatsManagement.DelSyncChangedNobats()." + ex.Message.ToString)
        End Try
    End Sub
    Private Shared Function DelNobatInLocalSystemBySTP(ByVal Pelak As String, ByVal Serial As String) As Object
        Dim CmdSqlLocalSystem As New SqlClient.SqlCommand
        CmdSqlLocalSystem.Connection = New SqlClient.SqlConnection(TWSClassConfigurationManagement.GetLocalSystemConnectionString)
        Try
            CmdSqlLocalSystem.CommandType = CommandType.StoredProcedure
            CmdSqlLocalSystem.CommandText = "TDBClientDelNobat"
            CmdSqlLocalSystem.Parameters.Add("@Pelak", SqlDbType.NVarChar).Value = Pelak
            CmdSqlLocalSystem.Parameters.Add("@Serial", SqlDbType.NVarChar).Value = Serial
            Dim myRetParam As SqlClient.SqlParameter = New SqlClient.SqlParameter("@ReturnValue", System.Data.SqlDbType.NVarChar)
            myRetParam.Direction = System.Data.ParameterDirection.ReturnValue
            CmdSqlLocalSystem.Parameters.Add(myRetParam)
            CmdSqlLocalSystem.Connection.Open()
            CmdSqlLocalSystem.ExecuteNonQuery()
            CmdSqlLocalSystem.Connection.Close()
            Return CmdSqlLocalSystem.Parameters("@ReturnValue").SqlValue
        Catch ex As Exception
            If CmdSqlLocalSystem.Connection.State <> ConnectionState.Closed Then CmdSqlLocalSystem.Connection.Close()
            Throw New Exception("MClassNobatsManagement.DelNobatInLocalSystemBySTP" + ex.Message)
        End Try
    End Function
    Public Shared Sub SetSyncChangedNobats(ByVal SyncDS As DataSet)
        Dim Cmdsql As New SqlClient.SqlCommand
        Cmdsql.Connection = New SqlClient.SqlConnection(TWSClassConfigurationManagement.GetTDBClientConnectionString)
        Try
            Cmdsql.Connection.Open()
            Cmdsql.Transaction = Cmdsql.Connection.BeginTransaction
            For loopx As Int32 = 0 To SyncDS.Tables(0).Rows.Count - 1
                Dim myTruckId As Int32 = SyncDS.Tables(0).Rows(loopx).Item(0)
                Dim myTerminalId As Int16 = SyncDS.Tables(0).Rows(loopx).Item(2)
                Dim myPelak As String = GetPelakFromTruckId(myTruckId, TWSClassConfigurationManagement.GetTDBClientConnectionString)
                Dim mySerial As String = GetSerialFromTruckId(myTruckId, TWSClassConfigurationManagement.GetTDBClientConnectionString)
                Dim myTravelTime As Int16 = SyncDS.Tables(0).Rows(loopx).Item(3)
                Dim mySodoorTime As DateTime = SyncDS.Tables(0).Rows(loopx).Item(4)
                If SyncDS.Tables(0).Rows(loopx).Item(1) = NobatsStatus.Added Then
                    Cmdsql.CommandText = "insert into TblSyncServerNobats(Pelak,Serial,TerminalId,TravelTime,SodoorTime) values('" & myPelak & "','" & mySerial & "'," & myTerminalId & "," & myTravelTime & ",'" & mySodoorTime.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture) & "')"
                    Cmdsql.ExecuteNonQuery()
                ElseIf SyncDS.Tables(0).Rows(loopx).Item(1) = NobatsStatus.Deleted Then
                    Cmdsql.CommandText = "delete from TblSyncServerNobats where (Pelak='" & myPelak & "') and (Serial='" & mySerial & "') and (TerminalId=" & myTerminalId & ")"
                    Cmdsql.ExecuteNonQuery()
                    'هنگامي که طول سفر به پايان مي رسد و نوبت توسط سرويس گاربيج از سرور حذف مي گردد ، نوبت بايد از ترمينال مرتبط هم حذف گردد 
                    Cmdsql.CommandText = "delete from TblNobats where (Pelak='" & myPelak & "') and (Serial='" & mySerial & "')"
                    Cmdsql.ExecuteNonQuery()
                ElseIf SyncDS.Tables(0).Rows(loopx).Item(1) = NobatsStatus.Sodoor Then
                    Cmdsql.CommandText = "Update TblSyncServerNobats set TravelTime=" & myTravelTime & ",SodoorTime='" & mySodoorTime.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture) & "' where (Pelak='" & myPelak & "') and (Serial='" & mySerial & "') and (TerminalId=" & myTerminalId & ")"
                    Cmdsql.ExecuteNonQuery()
                ElseIf SyncDS.Tables(0).Rows(loopx).Item(1) = NobatsStatus.DelNobatBarnamehOnline Then
                    Dim RetValue As Object = DelNobatInLocalSystemBySTP(myPelak, mySerial)
                    If RetValue IsNot Nothing Then
                        Cmdsql.CommandText = "Insert into TblExistNobatsInOther(Pelak,Serial,Msg,ChekTime) Values('" & myPelak & "' ,'" & mySerial & "','" & "BarnameOnlineDelNobat:" + RetValue.Value.ToString & "','" & Date.Now.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture) & "' )"
                        Cmdsql.ExecuteNonQuery()
                    Else
                        Cmdsql.CommandText = "Insert into TblExistNobatsInOther(Pelak,Serial,Msg,ChekTime) Values('" & myPelak & "' ,'" & mySerial & "','" & "BarnameOnlineDelNobat:Nothing" & "','" & Date.Now.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture) & "' )"
                        Cmdsql.ExecuteNonQuery()
                    End If
                ElseIf SyncDS.Tables(0).Rows(loopx).Item(1) = NobatsStatus.DelNobatUserRequest Then
                    Dim RetValue As Object = DelNobatInLocalSystemBySTP(myPelak, mySerial)
                    If RetValue IsNot Nothing Then
                        Cmdsql.CommandText = "Insert into TblExistNobatsInOther(Pelak,Serial,Msg,ChekTime) Values('" & myPelak & "' ,'" & mySerial & "','" & "UserRequestDelNobat:" + RetValue.Value.ToString & "','" & Date.Now.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture) & "' )"
                        Cmdsql.ExecuteNonQuery()
                    Else
                        Cmdsql.CommandText = "Insert into TblExistNobatsInOther(Pelak,Serial,Msg,ChekTime) Values('" & myPelak & "' ,'" & mySerial & "','" & "UserRequestDelNobat:Nothing" & "','" & Date.Now.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture) & "' )"
                        Cmdsql.ExecuteNonQuery()
                    End If
                ElseIf SyncDS.Tables(0).Rows(loopx).Item(1) = NobatsStatus.DelNobatOverOne1 Then
                    Dim RetValue As Object = DelNobatInLocalSystemBySTP(myPelak, mySerial)
                    If RetValue IsNot Nothing Then
                        Cmdsql.CommandText = "Insert into TblExistNobatsInOther(Pelak,Serial,Msg,ChekTime) Values('" & myPelak & "' ,'" & mySerial & "','" & "OverOne1DelNobat:" + RetValue.Value.ToString & "','" & Date.Now.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture) & "' )"
                        Cmdsql.ExecuteNonQuery()
                    Else
                        Cmdsql.CommandText = "Insert into TblExistNobatsInOther(Pelak,Serial,Msg,ChekTime) Values('" & myPelak & "' ,'" & mySerial & "','" & "OverOne1DelNobat:Nothing" & "','" & Date.Now.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture) & "' )"
                        Cmdsql.ExecuteNonQuery()
                    End If
                End If
            Next
            Cmdsql.Transaction.Commit() : Cmdsql.Connection.Close()
        Catch ex As Exception
            If Cmdsql.Connection.State <> ConnectionState.Closed Then
                Cmdsql.Transaction.Rollback() : Cmdsql.Connection.Close()
                Throw New Exception("MClassNobatsManagement.SetSyncChangedNobats()." + ex.Message.ToString)
            End If
        End Try
    End Sub
    Public Shared Sub WinServiceClearNobatsBuffer()
        Dim Cmdsql As New SqlClient.SqlCommand
        Cmdsql.Connection = New SqlClient.SqlConnection(TWSClassConfigurationManagement.GetTDBClientConnectionString)
        Try
            Cmdsql.Connection.Open()
            Cmdsql.Transaction = Cmdsql.Connection.BeginTransaction
            Cmdsql.CommandText = "delete TblNobats" : Cmdsql.ExecuteNonQuery()
            Cmdsql.CommandText = "delete TblSyncChangedNobats" : Cmdsql.ExecuteNonQuery()
            Cmdsql.CommandText = "delete TblSyncServerNobats" : Cmdsql.ExecuteNonQuery()
            Cmdsql.Transaction.Commit() : Cmdsql.Connection.Close()
        Catch ex As Exception
            If Cmdsql.Connection.State <> ConnectionState.Closed Then
                Cmdsql.Transaction.Rollback() : Cmdsql.Connection.Close()
            End If
            Throw New Exception("MClassNobatsManagement.WinServiceClearNobatsBuffer()." + ex.Message.ToString)
        End Try
    End Sub

End Class
