using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Web;

using Microsoft.AspNet.Identity.EntityFramework;


namespace AspnetIdentityDemo.Models
{
    public class AppRole: IdentityRole
    {
        public AppRole() : base() 
        {

        }

        public AppRole(string name): base(name)
        {
            //IEnumerable<string> test = new string[] {"s", "b" };
            //test.Count();
            
            
        }
    }
}