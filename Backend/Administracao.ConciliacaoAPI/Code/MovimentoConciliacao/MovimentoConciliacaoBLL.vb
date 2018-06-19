Imports Administracao.ConciliacaoAPI
Imports Administracao.ConciliacaoAPI.Model
Namespace Code.MovimentoConciliacao
  Public Class MovimentoConciliacaoBLL
    Public Function SelectMovimentoConciliacao() As IEnumerable(Of MovimentoConciliacaoModel)
      Try
        Dim dal As New MovimentoConciliacaoDAL
        Return dal.SelectMovimentoConciliacao()
      Catch e As Exception
        Throw e
      End Try
    End Function
    Public Function SelectMovimentoConciliacaoPorId(id As Integer) As MovimentoConciliacaoModel
      Try
        Dim dal As New MovimentoConciliacaoDAL
        Return dal.SelectMovimentoConciliacaoPorId(id)
      Catch e As Exception
        Throw e
      End Try
    End Function

    Public Sub DeleteMovimentoConciliacao(id As Integer)
      Try
        Dim dal As New MovimentoConciliacaoDAL
        dal.DeleteMovimentoConciliacao(id)
      Catch e As Exception
        Throw e
      End Try
    End Sub

    Friend Function SelectMovimentoConciliacaoPorMovimentoContabil(CodIdentidadeContabil As Integer) As List(Of MovimentoConciliacaoModel)
      Try
        Dim dal As New MovimentoConciliacaoDAL
        Return dal.SelectMovimentoConciliacaoPorMovimentoContabil(CodIdentidadeContabil)
      Catch e As Exception
        Throw e
      End Try
    End Function

    Public Sub InsertMovimentoConciliacao(movimentoConciliacao As MovimentoConciliacaoModel)
      Try
        Dim dal As New MovimentoConciliacaoDAL
        dal.InsertMovimentoConciliacao(movimentoConciliacao)
      Catch e As Exception
        Throw e
      End Try
    End Sub



    Public Sub UpdateMovimentoConciliacao(movimentoConciliacao As MovimentoConciliacaoModel)
      Try
        Dim dal As New MovimentoConciliacaoDAL
        dal.UpdateMovimentoConciliacao(movimentoConciliacao)
      Catch e As Exception
        Throw e
      End Try
    End Sub
  End Class
End Namespace
