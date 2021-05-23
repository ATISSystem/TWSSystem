Public Class TWSStandardTruckStructure
    Inherits TWSStandardStructure


    Private myPelak As String = Nothing
    Private mySerial As String = Nothing



#Region "Constructors"
    Public Sub New()
        MyBase.New()
    End Sub
    Public Sub New(ByVal TruckIdd As String, ByVal Pelakk As String, ByVal Seriall As String)
        MyBase.New(TruckIdd, "")
        Pelak = Pelakk
        Serial = Seriall
    End Sub
#End Region
#Region "Propertis"
    Public Property Pelak() As String
        Get
            Return Trim(myPelak)
        End Get
        Set(ByVal Value As String)
            myPelak = Value
        End Set
    End Property
    Public Property Serial() As String
        Get
            Return Trim(mySerial)
        End Get
        Set(ByVal Value As String)
            mySerial = Value
        End Set
    End Property

#End Region

End Class
