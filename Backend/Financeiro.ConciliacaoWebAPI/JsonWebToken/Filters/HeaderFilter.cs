using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;
using System.Web.Http.Controllers;
using System.Net;
using System.Net.Http;
using JsonWebToken.Model;
using System.IdentityModel.Tokens;
using Newtonsoft.Json;
using JsonWebToken.Util;

namespace JsonWebToken.Filters
{
  public class HeaderFilter : ActionFilterAttribute
  {
    public override void OnActionExecuting(HttpActionContext actionContext)
    {
      var request = actionContext.Request;
      var headers = request.Headers;

      if (headers.Authorization == null || string.IsNullOrEmpty(headers.Authorization.Parameter))
      {
        TransactionalInformation transactionInformation = new TransactionalInformation();
        transactionInformation.ReturnMessage.Add("Invalid token");
        transactionInformation.ReturnStatus = false;

        actionContext.Response = request.CreateResponse<TransactionalInformation>(HttpStatusCode.BadRequest, transactionInformation);
        return;
      }

      var accessToken = headers.Authorization.Parameter;

      var jwtToken = new JwtSecurityToken(accessToken);

      // claims
      var userCode = jwtToken.Claims.FirstOrDefault(claim => claim.Type == "ldap_usercode").Value;
      var rolesJson = jwtToken.Claims.FirstOrDefault(claim => claim.Type == "roles_json").Value;

      Utils.UserCodeLDAP = userCode;
      Utils.RolesObject = string.IsNullOrEmpty(rolesJson) ? new List<object>() : JsonConvert.DeserializeObject<List<object>>(rolesJson);
    }
  }
}
