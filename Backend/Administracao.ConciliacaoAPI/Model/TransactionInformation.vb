Public Class TransactionalInformation
    Public Property ReturnStatus As Boolean
    Public Property ReturnMessage As List(Of String)
    Public Property ValidationErrors As Hashtable
    Public Property TotalPages As Integer
    Public Property TotalRows As Integer
    Public Property PageSize As Integer
    Public Property IsAuthenicated As Boolean
    Public Property SortExpression As String
    Public Property SortDirection As String
    Public Property CurrentPageNumber As Integer
    Public Property Search As String
    Public Property Motive As String

    Public Sub New()
        ReturnMessage = New List(Of String)()
        ReturnStatus = True
        ValidationErrors = New Hashtable()
        TotalPages = 0
        TotalPages = 0
        PageSize = 10
        IsAuthenicated = False
    End Sub
End Class
