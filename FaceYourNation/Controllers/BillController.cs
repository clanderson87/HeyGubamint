using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FaceYourNation.Models;
using FaceYourNation.DAL;

namespace FaceYourNation.Controllers
{
    [Route("api/[controller]")]
    public class BillController : ApiController
    {
        HGRepo Repo = new HGRepo();

        // GET: api/Bill
        public IEnumerable<Bill> Get()
        {
            return Repo.GetBills();
        }

        // GET: api/Bill/5
        public Bill Get(string id)
        {
            return Repo.GetBill(id);
        }
        
        //GET: api/Bill
        public PositionResult Get(string _dis, string _house = "", string _senate = "")
        {
            return Repo.GetBillPublicPosition(dis: _dis, senate: _senate, house: _house);
        }

        // POST: api/Bill
        public void Post(string name, string billUrl, string houseID = "", string senateID = "", bool _pres_support = false)
        {
            Repo.AddBill(name: name, the_bill: billUrl, house: houseID, senate: senateID, pres_support: _pres_support);
        }

        // POST: api/Bill
        public void Post(string _vid, string _dis, bool support, string houseID = "", string senateID = "", int _import = 5)
        {
            Repo.AddBillPosition(vid: _vid, dis: _dis, _bool: support, house: houseID, senate: senateID, import: _import);
        }
    }
}
