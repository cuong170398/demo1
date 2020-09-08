using ClosedXML.Excel;
using MVC1.Areas.Admin.Models;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MVC1.Areas.Admin.Controllers
{
    public class CatalogController : Controller
    {
        // GET: Admin/Catalog
        CatalogDB empDB = new CatalogDB();
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult List()
        {
            return Json(empDB.ListAll(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Add(CatalogModel emp)
        {
            return Json(empDB.Add(emp), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetbyID(int ID)
        {
            var Employee = empDB.ListAll().Find(x => x.Catalogs_id.Equals(ID));
            return Json(Employee, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update(CatalogModel emp)
        {
            return Json(empDB.Update(emp), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(int ID)
        {
            return Json(empDB.Delete(ID), JsonRequestBehavior.AllowGet);
        }
        //public ActionResult ExportToExcel()
        //{
        //    var gv = new GridView();
        //    gv.DataSource = this.empDB.ListAll()
        //    .Select(r => new
        //    {
        //        id = r.Catalogs_id,
        //        name = r.Catalogs_name,
        //        status = r.Catalogs_Status == true ? "Active" : "Blocked"
        //    })
        //    .ToList();
        //    gv.DataBind();
        //    Response.Clear();
        //    Response.Buffer = true;
        //    //Response.AddHeader("content-disposition",
        //    // "attachment;filename=GridViewExport.xls");
        //    Response.Charset = "utf-8";
        //    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        //    Response.AddHeader("content-disposition", "attachment;filename=CatalogInfo.xls");
        //    Response.Charset = "";
        //    //Mã hóa chữa sang UTF8
        //    Response.ContentEncoding = System.Text.Encoding.UTF8;
        //    Response.BinaryWrite(System.Text.Encoding.UTF8.GetPreamble());

        //    StringWriter sw = new StringWriter();
        //    HtmlTextWriter hw = new HtmlTextWriter(sw);

        //    for (int i = 0; i < gv.Rows.Count; i++)
        //    {
        //        //Apply text style to each Row
        //        gv.Rows[i].Attributes.Add("class", "textmode");
        //    }
        //    //Add màu nền cho header của file excel
        //    gv.HeaderRow.BackColor = System.Drawing.Color.DarkBlue;
        //    ////Màu chữ cho header của file excel
        //    gv.HeaderStyle.ForeColor = System.Drawing.Color.White;

        //    gv.HeaderRow.Cells[0].Text = "id";
        //    gv.HeaderRow.Cells[1].Text = "Tên Loại";
        //    //gv.HeaderRow.Cells[2].Text = "logo";
        //    gv.HeaderRow.Cells[2].Text = "Trạng Thái";

        //    gv.RenderControl(hw);

        //    Response.Output.Write(sw.ToString());
        //    Response.Flush();
        //    Response.End();
        //    return View("Index");
        //}
        public ActionResult ExportToExcel()
        {            string export = "Export";
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Danh sách Catalog");
                var currentRow = 5;
                worksheet.Cell(currentRow, 4).Value = "ID";
                worksheet.Cell(currentRow, 5).Value = "TÊN LOẠI";
                worksheet.Cell(currentRow, 6).Value = "TRẠNG THÁI";
                worksheet.Cells("D5:F5").Style.Font.FontSize = 16;
                worksheet.Cells("D5:F5").Style.Font.Bold = true;
                worksheet.Cells("D5:F5").Style.Font.FontColor = XLColor.Red;
                foreach (var user in empDB.ListAll())
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 4).Value = user.Catalogs_id;
                    worksheet.Cell(currentRow, 5).Value = user.Catalogs_name;
                    worksheet.Cell(currentRow, 6).Value = user.Catalogs_Status == true ? "Active" : "Blocked";

                }
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    
                    var content = stream.ToArray();
                    //string fullPath = Path.Combine(Server.MapPath("~/F:/BT"));
                    return File(
                        content,
                        contentType: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        fileDownloadName: export + ".xlsx");
                }
            }
        }
    }
}