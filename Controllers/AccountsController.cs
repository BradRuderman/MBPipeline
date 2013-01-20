using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;

namespace MB_Pipeline.Controllers
{
    public class AccountsController : Controller
    {
        //
        // GET: /Accounts/
        [Authorize()]
        public ActionResult Index()
        {
            return View(Helper.Accounts.GetAccountDashboard(Helper.Sessions.GetUserFromSession().ID));
        }

        //
        // GET: /Accounts/Details/ID
        [Authorize()]
        public ActionResult Details(int ID)
        {
            var a = Helper.Accounts.GetAccountDetails(Helper.Sessions.GetUserFromSession().ID, ID);
            if (a == null)
            {
                return Redirect("/404");
            }
            else
            {
                ViewData["Account"] = a;
            }
            var c = Helper.Accounts.GetContacts(ID);
            if (c != null && c.Count > 0)
            {
                ViewData["Contacts"] = Helper.Accounts.GetContacts(ID).ToArray();
            }
            var l = Helper.Accounts.GetLocations(ID);
            if (l != null && l.Count > 0)
            {
                ViewData["Locations"] = Helper.Accounts.GetLocations(ID).ToArray();
            }
            return View();
        }

        //
        //GET: /Accounts/New
        [Authorize]
        public ActionResult New()
        {
            List<MB_Pipeline.Controllers.Models.Parent_Account> parent_acts = Helper.Accounts.GetParentAccounts(Helper.Sessions.GetUserFromSession().ID);
            List<SelectListItem> select_list_items = (from MB_Pipeline.Controllers.Models.Parent_Account act in parent_acts
                                                      select new SelectListItem() { Value = act.id.ToString(), Text = act.name }).ToList<SelectListItem>();
            select_list_items.Add(new SelectListItem() { Text = "None", Value = "0", Selected = true });
            @ViewBag.ParentAccounts = select_list_items;
            return View();
        }

        [Authorize]
        public ActionResult New_Account()
        {
            string name = Request["name"];
            Int32 parent_account = Convert.ToInt32(Request["parent_account_dropdown"]);
            var b = MB_Pipeline.Helper.Accounts.CreateAccount(name, parent_account, Helper.Sessions.GetUserFromSession().ID);
            if (b)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return Redirect("/404");
            }
        }

        //Get: /Accounts/SalesStage
        public ActionResult SalesStage(int account)
        {
            return View();
        }

        public ActionResult SalesInformation(int account)
        {
            var a = Helper.Accounts.GetAccountDetails(Helper.Sessions.GetUserFromSession().ID, account);
            if (a == null)
            {
                return Redirect("/404");
            }
            return View(a);
        }

        public ActionResult SalesInformationUpdate()
        {
            MB_Pipeline.Controllers.Models.Account_Dashboard act = new MB_Pipeline.Controllers.Models.Account_Dashboard();
            act.ID = Convert.ToInt32(Request["id"]);
            act.account_rank = Request["account_rank"];
            act.revenue = Convert.ToDecimal(Request["revenue"]);
            act.sales_stage = Request["sales_stage"];
            act.units = Request["units"];
            act.visits_per_year = Convert.ToInt32(Request["visits_per_year"]);
            act.volume = Convert.ToInt32(Request["volume"]);
            if (Helper.Accounts.UpdateSalesInformation(act))
            {
                return Redirect("/Accounts/Details/" + Request["id"]);
            }
            return Redirect("/404");
        }
    }
}
