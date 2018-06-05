Imports System.Web.Http
Imports Martins.Conciliacao.Code.Unidade
Imports Martins.Conciliacao.Model

Namespace Controller
  Public Class UnidadeController
    Inherits ApiController
    ' GET api/<controller>
    Public Function [Get]() As IEnumerable(Of UnidadeModel)
      Dim bll As New UnidadeBLL()
      Return bll.SelectUnidade()
    End Function

    ' GET api/<controller>/5
    Public Function [Get](id As Integer) As String
      ' UnidadeBLL bll = new UnidadeBLL();
      Return "value"
    End Function

    ' POST api/<controller>
    Public Sub Post(<FromBody> Unidade As UnidadeModel)
      Dim bll As New UnidadeBLL()

      bll.InsertUnidade(Unidade)
    End Sub

    ' PUT api/<controller>/5
    Public Sub Put(<FromBody> Unidade As UnidadeModel, acao As String)
      Dim bll As New UnidadeBLL()
      If acao.ToLower().Equals("ativar") Then
        bll.AtivarUnidade(Unidade)
      ElseIf acao.ToLower().Equals("inativar") Then
        bll.InativarUnidade(Unidade)
      End If

    End Sub

    ' DELETE api/<controller>/5
    Public Sub Delete(id As Integer)
      'não realiza esta operacao
      '  UnidadeBLL bll = new UnidadeBLL();

    End Sub
  End Class
End Namespace
