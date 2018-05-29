Imports System.Web.Http
Imports Martins.Conciliacao.Code.Periodo
Imports Martins.Conciliacao.Model
Imports Microsoft.Owin.Security.OAuth

Namespace Controllers
  Public Class PeriodoController
    Inherits ApiController
    Private context As OAuthGrantResourceOwnerCredentialsContext


    Public Sub PeriodoController(contexto As OAuthGrantResourceOwnerCredentialsContext)
      context = contexto
    End Sub
    ' GET api/<controller>
    Public Function [Get](nome As String, situacao As String) As IEnumerable(Of PeriodoModel)
      Dim bll As New PeriodoBLL()
      If nome IsNot Nothing Then
        nome = "%" & nome & "%"
      End If
      Return bll.selectPeriodo(nome, situacao)
    End Function
    ' GET api/<controller>
    Public Function [Get]() As IEnumerable(Of PeriodoModel)
      Dim bll As New PeriodoBLL()
      Return bll.selectPeriodo(Nothing, Nothing)
    End Function
    ' GET api/<controller>
    Public Function [Get](nome As String) As IEnumerable(Of PeriodoModel)
      Dim bll As New PeriodoBLL()
      If nome IsNot Nothing Then
        nome = "%" & nome & "%"
      End If
      Return bll.selectPeriodo(nome, Nothing)
    End Function
    ' GET api/<controller>/5
    Public Function [Get](id As Integer) As PeriodoModel
      Dim bll As New PeriodoBLL()

      Return bll.selectPeriodoPorId(id)
    End Function

    ' POST api/<controller>
    Public Sub [Post](<FromBody> periodo As PeriodoModel)
      Dim bll As New PeriodoBLL()
      If bll.selectPeriodo(periodo.nome, Nothing).Count > 0 Then
        Throw New Exception("Nome do Período já existente")
        Exit Sub
      End If
      bll.insertPeriodo(periodo)
    End Sub

    ' PUT api/<controller>/5
    Public Sub Put(<FromBody> periodo As PeriodoModel, acao As String)
      Dim bll As New PeriodoBLL()
      If acao.ToLower().Equals("ativar") OrElse acao.ToLower().Equals("inativar") Then
        bll.ativarDesativarPeriodo(periodo)
      Else
        bll.updatePeriodo(periodo)
      End If
    End Sub

    ' DELETE api/<controller>/5
    Public Sub Delete(id As Integer)
      Dim bll As New PeriodoBLL()
      bll.deletePeriodo(id)
    End Sub
  End Class
End Namespace
