Imports System.Security.Claims
Imports System.Threading.Tasks
Imports System.Web.Configuration
Imports Microsoft.Owin.Security
Imports Microsoft.Owin.Security.OAuth
Imports Martins.Conciliacao.Code.Permissao
Imports Martins.Conciliacao.Model
Imports Newtonsoft.Json

Public Class MartinsAuthorizationServerProvider
  Inherits OAuthAuthorizationServerProvider

  Private ReadOnly _expire As Integer = Convert.ToInt32(String.Concat("0", WebConfigurationManager.AppSettings("expire")))


  Public Overrides Async Function ValidateClientAuthentication(context As OAuthValidateClientAuthenticationContext) As Task
    context.Validated()
    Await Task.FromResult(Of Object)(Nothing)
  End Function

  Public Overrides Async Function GrantResourceOwnerCredentials(context As OAuthGrantResourceOwnerCredentialsContext) As Task
    'context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", New String() {"*"})

    If String.IsNullOrEmpty(context.UserName) OrElse String.IsNullOrEmpty(context.Password) Then
      context.SetError("invalid_grant", "Usuário ou senha invalidos")
      Exit Function
    End If

    Dim permissaoController = New Controllers.PermissaoController()
    Dim resp As AuthenticateAdModel = permissaoController.PostAuthenticateAD(context.UserName, context.Password)

    If resp.Code <> 104 Then
      context.SetError(resp.Code.ToString(), resp.Message)
      Exit Function
    End If

    Dim lstGroupAD = New List(Of [String])()

    If resp.UserAD IsNot Nothing AndAlso resp.UserAD.lstGroupAD IsNot Nothing Then
      For Each item As Object In resp.UserAD.lstGroupAD
        lstGroupAD.Add(item.Name)
      Next
    End If

    Dim roles = New List(Of Object)
    Dim permissao = New PermissaoBLL()
    Dim lstPermissoes = permissao.SelectPermissao(lstGroupAD)
    Dim permissoes = String.Join(",", lstPermissoes.[Select](Function(x) x.NOMACSFUN).ToList())

    For Each item In lstPermissoes
      roles.Add(New With {
                .code = item.CODACSFUN,
                .name = item.NOMACSFUN
      })
    Next

    Dim identity = New ClaimsIdentity("JWT")
    identity.AddClaim(New Claim(ClaimTypes.Name, context.UserName))
    identity.AddClaim(New Claim("ldap_usercode", resp.UserAD.Code))
    identity.AddClaim(New Claim("ldap_username", context.UserName))
    identity.AddClaim(New Claim("roles_json", IIf(roles.Count > 0, JsonConvert.SerializeObject(roles), String.Empty)))
    identity.AddClaim(New Claim("expires", DateTime.Now.AddDays(_expire).ToString()))

    'TODO * remover mock
    'identity.AddClaim(New Claim(ClaimTypes.Role, "Administração"))
    'identity.AddClaim(New Claim(ClaimTypes.Role, "Financeiro"))

    For Each item As Object In lstPermissoes
      identity.AddClaim(New Claim(ClaimTypes.Role, item.NOMACSFUN))
    Next

    'TODO * remover mock 2
    'Dim props = New AuthenticationProperties(New Dictionary(Of String, String)() From {
    '    {"audience", If(context.ClientId, "e84a2d13704647d18277966ec839d39e:CgP7NyLXtaGmyOgjj3sUMwmAlrSKqa5JyZ4P1OlfQeM")},
    '    {"roles", If(context.ClientId, "{ [ Administração, Financeiro ] }")}
    '})

    Dim props = New AuthenticationProperties(New Dictionary(Of String, String) From {
                {"audience", If(context.ClientId, "e84a2d13704647d18277966ec839d39e:CgP7NyLXtaGmyOgjj3sUMwmAlrSKqa5JyZ4P1OlfQeM")},
                {"roles", If(context.ClientId, permissoes)}
            })

    Dim ticket = New AuthenticationTicket(identity, props)

    context.Validated(ticket)

    Await Task.FromResult(Of Object)(Nothing)
  End Function

  Public Overrides Async Function TokenEndpoint(context As OAuthTokenEndpointContext) As Task
    For Each [dadosUsuario] As KeyValuePair(Of String, String) In context.Properties.Dictionary
      context.AdditionalResponseParameters.Add([dadosUsuario].Key, [dadosUsuario].Value)
    Next
    Await Task.FromResult(Of Object)(Nothing)
  End Function

End Class
