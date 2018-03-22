using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimplePasswordGrant.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        // GET: Home
        [AllowAnonymous]
        public ActionResult Index()
        {
            return Redirect("/index.html");
        }

        [AllowAnonymous]
        public ActionResult General()
        {
            return Json(new
            {
                AccessType = "Anonymous Access"
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AuthorizeAccess()
        {
            return Json(new
            {
                AccessType = "Authenticated Access"
            }, JsonRequestBehavior.AllowGet);
        }
    }
}