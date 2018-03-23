using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChoETL;
using System.Text;

namespace HelloWorldMvcWebApiApplication.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetStringFromCSVFile()
        {
            StringBuilder bldr = new StringBuilder();
            foreach (dynamic e in new ChoCSVReader("Emp.csv").WithFirstLineHeader())
                bldr.AppendLine("Id: " + e.Id + " Name: " + e.Name);

            return Content(bldr.ToString());
        }
    }
}