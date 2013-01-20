using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MB_Pipeline.Controllers.Models
{
    public class User
    {
        public int ID { get; set; }

        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        public bool Admin { get; set; }
        public string Remember_Token { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}