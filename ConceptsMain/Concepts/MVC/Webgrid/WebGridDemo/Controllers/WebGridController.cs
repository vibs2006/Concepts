using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;


namespace WebGridDemo.Controllers
{
    public class WebGridController : Controller
    {
        Customers _dbContext = new Customers();
        public WebGridController()
        {

        }
        public ActionResult List()
        {
            
            return View();
        }

        public ActionResult GetGridData()
        {

            return View();
        }

    }
}