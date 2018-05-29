Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Http.Filters
Imports System.Web.Http.Controllers
Imports System.Net
Imports System.Net.Http
Imports JsonWebToken.Model
Imports System.IdentityModel.Tokens
Imports Newtonsoft.Json
Imports JsonWebToken.Util
Imports Martins.Conciliacao.Util

Namespace Filters
  Public Class HeaderFilter
    Inherits ActionFilterAttribute

    Public Overrides Sub OnActionExecuting(ByVal actionContext As HttpActionContext)
      Dim request = actionContext.Request
      Dim headers = request.Headers

      If headers.Authorization Is Nothing OrElse String.IsNullOrEmpty(headers.Authorization.Parameter) Then
        Dim transactionInformation As TransactionalInformation = New TransactionalInformation()
        transactionInformation.ReturnMessage.Add("Invalid token")
        transactionInformation.ReturnStatus = False
        actionContext.Response = request.CreateResponse(Of TransactionalInformation)(HttpStatusCode.BadRequest, transactionInformation)
        Return
      End If

      Dim accessToken = headers.Authorization.Parameter
      Dim jwtToken = New JwtSecurityToken(accessToken)
      Dim userCode = jwtToken.Claims.FirstOrDefault(Function(claim) claim.Type = "ldap_usercode").Value
      Dim rolesJson = jwtToken.Claims.FirstOrDefault(Function(claim) claim.Type = "roles_json").Value
      Utils.UserCodeLDAP = userCode
      Utils.RolesObject = If(String.IsNullOrEmpty(rolesJson), New List(Of Object)(), JsonConvert.DeserializeObject(Of List(Of Object))(rolesJson))
    End Sub
  End Class
End Namespace
