Public Class TWSStandardTerminalStructure
    Inherits TWSStandardStructure


    Private myRndCode As String = Nothing



#Region "Constructors"
    Public Sub New()
        MyBase.New()
    End Sub
    Public Sub New(ByVal TerminalIdd As String, ByVal TerminalNamee As String, ByVal RndCodee As String)
        MyBase.New(TerminalIdd, TerminalNamee)
        RndCode = RndCodee
    End Sub
#End Region
#Region "Propertis"
    Public Property RndCode() As String
        Get
            Return Trim(myRndCode)
        End Get
        Set(ByVal Value As String)
            myRndCode = Value
        End Set
    End Property
#End Region

End Class
