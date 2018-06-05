Imports System.Web.Http
Imports Martins.Conciliacao.Code.Conta
Imports Martins.Conciliacao.Model


Namespace Controller
  Public Class ContaController
    Inherits ApiController
    Public Function [Get]() As IEnumerable(Of ContaModel)
      Dim bll As New ContaBLL()
      Return bll.SelectConta()
    End Function

    ' GET api/<controller>/5
    Public Function [Get](id As Integer) As String
      ' ContaBLL bll = new ContaBLL();
      Return "value"
    End Function

    ' POST api/<controller>
    Public Sub Post(<FromBody> Conta As ContaModel)
      Dim bll As New ContaBLL()

      bll.InsertConta(Conta)
    End Sub

    ' PUT api/<controller>/5
    Public Sub Put(<FromBody> Conta As ContaModel, acao As String)
      Dim bll As New ContaBLL()
      If acao.ToLower().Equals("ativar") Then
        bll.AtivarConta(Conta)
      ElseIf acao.ToLower().Equals("inativar") Then
        bll.InativarConta(Conta)
      End If

    End Sub

    ' DELETE api/<controller>/5
    Public Sub Delete(id As Integer)
      'não realiza esta operacao
      '  ContaBLL bll = new ContaBLL();

    End Sub
  End Class
End Namespace
