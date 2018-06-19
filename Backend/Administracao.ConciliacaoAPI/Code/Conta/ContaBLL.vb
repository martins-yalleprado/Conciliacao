Imports Administracao.ConciliacaoAPI.Model

Namespace Code.Conta
  Public Class ContaBLL
    'Public Sub DeleteConta(id As Integer)
    '  Dim dal As New ContaDAL
    '  dal.DeleteConta(id)
    'End Sub

    Public Sub UpdateConta(ContaModel As ContaModel, acao As String)
      Dim dal As New ContaDAL
      If acao.ToLower.Equals("ativar") Then
        dal.AtivarConta(ContaModel)
      ElseIf acao.ToLower.Equals("inativar") Then
        dal.InativarConta(ContaModel)
      Else
        Throw New Exception("Ação Inexistente")
      End If
    End Sub

    Public Function SelectConta() As IEnumerable(Of ContaModel)
      Dim dal As New ContaDAL
      Return dal.SelectConta()
    End Function

    Public Sub InsertConta(ContaModel As ContaModel)
      Dim dal As New ContaDAL
      dal.InsertConta(ContaModel)
    End Sub

    Public Function SelectContaPorId(id As Integer) As ContaModel
      Dim dal As New ContaDAL
      Return dal.SelectContaPorId(id)
    End Function
  End Class
End Namespace
