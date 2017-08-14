using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Web;

using Microsoft.AspNet.Identity.EntityFramework;


namespace AspnetIdentityDemo.Models
{
    /*
        ASP.NET Identity provides a strongly typed base class for accessing and managing roles called RoleManager<T>, where
        T is the implementation of the IRole interface supported by the storage mechanism used to represent roles. The Entity
        Framework uses a class called IdentityRole to implement the IRole interface 
     */
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