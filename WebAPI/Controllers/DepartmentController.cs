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
            DataTable table = new DataTable();
            string query = @"select DepartmentID,DepartmentName 
                             from Departments";
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString))
            {
                using (var cmd = new SqlCommand(query, con))
                {
                    using (var da = new SqlDataAdapter(cmd))
                    {
                        cmd.CommandType = CommandType.Text;
                        da.Fill(table);
                    }
                }
            }

            return Request.CreateResponse(HttpStatusCode.OK, table);
        }

        [HttpPost]
        public string Post(Department department)
        {
            try
            {
                DataTable table = new DataTable();
                string query = @"insert into Departments values ('" + department.DepartmentName + "')";

                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString))
                {
                    using (var cmd = new SqlCommand(query, con))
                    {
                        using (var da = new SqlDataAdapter(cmd))
                        {
                            cmd.CommandType = CommandType.Text;

                            //cmd.ExecuteNonQuery();
                            da.Fill(table);
                        }
                    }
                }
                return "Added successfully";
            }
            catch (Exception)
            {
                return "Faild to add";
            }
        }

        [HttpPut]
        public string Put(Department department)
        {
            try
            {
                DataTable table = new DataTable();
                string query = @"update Departments Set DepartmentName='" + department.DepartmentName + "' " +
                    " where DepartmentID='" + department.DepartmentID + "'";

                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString))
                {
                    using (var cmd = new SqlCommand(query, con))
                    {
                        using (var da = new SqlDataAdapter(cmd))
                        {
                            cmd.CommandType = CommandType.Text;
                            //cmd.ExecuteNonQuery();
                            da.Fill(table);
                        }
                    }
                }
                return "Edit successfully";
            }
            catch (Exception ex)
            {
                return "Faild to add" + ex;
            }
        }

        [HttpDelete]
        public string Delete(int id)
        {
            try
            {
                DataTable table = new DataTable();
                string query = @"delete from Departments where DepartmentID='" + id + "'";

                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString))
                {
                    using (var cmd = new SqlCommand(query, con))
                    {
                        using (var da = new SqlDataAdapter(cmd))
                        {
                            cmd.CommandType = CommandType.Text;
                            //cmd.ExecuteNonQuery();
                            da.Fill(table);
                        }
                    }
                }
                return "Deleted successfully";
            }
            catch (Exception ex)
            {
                return "Faild to delete" + ex;
            }
        }
    }
}
