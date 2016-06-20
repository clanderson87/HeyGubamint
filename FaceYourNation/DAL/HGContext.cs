using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FaceYourNation.Models;
using System.Data.Entity;

namespace FaceYourNation.DAL
{
    public class HGContext : ApplicationDbContext
    {
        public virtual DbSet<Issue> Issues { get; set; }
        public virtual DbSet<Bill> Bills { get; set; }
    }
}