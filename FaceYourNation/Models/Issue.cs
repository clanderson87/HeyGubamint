using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FaceYourNation.Models
{
    public class Issue
    {
        public string Name { get; set; }
        public int PublicSupport { get; set; }
        public int PublicOpposition { get; set; }
        public string PresidentialPosition { get; set; }
        public string PresPositionURL { get; set; }
        public List<Bill> Legislation { get; set; }

        public void IncrementPublicSupport()
        {
            PublicSupport = PublicSupport + 1;
        }

        public void IncrementPublicOpposition()
        {
            PublicOpposition = PublicOpposition + 1;
        }
        
        public void AddLegislation(string str, string house = "", string senate = "", bool presidential = false)
        {
            Bill bill = new Bill();
            bill.Name = str;
            if (house != "")
            {
                bill.HouseID = house;
            }
            if (senate != "")
            {
                bill.SenateID = senate;
            }
            bill.PresidentialSupport = presidential;

            for (int i = 0; i < Legislation.Count(); i++)
            {
                var legis = Legislation[i];
                if ((legis.HouseID != bill.HouseID)
                    || (legis.SenateID != bill.SenateID))
                {
                    Legislation.Add(bill);
                }
            }
        }
    }
}