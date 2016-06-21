using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FaceYourNation.Models
{
    public class Issue
    {
        public string Name { get; set; }
        public string Iid { get; set; }
        public List<Vote> PublicPosition { get; set; }
        public string PresidentialPosition { get; set; }
        public string PresPositionURL { get; set; }
        public List<Bill> Legislation { get; set; }

        public void AddVote(Vote vote)
        {
            PublicPosition.Add(vote);
        }
        
        public void AddLegislation(Bill bill)
        { 
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

        public void AddPresidentialPosition(string url)
        {
            string pres_pos = PresidentialPosition;
            string pres_posURL = PresPositionURL;
            string whgov = "whitehouse.gov/issues/" + Name; //this is hard-coded by the Obama Administration's url naming schemes. This naming scheme could change under HillTrump. Be advised.
            if (pres_posURL.Contains(whgov))
            {
                return;
            }
            else
            {
                if (url.Contains(whgov)){
                    PresPositionURL = url;
                }
            }
        }
    }
}