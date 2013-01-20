using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MB_Pipeline.Controllers
{
    public class SessionsController : Controller
    {
        //
        // GET: /Sessions/

        public ActionResult Index()
        {

            return View();
        }

        //5
        // POST /Sessions/New
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult New()
        {
            if (Helper.Sessions.LoginUser(Request.Params["email"], Request.Params["password"], Request.Params["remember"]))
            {
                if (Request.Params["ReturnUrl"] != null)
                {
                    return Redirect(Request.Params["ReturnUrl"]);
                }
                else
                {
                    return Redirect("/");
                }
            }
            else
            {
                string[] error = { "User name or password is incorrect." };
                TempData["Error"] = error;
                return RedirectToAction("Index");
            }
        }

        //
        //Post /Sessions/Delete
        public ActionResult Delete()
        {
            Helper.Sessions.LogoutUser();
            return Redirect("/");
        }
    }
}
