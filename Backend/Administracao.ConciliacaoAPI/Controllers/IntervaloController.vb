Imports System.Net
Imports System.Net.Http
Imports System.Web.Http
Imports Administracao.ConciliacaoAPI.Code.Intervalo
Imports Administracao.ConciliacaoAPI.Model

Namespace Controllers
    Public Class IntervaloController
        Inherits ApiController
        ' GET api/<controller>
        <Route("api/Intervalo/{periodo}")>
        Public Function GetValues(periodo As Integer) As Object
            Try
                Dim bll As New IntervaloBLL()

                Return New ResultModel(bll.selectIntervalo(periodo, Nothing))
            Catch ex As Exception
                Return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message)
            End Try
        End Function

        <Route("api/Intervalo/{periodo}/{situacao}")>
        Public Function GetValues(periodo As Integer, situacao As String) As Object
            Try
                Dim bll As New IntervaloBLL()

                Return New ResultModel(bll.selectIntervalo(periodo, situacao))
            Catch ex As Exception
                Return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message)
            End Try
        End Function

        ' GET api/<controller>/5
        '  public string Get(int id)
        '  {
        '    return "value";
        '  }

        ' POST api/<controller>
        <Route("api/Intervalo")>
        Public Function PostValue(<FromBody> intervalo As IntervaloModel) As Object
            Try
                Dim bll As New IntervaloBLL()
                Dim teste = bll.selectIntervaloDeAte(intervalo.inicio, intervalo.fim, intervalo.codPeriodo)
                If bll.selectIntervaloDeAte(intervalo.inicio, intervalo.fim, intervalo.codPeriodo) = 1 Then
                    Throw New Exception("Intervalo já existente")
                    Exit Function
                End If
                bll.insertIntervalo(intervalo)
                Return New ResultModel(Nothing)
            Catch ex As Exception
                Return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message)
            End Try
        End Function

        ' PUT api/<controller>/5
        <Route("api/Intervalo")>
        Public Function PutValue(<FromBody> intervalo As IntervaloModel, acao As String) As Object
            Try
                Dim bll As New IntervaloBLL()
                If acao.ToLower().Equals("ativar") OrElse acao.ToLower().Equals("desativar") Then
                    bll.ativarDesativarIntervalo(intervalo)
                Else
                    bll.updateIntervalo(intervalo)
                End If
                Return New ResultModel(Nothing)
            Catch ex As Exception
                Return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message)
            End Try
        End Function

    End Class
End Namespace
