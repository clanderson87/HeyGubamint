using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FaceYourNation.Models
{
    public class Issue
    {
        [Key]
        public string Iid { get; set; }
        public string Name { get; set; }
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
            if (Legislation == null)
            {
                Legislation = new List<Bill> { bill };
            }
            else
            {
                for (int i = 0; i < Legislation.Count; i++)
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

        public void AddPresidentialPositionURL(string url)
        {
            string whgov = "whitehouse.gov/issues/" + Name; //this is hard-coded by the Obama Administration's url naming schemes. This naming scheme could change under HillTrump. Be advised.
            if ((PresPositionURL == null) && (url.Contains(whgov) == true))
            {
                PresPositionURL = url;
                return;
            }
            else if ((PresPositionURL == null))
            {
                throw new ArgumentException("Please enter a valid 'whitehouse.gov/issues/' URL");
            }
            
            if (PresPositionURL.Contains(whgov))
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