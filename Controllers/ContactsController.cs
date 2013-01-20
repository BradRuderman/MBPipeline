using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MB_Pipeline.Controllers.Models;

namespace MB_Pipeline.Controllers
{
    public class ContactsController : Controller
    {
        //
        // GET: /Contacts?contact={}&account={}
        [Authorize]
        public ActionResult Index(int contact, int account = 0)
        {
            List<Contact_Owner> c = Helper.Accounts.GetContact(contact);
            if (c == null || c.Count == 0 || c[0].owner != Helper.Sessions.GetUserFromSession().ID)
            {
                return Redirect("/404");
            }
            List<SelectListItem> states = Helper.Contacts.GetStateDropdown();
            var q = (from SelectListItem item in states
                     where item.Text == c[0].state
                     select item).First().Selected = true;
            ViewData["Account"] = account;
            ViewData["States"] = states;
            return View(c[0]);
        }


        //GET: /Contacts/New
        [Authorize]
        public ActionResult New(int account)
        {
            ViewData["Account"] = account;
            List<SelectListItem> states = Helper.Contacts.GetStateDropdown();
            ViewData["States"] = states;
            return View();
        }


        [Authorize]
        public ActionResult Save()
        {
            var i = new MB_Pipeline.Controllers.Models.Contact();
            i.name = Request["name"];
            i.title = Request["title"];
            i.address = Request["address"];
            i.address_line2 = Request["address_line2"];
            i.city = Request["city"];
            i.country = Request["country"];
            i.email = Request["email"];
            i.phone_number = Request["phone_number"];
            i.secondary_number = Request["secondary_number"];
            i.zip_code = Request["zip_code"];
            i.state = Request["state_dropdown"];
            if (MB_Pipeline.Helper.Contacts.New(i, Convert.ToInt32(Request["Account"])))
            {
                return Redirect("/Accounts/Details/" + Request["Account"]);
            }
            return Redirect("/404");
        }

        //GET: /Contacts/Update
        [Authorize]
        public ActionResult Update()
        {
            var i = new MB_Pipeline.Controllers.Models.Contact();
            i.id = Convert.ToInt32(Request["id"]);
            i.name = Request["name"];
            i.title = Request["title"];
            i.address = Request["address"];
            i.address_line2 = Request["address_line2"];
            i.city = Request["city"];
            i.country = Request["country"];
            i.email = Request["email"];
            i.phone_number = Request["phone_number"];
            i.secondary_number = Request["secondary_number"];
            i.state = null;
            i.zip_code = Request["zip_code"];
            i.state = Request["state_dropdown"];
            if (MB_Pipeline.Helper.Contacts.Update(i))
            {
                return Redirect("/Accounts/Details/" + Request["account"]);
            }
            return Redirect("/404");
        }

    }


}
