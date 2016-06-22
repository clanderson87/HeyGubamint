using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
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

        // POST: api/Bill
        [HttpPut]
        public void Put([FromUri]string name, [FromUri]string billUrl, [FromUri]string houseID = "", [FromUri]string senateID = "", [FromUri]bool _pres_support = false)
        {   
            Repo.AddBill(name: name, the_bill: billUrl, house: houseID, senate: senateID, pres_support: _pres_support);
        }

        // POST: api/Bill
        [HttpPost]
        public void Post(string _vid, string _dis, bool support, string houseID = "", string senateID = "", int _import = 5)
        {
            Repo.AddBillPosition(vid: _vid, dis: _dis, _bool: support, house: houseID, senate: senateID, import: _import);
        }
    }
}
