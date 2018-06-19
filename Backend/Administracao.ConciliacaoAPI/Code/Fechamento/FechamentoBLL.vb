Imports Administracao.ConciliacaoAPI.Model

Namespace Code.Fechamento
  Public Class FechamentoBLL
    Public Function SelectFechamento() As List(Of FechamentoModel)
      Try
        Dim dal As New FechamentoDAL()
        Return dal.SelectFechamento()
      Catch ex As Exception
        Throw ex
      End Try
    End Function
        Public Function SelectFechamentoPorTipoID(tipo As String, CodFechamento As Integer, CodUnidade As Integer, CodConta As Integer) As List(Of FechamentoModel)
            Try
                Dim dal As New FechamentoDAL()
                Return dal.SelectFechamentoPorTipoID(tipo, CodFechamento, CodUnidade, CodConta)
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        Public Sub AtivarFechamento(Fechamento As FechamentoModel)
      Try
        Dim dal As New FechamentoDAL()
        dal.AtivarFechamento(Fechamento)
      Catch ex As Exception
        Throw ex
      End Try
    End Sub
    Public Sub InativarFechamento(Fechamento As FechamentoModel)
      Try
        Dim dal As New FechamentoDAL()
        dal.InativarFechamento(Fechamento)
      Catch ex As Exception
        Throw ex
      End Try
    End Sub
    Public Sub InsertFechamento(Fechamento As FechamentoModel)
      Try
        Dim dal As New FechamentoDAL()
        dal.InsertFechamento(Fechamento)
      Catch ex As Exception
        Throw ex
      End Try
    End Sub
  End Class
End Namespace
