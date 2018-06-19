Imports Administracao.ConciliacaoAPI.Model

Namespace Code.Periodo
    Public Class PeriodoBLL
        Public Function selectPeriodoPorId(id As Integer) As PeriodoModel
            Try
                Dim DAL As New PeriodoDAL()
                Return DAL.selectPeriodoPorId(id)
            Catch e As Exception
                Throw e
            End Try
        End Function
        Public Function selectPeriodo(nome As String, situacao As String) As List(Of PeriodoModel)
            Try
                Dim DAL As New PeriodoDAL()
                Dim list As List(Of PeriodoModel) = DAL.selectPeriodo(nome, situacao)
                Return list
            Catch e As Exception
                Throw e
            End Try
        End Function


        Public Sub deletePeriodo(id As Integer)
            Try
                Dim DAL As New PeriodoDAL()

                DAL.deletePeriodo(id)
            Catch e As Exception
                Throw e
            End Try
        End Sub
        Public Sub insertPeriodo(periodo As PeriodoModel)
            Try
                Dim DAL As New PeriodoDAL()

                DAL.inserirPeriodo(periodo)
            Catch e As Exception
                Throw e
            End Try

        End Sub

        Public Sub updatePeriodo(periodo As PeriodoModel)
            Try
                Dim DAL As New PeriodoDAL()
                DAL.updatePeriodo(periodo)
            Catch e As Exception
                Throw e
            End Try

        End Sub

        Public Sub ativarDesativarPeriodo(periodo As PeriodoModel)
            Try
                Dim DAL As New PeriodoDAL()
                If periodo.situacao.Equals(0) Then
                    DAL.ativarPeriodo(periodo.codPeriodo)
                Else
                    DAL.desativarPeriodo(periodo.codPeriodo)
                End If
            Catch e As Exception
                Throw e
            End Try

        End Sub
    End Class
End Namespace
