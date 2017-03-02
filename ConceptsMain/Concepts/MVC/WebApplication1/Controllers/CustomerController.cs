using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            return RedirectToAction("RegisterCustomer");
            //return View();
        }

        [HttpGet]
        public ActionResult RegisterCustomer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterCustomer(Customer objCust)
        {
            if (ModelState.IsValid)
            {
                CustomerDBContext _dbcontext = new CustomerDBContext();
                _dbcontext.Customers.Add(objCust);
                _dbcontext.SaveChanges();
                return View("CustomerSaveConfirmation",objCust);
            }
            else
            {
                return View("RegisterCustomer", objCust);
            }


        }


    }
}