Imports System
Imports System.Linq
Imports Microsoft.Owin
Imports Microsoft.Owin.Security.OAuth
Imports Owin
Imports Microsoft.Owin.Security.DataHandler.Encoder
Imports Microsoft.Owin.Security.Jwt
Imports System.Web.Configuration


Partial Public Class Startup
  Private _expire As Int32 = Convert.ToInt32(String.Concat("0", WebConfigurationManager.AppSettings("expire")))
  Private _issuer As String = WebConfigurationManager.AppSettings("issuer")

  Public Sub ConfigureAuth(ByVal app As IAppBuilder)
    Dim authServerOptions As OAuthAuthorizationServerOptions = New OAuthAuthorizationServerOptions() With {
        .AllowInsecureHttp = True,
        .TokenEndpointPath = New PathString("/oauth2/token"),
        .AccessTokenExpireTimeSpan = TimeSpan.FromDays(_expire),
        .Provider = New MartinsAuthorizationServerProvider(),
        .AccessTokenFormat = New CustomJwtFormat(_issuer)
    }
    app.UseOAuthAuthorizationServer(authServerOptions)
    Dim audience = WebApplicationAccess.WebApplicationAccessList.[Select](Function(x) x.Value.ClientId).AsEnumerable()
    Dim secretsSymmetricKey = (From x In WebApplicationAccess.WebApplicationAccessList Select New SymmetricKeyIssuerSecurityTokenProvider(_issuer, TextEncodings.Base64Url.Decode(x.Value.SecretKey))).ToArray()
    app.UseJwtBearerAuthentication(New JwtBearerAuthenticationOptions With {
        .AuthenticationMode = Microsoft.Owin.Security.AuthenticationMode.Active,
        .AllowedAudiences = audience,
        .IssuerSecurityTokenProviders = secretsSymmetricKey
    })
  End Sub
End Class
