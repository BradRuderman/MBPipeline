using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MB_Pipeline.Controllers.Models
{
    public class Location
    {
        public int id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string address_line2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip_code { get; set; }
        //public string country { get; set; }
        public string location_type { get; set; }
    }
}