using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC1.Areas.Admin.Models
{
    public class OrderModel
    {
        public int Orders_id { set; get; }
        public int Customer_id { set; get; }
        public int Admin_id { set; get; }
        public DateTime Order_date { set; get; }
        public DateTime Delivery_date { set; get; }
        public string Adress { set; get; }
        public Boolean Order_Status { set; get; }

    }
}