using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Cors;
using FaceYourNation.Models;
using FaceYourNation.DAL;

namespace FaceYourNation.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "get, post")]
    public class VoteController : ApiController
    {
        HGRepo repo = new HGRepo();
        
        // POST: api/Vote
        [HttpPost]
        [ResponseType(typeof(Vote))]
        public IHttpActionResult Post([FromBody]Vote vote)
        {
            if(!ModelState.IsValid || vote == null)
            {
                return BadRequest();
            }
            else
            {
                repo.AddVote(vote);
                return CreatedAtRoute("DefaultApi", new { id = vote.VoteId }, vote);
            }
        }
    }
}
