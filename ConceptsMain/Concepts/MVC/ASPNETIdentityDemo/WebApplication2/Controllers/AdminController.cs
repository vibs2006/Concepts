using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using AspnetIdentityDemo.Infrastructure;

namespace AspnetIdentityDemo.Controllers
{
    public class AdminController : Controller
    {

        /*
        
        The Index action method enumerates the users managed by the Identity system; of course, there aren’t any
        users at the moment, but there will be soon. The important part of this listing is the way that I obtain an instance of the
        AppUserManager class, through which I manage user information. I will be using the AppUserManager class repeatedly
        as I implement the different administration functions, and I defined the UserManager property in the Admin controller
        to simplify my code.
        The Microsoft.Owin.Host.SystemWeb assembly adds extension methods for the HttpContext class, one of which
        is GetOwinContext. This provides a per-request context object into the OWIN API through an IOwinContext object.
        The IOwinContext isn’t that interesting in an MVC framework application, but there is another extension method
        called GetUserManager<T> that is used to get instances of the user manager class. 
        
        I called the GetUserManager with a generic type parameter to specify the AppUserManager class that I created
        earlier in the chapter, like this:
        ...
        return HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
        ...
        Once I have an instance of the AppUserManager class, I can start to query the data store. The AppUserManager.Users
        property returns an enumeration of user objects—instances of the AppUser class in my application—which can be
        queried and manipulated using LINQ.
        
        */

        public ActionResult Index()
        {
            return View(UserManager.Users);
        }

        private AppUserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
            }
        }
    }
}