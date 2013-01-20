using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MB_Pipeline.Controllers
{
    public class StaticPagesController : Controller
    {
        ////
        //// GET: /StaticPages/

        //public ActionResult Index()
        //{
        //    return View();
        //}

        //
        // GET: /Help

        public ActionResult Help()
        {
            return View();
        }

        //
        // GET: /About

        public ActionResult About()
        {
            return View();
        }

        //
        // GET: /Contact

        public ActionResult Contact()
        {
            return View();
        }

        //
        // GET: /401
        public ActionResult AccessDenied()
        {
            return View();
        }
    }
}
