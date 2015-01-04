using System;
using System.Web.Mvc;
using Insya.Localization;

namespace Classroom2.Controllers
{
    public class LocalesController : Controller
    {

        public ActionResult Index(string lang = "en_US")
        {
            Response.Cookies["CacheLang"].Value = lang;
<<<<<<< HEAD

            if (Request.UrlReferrer != null)
                Response.Redirect(Request.UrlReferrer.ToString());

			var message = Localization.Get("changedlng");

=======

            if (Request.UrlReferrer != null)
                Response.Redirect(Request.UrlReferrer.ToString());

			var message = Localization.Get("changedlng");

>>>>>>> origin/master
			return Content(message);
        }

    }
<<<<<<< HEAD
}
=======
}
>>>>>>> origin/master
