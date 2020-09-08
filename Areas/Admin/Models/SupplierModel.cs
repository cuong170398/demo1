using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC1.Areas.Admin.Models
{
    public class SupplierModel
    {
        public int Supplier_id { set; get; }
        public string Supplier_name { set; get; }
        public string Supplier_address { set; get; }
        public string Supplier_phone { set; get; }
        public string Supplier_fax { set; get; }
        public string Supplier_email { set; get; }
        public Boolean Supplier_Status { set; get; }
    }
}