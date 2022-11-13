using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using WebAPI.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebAPI.Controllers
{
    public class DepartmentController : ApiController
    {
        public HttpResponseMessage Get()
        {
            DataTable dt = new DataTable();
            string query = @"select DepartmentID,DepartmentName 
                             from Departments";
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString))
            {

            }


        }
    }
}
