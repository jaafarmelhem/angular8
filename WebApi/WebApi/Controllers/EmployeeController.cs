using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class EmployeeController : ApiController
    {

        public HttpResponseMessage Get()
        {

            //https://localhost:44318/api/Employee Postman Get method

            DataTable table = new DataTable();
            string query = @"
                Select EmployeeID, EmployeeName, Department, 
                MailID, 
                convert(varchar(10),DOJ, 120) as DOJ
                from dbo.Employees
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

        public string Post(Employee emp)
        {
            try
            {

                //https://localhost:44318/api/Employee postman Post method
                //Request body: (raw / json )
                //{
                //    "EmployeeID": null,
                //    "EmployeeName": "Mary",
                //    "Department": "Support",
                //    "MailID": "mary123@gmail.com",
                //    "DOJ": "2019-05-12"
                //}

                DataTable table = new DataTable();
                string query = @"
                insert into dbo.Employees 
                (EmployeeName,
                Department,
                MailID,
                DOJ)
                values(
                '" + emp.EmployeeName + @"',
                '" + emp.Department + @"',
                '" + emp.MailID + @"',
                '" + emp.DOJ + @"'

                ) 
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

        public string Put(Employee emp)
        {

            //https://localhost:44318/api/Employee postman PUT method
            //Request body: (raw / json )
            //{
            //    "EmployeeID": 3,
            //    "EmployeeName": "Mary",
            //    "Department": "Operations",
            //    "MailID": "mary456@gmail.com",
            //    "DOJ": "2019-05-12"
            //}


            try
            {

                DataTable table = new DataTable();
                string query = @"
                update dbo.Employees
                set EmployeeName = '" + emp.EmployeeName + @"',
                Department = '" + emp.Department + @"',
                MailID = '" + emp.MailID + @"',
                DOJ = '" + emp.DOJ + @"'
                where EmployeeID = " + emp.EmployeeID + @"
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
            catch (Exception)
            {
                return "Failed to Update";
            }
        }

        public string Delete(int id)
        {

            //https://localhost:44318/api/Employee/4 postman DELETE method


            try
            {

                DataTable table = new DataTable();
                string query = @"
                delete from dbo.Employees
                where EmployeeID = " + id;


                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Deleted Successfully";
            }
            catch (Exception)
            {
                return "Failed to Delete";
            }
        }

    }
}
