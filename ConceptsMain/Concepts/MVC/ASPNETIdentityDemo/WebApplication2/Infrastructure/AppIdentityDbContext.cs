using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using AspnetIdentityDemo.Models;

namespace AspnetIdentityDemo.Infrastructure
{
    /*
    The next step is to create an Entity Framework database context that operates on the AppUser class. This will allow
    the Code First feature to create and manage the schema for the database and provide access to the data it stores. The
    context class is derived from IdentityDbContext<T>, where T is the user class (AppUser in the example). I created a
    folder called Infrastructure in the project and added to it a class file called AppIdentityDbContext.cs 

    The constructor for the AppIdentityDbContext class calls its base with the name of the connection string that will
    be used to connect to the database, which is IdentityDb in this example. This is how I associate the connection string
    I defined in Listing 13-4 with ASP.NET Identity.

    The AppIdentityDbContext class also defines a static constructor, which uses the Database.SetInitializer
    method to specify a class that will seed the database when the schema is first created through the Entity Framework
    Code First feature. My seed class is called IdentityDbInit, and I have provided just enough of a class to create a
    placeholder so that I can return to seeding the database later by adding statements to the PerformInitialSetup
    method. I show you how to seed the database in Chapter 14.
    Finally, the AppIdentityDbContext class defines a Create method. This is how instances of the class will be
    created when needed by the OWIN,


    */
    public class AppIdentityDbContext: IdentityDbContext<AppUser>
    {
        public AppIdentityDbContext() : base("IdentityDb") //Name of the Connection String
        {

        }

        static AppIdentityDbContext()
        {
            System.Data.Entity.Database.SetInitializer<AppIdentityDbContext>(new IdentityDbInit());
        }

        public static AppIdentityDbContext Create()
        {
            return new AppIdentityDbContext();
        }
    }

    public class IdentityDbInit : DropCreateDatabaseIfModelChanges<AppIdentityDbContext>
    {
        protected override void Seed(AppIdentityDbContext context)
        {
            PerformInitialSetup(context);
            base.Seed(context);
        }

        public void PerformInitialSetup(AppIdentityDbContext context)
        {
            // initial configuration will go here. 
        }
    }
}