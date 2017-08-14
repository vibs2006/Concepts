using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;

namespace AspnetIdentityDemo.Infrastructure
{
    public static class IdentityHelpers
    {
        /*
        Custom HTML helper methods are defined as extensions on the HtmlHelper class. My helper, which is called
        GetUsername, takes a string argument containing a user ID, obtains an instance of the AppUserManager through the
        GetOwinContext.GetUserManager method (where GetOwinContext is an extension method on the HttpContext
        class), and uses the FindByIdAsync method to locate the AppUser instance associated with the ID and to return the
        value of the UserName property.
        */
        public static MvcHtmlString GetUserName(this HtmlHelper html, string id)
        {
            AppUserManager mgr = HttpContext.Current.GetOwinContext().GetUserManager<AppUserManager>();

            return new MvcHtmlString(mgr.FindByIdAsync(id).Result.UserName);

        }

    }
}