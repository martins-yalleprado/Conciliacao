Imports Administracao.ConciliacaoAPI.Model

Namespace Code.MovimentoAging
    Public Class MovimentoAgingBLL
        Public Function selectDatasAgingPorCarga(numSeqCarga As Integer) As List(Of Date)
            Try
                Dim DAL As New MovimentoAgingDAL
                Return DAL.selectDatasAgingPorCarga(numSeqCarga)
            Catch e As Exception
                Throw e
            End Try
        End Function
    End Class
End Namespace
