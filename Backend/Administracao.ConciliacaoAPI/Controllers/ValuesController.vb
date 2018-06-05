Imports System.Collections.Generic
Imports System.Linq
Imports System.Net
Imports System.Net.Http
Imports System.Web.Http
Imports Martins.Conciliacao.Filters
Imports Martins.Conciliacao.Util

Namespace Controllers
  <Authorize>
  Public Class ValuesController
    Inherits ApiController
    ' GET api/values
    <HttpGet, HeaderFilter, Authorize(Roles:="Financeiro, Administraçãox")>
    Public Function [Get]() As IEnumerable(Of String)
      Return New String() {"value1", "value2", "ldap_usercode " + Utils.UserCodeLDAP.ToString(), "count roles_json " + Utils.RolesObject.Count().ToString()}
    End Function

    ' GET api/values/5
    Public Function [Get](id As Integer) As String
      Return "value"
    End Function

    ' POST api/values
    Public Sub Post(<FromBody> value As String)
    End Sub

    ' PUT api/values/5
    Public Sub Put(id As Integer, <FromBody> value As String)
    End Sub

    ' DELETE api/values/5
    Public Sub Delete(id As Integer)
    End Sub
  End Class
End Namespace
