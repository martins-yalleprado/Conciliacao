Imports System.Web.Http
Imports Martins.Conciliacao.Code.Intervalo
Imports Martins.Conciliacao.Model

Namespace Controllers
  Public Class IntervaloController
    Inherits ApiController
    ' GET api/<controller>
    Public Function [Get](periodo As Integer) As IEnumerable(Of IntervaloModel)
      Dim bll As New IntervaloBLL()

      Return bll.selectIntervalo(periodo)
    End Function

    ' GET api/<controller>/5
    '  public string Get(int id)
    '  {
    '    return "value";
    '  }

    ' POST api/<controller>
    Public Sub Post(<FromBody> intervalo As IntervaloModel)
      Dim bll As New IntervaloBLL()
      bll.insertIntervalo(intervalo)
    End Sub

    ' PUT api/<controller>/5
    Public Sub Put(<FromBody> intervalo As IntervaloModel, acao As String)
      Dim bll As New IntervaloBLL()
      If acao.ToLower().Equals("ativar") OrElse acao.ToLower().Equals("desativar") Then
        bll.ativarDesativarIntervalo(intervalo)
      Else
        bll.updateIntervalo(intervalo)
      End If
    End Sub

    ' DELETE api/<controller>/5
    Public Sub Delete(id As Integer)
    End Sub
  End Class
End Namespace
