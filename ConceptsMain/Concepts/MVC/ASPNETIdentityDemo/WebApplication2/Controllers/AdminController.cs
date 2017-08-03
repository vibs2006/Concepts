using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using AspnetIdentityDemo.Infrastructure;
using AspnetIdentityDemo.Models;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;


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

        public ActionResult Error()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View(UserManager.Users);
        }

        /*
        I added a pair of Create action methods to the Admin controller, which are targeted by the link in the Index view
        from the previous section and which uses the standard controller pattern to present a view to the user for a GET
        request and process form data for a POST request.
         */
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateModel model)
        {
            if (ModelState.IsValid)
            {
                /*
                The important part of this listing is the Create method that takes a CreateModel argument and that will be
                invoked when the administrator submits their form data. I use the ModelState.IsValid property to check that the
                data I am receiving contains the values I require, and if it does, I create a new instance of the AppUser class and pass it
                to the UserManager.CreateAsync method, like this
                 */
                AppUser user = new AppUser
                {
                    UserName = model.Name,
                    Email = model.Email
                };

                IdentityResult result = await UserManager.CreateAsync(user, model.Password);
                //The result from the CreateAsync method is an implementation of the IdentityResult interface, which describes
                //the outcome of the operation through the properties
                /*
                I inspect the Succeeded property in the Create action method to determine whether I have been able to create a
                new user record in the database. If the Succeeded property is true, then I redirect the browser to the Index action so
                that list of users is displayed:
                 */
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    AddErrorsFromResult(result);
                }

            }

            return View(model);
        }

        private void AddErrorsFromResult(IdentityResult result)
        {
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError("", item);
            }
        }

        private AppUserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
            }
        }
        /// <summary>
        /// The user manager class defines a DeleteAsync method that takes an instance of the user class 
        /// and removes it from the  database.
        /// My action method received the unique ID for the user as an argument, and I use the FindByIdAsync method to locate the 
        /// corresponding user object so that I can pass it to DeleteAsync method. The result of the DeleteAsync
        /// method is an IdentityResult, which I process in the same way I did in earlier examples to ensure that any errors
        /// are displayed to the user. 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Delete(string id)
        {
            AppUser user = await UserManager.FindByIdAsync(id);
            if (user!=null)
            {
                IdentityResult result = await UserManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("Error", result.Errors);
                }
            }
            else
            {
                return View("Error", new string[] { "User Not Found" });
            }

        }

        [HttpGet]
        public async Task<ActionResult> Edit(string id)
        {
            AppUser user = await UserManager.FindByIdAsync(id);
            if (user!=null)
            {
                return View(user);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        /// <summary>
        /// The Edit Action targeted by GET requests uses the ID string embedded in the Index view
        /// to call the FindByIdAsync method in order to get an AppUser object that represents the user. 
        /// The more complex implimentation receives the POST request, with arguments for the user ID, the email-email Address
        /// , and the password. I have to perform server tasks to compelte the editing operation. 
        /// The first task is to validate the values I have receivead. I"m workign with a saimple user object at themoment
        /// although I'll show you hwo to customer the data later but even for that I need to validate the data
        /// to ensure that I don't violate the customer policies defined in the "Validating User Details"
        /// </summary>
        /// <param name="id"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Edit(string id, string email, string password)
        {
            AppUser user = await UserManager.FindByIdAsync(id);
            if (user != null)
            {
                user.Email = email;

                IdentityResult validEmail = await UserManager.UserValidator.ValidateAsync(user);

                if(!validEmail.Succeeded)
                {
                    AddErrorsFromResult(validEmail);
                }

                IdentityResult validPass = null;

                if (password != string.Empty)
                {
                    validPass = await UserManager.PasswordValidator.ValidateAsync(password);

                    if (validPass.Succeeded)
                    {
                        user.PasswordHash = UserManager.PasswordHasher.HashPassword(password);
                    }
                    else
                    {
                        AddErrorsFromResult(validPass);
                    }
                }

                if ((validEmail.Succeeded && validPass == null) || (validEmail.Succeeded && password != string.Empty && validPass.Succeeded))
                {
                    IdentityResult result = await UserManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        AddErrorsFromResult(result);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "User Not Found");
                }
                return View(user);
            }
        }

    }
}