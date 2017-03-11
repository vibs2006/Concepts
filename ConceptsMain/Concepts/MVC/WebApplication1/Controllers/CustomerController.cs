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

                var AllCustomers = _dbcontext.Customers.ToList<Customer>();

                ViewBag.AllCustomers = AllCustomers;

                return View("CustomerSaveConfirmation",objCust);
            }
            else
            {
                return View("RegisterCustomer", objCust);
            }


        }

        
        [HandleError(ExceptionType = typeof(Exception), View = "Error"  )]
        public ActionResult testException()
        {
            int i = 0;

            int y = 5 / i;

            return Content("test");

        }


    }
}