using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FaceYourNation.Models
{
    public class Bill
    {
        [Key]
        public int Bid { get; set; }
        public string Name { get; set; } //the title of the bill
        public string HouseID { get; set; } //House ID number
        public string SenateID { get; set; } //Senate ID Number
        public bool PresidentialSupport { get; set; } //if the sitting President supports this
        public List<Vote> PublicPosition { get; set; } //List of the public's votes.

        [Required]
        public string theBill { get; set; } //a link to the Bill
        

        public void AddVote(Vote vote)
        {
            if (PublicPosition == null)
            {
                PublicPosition = new List<Vote>();
                PublicPosition.Add(vote);
            }
            else
            {
                if (PublicPosition.Exists(v => v.VoteId == vote.VoteId))
                {
                    return;
                }
                PublicPosition.Add(vote);
            }
        }
    }
}