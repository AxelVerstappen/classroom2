using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Classroom2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public class LanguageFilter
       : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                var taal = (string)filterContext.HttpContext.Session["taal"];
                SetLanguage(taal);
            }

            protected void SetLanguage(string language)
            {
                if (!string.IsNullOrEmpty(language))
                {
                    System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(language);
                    System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(language);
                }
            }

        }
        public ActionResult SwitchLanguage(string language)
        {
            Session.Add("taal", language);
            return RedirectToAction("Index");
        }
    }
}
