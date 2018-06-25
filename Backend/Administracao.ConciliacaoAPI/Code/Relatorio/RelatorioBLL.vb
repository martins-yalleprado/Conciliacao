Imports Administracao.ConciliacaoAPI.Model

Namespace Code.Relatorio
    Public Class RelatorioBLL
        Public Function selectRelatorioPorId(id As Integer) As RelatorioModel
            Try
                Dim DAL As New RelatorioDAL()
                Return DAL.selectRelatorioPorId(id)
            Catch e As Exception
                Throw e
            End Try
        End Function
        Public Function selectRelatorio() As List(Of RelatorioModel)
            Try
                Dim DAL As New RelatorioDAL()
                Dim list As List(Of RelatorioModel) = DAL.selectRelatorio()
                Return list
            Catch e As Exception
                Throw e
            End Try
        End Function
        Public Function selectRelatorio(ByVal tipo As Integer, data As DateTime) As List(Of RelatorioModel)
            Try
                Dim DAL As New RelatorioDAL()
                Dim list As List(Of RelatorioModel) = DAL.selectRelatorio(tipo, data)
                Return list
            Catch e As Exception
                Throw e
            End Try
        End Function

        Public Sub deleteRelatorio(id As Integer)
            Try
                Dim DAL As New RelatorioDAL()

                DAL.deleteRelatorio(id)
            Catch e As Exception
                Throw e
            End Try
        End Sub
        Public Sub insertRelatorio(Relatorio As RelatorioModel)
            Try
                Dim DAL As New RelatorioDAL()

                DAL.inserirRelatorio(Relatorio)
            Catch e As Exception
                Throw e
            End Try

        End Sub

        Public Sub updateRelatorio(Relatorio As RelatorioModel)
            Try
                Dim DAL As New RelatorioDAL()
                DAL.updateRelatorio(Relatorio)
            Catch e As Exception
                Throw e
            End Try

        End Sub


    End Class
End Namespace
