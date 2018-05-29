Imports System.Web.Configuration
Imports System.Web.Http
Imports ApplicationService
Imports Microsoft.Owin
Imports Microsoft.Owin.Cors
Imports Microsoft.Owin.Security.OAuth
Imports Owin

Public Class Startup
  'Private ReadOnly _expire As Integer = Convert.ToInt32(String.Concat("0", WebConfigurationManager.AppSettings("expire")))
  'Private ReadOnly _issuer As String = WebConfigurationManager.AppSettings("issuer")

  Public Sub Configuration(ByVal app As IAppBuilder)
    app.UseCors(CorsOptions.AllowAll)
    ConfigureAuth(app)
  End Sub

  'Public Sub Configuration(app As IAppBuilder)
  '  Dim config As New HttpConfiguration()

  '  With config
  '    .MapHttpAttributeRoutes()
  '    .Routes.MapHttpRoute(
  '        name:="DefaultApi",
  '        routeTemplate:="api/{controller}/{id}",
  '        defaults:=New With {.id = RouteParameter.Optional}
  '    )
  '  End With

  '  Dim formatters = config.Formatters
  '  formatters.Remove(formatters.XmlFormatter)

  '  ConfigureOAuth(app)
  '  app.UseCors(Cors.CorsOptions.AllowAll)
  '  app.UseWebApi(config)
  'End Sub

  'Public Sub ConfigureOAuth(app As IAppBuilder)

  '  Dim OAuthServerOptions As New OAuthAuthorizationServerOptions()
  '  With OAuthServerOptions
  '    .AllowInsecureHttp = True
  '    .TokenEndpointPath = New PathString("/oauth2/token")
  '    .AccessTokenExpireTimeSpan = TimeSpan.FromDays(3)
  '    .Provider = New MartinsAuthorizationServerProvider()
  '    .AllowInsecureHttp = True
  '    '.AccessTokenExpireTimeSpan = TimeSpan.FromDays(_expire)
  '    .AccessTokenFormat = New CustomJwtFormat(_issuer)
  '  End With

  '  app.UseOAuthAuthorizationServer(OAuthServerOptions)
  '  Dim audience = WebApplicationAccess.WebApplicationAccessList.[Select](Function(x) x.Value.ClientId).AsEnumerable()
  '  'Dim secretsSymmetricKey = (From x In WebApplicationAccess.WebApplicationAccessList Select New SymmetricKeyIssuerSecurityTokenProvider(_issuer, TextEncodings.Base64Url.Decode(x.Value.SecretKey))).ToArray()

  '  app.UseOAuthBearerAuthentication(
  '    New OAuthBearerAuthenticationOptions With {
  '    .AuthenticationMode = Microsoft.Owin.Security.AuthenticationMode.Active
  '    })

  'End Sub
End Class
