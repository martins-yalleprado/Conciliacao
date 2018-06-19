Imports System.Net
Imports System.Net.Http
Imports System.Web.Http
Imports System.Web.Services.Description
Imports Administracao.ConciliacaoAPI.Code.Conta
Imports Administracao.ConciliacaoAPI.Model
Namespace Controllers
    Public Class ContaController
        Inherits ApiController

        ' GET api/<controller>
        Public Function GetValues() As Object
            Try
                Dim bll As New ContaBLL
                Return New ResultModel(bll.SelectConta())
            Catch ex As Exception
                Return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message)
            End Try
        End Function

        ' GET api/<controller>/5
        Public Function GetValue(ByVal id As Integer) As Object
            Try
                Dim bll As New ContaBLL
                Return New ResultModel(bll.SelectContaPorId(id))
            Catch ex As Exception
                Return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message)
            End Try
        End Function

        ' POST api/<controller>
        Public Function PostValue(<FromBody()> ByVal ContaModel As ContaModel) As Object
            Try
                Dim bll As New ContaBLL
                bll.InsertConta(ContaModel)
            Catch ex As Exception
                Return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message)
            End Try
        End Function

        ' PUT api/<controller>/5
        Public Function PutValue(<FromBody()> ByVal ContaModel As ContaModel, acao As String) As Object
            Try
                Dim bll As New ContaBLL
                bll.UpdateConta(ContaModel, acao)
                Return New ResultModel(Nothing)
            Catch ex As Exception
                Return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message)
            End Try
        End Function
    End Class
End Namespace
