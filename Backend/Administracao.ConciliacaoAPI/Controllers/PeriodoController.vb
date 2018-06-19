Imports System.Net
Imports System.Net.Http
Imports System.Web.Http
Imports Administracao.ConciliacaoAPI.Code.Periodo
Imports Administracao.ConciliacaoAPI.Model
Imports Microsoft.Owin.Security.OAuth

Namespace Controllers
    Public Class PeriodoController
        Inherits ApiController

        ' GET api/<controller>
        <Route("api/Periodo/{nome}/{situacao}")>
        Public Function GetValue(nome As String, situacao As String) As Object
            Try
                Dim bll As New PeriodoBLL()
                If nome IsNot Nothing Then
                    nome = "%" & nome & "%"
                End If
                Return New ResultModel(bll.selectPeriodo(nome, situacao))
            Catch ex As Exception
                Return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message)
            End Try
        End Function
        ' GET api/<controller>
        <Route("api/Periodo")>
        Public Function GetValues() As Object
            Try
                Dim bll As New PeriodoBLL()
                Return New ResultModel(bll.selectPeriodo(Nothing, Nothing))
            Catch ex As Exception
                Return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message)
            End Try
        End Function
        ' GET api/<controller>
        <Route("api/Periodo/{nome}")>
        Public Function GetValues(nome As String) As Object
            Try
                Dim bll As New PeriodoBLL()
                If nome IsNot Nothing Then
                    nome = "%" & nome & "%"
                End If
                Return New ResultModel(bll.selectPeriodo(nome, Nothing))
            Catch ex As Exception
                Return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message)
            End Try
        End Function
        ' GET api/<controller>/5
        <Route("api/Periodo/id/{id:int}")>
        Public Function GetValue(id As Integer) As Object
            Try
                Dim bll As New PeriodoBLL()
                Return New ResultModel(bll.selectPeriodoPorId(id))
            Catch ex As Exception
                Return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message)
            End Try
        End Function

        ' POST api/<controller>
        <Route("api/Periodo")>
        Public Function PostValue(<FromBody> periodo As PeriodoModel) As Object
            Try
                Dim bll As New PeriodoBLL()
                If bll.selectPeriodo(periodo.nome, Nothing).Count > 0 Then
                    Throw New Exception("Nome do Período já existente")
                    Exit Function
                End If
                bll.insertPeriodo(periodo)
                Return New ResultModel(Nothing)
            Catch ex As Exception
                Return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message)
            End Try
        End Function

        ' PUT api/<controller>/5
        <Route("api/Periodo")>
        Public Function PutValue(<FromBody> periodo As PeriodoModel, acao As String) As Object
            Try
                Dim bll As New PeriodoBLL()
                If acao.ToLower().Equals("ativar") OrElse acao.ToLower().Equals("inativar") Then
                    bll.ativarDesativarPeriodo(periodo)
                Else
                    bll.updatePeriodo(periodo)
                End If
                Return New ResultModel(Nothing)
            Catch ex As Exception
                Return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message)
            End Try
        End Function

        ' DELETE api/<controller>/5
        <Route("api/Periodo/{id}")>
        Public Function DeleteValue(id As Integer) As Object
            Try
                Dim bll As New PeriodoBLL()
                bll.deletePeriodo(id)
                Return New ResultModel(Nothing)
            Catch ex As Exception
                Return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message)
            End Try
        End Function
    End Class
End Namespace
