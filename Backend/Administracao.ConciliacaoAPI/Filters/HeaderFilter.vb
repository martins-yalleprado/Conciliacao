Imports System.Web.Http.Filters
Imports System.Web.Http.Controllers
Imports System.Net
Imports System.Net.Http
Imports System.IdentityModel.Tokens
Imports Newtonsoft.Json
Imports Administracao.ConciliacaoAPI.Util

Namespace Filters
    Public Class HeaderFilter
        Inherits ActionFilterAttribute

        Private _roles As String
        Public Property Roles() As String
            Get
                Return _roles
            End Get
            Set(ByVal value As String)
                _roles = value
            End Set
        End Property

        Public Overrides Sub OnActionExecuting(ByVal actionContext As HttpActionContext)

            Dim request = actionContext.Request
            Dim headers = request.Headers
            Dim transactionInformation As TransactionalInformation = New TransactionalInformation()

            If Not headers.Contains("x-session-token") OrElse headers.GetValues("x-session-token").FirstOrDefault() Is Nothing Then
                transactionInformation.ReturnMessage.Add("token inválido")
                transactionInformation.ReturnStatus = False
                actionContext.Response = request.CreateResponse(Of TransactionalInformation)(HttpStatusCode.BadRequest, transactionInformation)

                Return
            End If

            Dim accessToken = headers.GetValues("x-session-token").FirstOrDefault()

            Dim jwtToken = New JwtSecurityToken(accessToken)

            Dim tknRoles = jwtToken.Claims.Where(Function(claim) claim.Type = "role").Select(Function(claim) claim.Value).ToList

            Dim appRoles = New List(Of String)

            If (Not Roles.Equals("")) Then
                appRoles = Roles.Split(",").ToList
            End If

            Dim intersect = New List(Of String)

            If (Not tknRoles Is Nothing And tknRoles.Count > 0) Then
                intersect = tknRoles.Intersect(appRoles).ToList
            End If

            If (Not intersect Is Nothing AndAlso intersect.Count = 0) Then
                transactionInformation.ReturnMessage.Add("acesso negado")
                transactionInformation.ReturnStatus = False
                actionContext.Response = request.CreateResponse(Of TransactionalInformation)(HttpStatusCode.Unauthorized, transactionInformation)

                Return
            End If

            Dim ldapuser = jwtToken.Claims.FirstOrDefault(Function(claim) claim.Type = "ldap_usercode")

            If (ldapuser IsNot Nothing) Then
                Utils.UserCodeLDAP = ldapuser.Value
            End If


            If (headers.Contains("x-codigo-conta")) Then
                Dim vlr = headers.GetValues("x-codigo-conta").FirstOrDefault()

                If (Regex.IsMatch(vlr, "^[0-9]*$")) Then
                    Utils.CodigoConta = If(vlr, 0L)
                End If
            Else
                transactionInformation.ReturnMessage.Add("x-codigo-conta é obrigatório")
                transactionInformation.ReturnStatus = False
                actionContext.Response = request.CreateResponse(Of TransactionalInformation)(HttpStatusCode.InternalServerError, transactionInformation)
            End If

            If (headers.Contains("x-codigo-unidade")) Then
                Dim vlr = headers.GetValues("x-codigo-unidade").FirstOrDefault()

                If (Regex.IsMatch(vlr, "^[0-9]*$")) Then
                    Utils.CodigoUnidade = If(vlr, 0L)
                End If
            Else
                transactionInformation.ReturnMessage.Add("x-codigo-unidade é obrigatório")
                transactionInformation.ReturnStatus = False
                actionContext.Response = request.CreateResponse(Of TransactionalInformation)(HttpStatusCode.InternalServerError, transactionInformation)
            End If

            If (headers.Contains("x-descricao-conta")) Then
                Dim vlr = headers.GetValues("x-descricao-conta").FirstOrDefault()
                Utils.DescricaoConta = If(vlr, String.Empty)

            End If

            If (headers.Contains("x-descricao-unidade")) Then
                Dim vlr = headers.GetValues("x-descricao-unidade").FirstOrDefault()
                Utils.DescricaoUnidade = If(vlr, String.Empty)
            End If

        End Sub
    End Class
End Namespace
