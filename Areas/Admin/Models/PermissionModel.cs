using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC1.Areas.Admin.Models
{
    public class PermissionModel
    {
        public int Permission_id { set; get; }
        public string Permision_name { set; get; }
        public Boolean Permission_Status { set; get; }
    }
}