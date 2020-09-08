using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC1.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required]
        public string Email { set; get; }
        [Required]
        public string PassW { set; get; }
        public string Last_name { set; get; }
    }
}