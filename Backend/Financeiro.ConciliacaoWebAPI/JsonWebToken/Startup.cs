using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Cors;

[assembly: OwinStartup(typeof(JsonWebToken.Startup))]

namespace JsonWebToken
{
  public partial class Startup
  {
    public void Configuration(IAppBuilder app)
    {
      //HACK CORS OWIN
      app.UseCors(CorsOptions.AllowAll);
      ConfigureAuth(app);
    }
  }
}
