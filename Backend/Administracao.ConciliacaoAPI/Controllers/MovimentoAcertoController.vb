Imports System.Net
Imports System.Net.Http
Imports System.Web.Http
Imports Administracao.ConciliacaoAPI.Code.MovimentoAcerto
Imports Administracao.ConciliacaoAPI.Filters
Imports Administracao.ConciliacaoAPI.Model

Public Class MovimentoAcertoController
    Inherits ApiController
    ' GET api/<controller>
    <HttpGet, Route("api/MovimentoAcerto")>
    Public Function GetValues() As Object
        Try
            Dim bll As New MovimentoAcertoBLL
            Return New ResultModel(bll.SelectMovimentoAcerto())
        Catch ex As Exception
            Return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message)
        End Try
    End Function
    ' GET api/<controller>
    <HttpGet, Route("api/MovimentoAcerto/{dataMov}")>
    Public Function GetValues(ByVal dataMov As DateTime) As Object
        Try
            Dim bll As New MovimentoAcertoBLL
            Return New ResultModel(bll.SelectMovimentoAcerto(dataMov))
        Catch ex As Exception
            Return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message)
        End Try
    End Function


    ' GET api/<controller>/5
    <HttpGet, Route("api/MovimentoAcerto/{sequencial}/{data}/{CodIdentidadeContabil}")>
    Public Function GetValue(ByVal sequencial As Integer, ByVal data As Date, ByVal CodIdentidadeContabil As Integer) As Object
        Try
            Dim bll As New MovimentoAcertoBLL
            Return New ResultModel(bll.SelectMovimentoAcertoPorId(sequencial, data, CodIdentidadeContabil))
        Catch ex As Exception
            Return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message)
        End Try
    End Function


    ' POST api/<controller>
    <HttpPost, Route("api/MovimentoAcerto")>
    Public Function PostValue(<FromBody()> ByVal MovimentoAcertoModel As MovimentoAcertoModel) As Object
        Try
            Dim bll As New MovimentoAcertoBLL
            bll.InsertMovimentoAcerto(MovimentoAcertoModel)
            Return New ResultModel(Nothing)
        Catch ex As Exception
            Return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message)
        End Try
    End Function

    ' PUT api/<controller>
    <HttpPut, Route("api/MovimentoAcerto")>
    Public Function PutValue(<FromBody()> ByVal MovimentoAcertoModel As MovimentoAcertoModel) As Object
        Try
            Dim bll As New MovimentoAcertoBLL
            bll.UpdateMovimentoAcerto(MovimentoAcertoModel)
            Return New ResultModel(Nothing)
        Catch ex As Exception
            Return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message)
        End Try
    End Function

    ' DELETE api/<controller>/5
    <HttpDelete, Route("api/MovimentoAcerto/{sequencial}/{data}/{CodIdentidadeContabil}")>
    Public Function DeleteValue(ByVal sequencial As Integer, ByVal data As String, ByVal CodIdentidadeContabil As Integer) As Object
        Try
            Dim dataF As DateTime = Convert.ToDateTime(data.Replace(";", ":"))

            Dim bll As New MovimentoAcertoBLL
            bll.DeleteMovimentoAcerto(sequencial, dataF, CodIdentidadeContabil)
            Return New ResultModel(Nothing)
        Catch ex As Exception
            Return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message)
        End Try
    End Function

End Class
