Imports System.Web.Http
Imports Administracao.ConciliacaoAPI.Code.Relatorio
Imports Administracao.ConciliacaoAPI.Model
Imports Microsoft.Owin.Security.OAuth

Namespace Controllers
    Public Class RelatorioController
        Inherits ApiController

        ' GET api/<controller>
        <Route("api/Relatorio")>
        Public Function GetValues() As ResultModel
            Try
                Dim bll As New RelatorioBLL()
                Return New ResultModel(bll.selectRelatorio())
            Catch ex As Exception
                Return New ResultModel(Nothing, New ErroModel(ex.Message))
            End Try
        End Function
        ' GET api/<controller>
        <Route("api/Relatorio/{tipo}/{data}")>
        Public Function GetValues(tipo As Integer, data As DateTime) As ResultModel
            Try
                Dim bll As New RelatorioBLL()
                Return New ResultModel(bll.selectRelatorio(tipo, data))
            Catch ex As Exception
                Return New ResultModel(Nothing, New ErroModel(ex.Message))
            End Try
        End Function
        ' GET api/<controller>/5
        <Route("api/Relatorio/{id:int}")>
        Public Function GetValue(id As Integer) As ResultModel
            Try
                Dim bll As New RelatorioBLL()
                Return New ResultModel(bll.selectRelatorioPorId(id))
            Catch ex As Exception
                Return New ResultModel(Nothing, New ErroModel(ex.Message))
            End Try
        End Function

        ' POST api/<controller>
        <Route("api/Relatorio")>
        Public Function PostValue(<FromBody> Relatorio As RelatorioModel) As ResultModel
            Try
                Dim bll As New RelatorioBLL()

                bll.insertRelatorio(Relatorio)
                Return New ResultModel(Nothing)
            Catch ex As Exception
                Return New ResultModel(Nothing, New ErroModel(ex.Message))
            End Try
        End Function

        ' PUT api/<controller>/5
        <Route("api/Relatorio")>
        Public Function PutValue(<FromBody> Relatorio As RelatorioModel) As ResultModel
            Try
                Dim bll As New RelatorioBLL()

                bll.updateRelatorio(Relatorio)

                Return New ResultModel(Nothing)
            Catch ex As Exception
                Return New ResultModel(Nothing, New ErroModel(ex.Message))
            End Try
        End Function

        ' DELETE api/<controller>/5
        <Route("api/Relatorio/{id}")>
        Public Function DeleteValue(id As Integer) As ResultModel
            Try
                Dim bll As New RelatorioBLL()
                bll.deleteRelatorio(id)
                Return New ResultModel(Nothing)
            Catch ex As Exception
                Return New ResultModel(Nothing, New ErroModel(ex.Message))
            End Try
        End Function
    End Class
End Namespace
