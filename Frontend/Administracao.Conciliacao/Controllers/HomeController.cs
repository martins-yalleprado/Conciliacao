using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace Administracao.Conciliacao.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public JsonResult UrlBack()
        {
            return Json(WebConfigurationManager.AppSettings["UrlBackEnd"], JsonRequestBehavior.AllowGet);
        }

        [AllowAnonymous]
        public JsonResult UrlFront()
        {
            return Json(WebConfigurationManager.AppSettings["UrlBackFront"], JsonRequestBehavior.AllowGet);
        }
    }
}