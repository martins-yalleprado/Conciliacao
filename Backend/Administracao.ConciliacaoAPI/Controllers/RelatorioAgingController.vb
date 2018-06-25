Imports System.Web.Http


Namespace Controllers
    Public Class RelatorioAgingController
        Inherits ApiController

        ' GET: api/<controller>
        <Route("api/RelatorioAging/Sintetico/{data}/{periodoId}")>
        Function GetRelatorioAgingSintetico(data As DateTime, periodoId As Integer) As ResultModel

            Try
                Dim bll As New RelatorioAgingBLL()
                Return New ResultModel(bll.selectRelatorioAgingSintetico(data.ToShortDateString(), periodoId))
            Catch ex As Exception
                Return New ResultModel(Nothing, New ErroModel(ex.Message))
            End Try

        End Function
    End Class
End Namespace