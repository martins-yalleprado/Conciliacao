Imports System.Web.Http
Imports Martins.Conciliacao.Code.GestaoCarga
Imports Martins.Conciliacao.Filters
Imports Martins.Conciliacao.Model


Namespace Controllers
  '<Authorize>
  Public Class GestaoCargaController
    Inherits ApiController
    Private Enum Tipo
      AGN
      CTB
      TIT
    End Enum

        ' GET api/<controller
        ' dataref : data de referencia para criação do Lote
        ' tipo : é uma lista contendo os tipos(CTB, AGN, TIT) separa do por virgulas
        '<HeaderFilter, Authorize(Roles:="GESTAO.CARGA.PESQUISAR")>
        Public Function [Get](dataref As DateTime, tipo As String) As IEnumerable(Of GestaoCargaModel)
      Dim bll As New GestaoCargaBLL()
      Dim list As New List(Of GestaoCargaModel)
      Dim listTipos = tipo.ToUpper.Split(",")
      For Each obj As String In [Enum].GetNames(GetType(Tipo))
        If listTipos.Contains(obj) Then
          list.AddRange(bll.selectGestaoCarga(dataref, obj))
        End If
      Next
      Return list

    End Function

        ' GET api/<controller>/5   
        '<HeaderFilter, Authorize(Roles:="GESTAO.CARGA.PESQUISAR")>
        Public Function [Get](id As Integer) As GestaoCargaModel
            Dim bll As New GestaoCargaBLL()
            Return bll.selectGestaoCargaPorId(id)
        End Function

        ' POST api/<controller>
        ' dataref : data de referencia para criação do Lote
        ' tipo : é uma lista contendo os tipos(CTB, AGN, TIT) separa do por virgulas
        ' codUnidade: é o CodUnidade
        '<HeaderFilter, Authorize(Roles:="GESTAO.CARGA.CRIAR")>
        Public Sub Post(dataref As DateTime, tipo As String, codUnidade As Integer)
      Dim bll As New GestaoCargaBLL()
      Dim listTipos = tipo.ToUpper.Split(",")
      For Each obj As String In [Enum].GetNames(GetType(Tipo))
        If listTipos.Contains(obj) Then
          bll.insertGestaoCarga(dataref, obj, codUnidade)
        End If
      Next
    End Sub

        ' PUT api/<controller>/5    
        '<HeaderFilter, Authorize(Roles:="GESTAO.CARGA.EDITAR")>
        Public Sub Put(<FromBody> GestaoCargaModel As GestaoCargaModel)
      Dim bll As New GestaoCargaBLL()
      bll.updateGestaoCarga(GestaoCargaModel)
    End Sub

        ' DELETE api/<controller>/5    
        '<HeaderFilter, Authorize(Roles:="GESTAO.CARGA.REMOVER")>
        Public Sub Delete(id As Integer)
      Dim bll As New GestaoCargaBLL()
      bll.deleteGestaoCarga(id)
    End Sub
  End Class
End Namespace
