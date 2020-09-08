using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC1.Areas.Admin.Models
{
    public class CustomerModel
    {
        public int Customer_id { set; get; }
        public string Customer_name { set; get; }
        public string Customer_phone { set; get; }
        public string Customer_Address { set; get; }
        public string Customer_Email { set; get; }
        public string Customer_Pass { set; get; }
        public DateTime Customer_Birthday { set; get; }
        public string Customer_Gender { set; get; }
        public Boolean Customer_Status { set; get; }
    }
}