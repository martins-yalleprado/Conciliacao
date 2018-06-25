Imports System.Net
Imports System.Net.Http
Imports System.Web.Http
Imports Administracao.ConciliacaoAPI.Code.MovimentoAcerto
Imports Administracao.ConciliacaoAPI.Code.MovimentoContabil
Imports Administracao.ConciliacaoAPI.Model
Namespace Controllers
    Public Class MovimentoContabilController
        Inherits ApiController

        ' GET api/<controller>
        <Route("api/MovimentoContabil")>
        Public Function GetMovimentosPorUnidade(<FromUri()> ByVal codUnidadeNegocio As Integer) As Object
            Try
                Dim bll As New MovimentoContabilBLL
                Return New ResultModel(bll.SelectMovimentoContabil(codUnidadeNegocio))
            Catch ex As Exception
                Return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message)
            End Try
        End Function


        ' GET api/<controller>/5
        <Route("api/MovimentoContabil/{id}")>
        Public Function GetValue(ByVal id As Integer) As Object
            Try
                Dim bll As New MovimentoContabilBLL
                Return New ResultModel(bll.SelectMovimentoContabilPorId(id))
            Catch ex As Exception
                Return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message)
            End Try
        End Function
        ' GET api/<controller>/5
        <Route("api/MovimentoContabil/{codUnidade}/{codConta}/{CodEventoContabil}/{CodFatoContabil}/{DesEventoContabil}/{DesFatoContabil}/{NomSistemaInformacao}")>
        Public Function GetValues(ByVal codunidade As Integer, ByVal codConta As Integer, ByVal CodEventoContabil As Integer, ByVal CodFatoContabil As Integer, ByVal DesEventoContabil As String, ByVal DesFatoContabil As String, ByVal NomSistemaInformacao As String) As Object
            Try
                Dim bll As New MovimentoContabilBLL
                Return New ResultModel(bll.SelectMovimentoContabilPorUnidadeConta(codunidade, codConta, CodEventoContabil, CodFatoContabil, DesEventoContabil, DesFatoContabil, NomSistemaInformacao))
            Catch ex As Exception
                Return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message)
            End Try
        End Function

        <Route("api/MovimentoContabil/detail/{numSeqCarga}")>
        Public Function GetValues(ByVal numSeqCarga As Integer) As Object
            Try
                Dim bll As New MovimentoContabilBLL
                Return New ResultModel(bll.SelectDatasMovimentoContabilPorCarga(numSeqCarga))
            Catch ex As Exception
                Return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message)
            End Try
        End Function

        ' POST api/<controller>
        Public Function PostValue(<FromBody()> ByVal movimentoContabilModel As MovimentoContabilModel) As Object
            Try
                Dim bll As New MovimentoContabilBLL
                bll.InsertMovimentoContabil(movimentoContabilModel)
                Return New ResultModel(Nothing)
            Catch ex As Exception
                Return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message)
            End Try
        End Function

        ' PUT api/<controller>
        Public Function PutValue(<FromBody()> ByVal movimentoContabilModel As MovimentoContabilModel) As Object
            Try
                Dim bll As New MovimentoContabilBLL
                bll.UpdateMovimentoContabil(movimentoContabilModel)
                Return New ResultModel(Nothing)
            Catch ex As Exception
                Return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message)
            End Try
        End Function

        ' DELETE api/<controller>/5
        Public Function DeleteValue(ByVal id As Integer) As Object
            Try
                Dim bll As New MovimentoContabilBLL
                bll.DeleteMovimentoContabil(id)
                Return New ResultModel(Nothing)
            Catch ex As Exception
                Return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message)
            End Try
        End Function
    End Class
End Namespace
