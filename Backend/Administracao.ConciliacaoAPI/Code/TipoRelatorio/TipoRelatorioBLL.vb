Imports Administracao.ConciliacaoAPI.Model

Namespace Code.TipoRelatorio
    Public Class TipoRelatorioBLL
        Public Function selectTipoRelatorioPorId(id As Integer) As TipoRelatorioModel
            Try
                Dim DAL As New TipoRelatorioDAL()
                Return DAL.selectTipoRelatorioPorId(id)
            Catch e As Exception
                Throw e
            End Try
        End Function
        Public Function selectTipoRelatorio() As List(Of TipoRelatorioModel)
            Try
                Dim DAL As New TipoRelatorioDAL()
                Dim list As List(Of TipoRelatorioModel) = DAL.selectTipoRelatorio()
                Return list
            Catch e As Exception
                Throw e
            End Try
        End Function


        Public Sub deleteTipoRelatorio(id As Integer)
            Try
                Dim DAL As New TipoRelatorioDAL()

                DAL.deleteTipoRelatorio(id)
            Catch e As Exception
                Throw e
            End Try
        End Sub
        Public Sub insertTipoRelatorio(ByRef TipoRelatorio As TipoRelatorioModel)
            Try
                Dim DAL As New TipoRelatorioDAL()

                DAL.inserirTipoRelatorio(TipoRelatorio)
            Catch e As Exception
                Throw e
            End Try

        End Sub

        Public Sub updateTipoRelatorio(TipoRelatorio As TipoRelatorioModel)
            Try
                Dim DAL As New TipoRelatorioDAL()
                DAL.updateTipoRelatorio(TipoRelatorio)
            Catch e As Exception
                Throw e
            End Try

        End Sub


    End Class
End Namespace
