Imports Administracao.ConciliacaoAPI.Model

Namespace Code.MovimentoContabil
  Public Class MovimentoContabilBLL
    Public Sub DeleteMovimentoContabil(id As Integer)
      Dim dal As New MovimentoContabilDAL
      dal.DeleteMovimentoContabil(id)
    End Sub

    Public Sub UpdateMovimentoContabil(movimentoContabilModel As MovimentoContabilModel)
      Dim dal As New MovimentoContabilDAL
      dal.UpdateMovimentoContabil(movimentoContabilModel)
    End Sub

        Public Function SelectMovimentoContabil(codUndNgc As Integer) As IEnumerable(Of MovimentoContabilModel)
            Dim dal As New MovimentoContabilDAL
            Return dal.SelectMovimentoContabil(codUndNgc)
        End Function

        Public Sub InsertMovimentoContabil(movimentoContabilModel As MovimentoContabilModel)
            Dim dal As New MovimentoContabilDAL
            dal.InsertMovimentoContabil(movimentoContabilModel)
        End Sub

        Public Function SelectDatasMovimentoContabilPorCarga(numSeqCarga As Integer) As List(Of Date)
            Dim dal As New MovimentoContabilDAL
            Return dal.SelectDatasMovimentoContabilPorCarga(numSeqCarga)
        End Function



        Public Function SelectMovimentoContabilPorUnidadeConta(ByVal codunidade As Integer, ByVal codConta As Integer, ByVal CodEventoContabil As Integer, ByVal CodFatoContabil As Integer, ByVal DesEventoContabil As String, ByVal DesFatoContabil As String, ByVal NomSistemaInformacao As String) As List(Of MovimentoContabilModel)
      Dim dal As New MovimentoContabilDAL
      Return dal.SelectMovimentoContabilPorUnidadeConta(codunidade, codConta, CodEventoContabil, CodFatoContabil, DesEventoContabil, DesFatoContabil, NomSistemaInformacao)
    End Function

    Public Function SelectMovimentoContabilPorId(id As Integer) As MovimentoContabilModel
      Dim dal As New MovimentoContabilDAL
      Return dal.SelectMovimentoContabilPorId(id)
    End Function
  End Class
End Namespace
