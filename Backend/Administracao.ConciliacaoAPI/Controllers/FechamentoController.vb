Imports System.Net
Imports System.Net.Http
Imports System.Web.Http
Imports Administracao.ConciliacaoAPI.Code.Fechamento
Imports Administracao.ConciliacaoAPI.Model

Namespace Controllers
    Public Class FechamentoController
        Inherits ApiController
        ' GET api/<controller>
        Public Function GetValues() As Object
            Try
                Dim bll As New FechamentoBLL()
                Return New ResultModel(bll.SelectFechamento())
            Catch ex As Exception
                Return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message)
            End Try
        End Function

        ' GET api/<controller>/5
        Public Function GetValue(tipo As String, CodFechamento As Integer, CodUnidade As Integer, CodConta As Integer) As Object
            Try
                Dim bll As New FechamentoBLL()
                Return New ResultModel(bll.SelectFechamentoPorTipoID(tipo, CodFechamento, CodUnidade, CodConta))
            Catch ex As Exception
                Return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message)
            End Try
        End Function

        ' POST api/<controller>
        Public Function PostValue(<FromBody> Fechamento As FechamentoModel) As Object
            Try
                Dim bll As New FechamentoBLL()

                bll.InsertFechamento(Fechamento)
                Return New ResultModel(Nothing)
            Catch ex As Exception
                Return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message)
            End Try
        End Function


        ' PUT api/<controller>/5
        Public Function PutValue(<FromBody> Fechamento As FechamentoModel, acao As String) As Object
            Try
                Dim bll As New FechamentoBLL()
                If acao.ToLower().Equals("ativar") Then
                    bll.AtivarFechamento(Fechamento)
                ElseIf acao.ToLower().Equals("inativar") Then
                    bll.InativarFechamento(Fechamento)
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
                '  FechamentoBLL bll = new FechamentoBLL();

                Return New ResultModel(Nothing, New ErroModel("Função delete não implementada"))
            Catch ex As Exception
                Return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message)
            End Try
        End Function
    End Class
End Namespace
