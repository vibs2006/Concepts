using MVCSortingPagingJquery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq.Dynamic;

namespace MVCSortingPagingJquery.Controllers
{
    public class WebgridController : Controller
    {
        //
        // GET: /Webgrid/

        public ActionResult List()
        {
            return View();
        }

        public ActionResult GetCustomerData(int page = 1, string sort = "CustomerName", string sortdir = "ASC")
        {
            CustomerDataModel cdm = new CustomerDataModel();
            cdm.PageSize = 4;
            using (MyDatabaseEntities dc = new MyDatabaseEntities())
            {
                cdm.TotalRecord = dc.CustomerInfoes.Count();
                cdm.NoOfPages = (cdm.TotalRecord / cdm.PageSize) + ((cdm.TotalRecord % cdm.PageSize) > 0 ? 1 : 0);
                //cdm.Customer = dc.CustomerInfoes.OrderBy(sort + " " + sortdir).Skip((page - 1) * cdm.PageSize).Take(cdm.PageSize).ToList();
                cdm.Customer = dc.CustomerInfoes.ToList();
            }
            return PartialView("_dataList", cdm);
        }

        [HttpPost]
        public ActionResult GetCustomerData2(GridParameters objParams)
        {
            var page = Convert.ToInt16(objParams.page);
            CustomerDataModel cdm = new CustomerDataModel();
            cdm.PageSize = 4;
            using (MyDatabaseEntities dc = new MyDatabaseEntities())
            {
                cdm.TotalRecord = dc.CustomerInfoes.Count();
                cdm.NoOfPages = (cdm.TotalRecord / cdm.PageSize) + ((cdm.TotalRecord % cdm.PageSize) > 0 ? 1 : 0);
                cdm.Customer = dc.CustomerInfoes.OrderBy("CustomerID").Skip((page - 1) * cdm.PageSize).Take(cdm.PageSize).ToList();
            }
            return PartialView("_dataList", cdm);
        }

        
    }

    public class GridParameters
    {
        public string page { get; set; }

    }
}
