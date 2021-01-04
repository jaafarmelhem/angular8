using System;
using System.Web.Http;
using System.Net.Http;
using WebApi.Models;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Net;

namespace WebApi.Controllers
{
    public class DepartmentController : ApiController
    {

        public HttpResponseMessage Get()
        {
            //https://localhost:44318/api/Department Postman Get method

            DataTable table = new DataTable();
            string query = @"
                Select DepartmentID, DepartmentName 
                from dbo.Departments
                ";


            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }

            return Request.CreateResponse(HttpStatusCode.OK, table);

        }

        public string Post(Department dep)
        {

            //https://localhost:44318/api/Department postman Post method
            //Request body: (raw / json )
            //{
            //    "DepartmentID":null,
            //    "DepartmentName": "Support"
            //}

            try
            {

                DataTable table = new DataTable();
                string query = @"
                insert into dbo.Departments values('" + dep.DepartmentName + @"') 
                ";


                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Added Successfully";
            }
            catch (Exception)
            {
                return "Failed to Add";
            }
        }

        public string Put(Department dep)
        {

            //https://localhost:44318/api/Department postman PUT method
            //Request body: (raw / json )
            //{
            //    "DepartmentID":3,
            //    "DepartmentName": "Operations"
            //}


            try
            {

                DataTable table = new DataTable();
                string query = @"
                update dbo.Departments
                set DepartmentName = '" + dep.DepartmentName + @"'
                where DepartmentID = " + dep.DepartmentID + @"
                ";


                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Updated Successfully";
            }
            catch (Exception ex)
            {
                return "Failed to Update";
            }
        }

        public string Delete(int id)
        {

            //https://localhost:44318/api/Department/4 postman DELETE method

            try
            {

                DataTable table = new DataTable();
                string query = @"
                delete from dbo.Departments
                where DepartmentID = " + id;


                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Deleted Successfully";
            }
            catch (Exception ex)
            {
                return "Failed to Delete";
            }
        }

    }
}
