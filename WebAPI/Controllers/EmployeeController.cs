using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class EmployeeController : ApiController
    {
        public HttpResponseMessage Get()
        {
            DataTable table = new DataTable();
            string query = @"select * from Employees";
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
        public string Post(Employee employee)
        {
            try
            {
                DataTable table = new DataTable();
                string query = @"insert into Employees values ('" + employee.EmployeeName + "' " +
                    ", '" + employee.Department + "' " +
                    ", '" + employee.MailID + "' " +
                    ", '" + employee.DOJ + "')";

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
            catch (Exception ex)
            {
                return "Faild to add" + ex;
            }
        }

        [HttpPut]
        public string Put(Employee employee)
        {
            try
            {
                DataTable table = new DataTable();
                string query = @"update Employees Set EmployeeName='" + employee.EmployeeName + "' " +
                    ", Department='" + employee.Department + "' " +
                    ", MailID='" + employee.MailID + "' " +
                    ", DOJ='" + employee.DOJ + "' " +
                    " where EmployeeID='" + employee.EmployeeID + "'";

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
                string query = @"delete from Employees where EmployeeID='" + id + "'";

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
