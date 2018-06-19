Imports Administracao.ConciliacaoAPI.Code.Conta
Imports Administracao.ConciliacaoAPI.Code.Unidade
Imports Administracao.ConciliacaoAPI.Model

Namespace Code.UnidadeConta
  Public Class UnidadeContaBLL
        Public Function SelectUnidadeConta() As List(Of UnidadeContaModel)
            Try
                Dim dal As New UnidadeContaDAL()
                Dim list As List(Of UnidadeContaModel) = dal.SelectUnidadeConta()
                Return list
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function SelectUnidadeConta(codUnidade As Integer, CodConta As Integer) As List(Of UnidadeContaModel)
      Try
        Dim dal As New UnidadeContaDAL()
        Dim list As List(Of UnidadeContaModel) = dal.SelectUnidadeConta(codUnidade, CodConta)
        Return list
      Catch ex As Exception
        Throw ex
      End Try
    End Function


        Public Sub AtivarInativarUnidadeConta(unidadeConta As UnidadeContaModel)
            Try
                Dim dal As New UnidadeContaDAL()
                dal.AtivarInativarUnidadeConta(unidadeConta)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Sub InsertUnidadeConta(unidadeConta As UnidadeContaModel)
      Try
        Dim dal As New UnidadeContaDAL()
        dal.InsertUnidadeConta(unidadeConta)
      Catch ex As Exception
        Throw ex
      End Try
    End Sub
  End Class
End Namespace
