Imports System.Web.Http
Imports Martins.Conciliacao.Code.UnidadeConta
Imports Martins.Conciliacao.Model

Namespace Controller
  Public Class UnidadeContaController
    Inherits ApiController
    ' GET api/<controller>
    Public Function [Get]() As IEnumerable(Of UnidadeContaModel)
      Dim bll As New UnidadeContaBLL()
      Return bll.SelectUnidadeConta()
    End Function

    ' GET api/<controller>/5
    Public Function [Get](id As Integer) As String
      ' UnidadeContaBLL bll = new UnidadeContaBLL();
      Return "value"
    End Function

    ' POST api/<controller>
    Public Sub Post(<FromBody> unidadeConta As UnidadeContaModel)
      Dim bll As New UnidadeContaBLL()

      bll.InsertUnidadeConta(unidadeConta)
    End Sub

    ' PUT api/<controller>/5
    Public Sub Put(<FromBody> unidadeConta As UnidadeContaModel, acao As String)
      Dim bll As New UnidadeContaBLL()
      If acao.ToLower().Equals("ativar") Then
        bll.AtivarUnidadeConta(unidadeConta)
      ElseIf acao.ToLower().Equals("inativar") Then
        bll.InativarUnidadeConta(unidadeConta)
      End If

    End Sub

    ' DELETE api/<controller>/5
    Public Sub Delete(id As Integer)
      'não realiza esta operacao
      '  UnidadeContaBLL bll = new UnidadeContaBLL();

    End Sub
  End Class
End Namespace
