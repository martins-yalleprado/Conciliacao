Imports System.Net
Imports System.Net.Http
Imports System.Web.Http
Imports Administracao.ConciliacaoAPI.Code.Unidade
Imports Administracao.ConciliacaoAPI.Model

Namespace Controllers
    Public Class UnidadeController
        Inherits ApiController
        ' GET api/<controller>
        Public Function GetValues() As Object
            Try
                Dim bll As New UnidadeBLL()
                Return New ResultModel(bll.SelectUnidade())
            Catch ex As Exception
                Return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message)
            End Try
        End Function

        ' GET api/<controller>/5
        Public Function GetValue(id As Integer) As Object
            Try
                Dim bll As New UnidadeBLL()
                Return New ResultModel(bll.SelectUnidadePorId(id))
            Catch ex As Exception
                Return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message)
            End Try
        End Function

        ' POST api/<controller>
        Public Function PostValue(<FromBody> Unidade As UnidadeModel) As Object
            Try
                Dim bll As New UnidadeBLL()

                bll.InsertUnidade(Unidade)
                Return New ResultModel(Nothing)
            Catch ex As Exception
                Return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message)
            End Try
        End Function


        ' PUT api/<controller>/5
        Public Function PutValue(<FromBody> Unidade As UnidadeModel, acao As String) As Object
            Try
                Dim bll As New UnidadeBLL()
                If acao.ToLower().Equals("ativar") Then
                    bll.AtivarUnidade(Unidade)
                ElseIf acao.ToLower().Equals("inativar") Then
                    bll.InativarUnidade(Unidade)
                End If
                Return New ResultModel(Nothing)
            Catch ex As Exception
                Return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message)
            End Try
        End Function

        ' DELETE api/<controller>/5
        Public Function DeleteValue(id As Integer) As Object
            Try
                'não realiza esta operacao
                '  UnidadeBLL bll = new UnidadeBLL();

                Return New ResultModel(Nothing)
            Catch ex As Exception
                Return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message)
            End Try
        End Function
    End Class
End Namespace
