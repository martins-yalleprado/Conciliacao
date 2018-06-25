Imports System.Net
Imports System.Net.Http
Imports System.Web.Http
Imports Administracao.ConciliacaoAPI.Code.MovimentoTitulo

Namespace Controllers
    Public Class MovimentoTituloController
        Inherits ApiController

        ' GET: MovimentoTitulo
        <Route("api/MovimentoTitulo/{numSeqCarga}")>
        Public Function GetValues(numSeqCarga As Integer) As Object
            Try
                Dim bll As New MovimentoTituloBLL()
                Return New ResultModel(bll.selectDatasTitulosPorCarga(numSeqCarga))
            Catch ex As Exception
                Return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message)
            End Try
        End Function
    End Class
End Namespace