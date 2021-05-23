

Imports Microsoft.Win32
Imports System.Globalization
Imports System.Reflection
Imports TWSClassLibrary.ConfigurationManagement

Public Enum TraceWriter
    None = 0
    WebService = 1
    Garbage = 2
End Enum
Namespace LoggingManagement
    Public Enum Logging
        NoneOrMsg = 0
        ErrorLog = 1
        SyncTrucks = 2
        SyncAll = 3
        Authentication = 4
        SystemStatusChangedToSystemClearNobatsTrucksBufferAndSilent = 5
        SystemStatusChangedToSystemGeneral = 6
        SystemStatusChangedToSystemFullSilent = 7
        SystemStatusChangedToStpExistNobatSilent = 8
        SystemStatusChangedToWinServiceSilent = 9
        SystemStatusChangedToExecuteNonOutputSqlCommand = 10
        SystemStatusChangedToExecuteWithOutputSqlCommand = 11
        WinServiceStart = 12
        WinServiceStop = 13
        SendCurrentStatus = 14
        SetWinServiceSyncCounting = 15
        SetWinServiceTimerInterval = 16
        GetWinServiceConnectionString = 17
        GetWinServiceTerminalId = 18
        GetWinServiceDateTime = 19
        GetWinServiceComputerInfo = 20
        GetExistNobatsInOtherData = 21
        GetSTPsTblConfigurationData = 22
        IdentifyTerminal = 23
        ClientWinAppSettingSqlServerAdmin = 24
        ClientWinAppServiceStart = 25
        ServerWinServiceStart = 26
        ServerWinServiceStop = 27
        ServerWinServiceGarbageTimerElapsed = 28
        ServerWinAppCreateTerminal = 29
        ClientWinReportAppTimerStart = 30
        ClientWinReportAppPassOk = 31
        CenterControlChangeSystemStatus = 32
        WebMethodSetNewSystemStatus = 33
        WebMethodGetNewSystemStatus = 34
        Warning = 35
        WebMethodDelNobatBarnameOnline = 36
        WebMethodDelNobatUserRequest = 37
    End Enum
    Public Enum LogSource
        None = 0
        ServerWinApplication = 1
        ServerWinService = 2
        ServerWebService = 3
        ClientWinService = 4
        ClientWinApplication = 5
        ClientWebApplication = 6
        ClientWinApplicationReporting = 7
    End Enum
    Public Enum TruckTrace
        None = 0
        NoPelakSerialFound = 1
        NoRecordFound = 2
        OK = 3
    End Enum
    Public Class TWSClassLoggingManagement
        Public Overloads Shared Sub LoggingMessageSabt(ByVal LogId As Logging, ByVal LogSource As LogSource, ByVal TDB As DatabaseManagement.Database, ByVal TDBObject As String, ByVal TerminalId As Int16, ByVal UserName As String, ByVal MethodName As String, ByVal AuthenticationResult As Boolean, ByVal AuthenticationId As String, ByVal AckSignal As AckSignalManagement.ACKSignal, ByVal Data As DataSet, ByVal SystemStatus As SystemStatusManagement.SystemStatus, ByVal SyncCounting As Int16, ByVal LogNote As String)
            Dim CmdSql As New SqlClient.SqlCommand
            CmdSql.Connection = New SqlClient.SqlConnection(TWSClassConfigurationManagement.GetTDBServerConnectionString)
            Try
                Dim myTerminalName As String
                If TerminalId <> 0 Then
                    myTerminalName = TerminalsManagement.TWSClassTerminalsManagement.GetTerminalName(TerminalId, TWSClassConfigurationManagement.GetTDBServerConnectionString)
                Else
                    myTerminalName = "درخواست وضعيت"
                End If

                'متغيرهاي مخصوص لوگينگ synctrucks , syncall
                Dim myTrucksInTotal As Int32 = 0 : Dim myTrucksOutTotal As Int32 = 0 : Dim myTrucksInContent As String : Dim myTrucksOutContent As String
                Dim myNobatsInAddTotal As Int32 = 0 : Dim myNobatsOutAddTotal As Int32 = 0 : Dim myNobatsInAddContent As String : Dim myNobatsOutAddContent As String
                Dim myNobatsInDelTotal As Int32 = 0 : Dim myNobatsOutDelTotal As Int32 = 0 : Dim myNobatsInDelContent As String : Dim myNobatsOutDelContent As String
                Dim myNobatsInSodoorTotal As Int32 = 0 : Dim myNobatsOutSodoorTotal As Int32 = 0 : Dim myNobatsInSodoorContent As String : Dim myNobatsOutSodoorContent As String
                Dim myNobatsEndTravelTimeTotal As Int32 : Dim myNobatsEndTravelTimeContent As String
                Dim myTerminalsOutTotal As Int32 = 0 : Dim myTerminalsOutContent As String

                Select Case LogId
                    Case Logging.SyncTrucks
                        'ليست و سرجمع ناوگان دريافتي از پايانه
                        myTrucksInTotal = Data.Tables(0).Rows.Count
                        For loopx As Int32 = 0 To Data.Tables(0).Rows.Count - 1
                            myTrucksInContent = myTrucksInContent + Data.Tables(0).Rows(loopx).Item(0).trim + "-" + Data.Tables(0).Rows(loopx).Item(1).trim + ControlChars.CrLf
                        Next
                        'ليست و سرجمع ناوگان ارسالي به پايانه
                        myTrucksOutTotal = Data.Tables(1).Rows.Count
                        For loopx As Int32 = 0 To Data.Tables(1).Rows.Count - 1
                            myTrucksOutContent = myTrucksOutContent + Data.Tables(1).Rows(loopx).Item(2).trim + "-" + Data.Tables(1).Rows(loopx).Item(3).trim + ControlChars.CrLf
                        Next
                    Case Logging.SyncAll
                        Dim myTWSQueryTruck As TWSQueryTruck = New TWSQueryTruck
                        myTWSQueryTruck.Preparing(TWSClassConfigurationManagement.GetTDBServerConnectionString, 1, TWSPublicEnums.CodeNameSortOrder.Code)
                        'ليست و سرجمع ناوگان ارسالي به پايانه
                        myTrucksOutTotal = Data.Tables(2).Rows.Count
                        For loopx As Int32 = 0 To Data.Tables(2).Rows.Count - 1
                            myTrucksOutContent = myTrucksOutContent + Data.Tables(2).Rows(loopx).Item(2).trim + "-" + Data.Tables(2).Rows(loopx).Item(3).trim + ControlChars.CrLf
                        Next
                        'ليست و سرجمع نوبت هاي دريافتي از پايانه به تفکيک وضعيت
                        For loopx As Int32 = 0 To Data.Tables(0).Rows.Count - 1
                            'ليست و سرجمع نوبت هاي دريافتي اضافه شده از پايانه
                            If Data.Tables(0).Rows(loopx).Item(1) = NobatsManagement.NobatsStatus.Added Then
                                myNobatsInAddTotal += 1
                                myNobatsInAddContent = myNobatsInAddContent + myTWSQueryTruck.Pelak(Data.Tables(0).Rows(loopx).Item(0).ToString) + "-" + myTWSQueryTruck.Serial(Data.Tables(0).Rows(loopx).Item(0).ToString) + ControlChars.CrLf
                            End If
                            'ليست و سرجمع نوبت هاي دريافتي حذف شده از پايانه
                            If Data.Tables(0).Rows(loopx).Item(1) = NobatsManagement.NobatsStatus.Deleted Then
                                myNobatsInDelTotal += 1
                                myNobatsInDelContent = myNobatsInDelContent + myTWSQueryTruck.Pelak(Data.Tables(0).Rows(loopx).Item(0).ToString) + "-" + myTWSQueryTruck.Serial(Data.Tables(0).Rows(loopx).Item(0).ToString) + ControlChars.CrLf
                            End If
                            'ليست و سرجمع نوبت هايي که براي آنهامجوز صادر شده از پايانه
                            If Data.Tables(0).Rows(loopx).Item(1) = NobatsManagement.NobatsStatus.Sodoor Then
                                myNobatsInSodoorTotal += 1
                                myNobatsInSodoorContent = myNobatsInSodoorContent + myTWSQueryTruck.Pelak(Data.Tables(0).Rows(loopx).Item(0).ToString) + "-" + myTWSQueryTruck.Serial(Data.Tables(0).Rows(loopx).Item(0).ToString) + ControlChars.CrLf
                            End If
                        Next
                        'ليست و سرجمع نوبت هاي ارسالي به پايانه به تفکيک وضعيت
                        For loopx As Int32 = 0 To Data.Tables(1).Rows.Count - 1
                            'ليست و سرجمع نوبت هاي ارسالي اضافه شده به پايانه
                            If Data.Tables(1).Rows(loopx).Item(1) = NobatsManagement.NobatsStatus.Added Then
                                myNobatsOutAddTotal += 1
                                myNobatsOutAddContent = myNobatsOutAddContent + myTWSQueryTruck.Pelak(Data.Tables(1).Rows(loopx).Item(0).ToString) + "-" + myTWSQueryTruck.Serial(Data.Tables(1).Rows(loopx).Item(0).ToString) + ControlChars.CrLf
                            End If
                            'ليست و سرجمع نوبت هاي ارسالي حذف شده به پايانه
                            If Data.Tables(1).Rows(loopx).Item(1) = NobatsManagement.NobatsStatus.Deleted Then
                                'ليست و سرجمع نوبت هاي ارسالي حذف شده به پايانه
                                If Data.Tables(1).Rows(loopx).Item(3) = 0 Then
                                    myNobatsOutDelTotal += 1
                                    myNobatsOutDelContent = myNobatsOutDelContent + myTWSQueryTruck.Pelak(Data.Tables(1).Rows(loopx).Item(0).ToString) + "-" + myTWSQueryTruck.Serial(Data.Tables(1).Rows(loopx).Item(0).ToString) + ControlChars.CrLf
                                Else
                                    'ليست و سرجمع نوبت هاي ارسالي که طول سفر تمام شده به پايانه
                                    myNobatsEndTravelTimeTotal += 1
                                    myNobatsEndTravelTimeContent = myNobatsEndTravelTimeContent + myTWSQueryTruck.Pelak(Data.Tables(1).Rows(loopx).Item(0).ToString) + "-" + myTWSQueryTruck.Serial(Data.Tables(1).Rows(loopx).Item(0).ToString) + ControlChars.CrLf
                                End If
                            End If
                            'ليست و سرجمع نوبت هاي که براي آنها مجوز صادر شده به پايانه
                            If Data.Tables(1).Rows(loopx).Item(1) = NobatsManagement.NobatsStatus.Sodoor Then
                                myNobatsOutSodoorTotal += 1
                                myNobatsOutSodoorContent = myNobatsOutSodoorContent + myTWSQueryTruck.Pelak(Data.Tables(1).Rows(loopx).Item(0).ToString) + "-" + myTWSQueryTruck.Serial(Data.Tables(1).Rows(loopx).Item(0).ToString) + ControlChars.CrLf
                            End If
                        Next
                        'ليست و سرجمع پايانه هاي ارسالي به پايانه
                        myTerminalsOutTotal = Data.Tables(3).Rows.Count
                        For loopx As Int32 = 0 To Data.Tables(3).Rows.Count - 1
                            myTerminalsOutContent = myTerminalsOutContent + Data.Tables(3).Rows(loopx).Item(1) + ControlChars.CrLf
                        Next
                End Select

                CmdSql.Connection.Open()
                CmdSql.Transaction = CmdSql.Connection.BeginTransaction
                Dim myShDate As String = DateAndTimeManagement.TWSClassDateAndTimeManagement.GetShamsiDate(DateAndTime.Now.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture))
                Dim myTime As String = DateAndTimeManagement.TWSClassDateAndTimeManagement.GetTimeOfDate(DateAndTime.Now.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture))
                EventLog.WriteEntry("TWSServerSource", "TWSClassLoggingManagement.LoggingMessageSabt() : " + DateAndTime.Now.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture) + " " + myShDate + " " + myTime, EventLogEntryType.Information)
                CmdSql.CommandText = "Insert Into TblLogging(LogId,LogSource,TDB,TDBObject,TerminalId,TerminalName,UserName,ShDate,Time,DateTimeMilladi,MethodName,AuthenticationResult,AuthenticationId,AckSignal,TrucksInTotal,TrucksOutTotal,TrucksInContent,TrucksOutContent,NobatsInAddTotal,NobatsOutAddTotal,NobatsInAddContent,NobatsOutAddContent,NobatsInDelTotal,NobatsOutDelTotal,NobatsInDelContent,NobatsOutDelContent,NobatsInSodoorTotal,NobatsOutSodoorTotal,NobatsInSodoorContent,NobatsOutSodoorContent,NobatsEndTravelTimeTotal,NobatsEndTravelTimeContent,TerminalsOutTotal,TerminalsOutContent,SystemStatus,SyncCounting,LogNote) values(" & LogId & "," & LogSource & "," & TDB & ",'" & TDBObject & "'," & TerminalId & ",'" & myTerminalName & "','" & UserName & "','" & myShDate & "','" & myTime & "','" & DateAndTime.Now.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture) & "','" & MethodName & "'," & If(AuthenticationResult = True, 1, 0) & ",'" & AuthenticationId & "'," & AckSignal & "," & myTrucksInTotal & "," & myTrucksOutTotal & ",'" & myTrucksInContent & "','" & myTrucksOutContent & "'," & myNobatsInAddTotal & "," & myNobatsOutAddTotal & ",'" & myNobatsInAddContent & "','" & myNobatsOutAddContent & "'," & myNobatsInDelTotal & "," & myNobatsOutDelTotal & ",'" & myNobatsInDelContent & "','" & myNobatsOutDelContent & "'," & myNobatsInSodoorTotal & "," & myNobatsOutSodoorTotal & ",'" & myNobatsInSodoorContent & "','" & myNobatsOutSodoorContent & "'," & myNobatsEndTravelTimeTotal & ",'" & myNobatsEndTravelTimeContent & "'," & myTerminalsOutTotal & ",'" & myTerminalsOutContent & "'," & SystemStatus & "," & SyncCounting & ",'" & Mid(LogNote.Replace("'", "|"), 1, 400) & "')"
                CmdSql.ExecuteNonQuery()
                CmdSql.Transaction.Commit() : CmdSql.Connection.Close()
            Catch ex As Exception
                If CmdSql.Connection.State <> ConnectionState.Closed Then
                    CmdSql.Transaction.Rollback() : CmdSql.Connection.Close()
                End If
                EventLog.WriteEntry("TWSServerSource", "TWSClassLoggingManagement.LoggingMessageSabt()." + ex.Message.ToString, EventLogEntryType.Error)
            End Try
        End Sub
        Public Shared Function GetLoggingReport(ByVal DateAndTime As DateTime) As DataSet
            Try
                Dim da As New SqlClient.SqlDataAdapter : Dim ds As New DataSet
                da.SelectCommand = New SqlClient.SqlCommand("select * from TblLogging where  DateTimeMilladi>'" & DateAndTime.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture) & "' order by DateTimeMilladi asc")
                da.SelectCommand.Connection = New SqlClient.SqlConnection(TWSClassConfigurationManagement.GetTDBServerConnectionString)
                ds.Tables.Clear()
                da.Fill(ds)
                Return ds
            Catch ex As Exception
                Throw New Exception("TWSClassLoggingManagement.GetLoggingReport()." + ex.Message.ToString)
            End Try
        End Function
        Public Shared Function GetTruckTrace(ByVal Truckid As Int16, ByVal TotalRec As Int16) As DataSet
            Try

                Dim da As New SqlClient.SqlDataAdapter : Dim ds As New DataSet
                da.SelectCommand = New SqlClient.SqlCommand("SELECT TOP " & TotalRec & " T.TruckId,T.Status,T.TravelTime,T.SodoorTime ,T.DateReal,t.TraceWriter,TblTerminals.TerminalName  fROM TblSyncChangedNobatsTrace as T INNER JOIN TblTrucks on T.TruckId=TblTrucks.TruckID INNER JOIN TblTerminals ON T.TerminalId=TblTerminals.TerminalID  where (T.Truckid=" & Truckid & ") ORDER BY T.DateReal desc,T.SodoorTime Desc")
                da.SelectCommand.Connection = New SqlClient.SqlConnection(TWSClassConfigurationManagement.GetTDBServerConnectionString)
                ds.Tables.Clear()
                da.Fill(ds)
                Return ds
            Catch ex As Exception
                Throw New Exception("TWSClassLoggingManagement.GetTruckTrace()." + ex.Message.ToString)
            End Try
        End Function
    End Class
    Public Class StandardTruckTraceStructure
        Private myTruckId As Int16 = Nothing
        Private myStatus As NobatsManagement.NobatsStatus = NobatsManagement.NobatsStatus.None
        Private myTravelTime As Int16 = Nothing
        Private mySodoorTime As DateTime = Nothing
        Private myDateReal As DateTime = Nothing
        Private myTerminalName As String = Nothing
        Private myTraceWriter As String = Nothing
        Public Sub New()
        End Sub
        Public Sub New(ByVal TruckIdd As Int16, ByVal Statuss As NobatsManagement.NobatsStatus, ByVal TravelTimee As Int16, ByVal SodoorTimee As DateTime, ByVal DateReall As DateTime, ByVal TerminalNamee As String, ByVal TraceWriterr As String)
            Try
                TruckId = TruckIdd
                Status = Statuss
                TravelTime = TravelTimee
                SodoorTime = SodoorTimee
                DateReal = DateReall
                TerminalName = TerminalNamee
                TraceWriter = TraceWriterr
            Catch ex As Exception
                Throw New Exception("LoggingManagement.StandardTruckTraceStructure.New()." + ex.Message.ToString)
            End Try
        End Sub
        Public Property TruckId() As Int16
            Get
                Return Trim(myTruckId)
            End Get
            Set(ByVal Value As Int16)
                myTruckId = Value
            End Set
        End Property
        Public Property Status() As NobatsManagement.NobatsStatus
            Get
                Return Trim(myStatus)
            End Get
            Set(ByVal Value As NobatsManagement.NobatsStatus)
                myStatus = Value
            End Set
        End Property
        Public Property TravelTime() As Int16
            Get
                Return Trim(myTravelTime)
            End Get
            Set(ByVal Value As Int16)
                myTravelTime = Value
            End Set
        End Property
        Public Property SodoorTime() As DateTime
            Get
                Return Trim(mySodoorTime)
            End Get
            Set(ByVal Value As DateTime)
                mySodoorTime = Value
            End Set
        End Property
        Public Property DateReal() As DateTime
            Get
                Return Trim(myDateReal)
            End Get
            Set(ByVal Value As DateTime)
                myDateReal = Value
            End Set
        End Property
        Public Property TerminalName() As String
            Get
                Return Trim(myTerminalName)
            End Get
            Set(ByVal Value As String)
                myTerminalName = Value
            End Set
        End Property
        Public Property TraceWriter() As String
            Get
                Return Trim(myTraceWriter)
            End Get
            Set(ByVal Value As String)
                myTraceWriter = Value
            End Set
        End Property
    End Class
    Public Class StandardLogStructure


        Private myLogId As String = Nothing
        Private myLogSource As String = Nothing
        Private myTDB As String = Nothing
        Private myTDBObject As String = Nothing
        Private myTerminal As String = Nothing
        Private myUserName As String = Nothing
        Private myDateAndTime As String = Nothing
        Private myShDate As String = Nothing
        Private myTime As String = Nothing
        Private myMethodName As String = Nothing
        Private myAuthenticationResult As String = Nothing
        Private myAuthenticationId As String = Nothing
        Private myAckSignal As String = Nothing
        Private myTrucksInTotal As String = Nothing
        Private myTrucksInContent As String = Nothing
        Private myTrucksOutTotal As String = Nothing
        Private myTrucksOutContent As String = Nothing
        Private myNobatsInAddTotal As String = Nothing
        Private myNobatsInAddContent As String = Nothing
        Private myNobatsOutAddTotal As String = Nothing
        Private myNobatsOutAddContent As String = Nothing
        Private myNobatsInDelTotal As String = Nothing
        Private myNobatsInDelContent As String = Nothing
        Private myNobatsOutDelTotal As String = Nothing
        Private myNobatsOutDelContent As String = Nothing
        Private myNobatsInSodoorTotal As String = Nothing
        Private myNobatsInSodoorContent As String = Nothing
        Private myNobatsOutSodoorTotal As String = Nothing
        Private myNobatsOutSodoorContent As String = Nothing
        Private myNobatsEndTravelTimeTotal As String = Nothing
        Private myNobatsEndTravelTimeContent As String = Nothing
        Private myTerminalsOutTotal As String = Nothing
        Private myTerminalsOutContent As String = Nothing
        Private mySystemStatus As String = Nothing
        Private mySyncCounting As String = Nothing
        Private myLogNote As String = Nothing


        Public Sub New()
        End Sub
        Public Sub New(ByVal LogIdd As String, ByVal LogSourcee As String, ByVal TDBb As String, ByVal TDBObjectt As String, ByVal Terminall As String, ByVal UserNamee As String, ByVal DateAndTimee As String, ByVal ShDatee As String, ByVal Timee As String, ByVal MethodNamee As String, ByVal AuthenticationResultt As String, ByVal AuthenticationIdd As String, ByVal AckSignall As String, ByVal TrucksInTotall As String, ByVal TrucksInContentt As String, ByVal TrucksOutTotall As String, ByVal TrucksOutContentt As String, ByVal NobatsInAddTotall As String, ByVal NobatsInAddContentt As String, ByVal NobatsOutAddTotall As String, ByVal NobatsOutAddContentt As String, ByVal NobatsInDelTotall As String, ByVal NobatsInDelContentt As String, ByVal NobatsOutDelTotall As String, ByVal NobatsOutDelContentt As String, ByVal NobatsInSodoorTotall As String, ByVal NobatsInSodoorContentt As String, ByVal NobatsOutSodoorTotall As String, ByVal NobatsOutSodoorContentt As String, ByVal NobatsEndTravelTimeTotall As String, ByVal NobatsEndTravelTimeContentt As String, ByVal TerminalsOutTotall As String, ByVal TerminalsOutContentt As String, ByVal SystemStatuss As String, ByVal SyncCountingg As String, ByVal LogNotee As String)
            Try
                LogId = LogIdd
                LogSource = LogSourcee
                TDB = TDBb
                TDBObject = TDBObjectt
                Terminal = Terminall
                UserName = UserNamee
                DateAndTime = DateAndTimee
                ShDate = ShDatee
                Time = Timee
                MethodName = MethodNamee
                AuthenticationResult = AuthenticationResultt
                AuthenticationId = AuthenticationIdd
                AckSignal = AckSignall
                TrucksInTotal = TrucksInTotall
                TrucksInContent = TrucksInContentt
                TrucksOutTotal = TrucksOutTotall
                TrucksOutContent = TrucksOutContentt
                NobatsInAddTotal = NobatsInAddTotall
                NobatsInAddContent = NobatsInAddContentt
                NobatsOutAddTotal = NobatsOutAddTotall
                NobatsOutAddContent = NobatsOutAddContentt
                NobatsInDelTotal = NobatsInDelTotall
                NobatsInDelContent = NobatsInDelContentt
                NobatsOutDelTotal = NobatsOutDelTotall
                NobatsOutDelContent = NobatsOutDelContentt
                NobatsInSodoorTotal = NobatsInSodoorTotall
                NobatsInSodoorContent = NobatsInSodoorContentt
                NobatsOutSodoorTotal = NobatsOutSodoorTotall
                NobatsOutSodoorContent = NobatsOutSodoorContentt
                NobatsEndTravelTimeTotal = NobatsEndTravelTimeTotall
                NobatsEndTravelTimeContent = NobatsEndTravelTimeContentt
                TerminalsOutTotal = TerminalsOutTotall
                TerminalsOutContent = TerminalsOutContentt
                SystemStatus = SystemStatuss
                SyncCounting = SyncCountingg
                LogNote = LogNotee
            Catch ex As Exception
                Throw New Exception("LoggingManagement.StandardLogStructure.New()." + ex.Message.ToString)
            End Try
        End Sub
        Public Property LogId() As String
            Get
                Return Trim(myLogId)
            End Get
            Set(ByVal Value As String)
                myLogId = Value
            End Set
        End Property
        Public Property LogSource() As String
            Get
                Return Trim(myLogSource)
            End Get
            Set(ByVal Value As String)
                myLogSource = Value
            End Set
        End Property
        Public Property TDB() As String
            Get
                Return Trim(myTDB)
            End Get
            Set(ByVal Value As String)
                myTDB = Value
            End Set
        End Property
        Public Property TDBObject() As String
            Get
                Return Trim(myTDBObject)
            End Get
            Set(ByVal Value As String)
                myTDBObject = Value
            End Set
        End Property
        Public Property Terminal() As String
            Get
                Return Trim(myTerminal)
            End Get
            Set(ByVal Value As String)
                myTerminal = Value
            End Set
        End Property
        Public Property UserName() As String
            Get
                Return Trim(myUserName)
            End Get
            Set(ByVal Value As String)
                myUserName = Value
            End Set
        End Property
        Public Property ShDate() As String
            Get
                Return Trim(myShDate)
            End Get
            Set(ByVal Value As String)
                myShDate = Value
            End Set
        End Property
        Public Property DateAndTime() As String
            Get
                Return Trim(myDateAndTime)
            End Get
            Set(ByVal Value As String)
                myDateAndTime = Value
            End Set
        End Property
        Public Property Time() As String
            Get
                Return Trim(myTime)
            End Get
            Set(ByVal Value As String)
                myTime = Value
            End Set
        End Property
        Public Property MethodName() As String
            Get
                Return Trim(myMethodName)
            End Get
            Set(ByVal Value As String)
                myMethodName = Value
            End Set
        End Property
        Public Property AuthenticationResult() As String
            Get
                Return Trim(myAuthenticationResult)
            End Get
            Set(ByVal Value As String)
                myAuthenticationResult = Value
            End Set
        End Property
        Public Property AuthenticationId() As String
            Get
                Return Trim(myAuthenticationId)
            End Get
            Set(ByVal Value As String)
                myAuthenticationId = Value
            End Set
        End Property
        Public Property AckSignal() As String
            Get
                Return Trim(myAckSignal)
            End Get
            Set(ByVal Value As String)
                myAckSignal = Value
            End Set
        End Property
        Public Property TrucksInTotal() As String
            Get
                Return Trim(myTrucksInTotal)
            End Get
            Set(ByVal Value As String)
                myTrucksInTotal = Value
            End Set
        End Property
        Public Property TrucksOutTotal() As String
            Get
                Return Trim(myTrucksOutTotal)
            End Get
            Set(ByVal Value As String)
                myTrucksOutTotal = Value
            End Set
        End Property
        Public Property TrucksInContent() As String
            Get
                Return Trim(myTrucksInContent)
            End Get
            Set(ByVal Value As String)
                myTrucksInContent = Value
            End Set
        End Property
        Public Property TrucksOutContent() As String
            Get
                Return Trim(myTrucksOutContent)
            End Get
            Set(ByVal Value As String)
                myTrucksOutContent = Value
            End Set
        End Property
        Public Property NobatsInAddTotal() As String
            Get
                Return Trim(myNobatsInAddTotal)
            End Get
            Set(ByVal Value As String)
                myNobatsInAddTotal = Value
            End Set
        End Property
        Public Property NobatsOutAddTotal() As String
            Get
                Return Trim(myNobatsOutAddTotal)
            End Get
            Set(ByVal Value As String)
                myNobatsOutAddTotal = Value
            End Set
        End Property
        Public Property NobatsInAddContent() As String
            Get
                Return Trim(myNobatsInAddContent)
            End Get
            Set(ByVal Value As String)
                myNobatsInAddContent = Value
            End Set
        End Property
        Public Property NobatsOutAddContent() As String
            Get
                Return Trim(myNobatsOutAddContent)
            End Get
            Set(ByVal Value As String)
                myNobatsOutAddContent = Value
            End Set
        End Property
        Public Property NobatsInDelTotal() As String
            Get
                Return Trim(myNobatsInDelTotal)
            End Get
            Set(ByVal Value As String)
                myNobatsInDelTotal = Value
            End Set
        End Property
        Public Property NobatsOutDelTotal() As String
            Get
                Return Trim(myNobatsOutDelTotal)
            End Get
            Set(ByVal Value As String)
                myNobatsOutDelTotal = Value
            End Set
        End Property
        Public Property NobatsInDelContent() As String
            Get
                Return Trim(myNobatsInDelContent)
            End Get
            Set(ByVal Value As String)
                myNobatsInDelContent = Value
            End Set
        End Property
        Public Property NobatsOutDelContent() As String
            Get
                Return Trim(myNobatsOutDelContent)
            End Get
            Set(ByVal Value As String)
                myNobatsOutDelContent = Value
            End Set
        End Property
        Public Property NobatsInSodoorTotal() As String
            Get
                Return Trim(myNobatsInSodoorTotal)
            End Get
            Set(ByVal Value As String)
                myNobatsInSodoorTotal = Value
            End Set
        End Property
        Public Property NobatsOutSodoorTotal() As String
            Get
                Return Trim(myNobatsOutSodoorTotal)
            End Get
            Set(ByVal Value As String)
                myNobatsOutSodoorTotal = Value
            End Set
        End Property
        Public Property NobatsInSodoorContent() As String
            Get
                Return Trim(myNobatsInSodoorContent)
            End Get
            Set(ByVal Value As String)
                myNobatsInSodoorContent = Value
            End Set
        End Property
        Public Property NobatsOutSodoorContent() As String
            Get
                Return Trim(myNobatsOutSodoorContent)
            End Get
            Set(ByVal Value As String)
                myNobatsOutSodoorContent = Value
            End Set
        End Property
        Public Property NobatsEndTravelTimeTotal() As String
            Get
                Return Trim(myNobatsEndTravelTimeTotal)
            End Get
            Set(ByVal Value As String)
                myNobatsEndTravelTimeTotal = Value
            End Set
        End Property
        Public Property NobatsEndTravelTimeContent() As String
            Get
                Return Trim(myNobatsEndTravelTimeContent)
            End Get
            Set(ByVal Value As String)
                myNobatsEndTravelTimeContent = Value
            End Set
        End Property
        Public Property TerminalsOutTotal() As String
            Get
                Return Trim(myTerminalsOutTotal)
            End Get
            Set(ByVal Value As String)
                myTerminalsOutTotal = Value
            End Set
        End Property
        Public Property TerminalsOutContent() As String
            Get
                Return Trim(myTerminalsOutContent)
            End Get
            Set(ByVal Value As String)
                myTerminalsOutContent = Value
            End Set
        End Property
        Public Property SystemStatus() As String
            Get
                Return Trim(mySystemStatus)
            End Get
            Set(ByVal Value As String)
                mySystemStatus = Value
            End Set
        End Property
        Public Property SyncCounting() As String
            Get
                Return Trim(mySyncCounting)
            End Get
            Set(ByVal Value As String)
                mySyncCounting = Value
            End Set
        End Property
        Public Property LogNote() As String
            Get
                Return Trim(myLogNote)
            End Get
            Set(ByVal Value As String)
                myLogNote = Value
            End Set
        End Property
    End Class
End Namespace
Namespace DatabaseManagement
    Public Enum Database
        None = 0
        TDBClient = 1
        TDBServer = 2
        LocalSystem = 3
    End Enum
    Public Class TWSClassDatabaseManagement


    End Class
End Namespace
Namespace ConfigurationManagement
    Public Class TWSClassConfigurationManagement

        Private Shared myTDBServerConnectionString As String = Nothing
        Private Shared myTDBClientConnectionString As String = Nothing
        Private Shared myLocalSystemConnectionString As String = Nothing
        Private Shared myGarbageTimerInterval As String = Nothing
        Private Shared mySyncCounting As String = Nothing
        Private Shared myTerminalId As String = Nothing
        Private Shared myTimerInterval As String = Nothing

        Public Shared Sub FillPublicVariables()
            Try
                Dim fs As New System.IO.FileStream(System.Environment.CurrentDirectory + "\" + "Timciens.txt", IO.FileMode.Open, IO.FileAccess.Read)
                Dim sr As New System.IO.StreamReader(fs)
                sr.BaseStream.Seek(0, IO.SeekOrigin.Begin)
                sr.ReadLine() : sr.ReadLine() : sr.ReadLine() : sr.ReadLine()
                myGarbageTimerInterval = Split(Mid(sr.ReadLine, 13, 100), "#")(0)
                mySyncCounting = Split(Mid(sr.ReadLine, 23, 100), "#")(0)
                myTerminalId = Split(Mid(sr.ReadLine, 30, 100), "#")(0)
                myTimerInterval = Split(Mid(sr.ReadLine, 36, 100), "#")(0)
                Dim DSTemp = Split(Mid(sr.ReadLine, 15, 100), "#")(0)
                Dim PasswordTemp = Split(Mid(sr.ReadLine, 4, 100), "#")(0)
                myTDBServerConnectionString = "Data Source=@DS;Initial Catalog=TDBServer;Persist Security Info=True;User ID=sa;Password=@Password".Replace("@DS", DSTemp).Replace("@Password", PasswordTemp)
                DSTemp = Split(Mid(sr.ReadLine, 15, 100), "#")(0)
                PasswordTemp = Split(Mid(sr.ReadLine, 4, 100), "#")(0)
                myTDBClientConnectionString = "Data Source=@DS;Initial Catalog=TDBClient;Persist Security Info=True;User ID=sa;Password=@Password".Replace("@DS", DSTemp).Replace("@Password", PasswordTemp)
                DSTemp = Split(Mid(sr.ReadLine, 15, 100), "#")(0)
                PasswordTemp = Split(Mid(sr.ReadLine, 4, 100), "#")(0)
                Dim LocalDB = Split(Mid(sr.ReadLine, 13, 100), "#")(0)
                myLocalSystemConnectionString = "Data Source=@DS;Initial Catalog=@LocalDB;Persist Security Info=True;User ID=sa;Password=@Password".Replace("@DS", DSTemp).Replace("@Password", PasswordTemp).Replace("@LocalDB", LocalDB)
            Catch ex As Exception
                Throw New Exception(MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name + ex.Message)
            End Try
        End Sub

        Public Shared Function GetTDBServerConnectionString() As String
            Try
                If myTDBServerConnectionString = Nothing Then FillPublicVariables()
                Return myTDBServerConnectionString
            Catch ex As Exception
                Throw New Exception(MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name + ex.Message)
            End Try
        End Function

        Public Shared Function GetTDBClientConnectionString() As String
            Try
                If myTDBClientConnectionString = Nothing Then FillPublicVariables()
                Return myTDBClientConnectionString
            Catch ex As Exception
                Throw New Exception(MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name + ex.Message)
            End Try
        End Function

        Public Shared Function GetLocalSystemConnectionString() As String
            Try
                If myLocalSystemConnectionString = Nothing Then FillPublicVariables()
                Return myLocalSystemConnectionString
            Catch ex As Exception
                Throw New Exception(MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name + ex.Message)
            End Try
        End Function

        Public Shared Function GetGarbageTimerInterval() As String
            Try
                If myGarbageTimerInterval = Nothing Then FillPublicVariables()
                Return myGarbageTimerInterval
            Catch ex As Exception
                Throw New Exception(MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name + ex.Message)
            End Try
        End Function

        Public Shared Function GetSyncCounting() As String
            Try
                If mySyncCounting = Nothing Then FillPublicVariables()
                Return mySyncCounting
            Catch ex As Exception
                Throw New Exception(MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name + ex.Message)
            End Try
        End Function

        Public Shared Function GetTerminalId() As String
            Try
                If myTerminalId = Nothing Then FillPublicVariables()
                Return myTerminalId
            Catch ex As Exception
                Throw New Exception(MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name + ex.Message)
            End Try
        End Function

        Public Shared Function GetTimerInterval() As String
            Try
                If myTimerInterval = Nothing Then FillPublicVariables()
                Return myTimerInterval
            Catch ex As Exception
                Throw New Exception(MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name + ex.Message)
            End Try
        End Function

    End Class

End Namespace
Namespace DateAndTimeManagement
    Public Class TWSClassDateAndTimeManagement
        Public Shared Function GetTimeOfDate(ByVal DateAndTime As DateTime) As String
            Try
                Dim mycurrenttime As String = Trim(Mid(DateAndTime.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture), 12, 8))
                Return mycurrenttime
            Catch ex As Exception
                Throw New Exception("TWSClassDateAndTimeManagement.GetTimeOfDate()." + ex.Message.ToString)
            End Try
        End Function
        Public Shared Function ConvertToShamsiDate(ByVal MDate As DateTime) As String
            Try
                Dim MM(12) As Byte
                Dim yy, y, D, M, sum, a As Int16
                Dim m1, d1, y1 As String
                MM(1) = 31
                MM(2) = 28
                MM(3) = 31
                MM(4) = 30
                MM(5) = 31
                MM(6) = 30
                MM(7) = 31
                MM(8) = 31
                MM(9) = 30
                MM(10) = 31
                MM(11) = 30
                MM(12) = 31
                D = Microsoft.VisualBasic.DateAndTime.Day(MDate)
                M = Month(MDate)
                y = Year(MDate)
                yy = y - 1980
                yy = yy - Int(yy / 4) * 4
                If yy = 0 Then
                    MM(2) = 29
                Else
                    MM(2) = 28
                End If
                sum = 0
                If M <> 1 Then
                    For I As Int16 = 1 To M - 1
                        sum = sum + MM(I)
                    Next
                End If
                sum = sum + D
                If yy = 1 Then
                    sum = sum + 287
                Else
                    sum = sum + 286
                End If
                If yy = 1 Then
                    a = 366
                Else
                    a = 365
                End If
                If sum > a Then
                    sum = sum - a
                    y = y + 1
                End If
                If sum > 186 Then
                    sum = sum - 186
                    M = 7 + Int(sum / 30)
                    D = sum - (Int(sum / 30) * 30)
                    If D = 0 Then
                        D = 30
                        M = M - 1
                    End If
                Else
                    M = 1 + Int(sum / 31)
                    D = sum - (Int(sum / 31) * 31)
                    If D = 0 Then
                        M = M - 1
                        D = 31
                    End If
                End If
                y = y - 622
                If M < 10 Then
                    m1 = "0" + Trim(Str(M))
                Else
                    m1 = Trim(Str(M))
                End If
                If D < 10 Then
                    d1 = "0" + Trim(Str(D))
                Else
                    d1 = Trim(Str(D))
                End If
                y1 = Mid(Trim(Str(y)), 3, 4)
                Return (y1 + "/" + m1 + "/" + d1)
            Catch ex As Exception
                Throw New Exception("TWSClassDateAndTimeManagement.ConvertToShamsiDate()." + ex.Message.ToString)
            End Try
        End Function
        Public Shared Function GetCurrentShamsiDate() As String
            Try
                Return ConvertToShamsiDate(Date.Now)
            Catch ex As Exception
                Throw New Exception("TWSClassDateAndTimeManagement.GetCurrentShamsiDate()." + ex.Message.ToString)
            End Try
        End Function
        Public Shared Function GetShamsiDate(ByVal MDate As DateTime) As String
            Try
                Return ConvertToShamsiDate(MDate)
            Catch ex As Exception
                Throw New Exception("TWSClassDateAndTimeManagement.GetShamsiDate()." + ex.Message.ToString)
            End Try
        End Function
        Public Shared Function GetCurrentSal() As String
            Try
                Return Mid(GetCurrentShamsiDate(), 1, 2)
            Catch ex As Exception
                Throw New Exception("TWSClassDateAndTimeManagement.GetCurrentSal()." + ex.Message.ToString)
            End Try
        End Function
        Public Shared Function ChekShamsiDateSyntax(ByVal datex As String) As Boolean
            Try
                Dim mydate As String = Trim(datex)
                Dim mysal As String = Mid(mydate, 1, 2)
                Dim mymah As String = Mid(mydate, 4, 2)
                Dim myrooz As String = Mid(mydate, 7, 2)
                If Len(mydate) <> 8 Then Return False
                If Mid(mydate, 3, 1) <> "/" Then Return False
                If Mid(mydate, 6, 1) <> "/" Then Return False
                If Not ((Val(mymah) >= 1) And (Val(mymah) <= 12)) Then Return False
                If ((Val(mymah) >= 1) And (Val(mymah) <= 6)) Then
                    If Not ((Val(myrooz) >= 1) And (Val(myrooz) <= 31)) Then Return False
                ElseIf ((Val(mymah) >= 7) And (Val(mymah) <= 11)) Then
                    If Not ((Val(myrooz) >= 1) And (Val(myrooz) <= 30)) Then Return False
                ElseIf (Val(mymah) = 12) Then
                    If Not ((Val(myrooz) >= 1) And (Val(myrooz) <= 30)) Then Return False
                End If
                Return True
            Catch ex As Exception
                Throw New Exception("TWSClassDateAndTimeManagement.ChekShamsiDateSyntax()." + ex.Message.ToString)
            End Try
        End Function
    End Class
End Namespace
Namespace NobatsManagement
    Public Enum NobatsStatus
        None = 0
        Added = 1
        Deleted = 2
        Sodoor = 3
        DelNobatBarnamehOnline = 4
        DelNobatOverOne1 = 5
        DelNobatUserRequest = 6
    End Enum
    Public Class TWSClassNobatsManagement
        Public Shared Function GetStatusNameByCode(ByVal Status As NobatsStatus) As String
            If Status = NobatsStatus.Added Then Return "صدور نوبت"
            If Status = NobatsStatus.Deleted Then Return "حذف نوبت"
            If Status = NobatsStatus.Sodoor Then Return "صدور مجوز"
            If Status = NobatsStatus.DelNobatBarnamehOnline Then Return "حذف نوبت(بارنامه آنلاين)"
            If Status = NobatsStatus.DelNobatOverOne1 Then Return "حذف نوبت(دونوبتي)"
            If Status = NobatsStatus.DelNobatUserRequest Then Return "حذف نوبت(درخواست راننده)"
            If Status = NobatsStatus.None Then Return "نامعلوم"
        End Function
    End Class
End Namespace
Namespace TerminalsManagement
    Public Enum TerminalsStatus
        None = 0
        Added = 1
        Deleted = 2
    End Enum
    Public Class TWSClassTerminalsManagement
        Public Shared Sub AddTerminal(ByVal TerminalName As String, ByRef RndCode As String, ByRef TerminalId As Int16)
            Dim CmdSql As New SqlClient.SqlCommand
            CmdSql.Connection = New SqlClient.SqlConnection(TWSClassConfigurationManagement.GetTDBServerConnectionString)
            Try
                Dim myNewTerminalID As Int16
                CmdSql.Connection.Open()
                CmdSql.Transaction = CmdSql.Connection.BeginTransaction(System.Data.IsolationLevel.Serializable)
                CmdSql.CommandText = "select TerminalID from TblTerminals order by TerminalID desc"
                If CmdSql.ExecuteScalar = System.TypeCode.Empty Then
                    myNewTerminalID = 1
                Else
                    myNewTerminalID = CmdSql.ExecuteScalar + 1
                End If
                Randomize()
                Dim myRndCode As String = Rnd(8126351823)
                CmdSql.CommandText = "insert into TblTerminals(TerminalID,TerminalName,RndCode) values(" & myNewTerminalID & ",'" & TerminalName & "','" & myRndCode & "')"
                CmdSql.ExecuteNonQuery()
                CmdSql.Transaction.Commit() : CmdSql.Connection.Close()
                RndCode = myRndCode
                TerminalId = myNewTerminalID

                'Sync 
                'معرفي پايانه جديد به پايانه هاي قبلي
                Dim mySyncDS As DataSet = TerminalsManagement.TWSClassTerminalsManagement.GetTerminalsIDList(TWSClassConfigurationManagement.GetTDBServerConnectionString)
                CmdSql.Connection.Open()
                CmdSql.Transaction = CmdSql.Connection.BeginTransaction(System.Data.IsolationLevel.Serializable)
                For loopAddToSync As Int16 = 0 To mySyncDS.Tables(0).Rows.Count - 1
                    CmdSql.CommandText = "insert into TblSyncChangedTerminals(TerminalID,Status,SyncTerminalID,DelFlag) values(" & myNewTerminalID & "," & TerminalsStatus.Added & "," & mySyncDS.Tables(0).Rows(loopAddToSync).Item(0) & ",0)"
                    CmdSql.ExecuteNonQuery()
                Next
                'معرفي پايانه هاي قديم به پايانه جديد
                For loopDelToSync As Int16 = 0 To mySyncDS.Tables(0).Rows.Count - 1
                    If mySyncDS.Tables(0).Rows(loopDelToSync).Item(0) <> myNewTerminalID Then
                        CmdSql.CommandText = "insert into TblSyncChangedTerminals(TerminalID,Status,SyncTerminalID,DelFlag) values(" & mySyncDS.Tables(0).Rows(loopDelToSync).Item(0) & "," & TerminalsStatus.Added & "," & myNewTerminalID & ",0)"
                        CmdSql.ExecuteNonQuery()
                    End If
                Next

                'معرفي نوبت هاي موجود در ترمينال هاي ديگر به ترمينال جديد
                Dim daNobatsToNewTerminal As New SqlClient.SqlDataAdapter : Dim dsNobatsToNewTerminal As New DataSet
                daNobatsToNewTerminal.SelectCommand = New SqlClient.SqlCommand("select * from TblNobats")
                daNobatsToNewTerminal.SelectCommand.Connection = New SqlClient.SqlConnection(TWSClassConfigurationManagement.GetTDBServerConnectionString)
                dsNobatsToNewTerminal.Tables.Clear()
                daNobatsToNewTerminal.Fill(dsNobatsToNewTerminal)
                For LoopAddToSyncNewTerminal As Int32 = 0 To dsNobatsToNewTerminal.Tables(0).Rows.Count - 1
                    Dim myTruckId As Int32 = dsNobatsToNewTerminal.Tables(0).Rows(LoopAddToSyncNewTerminal).Item("TruckId")
                    Dim myTerminalId As Int16 = dsNobatsToNewTerminal.Tables(0).Rows(LoopAddToSyncNewTerminal).Item("TerminalId")
                    Dim myTravelTime As Int16 = dsNobatsToNewTerminal.Tables(0).Rows(LoopAddToSyncNewTerminal).Item("traveltime")
                    Dim mySodoorTime As DateTime = dsNobatsToNewTerminal.Tables(0).Rows(LoopAddToSyncNewTerminal).Item("sodoortime")
                    CmdSql.CommandText = "insert into TblSyncChangedNobats(TruckId,TerminalId,Status,SyncTerminalId,TravelTime,SodoorTime,DelFlag) values(" & myTruckId & "," & myTerminalId & "," & NobatsManagement.NobatsStatus.Added & "," & myNewTerminalID & "," & myTravelTime & ",'" & mySodoorTime.ToString("yyyy-MM-dd HH:mm:ss") & "',0)"
                    CmdSql.ExecuteNonQuery()
                Next
                'معرفي ناوگان موجود در سيستم به ترمينال جديد
                Dim daTrucksToNewTerminal As New SqlClient.SqlDataAdapter : Dim dsTrucksToNewTerminal As New DataSet
                daTrucksToNewTerminal.SelectCommand = New SqlClient.SqlCommand("select TruckId from TblTrucks")
                daTrucksToNewTerminal.SelectCommand.Connection = New SqlClient.SqlConnection(TWSClassConfigurationManagement.GetTDBServerConnectionString)
                dsTrucksToNewTerminal.Tables.Clear()
                daTrucksToNewTerminal.Fill(dsTrucksToNewTerminal)
                For LoopAddToSyncNewTerminal As Int32 = 0 To dsTrucksToNewTerminal.Tables(0).Rows.Count - 1
                    Dim myTruckId As Int32 = dsTrucksToNewTerminal.Tables(0).Rows(LoopAddToSyncNewTerminal).Item("TruckId")
                    CmdSql.CommandText = "insert into TblSyncChangedTrucks(TruckId,Status,SyncTerminalId,DelFlag) values(" & myTruckId & "," & TrucksManagement.TrucksStatus.Added & "," & myNewTerminalID & ",0)"
                    CmdSql.ExecuteNonQuery()
                Next
                CmdSql.Transaction.Commit() : CmdSql.Connection.Close()

            Catch ex As Exception
                If CmdSql.Connection.State <> ConnectionState.Closed Then
                    CmdSql.Transaction.Rollback() : CmdSql.Connection.Close()
                End If
                Throw New Exception("TWSClassTerminalsManagement.AddTerminal()." + ex.Message.ToString)
            End Try
        End Sub
        Public Shared Function GetTerminalsIDList(ByVal TDBConnectionString As String) As DataSet
            Try
                Dim da As New SqlClient.SqlDataAdapter : Dim ds As New DataSet
                da.SelectCommand = New SqlClient.SqlCommand("select TerminalID from TblTerminals")
                da.SelectCommand.Connection = New SqlClient.SqlConnection(TDBConnectionString)
                ds.Tables.Clear()
                da.Fill(ds)
                Return ds
            Catch ex As Exception
                Throw New Exception("TWSClassTerminalsManagement.GetTerminalsIDList()." + ex.Message.ToString)
            End Try
        End Function
        Public Shared Function GetTerminalsIDList(ByVal TerminalID As Int16, ByVal TDBConnectionString As String) As DataSet
            Try
                Dim da As New SqlClient.SqlDataAdapter : Dim ds As New DataSet
                da.SelectCommand = New SqlClient.SqlCommand("select TerminalID from TblTerminals WHERE TerminalID<>" & TerminalID & "")
                da.SelectCommand.Connection = New SqlClient.SqlConnection(TDBConnectionString)
                ds.Tables.Clear()
                da.Fill(ds)
                Return ds
            Catch ex As Exception
                Throw New Exception("TWSClassTerminalsManagement.GetTerminalsIDList()." + ex.Message.ToString)
            End Try
        End Function
        Public Shared Function GetTerminalsList(ByVal TDBConnectionString As String) As DataSet
            Try
                Dim da As New SqlClient.SqlDataAdapter : Dim ds As New DataSet
                da.SelectCommand = New SqlClient.SqlCommand("select * from TblTerminals order by TerminalId")
                da.SelectCommand.Connection = New SqlClient.SqlConnection(TDBConnectionString)
                ds.Tables.Clear()
                da.Fill(ds)
                Return ds
            Catch ex As Exception
                Throw New Exception("TWSClassTerminalsManagement.GetTerminalsList()." + ex.Message.ToString)
            End Try
        End Function
        Public Shared Function GetTerminalName(ByVal TerminalID As Int16, ByVal TDBConnectionString As String) As String
            Try
                Dim da As New SqlClient.SqlDataAdapter : Dim ds As New DataSet
                da.SelectCommand = New SqlClient.SqlCommand("select TerminalName from TblTerminals where TerminalID=" & TerminalID & "")
                da.SelectCommand.Connection = New SqlClient.SqlConnection(TDBConnectionString)
                ds.Tables.Clear()
                da.Fill(ds)
                Return ds.Tables(0).Rows(0).Item(0)
            Catch ex As Exception
                Throw New Exception("TWSClassTerminalsManagement.GetTerminalName()." + ex.Message.ToString)
            End Try
        End Function

    End Class
End Namespace
Namespace AuthenticationManagement

End Namespace
Namespace SystemStatusManagement
    Public Enum SystemStatus
        None = 0
        SystemIdle = 1 'حالت اوليه سيستم
        SystemGeneral = 2 'حالت عمومي و عادي سيستم
        SystemClearNobatsTrucksBufferAndSilent = 3 'تمام کلاينت ها و سرور موظفند در فراخواني بعدي بافرهاي مديريت نوبت خود را خالي نموده و در وضعيت بيکار باقي بمانند و منتظر فرمان بعدي باشند 
        SystemFullSilent = 4 'در کلاينت ها ويندوز سرويس و نرم افزار نوبت دهي هر دو تا اطلاع ثانوي در وضعيت بيکار يا ساکت باقي بمانند
        WinServiceSilent = 5 'در کلاينت ها ويندوز سرويس به حالت بيکار مي رود ولي نرم افزار نوبت دهي به کار خود ادامه مي دهد
        StpExistNobatSilent = 6 'در کلاينت ها کنترل وجود نوبت در پايانه هاي ديگر و يا کنترل طول سفر از طريق روال ذخيره شده انجام نگردد
        ExecuteNonOutputSqlCommand = 7 'اجراي يک دستور اسکيوال بدون خروجي روي بانک اطلاعات
        ExecuteWithOutputSqlCommand = 8 'اجراي يک دستور اسکيوال داراي خروجي روي بانک اطلاعات و ارسال ديتاست شامل اطلاعات به سرور
        SendCurrentStatus = 9 'دريافت وضعيت جاري کلاينت
        SetWinServiceTimerInterval = 10 'تنظيم تايمر اينتروال ويندوز سرويس
        SetWinServiceSyncCounting = 11 'تنظيم دقايق تاخير در اجراي فرآيند سنکرون يا ارسال اطلاعات نوبت ها و ناوگان
        GetWinServiceConnectionString = 12 'دريافت رشته اتصال به اسکيو ال سرور در کلاينت
        GetWinServiceTerminalId = 13 'دريافت شاخص پايانه ثبت شده در رجيستري کلاينت
        GetWinServiceDateTime = 14 'درياقت تاريخ و زمان کلاينت براي کنترل و جلوگيري از مشکلات در طول سفر
        GetWinServiceComputerInfo = 15 'دريافت مشخصات سيستم در کلاينت
        GetExistNobatsInOtherData = 16 'کل محتواي جدول مورد نظر را تحويل مي دهد
        GetSTPsTblConfigurationData = 17 'کل محتواي جدول مورد نظر را از يک ترمينال تحويل مي دهد
    End Enum
    Public Class TWSClassSystemStatusManagement

    End Class
End Namespace
Namespace TrucksManagement
    Public Enum TrucksStatus
        None = 0
        Added = 1
        Deleted = 2
    End Enum
    Public Class TWSClassTrucksManagement
        Public Overloads Shared Function ExistTruck(ByVal Pelak As String, ByVal Serial As String, ByVal Cmdsql As SqlClient.SqlCommand) As Boolean
            Try
                Cmdsql.CommandText = "select TruckId from TblTrucks where (ltrim(rtrim(Pelak))='" & Pelak.Trim & "')  and (ltrim(rtrim(Serial))='" & Serial.Trim & "')"
                If Cmdsql.ExecuteScalar = System.TypeCode.Empty Then
                    Return False
                Else
                    Return True
                End If
            Catch ex As Exception
                Throw New Exception("TWSClassTrucksManagement.ExistTruck()." + ex.Message.ToString)
            End Try
        End Function
        Public Overloads Shared Function ExistTruck(ByVal Pelak As String, ByVal Serial As String, ByVal Cnn As SqlClient.SqlConnection, Optional ByRef Truckid As Int16 = 0) As Boolean
            Try
                Dim da As New SqlClient.SqlDataAdapter : Dim ds As New DataSet
                da.SelectCommand = New SqlClient.SqlCommand("select TruckId from TblTrucks where (ltrim(rtrim(Pelak))='" & Pelak.Trim & "')  and (ltrim(rtrim(Serial))='" & Serial.Trim & "')")
                da.SelectCommand.Connection = Cnn
                If da.Fill(ds) = 0 Then
                    Return False
                Else
                    Truckid = ds.Tables(0).Rows(0).Item("truckid")
                    Return True
                End If
            Catch ex As Exception
                Throw New Exception("TWSClassTrucksManagement.ExistTruck()." + ex.Message.ToString)
            End Try
        End Function
        Public Shared Function GetPelakFromTruckId(ByVal TruckId As Int32, ByVal TDBConnectionString As String) As String
            Try
                Dim da As New SqlClient.SqlDataAdapter : Dim ds As New DataSet
                da.SelectCommand = New SqlClient.SqlCommand("select Pelak from TblTrucks where TruckId=" & TruckId & "")
                da.SelectCommand.Connection = New SqlClient.SqlConnection(TDBConnectionString)
                ds.Tables.Clear()
                da.Fill(ds)
                Return ds.Tables(0).Rows(0).Item("Pelak")
            Catch ex As Exception
                Throw New Exception("TWSClassTrucksManagement.GetPelakFromTruckId()." + ex.Message.ToString)
            End Try
        End Function
        Public Shared Function GetSerialFromTruckId(ByVal TruckId As Int32, ByVal TDBConnectionString As String) As String
            Try
                Dim da As New SqlClient.SqlDataAdapter : Dim ds As New DataSet
                da.SelectCommand = New SqlClient.SqlCommand("select Serial from TblTrucks where TruckId=" & TruckId & "")
                da.SelectCommand.Connection = New SqlClient.SqlConnection(TDBConnectionString)
                ds.Tables.Clear()
                da.Fill(ds)
                Return ds.Tables(0).Rows(0).Item("Serial")
            Catch ex As Exception
                Throw New Exception("TWSClassTrucksManagement.GetSerialFromTruckId()." + ex.Message.ToString)
            End Try
        End Function
    End Class
End Namespace
Namespace AckSignalManagement
    Public Enum ACKSignal
        NoneOrMsg = 0
        AckError = 1
        WebMethodSyncTrucks = 2
        WebMethodSyncAll = 3
        SystemStatusChangedToSystemGeneral = 4
        SystemStatusChangedToSystemClearNobatsTrucksBufferAndSilent = 5
        SystemStatusChangedToSystemFullSilent = 6
        SystemStatusChangedToWinServiceSilent = 7
        SystemStatusChangedToStpExistNobatSilent = 8
        SystemStatusChangedToExecuteNonOutputSqlCommand = 9
        SystemStatusChangedToExecuteWithOutputSqlCommand = 10
        WinServiceStart = 11
        WinServiceStop = 12
        SendCurrentStatus = 13
        SetWinServiceTimerInterval = 14
        SetWinServiceSyncCounting = 15
        GetWinServiceConnectionString = 16
        GetWinServiceTerminalId = 17
        GetWinServiceDateTime = 18
        GetWinServiceComputerInfo = 19
        GetExistNobatsInOtherData = 20
        GetSTPsTblConfigurationData = 21
        IdentifyTerminal = 22
        ClientWinAppSettingSqlServerAdmin = 23
        ClientWinAppServiceStart = 24
        ServerWinServiceStart = 25
        ServerWinServiceStop = 26
        ServerWinServiceGarbageTimerElapsed = 27
        ServerWinAppCreateTerminal = 28
        ClientWinReportAppTimerStart = 29
        ClientWinReportAppPassOk = 30
        CenterControlChangeSystemStatus = 31
        BarnamehOnLineDelNobat = 32
    End Enum
    Public Class TWSClassAckSignalManagement
    End Class
End Namespace
Namespace TDBClientStpType
    Public Enum TDBClientStpType
        None = 0
        Add = 1
        Del = 2
        Exist = 3
        Sodoor = 4
    End Enum
    Public Class TWSClassTDBClientStpType
    End Class
End Namespace
Namespace EventLogManagement
    Public Class TWSClassEventLogManagement
    End Class
End Namespace
Namespace NotifyManagement
    Public Class TWSClassNotifycationManagement
        Public Shared Sub Notify()

        End Sub
    End Class

End Namespace
Namespace TWSPublicEnums

    Public Enum CodeNameSortOrder
        None = 0
        Code = 1
        Name = 2
    End Enum

End Namespace
Namespace PublicSubsAndFunctions
    Public Class PublicSubsAndFunctions
        'روتين برگرداندن وضعيت کليد کپس لوک با استفاده از API
        Private Declare Function GetKeyState Lib "user32.dll" (ByVal nVirtKey As Long) As Int16
        Public Shared Function GetCapsLockVZ() As Boolean
            Try
                If (GetKeyState(&H14) And &H1) Then
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                Throw New Exception("GetCapsLockVZ()." + ex.Message.ToString)
            End Try
        End Function
        'روتين تغيير زبان صفحه کليد با استفاده از API
        Private Declare Function LoadKeyboardLayout Lib "user32" Alias "LoadKeyboardLayoutA" (ByVal pwszKLID As String, ByVal flags As Long) As Long
        Public Shared Function SetKeyboardLayout(ByVal Layout As String) As Boolean
            Try
                Dim mypwszKLID As String = IIf(Layout = "English", "00000409", "00000429")
                Dim myload As String = LoadKeyboardLayout(mypwszKLID, &H1)
                If myload = "" Then
                    Return False
                Else
                    Return True
                End If
            Catch ex As Exception
                Throw New Exception("SetKeyboardLayout()." + ex.Message.ToString)
            End Try
        End Function
    End Class
End Namespace
Namespace TDBClientManagement
    Public Class TWSClassTDBClientManagement

        Public Shared Function ExistNobat(ByVal YourPelak As String, ByVal YourSerial As String) As String
            Dim CmdSql As New SqlClient.SqlCommand
            CmdSql.Connection = New SqlClient.SqlConnection(TWSClassConfigurationManagement.GetTDBClientConnectionString)
            Try
                CmdSql.CommandText = "ExistNobat"
                CmdSql.CommandType = CommandType.StoredProcedure
                CmdSql.Parameters.Add("@Pelak", SqlDbType.VarChar, 50, ParameterDirection.Input).Value = YourPelak
                CmdSql.Parameters.Add("@Serial", SqlDbType.VarChar, 50, ParameterDirection.Input).Value = YourSerial
                CmdSql.Parameters.Add("@Msg", SqlDbType.VarChar, 500)
                CmdSql.Parameters("@Msg").Direction = ParameterDirection.Output
                CmdSql.Connection.Open()
                CmdSql.ExecuteNonQuery()
                CmdSql.Connection.Close()
                Return CmdSql.Parameters("@Msg").Value.ToString
            Catch ex As Exception
                Throw New Exception("TDBClientManagement.TWSClassTDBClientManagement.ExistNobat" + vbCrLf + ex.Message)
            End Try
        End Function

        Public Shared Sub AddNobat(ByVal YourPelak As String, ByVal YourSerial As String)
            Dim CmdSql As New SqlClient.SqlCommand
            CmdSql.Connection = New SqlClient.SqlConnection(TWSClassConfigurationManagement.GetTDBClientConnectionString)
            Try
                CmdSql.CommandText = "AddNobat"
                CmdSql.CommandType = CommandType.StoredProcedure
                CmdSql.Parameters.Add("@Pelak", SqlDbType.VarChar, 50, ParameterDirection.Input).Value = YourPelak
                CmdSql.Parameters.Add("@Serial", SqlDbType.VarChar, 50, ParameterDirection.Input).Value = YourSerial
                CmdSql.Connection.Open()
                CmdSql.ExecuteNonQuery()
                CmdSql.Connection.Close()
            Catch ex As Exception
                Throw New Exception("TDBClientManagement.TWSClassTDBClientManagement.AddNobat" + vbCrLf + ex.Message)
            End Try
        End Sub

        Public Shared Sub DelNobat(ByVal YourPelak As String, ByVal YourSerial As String)
            Dim CmdSql As New SqlClient.SqlCommand
            CmdSql.Connection = New SqlClient.SqlConnection(TWSClassConfigurationManagement.GetTDBClientConnectionString)
            Try
                CmdSql.CommandText = "DelNobat"
                CmdSql.CommandType = CommandType.StoredProcedure
                CmdSql.Parameters.Add("@Pelak", SqlDbType.VarChar, 50, ParameterDirection.Input).Value = YourPelak
                CmdSql.Parameters.Add("@Serial", SqlDbType.VarChar, 50, ParameterDirection.Input).Value = YourSerial
                CmdSql.Connection.Open()
                CmdSql.ExecuteNonQuery()
                CmdSql.Connection.Close()
            Catch ex As Exception
                Throw New Exception("TDBClientManagement.TWSClassTDBClientManagement.DelNobat" + vbCrLf + ex.Message)
            End Try
        End Sub

        Public Shared Sub Sodoor(ByVal YourPelak As String, ByVal YourSerial As String, YourTravelTime As Int64)
            Dim CmdSql As New SqlClient.SqlCommand
            CmdSql.Connection = New SqlClient.SqlConnection(TWSClassConfigurationManagement.GetTDBClientConnectionString)
            Try
                CmdSql.CommandText = "Sodoor"
                CmdSql.CommandType = CommandType.StoredProcedure
                CmdSql.Parameters.Add("@Pelak", SqlDbType.VarChar, 50, ParameterDirection.Input).Value = YourPelak
                CmdSql.Parameters.Add("@Serial", SqlDbType.VarChar, 50, ParameterDirection.Input).Value = YourSerial
                CmdSql.Parameters.Add("@TravelTime", SqlDbType.SmallInt, 50, ParameterDirection.Input).Value = YourTravelTime
                CmdSql.Connection.Open()
                CmdSql.ExecuteNonQuery()
                CmdSql.Connection.Close()
            Catch ex As Exception
                Throw New Exception("TDBClientManagement.TWSClassTDBClientManagement.Sodoor" + vbCrLf + ex.Message)
            End Try
        End Sub


    End Class
End Namespace






