using JsonWebToken.Code;
using JsonWebToken.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Configuration;
using System.Web.Http;

namespace JsonWebToken.Controllers
{

  [Authorize]
  public class PermissaoController : ApiController
  {

    [HttpPost]
    public IHttpActionResult PostAuthenticateAD(string user, string password)
    {
      try
      {
        var client = new RestClient(WebConfigurationManager.AppSettings["urlAuthenticationAPI"]);

        var request = new RestRequest(string.Format("/Data/authenticateAD?user={0}&password={1}", user, password), Method.POST)
        {
          RequestFormat = DataFormat.Json
        };

        var response = client.Execute(request);

        if (response.StatusCode == HttpStatusCode.OK)
        {
          AuthenticateAdModel resp = JsonConvert.DeserializeObject<AuthenticateAdModel>(response.Content);

          return Ok(resp);
        }
        else
        {
          return Unauthorized();
        }
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }
  }
}
