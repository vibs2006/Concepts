using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace AspnetIdentityDemo.Infrastructure
{
    /*
    The built-in password validation is sufficient for most applications, but you may need to implement a custom policy,
    especially if you are implementing a corporate line-of-business application where complex password policies are
    common. Extending the built-in functionality is done by deriving a new class from PasswordValidatator and
    overriding the ValidateAsync method 
     */
    public class CustomPasswordValidator:PasswordValidator
    {
        /*
        I have overridden the ValidateAsync method and call the base implementation so I can benefit from the built-in
        validation checks. The ValidateAsync method is passed the candidate password, and I perform my own check to
        ensure that the password does not contain the sequence 12345. The properties of the IdentityResult class are
        read-only, which means that if I want to report a validation error, I have to create a new instance, concatenate my
        error with any errors from the base implementation, and pass the combined list as the constructor argument. I used
        LINQ to concatenate the base errors with my custom one.
         */

        public override async Task<IdentityResult> ValidateAsync(string pass)
        {

            IdentityResult result = await base.ValidateAsync(pass);
            if (pass.Contains("12345"))
            {
                var errors = result.Errors.ToList();
                errors.Add("Passwords cannot contain numeric sequence");
                result = new IdentityResult(errors);
            }
            return result;
        }

    }
}