using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Google;
using Microsoft.Owin.Security.OAuth;
using Owin;
using JsonWebToken.Providers;
using JsonWebToken.Models;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataHandler.Encoder;
using Microsoft.Owin.Security.Jwt;
using System.Web.Configuration;

namespace JsonWebToken
{
  public partial class Startup
  {
    private readonly int _expire = Convert.ToInt32(string.Concat("0", WebConfigurationManager.AppSettings["expire"]));
    private readonly string _issuer = WebConfigurationManager.AppSettings["issuer"];

    // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
    public void ConfigureAuth(IAppBuilder app)
    {
      OAuthAuthorizationServerOptions authServerOptions = new OAuthAuthorizationServerOptions()
      {
        //Em produção se atentar que devemos usar HTTPS
        AllowInsecureHttp = true,
        TokenEndpointPath = new PathString("/oauth2/token"),
        //AccessTokenExpireTimeSpan = TimeSpan.FromTicks(DateTime.Now.AddDays(_expire).Ticks), // TimeSpan.FromMinutes(15768000),
        //AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(99),
        AccessTokenExpireTimeSpan = TimeSpan.FromDays(_expire), //HACK AccessTokenExpireTimeSpan
        Provider = new CustomOAuthProviderJwt(),
        AccessTokenFormat = new CustomJwtFormat(_issuer)
      };

      app.UseOAuthAuthorizationServer(authServerOptions);

      var audience = WebApplicationAccess.WebApplicationAccessList.Select(x => x.Value.ClientId).AsEnumerable();
      var secretsSymmetricKey = (from x in WebApplicationAccess.WebApplicationAccessList
                                 select new SymmetricKeyIssuerSecurityTokenProvider(_issuer, TextEncodings.Base64Url.Decode(x.Value.SecretKey))).ToArray();


      // Api controllers with an [Authorize] attribute will be validated with JWT
      app.UseJwtBearerAuthentication(
          new JwtBearerAuthenticationOptions
          {
            AuthenticationMode = Microsoft.Owin.Security.AuthenticationMode.Active,
            AllowedAudiences = audience,
            IssuerSecurityTokenProviders = secretsSymmetricKey
          });
    }
  }
}
