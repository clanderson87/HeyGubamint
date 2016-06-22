using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FaceYourNation.DAL;
using FaceYourNation.Models;

namespace FaceYourNation.Controllers
{
    public class IssueController : ApiController
    {
        HGRepo Repo = new HGRepo();

        // GET: api/Issue
        public IEnumerable<Issue> Get()
        {
            List<Issue> issues = Repo.GetIssues();
            return issues;
        }

        // GET: api/Issue/5
        public Issue Get(string name)
        {
            Issue iss = Repo.GetIssue(name);
            return iss;
        }

        // GET: api/Issue/
        public PositionResult Get(string _iss_name, string _dis = "")
        {
            PositionResult result = Repo.GetIssuePublicPosition(iss_name: _iss_name, dis: _dis);
            return result;
        }

        // POST: api/Issue
        public void Post(string _iss_name, string _dis, string _vid, bool _bool_, int _import = 5)
        {
            Repo.AddIssuePosition(iss_name: _iss_name, dis: _dis, vid: _vid, _bool: _bool_, import: _import);
        }
    }
}
