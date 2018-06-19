Imports System.Net
Imports System.Net.Http
Imports System.Web.Http
Imports Administracao.ConciliacaoAPI.Code.Saldo
Imports Administracao.ConciliacaoAPI.Filters
Imports Administracao.ConciliacaoAPI.Model
Imports Administracao.ConciliacaoAPI.Util

<HeaderFilter>
Public Class SaldoController
    Inherits ApiController

    <HttpGet>
    <Route("api/Saldo")>
    Public Function GetValues() As Object
        Try
            Dim bll As New SaldoBLL
            Return New ResultModel(bll.SelectSaldo())
        Catch ex As Exception
            Return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message)
        End Try
    End Function

    <HttpGet>
    <Route("api/Saldo/{DataMov}")>
    Public Function GetValue(ByVal DataMov As DateTime) As Object
        Try
            Dim bll As New SaldoBLL
            Return New ResultModel(bll.SelectSaldoPorId(Utils.CodigoUnidade, Utils.CodigoConta, DataMov))

        Catch ex As Exception
            Return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message)
        End Try
    End Function

    <HttpPost>
    Public Function PostValue(<FromBody()> ByVal SaldoModel As SaldoModel) As Object
        Try
            Dim bll As New SaldoBLL
            bll.InsertSaldo(SaldoModel)
            Return New ResultModel(Nothing)
        Catch ex As Exception
            Return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message)
        End Try
    End Function

    <HttpPut>
    <Route("api/Saldo/{SaldoModel}")>
    Public Function PutValue(<FromBody()> ByVal SaldoModel As SaldoModel) As Object
        Try
            Dim bll As New SaldoBLL
            bll.UpdateSaldo(SaldoModel)
            Return New ResultModel(Nothing)
        Catch ex As Exception
            Return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message)
        End Try
    End Function

    <HttpDelete>
    <Route("api/Saldo/{DataMov}")>
    Public Function DeleteValue(ByVal DataMov As DateTime) As Object
        Try
            Dim bll As New SaldoBLL
            bll.DeleteSaldo(Utils.CodigoUnidade, Utils.CodigoConta, DataMov)
            Return New ResultModel(Nothing)
        Catch ex As Exception
            Return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message)
        End Try
    End Function
End Class
