
Imports TWSClassLibrary.TWSPublicEnums
Public MustInherit Class TWSQueryGeneral

    Private myteadad As Int64
    Private myDataTable As DataTable = New DataTable


#Region "Constractors"
    Public Sub New()
    End Sub
#End Region
#Region "Properties Management"
    Public Property GeneralTable() As DataTable
        Get
            Return myDataTable
        End Get
        Set(ByVal Value As DataTable)
            myDataTable = Value
        End Set
    End Property
#End Region
#Region "Teadad Management"
    Public ReadOnly Property Teadad() As Int64
        Get
            Return myteadad
        End Get
    End Property
    Protected WriteOnly Property TeadadSet() As Int64
        Set(ByVal Value As Int64)
            myteadad = Value
        End Set
    End Property
#End Region
#Region "Public MustOverride Subs And Funcs"
    Public MustOverride Sub Preparing(ByVal TDBConnectionString As String, ByVal PrepareCode As Int16, ByVal SortOrder As CodeNameSortOrder, Optional ByVal SearchStr As Object = "", Optional ByVal Param1 As Object = "", Optional ByVal Param2 As Object = "", Optional ByVal Param3 As Object = "", Optional ByVal Param4 As Int64 = -1)
    Public MustOverride Function IsValidOCode(ByVal OCodee As String) As Boolean
    Public MustOverride Function IsValidOName(ByVal ONamee As String) As Boolean
    Public MustOverride Function GetValidONameFromOCode(ByVal OCodee As String) As String
    Public MustOverride Function GetValidOCodeFromOName(ByVal ONamee As String) As String
    Public MustOverride Function Getindex(ByVal OCode As String) As Int64
    Public MustOverride Function GetIndexBySearchStrInStartCharacters(ByVal SearchStr As String) As Int32
    Public MustOverride Function ExistInQueryOCode(ByVal Ocode As String) As Boolean
    Public MustOverride Function ExistInQueryOName(ByVal OName As String) As Boolean
#End Region


End Class
