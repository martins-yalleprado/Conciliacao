Imports Administracao.ConciliacaoAPI
Imports Administracao.ConciliacaoAPI.Model
Namespace Code.MovimentoAcerto
  Public Class MovimentoAcertoBLL
    Public Function SelectMovimentoAcerto() As List(Of MovimentoAcertoModel)
      Try
        Dim dal As New MovimentoAcertoDAL
        Return dal.SelectMovimentoAcerto()
      Catch e As Exception
        Throw e
      End Try
    End Function
    Public Function SelectMovimentoAcerto(dataMov As DateTime) As List(Of MovimentoAcertoModel)
      Try
        Dim dal As New MovimentoAcertoDAL
        Return dal.SelectMovimentoAcerto(dataMov)
      Catch e As Exception
        Throw e
      End Try
    End Function
    Public Function SelectMovimentoAcertoPorId(ByVal sequencial As Integer, ByVal data As Date, ByVal CodIdentidadeContabil As Integer) As MovimentoAcertoModel
      Try
        Dim dal As New MovimentoAcertoDAL
        Return dal.SelectMovimentoAcertoPorId(sequencial, data, CodIdentidadeContabil)
      Catch e As Exception
        Throw e
      End Try
    End Function

    Public Sub DeleteMovimentoAcerto(ByVal sequencial As Integer, ByVal data As Date, ByVal CodIdentidadeContabil As Integer)
      Try
        Dim dal As New MovimentoAcertoDAL
        dal.DeleteMovimentoAcerto(sequencial, data, CodIdentidadeContabil)
      Catch e As Exception
        Throw e
      End Try
    End Sub

    Public Sub InsertMovimentoAcerto(MovimentoAcerto As MovimentoAcertoModel)
      Try
        Dim dal As New MovimentoAcertoDAL
        dal.InsertMovimentoAcerto(MovimentoAcerto)
      Catch e As Exception
        Throw e
      End Try
    End Sub



    Public Sub UpdateMovimentoAcerto(MovimentoAcerto As MovimentoAcertoModel)
      Try
        Dim dal As New MovimentoAcertoDAL
        dal.UpdateMovimentoAcerto(MovimentoAcerto)
      Catch e As Exception
        Throw e
      End Try
    End Sub
  End Class
End Namespace
