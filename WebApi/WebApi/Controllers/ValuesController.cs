using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public HttpResponseMessage Get()
        {
            //https://localhost:44318/api/values  to access this action , through browser or postman

            //return new string[] { "value1", "value2" };
            DataTable dt = new DataTable();
            dt.Columns.Add("DepID");
            dt.Columns.Add("DepName");

            dt.Rows.Add(1, "IT");
            dt.Rows.Add(1, "Support");

            return Request.CreateResponse(HttpStatusCode.OK, dt);
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
