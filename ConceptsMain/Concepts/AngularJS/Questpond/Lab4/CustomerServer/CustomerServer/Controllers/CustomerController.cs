using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CustomerServer.Models;
namespace CustomerServer.Controllers
{
    public class CustomerController : ApiController
    {

        private List<Customer> listCustomers = new List<Customer>();

        public CustomerController()
        {
            listCustomers.Add(new Customer { cid = "A001", cname="Gaurav", Amount = 101 });
            listCustomers.Add(new Customer { cid = "A002", cname = "Gaarima", Amount = 102 });
            listCustomers.Add(new Customer { cid = "A003", cname = "Vibhor", Amount = 103 });
            listCustomers.Add(new Customer { cid = "A004", cname = "Gaurav2", Amount = 104 });
            listCustomers.Add(new Customer { cid = "A005", cname = "Gaura5", Amount = 105 });

        }


        public IEnumerable<Customer> Get()
        {
            return listCustomers;
        }
        // GET: api/Customer
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET: api/Customer/5
        public string Get(int id)
        {
            return "value"; 
        }

        // POST: api/Customer
        public Customer Post(Customer obj)
        {
            listCustomers.Add(obj);
            obj.cname = obj.cname.ToUpper();
            obj.cid = obj.cid.ToUpper();
            return obj;
        }

        // PUT: api/Customer/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Customer/5
        public void Delete(int id)
        {
        }
    }
}
