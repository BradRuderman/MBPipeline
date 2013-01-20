using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace MB_Pipeline.Helper
{
    public class Sessions
    {
        public static bool LoginUser(string Email, string Password, string remember = "false")
        {
            remember = (remember == "on" ? "true" : "false");
            Controllers.Models.User user = new Controllers.Models.User();
            user = Helper.Users.GetUser(Email);
            if (user != null && user.Password == Password)
            {
                FormsAuthentication.SetAuthCookie(user.Email, Convert.ToBoolean(remember));
                return true;
            }
            return false;
        }

        public static void LogoutUser()
        {
            FormsAuthentication.SignOut();
        }

        public static void SetSession(Controllers.Models.User user)
        {
            if (HttpContext.Current.Session["User_Data"] == null)
            {
                HttpContext.Current.Session.Add("User_Data", user);
            }
        }

        public static Controllers.Models.User GetUserFromSession()
        {
            var user = (Controllers.Models.User)HttpContext.Current.Session["User_Data"];
            if (user == null)
            {
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    user = Users.GetUser(HttpContext.Current.User.Identity.Name);
                    SetSession(user);
                }
            }
            return user;
        }
    }
}