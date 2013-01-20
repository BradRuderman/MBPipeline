using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MB_Pipeline.Controllers.Models
{
    public class Contact
    {
        public int id { get; set; }
        public string name { get; set; }
        public string title { get; set; }
        public string address { get; set; }
        public string address_line2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip_code { get; set; }
        public string country { get; set; }
        public string phone_number { get; set; }
        public string secondary_number { get; set; }
        public string email { get; set; }
    }

    public class Contact_Owner : Contact
    {
        public int owner { get; set; }
    }

    public class State
    {
        public string state { get; set; }
        public string state_abr { get; set; }
    }
}