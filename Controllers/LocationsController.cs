using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MB_Pipeline.Controllers
{
    public class LocationsController : Controller
    {
        //
        // GET: /Locations/
        
        [Authorize]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult Index(int location, int account)
        {
            ViewData["Account"] = account;
            var loc = Helper.Locations.GetLocation(location, account);
            List<SelectListItem> states = Helper.Contacts.GetStateDropdown();
            var q = (from SelectListItem item in states
                     where item.Value == loc.state
                     select item).First().Selected = true;
            ViewData["States"] = states;
            return View(loc);
        }

        //GET: /Locations/New
        [Authorize]
        public ActionResult New(int account)
        {
            ViewData["Account"] = account;
            List<SelectListItem> states = Helper.Contacts.GetStateDropdown();
            ViewData["States"] = states;
            return View();
        }

        [Authorize]
        public ActionResult Update()
        {
            var i = new MB_Pipeline.Controllers.Models.Location();
            i.id = Convert.ToInt32(Request["id"]);
            i.name = Request["name"];
            i.address = Request["address"];
            i.address_line2 = Request["address_line2"];
            i.city = Request["city"];
           // i.country = Request["country"];
            i.zip_code = Request["zip_code"];
            i.state = Request["state_dropdown"];
            if (Helper.Locations.Update(i))
            {
                return Redirect("/Accounts/Details/" + Request["Account"]);
            }
            return Redirect("/404");
        }

        [Authorize]
        public ActionResult Save()
        {
            var i = new MB_Pipeline.Controllers.Models.Location();
            i.name = Request["name"];
            i.address = Request["address"];
            i.address_line2 = Request["address_line2"];
            i.city = Request["city"];
           // i.country = Request["country"];
            i.zip_code = Request["zip_code"];
            i.state = Request["state_dropdown"];
            if (Helper.Locations.New(i, Convert.ToInt32(Request["account"])) == true)
            {

                return Redirect("/Accounts/Details/" + Request["Account"]);
            }
            return Redirect("/404");
        }
    }
}
