using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Facebook;
using System.Web.Security;
using Newtonsoft.Json.Linq;
using System.Web.Script.Serialization;

namespace MvcApplication2.Controllers
{
    public class AccountController : Controller
    {
        private Uri RedirectUri
        {
            get
            {
                var uriBuilder = new UriBuilder(Request.Url);
                uriBuilder.Query = null;
                uriBuilder.Fragment = null;
                uriBuilder.Path = Url.Action("FacebookCallback");
                return uriBuilder.Uri;
            }
        }

        [AllowAnonymous]
        public ActionResult login()
        {
            return View();
        }

        public ActionResult logout()
        {
            FormsAuthentication.SignOut();
            return View("Login");
        }

        [AllowAnonymous]
        public ActionResult Facebook()
        {
            var fb = new FacebookClient();
            var loginUrl = fb.GetLoginUrl(new
            {
                client_id = "428553750818163",
                client_secret = "62e1d1248648679bd5e6758ffb90440e",
                redirect_uri = RedirectUri.AbsoluteUri,
                response_type = "code",
                scope = "email" // Add other permissions as needed
            });

            return Redirect(loginUrl.AbsoluteUri);
        }

        public ActionResult FacebookCallback(string code)
        {
            var fb = new FacebookClient();
            dynamic result = fb.Post("oauth/access_token", new
            {
                client_id = "428553750818163",
                client_secret = "62e1d1248648679bd5e6758ffb90440e",
                redirect_uri = RedirectUri.AbsoluteUri,
                code = code
            });

            var accessToken = result.access_token;

            // Store the access token in the session for farther use
            Session["AccessToken"] = accessToken;

            // update the facebook client with the access token so 
            // we can make requests on behalf of the user
            fb.AccessToken = accessToken;

            // Get the user's information
            dynamic me = fb.Get("me?fields=first_name,middle_name,last_name,id,email,picture");

            string getMeType = result.GetType().FullName;
            string email = me.email;
            string firstname = me.first_name;
            string middlename = me.middle_name;
            string lastname = me.last_name;
            dynamic picPath = me.picture.data.url;
            //JObject jsobj = JObject.Parse(picPath);
            //var s = jsobj.Last.ToString();

            //JavaScriptSerializer j = new JavaScriptSerializer();
            //object a = j.Deserialize(picPath, typeof(object));

            

            // Set the auth cookie
            FormsAuthentication.SetAuthCookie(email, false);

            Session["Name"] = firstname + " " + lastname;
            Session["getMeType"] = getMeType;
            Session["picPath"] = picPath;
            
            return RedirectToAction("Index", "Home");
        }

    }
}
