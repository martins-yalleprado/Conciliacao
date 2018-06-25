Imports System.Web.Http
Imports Administracao.ConciliacaoAPI.Code.TipoRelatorio
Imports Administracao.ConciliacaoAPI.Model
Imports Microsoft.Owin.Security.OAuth

Namespace Controllers
    Public Class TipoRelatorioController
        Inherits ApiController

        ' GET api/<controller>
        <Route("api/TipoRelatorio")>
        Public Function GetValues() As ResultModel
            Try
                Dim bll As New TipoRelatorioBLL()
                Return New ResultModel(bll.selectTipoRelatorio())
            Catch ex As Exception
                Return New ResultModel(Nothing, New ErroModel(ex.Message))
            End Try
        End Function

        ' GET api/<controller>/5
        <Route("api/TipoRelatorio/{id:int}")>
        Public Function GetValue(id As Integer) As ResultModel
            Try
                Dim bll As New TipoRelatorioBLL()
                Return New ResultModel(bll.selectTipoRelatorioPorId(id))
            Catch ex As Exception
                Return New ResultModel(Nothing, New ErroModel(ex.Message))
            End Try
        End Function

        ' POST api/<controller>
        <Route("api/TipoRelatorio")>
        Public Function PostValue(<FromBody> TipoRelatorio As TipoRelatorioModel) As ResultModel
            Try
                Dim bll As New TipoRelatorioBLL()

                bll.insertTipoRelatorio(TipoRelatorio)
                Return New ResultModel(TipoRelatorio)
            Catch ex As Exception
                Return New ResultModel(Nothing, New ErroModel(ex.Message))
            End Try
        End Function

        ' PUT api/<controller>/5
        <Route("api/TipoRelatorio")>
        Public Function PutValue(<FromBody> TipoRelatorio As TipoRelatorioModel) As ResultModel
            Try
                Dim bll As New TipoRelatorioBLL()

                bll.updateTipoRelatorio(TipoRelatorio)

                Return New ResultModel(Nothing)
            Catch ex As Exception
                Return New ResultModel(Nothing, New ErroModel(ex.Message))
            End Try
        End Function

        ' DELETE api/<controller>/5
        <Route("api/TipoRelatorio/{id}")>
        Public Function DeleteValue(id As Integer) As ResultModel
            Try
                Dim bll As New TipoRelatorioBLL()
                bll.deleteTipoRelatorio(id)
                Return New ResultModel(Nothing)
            Catch ex As Exception
                Return New ResultModel(Nothing, New ErroModel(ex.Message))
            End Try
        End Function
    End Class
End Namespace
