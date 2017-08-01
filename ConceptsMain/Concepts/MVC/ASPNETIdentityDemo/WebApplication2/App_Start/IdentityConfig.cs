using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using AspnetIdentityDemo.Infrastructure;

namespace AspnetIdentityDemo
{
    public class IdentityConfig
    {
        public void Configuration(IAppBuilder app)
        {
            /*
             The IAppBuilder interface is supplemented by a number of extension methods defined in classes in the
            Owin namespace. The CreatePerOwinContext method creates a new instance of the AppUserManager and
            AppIdentityDbContext classes for each request. This ensures that each request has clean access to the ASP.NET
            Identity data and that I don’t have to worry about synchronization or poorly cached database data.
            The UseCookieAuthentication method tells ASP.NET Identity how to use a cookie to identity authenticated
            users, where the options are specified through the CookieAuthenticationOptions class. The important part here is
            the LoginPath property, which specifies a URL that clients should be redirected to when they request content without
            authentication.
             */
            app.CreatePerOwinContext<AppIdentityDbContext>(AppIdentityDbContext.Create);
            app.CreatePerOwinContext<AppUserManager>(AppUserManager.Create);

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login")
            });

        }

    }
}