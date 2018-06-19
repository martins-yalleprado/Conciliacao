Imports System.Net
Imports System.Net.Http
Imports System.Web.Http
Imports Administracao.ConciliacaoAPI.Code.UnidadeConta
Imports Administracao.ConciliacaoAPI.Model

Namespace Controllers
    Public Class UnidadeContaController
        Inherits ApiController
        ' GET api/<controller>
        Public Function GetValues() As Object
            Try
                Dim bll As New UnidadeContaBLL()
                Return New ResultModel(bll.SelectUnidadeConta())
            Catch ex As Exception
                Return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message)
            End Try
        End Function

        ' GET api/<controller>/5
        <HttpGet>
        <Route("api/UnidadeConta/{codUnidade}/{codConta}")>
        Public Function GetValues(CodUnidade As Integer, codConta As Integer) As Object
            Try
                Dim bll As New UnidadeContaBLL()
                Return New ResultModel(bll.SelectUnidadeConta(CodUnidade, codConta))
            Catch ex As Exception
                Return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message)
            End Try
        End Function

        ' POST api/<controller>
        Public Function PostValue(<FromBody> unidadeConta As UnidadeContaModel) As Object
            Try
                Dim bll As New UnidadeContaBLL()
                bll.InsertUnidadeConta(unidadeConta)
                Return New ResultModel(Nothing)
            Catch ex As Exception
                Return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message)
            End Try
        End Function

        ' PUT api/<controller>/5
        <HttpPut()>
        <Route("api/UnidadeConta/{codEmpresa}/{codConta}/{codUnidade}")>
        Public Function PutValue(codEmpresa As Integer, codConta As Integer, codUnidade As Integer, <FromBody> unidadeConta As UnidadeContaModel) As Object
            Try
                Dim bll As New UnidadeContaBLL()

                unidadeConta = New UnidadeContaModel()
                unidadeConta.ContaModel = New ContaModel()
                unidadeConta.UnidadeModel = New UnidadeModel()
                unidadeConta.CodEmpresa = codEmpresa
                unidadeConta.UnidadeModel.CodUnidade = codUnidade
                unidadeConta.ContaModel.CodContaContabil = codConta

                bll.AtivarInativarUnidadeConta(unidadeConta)

                Return New ResultModel(Nothing)

            Catch ex As Exception
                Return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message)
            End Try
        End Function

    End Class
End Namespace
