using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FaceYourNation.Models
{
    public class Bill
    {
        public string Name { get; set; } //the title of the bill
        public string HouseID { get; set; } //House ID number
        public string SenateID { get; set; } //Senate ID Number
        public bool PresidentialSupport { get; set; } //if the sitting President supports this
        public int PublicSupport { get; set; } //the amount of public support
        public int PublicOpposition { get; set; } //the amount of public opposition
        public string theBill { get; set; } //a link to the Bill
    }
}