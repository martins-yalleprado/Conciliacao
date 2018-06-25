Imports Administracao.ConciliacaoAPI.Model

Namespace Code.MovimentoTitulo
    Public Class MovimentoTituloBLL
        Public Function selectDatasTitulosPorCarga(numSeqCarga As Integer) As List(Of Date)
            Try
                Dim DAL As New MovimentoTituloDAL
                Return DAL.selectDatasTitulosPorCarga(numSeqCarga)
            Catch e As Exception
                Throw e
            End Try
        End Function
    End Class
End Namespace
