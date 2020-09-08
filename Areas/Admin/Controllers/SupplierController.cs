using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC1.Areas.Admin.Controllers
{
    public class SupplierController : Controller
    {
        // GET: Admin/Supplier
        public ActionResult Index()
        {
            return View();
        }
    }
}