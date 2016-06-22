namespace FaceYourNation.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using FaceYourNation.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<FaceYourNation.DAL.HGContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "FaceYourNation.DAL.HGContext";
        }

        protected override void Seed(FaceYourNation.DAL.HGContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
                context.Issues.AddOrUpdate(
                  i => i.Name,
                  new Issue { Iid = "i1", Name = "economy", PresPositionURL = "https://www.whitehouse.gov/economy"},
                  new Issue { Iid = "i2", Name = "education", PresPositionURL = "https://www.whitehouse.gov/education" },
                  new Issue { Iid = "i3", Name = "energy and environment", PresPositionURL = "https://www.whitehouse.gov/energy" },
                  new Issue { Iid = "i4", Name = "immigration", PresPositionURL = "https://www.whitehouse.gov/immigration" },
                  new Issue { Iid = "i5", Name = "health care", PresPositionURL = "https://www.whitehouse.gov/healthreform" }
                );

            context.Bills.AddOrUpdate(
                b => b.Name,
                new Bill { Bid = 1, Name = "Stop Mass Killings By Violent Terrorists Act", theBill = "https://www.govtrack.us/congress/bills/114/hr5470/text", HouseID = "hr5470" },
                new Bill { Bid = 2, Name = "Countering Terrorist Radicalization Act", theBill = "https://www.govtrack.us/congress/bills/114/hr5471/text", HouseID = "hr5471" },
                new Bill { Bid = 3, Name = "Smarter Sentancing Act of 2015", theBill = "https://www.govtrack.us/congress/bills/114/s502/text", SenateID = "s502" },
                new Bill { Bid = 4, Name = "Pilot's Bill of Rights", theBill = "https://www.govtrack.us/congress/bills/114/hr1062/text", HouseID = "hr1062", SenateID = "s571" },
                new Bill { Bid = 5, Name = "Commerce, Justice, Science, and Related Agencies Appropriations Act, 2016", theBill = "https://www.govtrack.us/congress/bills/114/hr2578/text", HouseID = "hr2578" },
                new Bill { Bid = 6, Name = "Separation of Powers Restoration Act of 2016", theBill = "https://www.govtrack.us/congress/bills/114/hr4768/text", HouseID = "hr4768" },
                new Bill { Bid = 7, Name = "Restoring Access to Medication Act of 2015", theBill = "https://www.govtrack.us/congress/bills/114/hr1270/text", HouseID = "hr1270" }
            );

            context.Votes.AddOrUpdate(
                v => v.issue_name,
                new Vote { vID = "v1", District = "tn5", issue_name = "economy", video_id = "9bZkp7q19f0" },
                new Vote { vID = "v2", District = "tn5", issue_name = "education", video_id = "74Wei0-vAZs" },
                new Vote { vID = "v3", District = "tn11", issue_name = "health care", video_id = "CmoERR3kSa4" },
                new Vote { vID = "v4", District = "tn5", issue_name = "energy and environment", video_id = "TfkUKb6IGFE" },
                new Vote { vID = "v5", District = "tn5", issue_name = "immigration", video_id = "c0rK2bLTimQ" }
            );
        }
    }
}
