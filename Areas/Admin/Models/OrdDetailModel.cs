using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC1.Areas.Admin.Models
{
    public class OrdDetailModel
    {
        public int Ordetail_id { set; get; }
        public int Oders_id { set; get; }
        public int Product_id { set; get; }
        public int Product_number { set; get; }
        public decimal Amount { set; get; }
        public Boolean Ordetais_Status { set; get; }

    }
}