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
    /*
    The RoleEditModel class will let me pass details of a role and details of the users in the system, categorized by
    membership. I use AppUser objects in the view model so that I can extract the name and ID for each user in the view
    that will allow memberships to be edited.
    */
    public class RoleEditModel
    {
        public AppRole Role { get; set; }
        public IEnumerable<AppUser> Members { get; set; }
        public IEnumerable<AppUser> NonMembers { get; set; }
    }

    /*
    The RoleModificationModel class is the one that I will receive from the
    model binding system when the user submits their changes. It contains arrays of user IDs rather than AppUser objects,
    which is what I need to change role memberships.
     */
    public class RoleModificationModel
    {
        [Required]
        public string RoleName { get; set; }
        public string[] IdsToAdd { get; set; }
        public string[] IdsToDelete { get; set; }
    }

}