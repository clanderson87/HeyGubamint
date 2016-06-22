using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FaceYourNation.Controllers
{
    public class IssueController : ApiController
    {
        // GET: api/Issue
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Issue/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Issue
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Issue/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Issue/5
        public void Delete(int id)
        {
        }
    }
}
