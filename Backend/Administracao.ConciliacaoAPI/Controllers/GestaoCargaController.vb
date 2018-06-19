Imports System.Net
Imports System.Net.Http
Imports System.Web.Http
Imports Administracao.ConciliacaoAPI.Code.GestaoCarga
Imports Administracao.ConciliacaoAPI.Filters
Imports Administracao.ConciliacaoAPI.Model


Namespace Controllers
    '<Authorize>
    Public Class GestaoCargaController
        Inherits ApiController
        Private Enum Tipo
            AGI
            CTB
            TIT
        End Enum

        ' GET api/<controller
        ' dataref : data de referencia para criação do Lote
        ' tipo : é uma lista contendo os tipos(CTB, AGN, TIT) separa do por virgulas
        '<HeaderFilter, Authorize(Roles:="GESTAO.CARGA.PESQUISAR")>
        Public Function GetValues(dataref As DateTime, tipo As String) As Object
            If String.IsNullOrWhiteSpace(tipo) Then
                Return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Selecione pelo menos um tipo.")
            End If
            Try
                Dim bll As New GestaoCargaBLL()
                Dim list As New List(Of GestaoCargaModel)
                Dim listTipos = tipo.ToUpper.Split(",")

                For Each obj As String In [Enum].GetNames(GetType(Tipo))
                    If listTipos.Contains(obj) Then
                        list.AddRange(bll.selectGestaoCarga(dataref, obj))
                    End If
                Next

                Return New ResultModel(list)

            Catch ex As Exception

                Return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message)
            End Try
        End Function

        ' GET api/<controller>/5   
        '   <HeaderFilter, Authorize(Roles:="GESTAO.CARGA.PESQUISAR")>
        Public Function GetValue(id As Integer) As Object
            Try
                Dim bll As New GestaoCargaBLL()
                Return New ResultModel(bll.selectGestaoCargaPorId(id))
            Catch ex As Exception
                Return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message)
            End Try
        End Function

        ' POST api/<controller>
        ' dataref : data de referencia para criação do Lote
        ' tipo : é uma lista contendo os tipos(CTB, AGN, TIT) separa do por virgulas
        ' codUnidade: é o CodUnidade
        '<HeaderFilter, Authorize(Roles:="GESTAO.CARGA.CRIAR")>
        Public Function PostValue(dataref As DateTime, tipo As String, codUnidade As Integer, codConta As Integer) As Object
            If String.IsNullOrWhiteSpace(tipo) Then
                Return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Selecione pelo menos um tipo.")
            End If
            Try
                Dim bll As New GestaoCargaBLL()
                Dim listTipos = tipo.ToUpper.Split(",")
                For Each obj As String In [Enum].GetNames(GetType(Tipo))
                    If listTipos.Contains(obj) Then
                        bll.insertGestaoCarga(dataref, obj, codUnidade, codConta)
                    End If
                Next

                Return New ResultModel(Nothing)

            Catch ex As Exception

                Return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message)
            End Try
        End Function

        ' PUT api/<controller>/5    
        ' <HeaderFilter, Authorize(Roles:="GESTAO.CARGA.EDITAR")>
        Public Function PutValue(<FromBody> GestaoCargaModel As GestaoCargaModel) As Object
            Try
                Dim bll As New GestaoCargaBLL()
                bll.updateGestaoCarga(GestaoCargaModel)
                Return New ResultModel(Nothing)
            Catch ex As Exception
                Return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message)
            End Try
        End Function

        ' DELETE api/<controller>/5    
        ' <HeaderFilter, Authorize(Roles:="GESTAO.CARGA.REMOVER")>
        Public Function DeleteValue(id As Integer) As Object
            Try
                Dim bll As New GestaoCargaBLL()
                bll.deleteGestaoCarga(id)
                Return New ResultModel(Nothing)
            Catch ex As Exception
                Return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message)
            End Try
        End Function
    End Class
End Namespace
