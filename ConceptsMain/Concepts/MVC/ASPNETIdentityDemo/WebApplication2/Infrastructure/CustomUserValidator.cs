using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using AspnetIdentityDemo.Models;
using System.Threading.Tasks;

namespace AspnetIdentityDemo.Infrastructure
{
    public class CustomUserValidator : UserValidator<AppUser>
    {
        /*
        The constructor of the derived class must take an instance of the user manager class and call the base
        implementation so that the built-in validation checks can be performed. 
        */
        public CustomUserValidator(AppUserManager mgr) : base(mgr)
        {

        }

        public override async Task<IdentityResult> ValidateAsync(AppUser user)
        {
            IdentityResult result = await base.ValidateAsync(user);

            /*
            Custom validation is implemented by overriding the ValidateAsync method, which takes an instance of the user class and returns an IdentityResult
            object. My custom policy restricts users to e-mail addresses in the example.com domain and performs the same LINQ
            manipulation I used for password validation to concatenate my error message with those produced by the base class
             */
            if (!user.Email.ToLower().EndsWith("@example.com"))
            {
                var errors = result.Errors.ToList();
                errors.Add("Only example.com email addresses are allowed");
                result = new IdentityResult(errors);
            }

            return result;
        }
    }
}