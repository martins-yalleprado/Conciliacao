Imports System.Net
Imports System.Net.Http
Imports System.Web.Http
Imports Administracao.ConciliacaoAPI.Code.MovimentoAging

Namespace Controllers
    Public Class MovimentoAgingController
        Inherits ApiController

        ' GET: MovimentoAging
        <Route("api/MovimentoAging/{numSeqCarga}")>
        Public Function GetValues(numSeqCarga As Integer) As Object
            Try
                Dim bll As New MovimentoAgingBLL()
                Return New ResultModel(bll.selectDatasAgingPorCarga(numSeqCarga))
            Catch ex As Exception
                Return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message)
            End Try
        End Function
    End Class
End Namespace