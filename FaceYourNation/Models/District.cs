using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FaceYourNation.Models
{
    public class District
    {
        public string dID { get; set; } //ex: TN5, NY8, CA42, TX30
        public List<string> district_issue_ids { get; set; } //WhiteHouse Issues
        public List<string> district_bill_ids { get; set; } //Either the HouseId // SenateId
        public List<string> video_ids { get; set; }
    }
}