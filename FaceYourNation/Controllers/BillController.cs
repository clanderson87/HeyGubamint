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
    public class BillController : ApiController
    {
        HGRepo Repo = new HGRepo();

        // GET: api/Bill
        public IEnumerable<Bill> Get()
        {
            List<Bill> bills =  Repo.GetBills();
            return bills;
        }

        // GET: api/Bill/5
        public Bill Get(string id)
        {
            Bill bill = Repo.GetBill(id);
            return bill;
        }
        
        //GET: api/Bill
        public PositionResult Get(string _dis, string _house = "", string _senate = "")
        {
            PositionResult result = Repo.GetBillPublicPosition(dis: _dis, senate: _senate, house: _house);
            return result;
        }

        [HttpPost]
        [ResponseType(typeof(Bill))]
        public IHttpActionResult Post([FromBody]Bill bill)
        {
            if (!ModelState.IsValid || bill == null)
            {
                return BadRequest();
            }
            else
            {
                Repo.AddBillByBill(bill);
                return CreatedAtRoute("DefaultApi", new { id = bill.Bid }, bill);
            }
        }
    }
}
