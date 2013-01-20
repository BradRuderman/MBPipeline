using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MB_Pipeline.Controllers.Models
{
    public class Account_Dashboard
    {
        public int ID { get; set; }
        public string name { get; set; }
        public string account_type { get; set; }
        public string sales_stage { get; set; }
        public int volume { get; set; }
        public string units { get; set; }
        public string account_rank { get; set; }
        public decimal revenue { get; set; }
        public int visits_per_year { get; set; }
        public int contact_id { get; set; }
        public string contact_name { get; set; }
        public string parent { get; set; }
    }

    public class Parent_Account
    {
        public int id { get; set; }
        public string name { get; set; }
    }
}