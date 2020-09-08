using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC1.Areas.Admin.Models;

namespace MVC1.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel acc,string Email,string PassW)
        {
            DataAccess da = new DataAccess();
            DataTable dt = da.GetTable("select*from SM_Adminstrator where Email='" + acc.Email + "'and PassW = '" + acc.PassW + "'");
            //DataTable dt = da.GetTable("Account_Login");
            //da.com.Parameters.AddWithValue("@email", acc.Email);
            //da.com.Parameters.AddWithValue("@pass", acc.PassW);
            //da.com.CommandType = CommandType.StoredProcedure;
            if (dt.Rows.Count > 0)
            {
                //if (Equals(acc.Email) && Equals(acc.PassW))
                //{
                //Session["user"] = new LoginModel() {Email=acc.Last_name ,Last_name = acc.Last_name };
                Session["user"] = new LoginModel() { Email = acc.Email };
                return RedirectToAction("Index", "Home");
                //}
            }
            else
            {
                ViewBag.Message = "Empty Excel File!";
                return RedirectToAction("Index", "Login");
            }
        }
        public ActionResult Logout()
        {
            Session.RemoveAll();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}