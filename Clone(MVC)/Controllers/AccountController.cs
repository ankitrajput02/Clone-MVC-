using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using Clone_MVC_.Controllers;
using Clone_MVC_.Models;
using System.Data.SqlClient;
namespace Clone_MVC_.Controllers
{
    public class AccountController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;

        // GET: Account
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        void connectionString()
        {
            con.ConnectionString= "data source =DESKTOP-274B54E; database=SompoDB; integrated security =SSPI; ";

		}
        [HttpPost]
        public ActionResult Verify(Account acc) 
        {
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "Select * from ASPNETUSER where username='" + acc.Name + "' and password='" + acc.Password + "'";
			dr = com.ExecuteReader();
            if (dr.Read())
            {
                con.Close();
				return View("Create");
			}
            else
            {
                con.Close();
				return View("Error");
			}
            

        }
    }
}