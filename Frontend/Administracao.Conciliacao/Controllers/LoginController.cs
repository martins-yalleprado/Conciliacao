using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Administracao.Conciliacao.Controllers
{
    [Authorize]
    public class LoginController : Controller
    {
        // GET: Login
       [AllowAnonymous]
        public ActionResult Index(string user)
        {
            if (user == null || user.Equals(""))
            {
                return View();
            }
            else
            {
                FormsAuthentication.SetAuthCookie(user, true);
            }
            return null;
        }
   
        [AllowAnonymous]
        public ActionResult Loggout()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index");
        }
    }

    
}