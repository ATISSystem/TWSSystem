

Public Class MClassManagement

    Public Shared Function AuthenticationId() As String
        Try
            Return "Biinfo878"
        Catch ex As Exception
            Throw New Exception("MClassManagement.AuthenticationId()." + ex.Message.ToString)
        End Try
    End Function

    Public Class StandardLogStructure


        Private myTerminal As String = Nothing
        Private myDateAndTime As String = Nothing
        Private myShDate As String = Nothing
        Private myTime As String = Nothing
        Private myLogNote As String = Nothing


        Public Sub New()
        End Sub
        Public Sub New(ByVal Terminall As String, ByVal DateAndTimee As String, ByVal ShDatee As String, ByVal Timee As String, ByVal LogNotee As String)
            Try
                Terminal = Terminall
                DateAndTime = DateAndTimee
                ShDate = ShDatee
                Time = Timee
                LogNote = LogNotee
            Catch ex As Exception
                Throw New Exception("StandardLogStructure.New()." + ex.Message.ToString)
            End Try
        End Sub
        Public Property Terminal() As String
            Get
                Return Trim(myTerminal)
            End Get
            Set(ByVal Value As String)
                myTerminal = Value
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
        Public Property LogNote() As String
            Get
                Return Trim(myLogNote)
            End Get
            Set(ByVal Value As String)
                myLogNote = Value
            End Set
        End Property
    End Class


End Class
