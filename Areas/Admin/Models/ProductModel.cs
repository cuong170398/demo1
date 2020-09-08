using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC1.Areas.Admin.Models
{
    public class ProductModel
    {
        public int Product_id { set; get; }
        public int Catalogs_id { set; get; }
        public int Supplier_id { set; get; }
        public string Product_name { set; get; }
        public decimal Product_Price { set; get; }
        public int Product_Discount { set; get; }
        public string Product_image { set; get; }
        public string Product_listimage { set; get; }
        public int Product_number { set; get; }
        public string Product_content { set; get; }
        public Boolean Product_Status { set; get; }
    }
}