Public Class TWSStandardStructure


    Private myOCode As String = Nothing
    Private myOName As String = Nothing

#Region "Constructing Management"
    Public Sub New()
    End Sub
    Public Sub New(ByVal OCodee As String, ByVal ONamee As String)
        Try
            OCode = OCodee
            OName = ONamee
        Catch ex As Exception
            Throw New Exception("TWSStandardStructure.New(OCode,OName)." + ex.Message.ToString)
        End Try
    End Sub
#End Region
#Region "Public Propertis"
    Public Property OCode() As String
        Get
            Return Trim(myOCode)
        End Get
        Set(ByVal Value As String)
            myOCode = Value
        End Set
    End Property
    Public Property OName() As String
        Get
            Return Trim(myOName)
        End Get
        Set(ByVal Value As String)
            myOName = Value
        End Set
    End Property
#End Region



End Class
