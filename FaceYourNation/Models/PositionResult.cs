using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FaceYourNation.Models
{
    public class PositionResult
    {
        public string Issue_Name { get; set; }
        public string House_Id { get; set; }
        public string SenateId { get; set; }
        public string District { get; set; }
        public int For { get; set; }
        public int Against { get; set; }
        public double AvgImportance { get; set; }
        public string VideoId { get; set; }
    }
}