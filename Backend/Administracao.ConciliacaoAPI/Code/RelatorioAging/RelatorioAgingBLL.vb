Public Class RelatorioAgingBLL
    Public Function selectRelatorioAgingSintetico(ByVal data As DateTime, periodoId As Integer) As List(Of RelatorioAgingModel)
        Try
            Dim DAL As New RelatorioAgingDAL()
            Dim list As List(Of RelatorioAgingModel) = DAL.selectRelatorioAgingSintetico(data, periodoId)
            Return list
        Catch e As Exception
            Throw e
        End Try
    End Function
End Class
