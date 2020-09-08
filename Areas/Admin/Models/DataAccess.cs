using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace MVC1.Areas.Admin.Models
{
    public class DataAccess
    {
        public SqlConnection conn = null;
        public DataTable dt = null;
        public SqlCommand com = new SqlCommand();
        public SqlDataAdapter sda = null;
        public SqlCommandBuilder scb = null;

        internal object ListAll()
        {
            throw new NotImplementedException();
        }

        public DataAccess()
        {
           conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
        }
        public DataTable GetTable(string strQuerySelect)
        {
            DataTable dt = new DataTable();
            try
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                else
                    conn.Open();

                SqlDataAdapter da = new SqlDataAdapter(strQuerySelect, conn);   //Đối tượng thực thi lệnh
                da.Fill(dt);
            }
            catch
            {

            }
            finally
            {
                conn.Close();
            }
            return dt;
        }
        public void showMessage(string mess)
        {
            string strBuilder = "<script>alert('" + mess + "')</script>";
            HttpContext.Current.Response.Write(strBuilder);
        }
    }
}