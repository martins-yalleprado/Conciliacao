Imports System.Net
Imports System.Net.Http
Imports System.Web.Http
Imports Administracao.ConciliacaoAPI.Code.MovimentoConciliacao
Imports Administracao.ConciliacaoAPI.Model

Namespace Controllers
    Public Class MovimentoConciliacaoController
        Inherits ApiController

        ' GET api/<controller>
        Public Function GetValues() As Object
            Try
                Dim bll As New MovimentoConciliacaoBLL
                Return New ResultModel(bll.SelectMovimentoConciliacao())
            Catch ex As Exception
                Return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message)
            End Try
        End Function

        'GET api/<controller>/5
        <Route("api/MovimentoConciliacao/{CodIdentidadeContabil}")>
        Public Function GetValue(CodIdentidadeContabil As Integer) As Object
            Try
                Dim bll As New MovimentoConciliacaoBLL
                Return New ResultModel(bll.SelectMovimentoConciliacaoPorMovimentoContabil(CodIdentidadeContabil))
            Catch ex As Exception
                Return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message)
            End Try
        End Function

        ' POST api/<controller>
        Public Function PostValue(<FromBody()> ByVal movimentoConciliacao As MovimentoConciliacaoModel) As Object
            Try
                Dim bll As New MovimentoConciliacaoBLL
                bll.InsertMovimentoConciliacao(movimentoConciliacao)
                Return New ResultModel(Nothing)
            Catch ex As Exception
                Return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message)
            End Try
        End Function

        ' PUT api/<controller>/5
        Public Function PutValue(<FromBody()> ByVal movimentoConciliacao As MovimentoConciliacaoModel) As Object
            Try
                Dim bll As New MovimentoConciliacaoBLL
                bll.UpdateMovimentoConciliacao(movimentoConciliacao)
            Catch ex As Exception
                Return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message)
            End Try
        End Function

        ' DELETE api/<controller>/5
        Public Function DeleteValue(ByVal id As Integer) As Object
            Try
                Dim bll As New MovimentoConciliacaoBLL
                bll.DeleteMovimentoConciliacao(id)
                Return New ResultModel(Nothing)
            Catch ex As Exception
                Return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message)
            End Try
        End Function
    End Class
End Namespace
