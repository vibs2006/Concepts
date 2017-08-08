using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AspnetIdentityDemo.Models
{
    /*
    The initial model I have defined is called CreateModel, and it defines the basic properties that I require to
    create a user account: a username, an e-mail address, and a password. I have used the Required attribute from the
    System.ComponentModel.DataAnnotations namespace to denote that values are required for all three properties
    defined in the model. 
     */
    public class CreateModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }

    public class LoginModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Password { get; set; }
    }
}