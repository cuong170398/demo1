
using System.Linq;
using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.Mvc;

namespace MVC1.Areas.Admin.Models
{
    public class CatalogDB
    {
        string cs = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
        DataAccess da = new DataAccess();

        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
        public List<CatalogModel> ListAll()
        {
            List<CatalogModel> CatalogList = new List<CatalogModel>();
            DataTable dt = da.GetTable("EXEC dbo.PhanTrang_Catalog @PageNumber=1,@PageSize=20");
            da.com.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var Catalog = new CatalogModel();
                Catalog.Catalogs_id = Convert.ToInt32(dt.Rows[i]["Catalogs_id"].ToString());
                Catalog.Catalogs_name = dt.Rows[i]["Catalogs_name"].ToString();
                Catalog.Catalogs_image = dt.Rows[i]["Catalogs_image"].ToString();
                Catalog.Catalogs_Status = Convert.ToBoolean(dt.Rows[i]["Catalogs_Status"].ToString());
                CatalogList.Add(Catalog);
            }
            return CatalogList;
        }
        //Method for Adding an Catalog
        public int Add(CatalogModel emp)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                try
                {
                    con.Open();
                    SqlCommand com = new SqlCommand("dbo.Insert_Catalogs", con);
                    com.CommandType = CommandType.StoredProcedure;
                    //com.Parameters.AddWithValue("@Catalogs_id", emp.Catalogs_id);
                    com.Parameters.AddWithValue("@Catalogs_name", emp.Catalogs_name);
                    com.Parameters.AddWithValue("@Catalogs_image", emp.Catalogs_image);
                    com.Parameters.AddWithValue("@Catalogs_Status", emp.Catalogs_Status);
                    //com.Parameters.AddWithValue("@Action", "Insert");
                    i = com.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return i;
        }
        //Method for Updating Catalog record
        public int Update(CatalogModel emp)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("dbo.Update_Catalos", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Catalogs_id", emp.Catalogs_id);
                com.Parameters.AddWithValue("@Catalogs_name", emp.Catalogs_name);
                com.Parameters.AddWithValue("@Catalogs_image", emp.Catalogs_image);
                com.Parameters.AddWithValue("@Catalogs_Status", emp.Catalogs_Status);
                i = com.ExecuteNonQuery();
            }
            return i;
        }
        //Method for Deleting an Catalog
        public int Delete(int ID)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("dbo.deleteCatalog", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Catalogs_id", ID);
                i = com.ExecuteNonQuery();
            }
            return i;
        }

    }
}