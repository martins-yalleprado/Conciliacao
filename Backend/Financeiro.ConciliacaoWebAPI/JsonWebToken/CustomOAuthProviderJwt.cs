using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Linq;
using System;
using System.IdentityModel.Tokens;
using Newtonsoft.Json;
using HttpResults = System.Web.Http.Results;
using JsonWebToken.Model;
using JsonWebToken.Code;
using System.Web.Configuration;

namespace JsonWebToken
{
  internal class CustomOAuthProviderJwt : OAuthAuthorizationServerProvider
  {
    private readonly int _expire = Convert.ToInt32(string.Concat("0", WebConfigurationManager.AppSettings["expire"]));

    public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
    {
      context.Validated();
      return Task.FromResult<object>(null);
    }

    public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
    {
      //context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

      if (string.IsNullOrEmpty(context.UserName) || string.IsNullOrEmpty(context.Password))
      {
        context.SetError("invalid_grant", "Usuário ou senha invalidos");
        return Task.FromResult<object>(null);
      }

      #region permissões

      var permissaoController = new Controllers.PermissaoController();
      var resp = permissaoController.PostAuthenticateAD(context.UserName, context.Password);

      var content = resp is HttpResults.UnauthorizedResult ? null : ((HttpResults.OkNegotiatedContentResult<AuthenticateAdModel>)resp).Content;

      if (content.Code != 104)
      {
        context.SetError(content.Code.ToString(), content.Message);
        return Task.FromResult<object>(null);
      }

      var lstGroupAD = new List<String>();

      if (content.UserAD != null && content.UserAD.lstGroupAD != null)
      {
        foreach (var item in content.UserAD.lstGroupAD)
        {
          lstGroupAD.Add(item.Name);
        }
      }

      var roles = new List<object>();
      var permissao = new PermissaoBLL();
      var lstPermissoes = permissao.SelectPermissao(lstGroupAD);
      var permissoes = string.Join(",", lstPermissoes.Select(x => x.NOMACSFUN).ToList());

      foreach (var item in lstPermissoes)
      {
        roles.Add(new { code = item.CODACSFUN, name = item.NOMACSFUN });
      }

      #endregion

      var identity = new ClaimsIdentity("JWT");

      identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
      identity.AddClaim(new Claim("ldap_usercode", content.UserAD.Code));
      identity.AddClaim(new Claim("ldap_username", context.UserName));
      identity.AddClaim(new Claim("roles_json", roles.Count != 0 ? JsonConvert.SerializeObject(roles) : string.Empty));      
      identity.AddClaim(new Claim("expires", DateTime.Now.AddDays(_expire).ToString()));

      //TODO * remover mock
      //identity.AddClaim(new Claim(ClaimTypes.Role, "Administração"));
      //identity.AddClaim(new Claim(ClaimTypes.Role, "Financeiro"));

      foreach (var item in lstPermissoes)
      {
        identity.AddClaim(new Claim(ClaimTypes.Role, item.NOMACSFUN));
      }

      //TODO * remover mock 2
      //var props = new AuthenticationProperties(new Dictionary<string, string>
      //{
      //  {
      //    "audience", context.ClientId ?? "e84a2d13704647d18277966ec839d39e:CgP7NyLXtaGmyOgjj3sUMwmAlrSKqa5JyZ4P1OlfQeM"
      //  }
      //  ,
      //  {
      //    "roles", context.ClientId ?? "{ [ Administração, Financeiro ] }"
      //  }
      //});

      var props = new AuthenticationProperties(new Dictionary<string, string>
      {
        {
          "audience", context.ClientId ?? "e84a2d13704647d18277966ec839d39e:CgP7NyLXtaGmyOgjj3sUMwmAlrSKqa5JyZ4P1OlfQeM"
        }
        ,
        {
          "roles", context.ClientId ?? permissoes
        }
      });

      var ticket = new AuthenticationTicket(identity, props);
      context.Validated(ticket);

      return Task.FromResult<object>(null);
    }

    public override Task TokenEndpoint(OAuthTokenEndpointContext context)
    {
      foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
      {
        context.AdditionalResponseParameters.Add(property.Key, property.Value);
      }

      return Task.FromResult<object>(null);
    }
  }
}
