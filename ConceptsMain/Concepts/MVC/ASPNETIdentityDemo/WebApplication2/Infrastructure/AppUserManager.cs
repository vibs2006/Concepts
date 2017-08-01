using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using AspnetIdentityDemo.Models;

namespace AspnetIdentityDemo.Infrastructure
{
    public class AppUserManager : UserManager<AppUser>
    {

        /*
        One of the most important Identity classes is the user manager, which manages instances of the user class. The
        user manager class must be derived from UserManager<T>, where T is the user class. The UserManager<T> class isn’t
        specific to the Entity Framework and provides more general features for creating and operating on user data.
        
        The static Create method will be called when Identity needs an instance of the AppUserManager, which will
        happen when I perform operations on user data—something that I will demonstrate once I have finished performing
        the setup.
        To create an instance of the AppUserManager class, I need an instance of UserStore<AppUser>. The UserStore<T>
        class is the Entity Framework implementation of the IUserStore<T> interface, which provides the storage-specific
        implementation of the methods defined by the UserManager class. To create the UserStore<AppUser>, I need an
        instance of the AppIdentityDbContext class, which I get through OWIN as follows:
        ...
        AppIdentityDbContext db = context.Get<AppIdentityDbContext>();
        ...
        The IOwinContext implementation passed as an argument to the Create method defines a generically typed Get
        method that returns instances of objects that have been registered in the OWIN start class, which I describe in the
        following section.

        Creating the Start Class
        The final piece I need to get ASP.NET Identity up and running is a start class. In Listing 13-4, I defined an application
        setting that specified a configuration class for OWIN, like this:
        ...
        <add key="owin:AppStartup" value="Users.IdentityConfig" />
        ...
        OWIN emerged independently of ASP.NET and has its own conventions. One of them is that there is a class
        that is instantiated to load and configure middleware and perform any other configuration work that is required.
        By default, this class is called Start, and it is defined in the global namespace. This class contains a method called
        Configuration, which is called by the OWIN infrastructure and passed an implementation of the Owin.IAppBuilder
        interface, which supports setting up the middleware that an application requires. The Start class is usually defined as
        a partial class, with its other class files dedicated to each kind of middleware that is being used.
        I freely ignore this convention, given that the only OWIN middleware that I use in MVC framework applications is
        Identity. I prefer to use the application setting in the Web.config file to define a single class in the top-level namespace
        of the application. 
        */
        public AppUserManager(IUserStore<AppUser> store) : base(store)
        {

        }

        public static AppUserManager Create(IdentityFactoryOptions<AppUserManager> options,IOwinContext context)
        {
            AppIdentityDbContext db = context.Get<AppIdentityDbContext>();
            AppUserManager manager = new AppUserManager(new UserStore<AppUser>(db));
            return manager;
        }

    }
}