//using JsonWebToken.Model;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Http;
//using System.Web.Http.Results;
//using System.Web.Mvc;

//using JsonWebToken.Model.Response;
//using System.Web.Http;
//using System.Web.Http.Results;


using JsonWebToken.Model;
using WEBHTTP = System.Web.Http;
using System.Web.Mvc;
using JsonWebToken.Model.Response;
using System;
using JsonWebToken.Enums;
using JsonWebToken.Infra;
using System.Web.Configuration;

namespace JsonWebToken.Controllers
{

  [Route("[controller]")]
  public class AuthController : WEBHTTP.ApiController
  {

    [AllowAnonymous]
    //[HttpPost("Token")]
    //[HttpPost, Route("api/auth/token")]
    // POST api/auth
    public JsonResult PostLogin([WEBHTTP.FromBody] LoginRequest loginRequest) //, [FromServices]TokenConfigurations tokenConfigurations
    {
      AuthResult authResult = new AuthResult();
      try
      {
        AuthenticateAdModel authenticateAdModel = null;

        authResult.ExpiresIn = 123456;
        authResult.TokenType = "bearer";
        authResult.AcessToken = new JWTHandler().CreateToken(loginRequest, out authenticateAdModel);

        if (authenticateAdModel == null)
          authResult.CreateError("500", string.Format("conexão não estabelecida com o serviço: {0}", WebConfigurationManager.AppSettings["urlAuthenticationAPI"]));
        else if (authenticateAdModel.Code != 104)
          authResult.CreateError(authenticateAdModel.Code.ToString(), authenticateAdModel.Message);
      }
      catch (Exception ex)
      {
        authResult.CreateError("500", ex.Message);
      }

      return authResult.GetJsonResult();
    }

    //[AllowAnonymous]
    ////[HttpGet("Token")]
    //[HttpGet, Route("token")]
    //public JsonResult ValidaToken(string token)
    //{
    //  AuthResult result = JWTHandler.ValidateToken(token);

    //  return result.GetJsonResult();
    //}
  }
}
