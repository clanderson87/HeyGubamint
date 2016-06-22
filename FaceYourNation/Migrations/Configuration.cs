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
                  new Issue { Name = "economy", PresPositionURL = "https://www.whitehouse.gov/economy"},
                  new Issue { Name = "education", PresPositionURL = "https://www.whitehouse.gov/education" },
                  new Issue { Name = "energy and environment", PresPositionURL = "https://www.whitehouse.gov/energy" },
                  new Issue { Name = "immigration", PresPositionURL = "https://www.whitehouse.gov/immigration" },
                  new Issue { Name = "health care", PresPositionURL = "https://www.whitehouse.gov/healthreform" },
                  new Issue { Name = "iran deal", },
                  new Issue { Name = "civil rights" },
                  new Issue { Name = "defense" },
                  new Issue { Name = "disibilities" },
                  new Issue { Name = "equal pay" },
                  new Issue { Name = "ethics" },
                  new Issue { Name = "homeland security" },
                  new Issue { Name = "reducing gun violence" },
                  new Issue { Name = "service" },
                  new Issue { Name = "rural" },
                  new Issue { Name = "seniors and social security" },
                  new Issue { Name = "taxes" },
                  new Issue { Name = "technology" },
                  new Issue { Name = "trade" },
                  new Issue { Name = "urban and economic mobility" },
                  new Issue { Name = "veterans" },
                  new Issue { Name = "women" },
                  new Issue { Name = "scotus nomination" },
                  new Issue { Name = "criminal justice reform" },
                  new Issue { Name = "the record" },
                  new Issue { Name = "cuba" },
                  new Issue { Name = "21st century policing" },
                  new Issue { Name = "fiscal responsibility" },
                  new Issue { Name = "violence prevention" }
                );

            context.Bills.AddOrUpdate(
                b => b.Name,
                new Bill { Name = "Stop Mass Killings By Violent Terrorists Act", theBill = "https://www.govtrack.us/congress/bills/114/hr5470/text", HouseID = "hr5470" },
                new Bill { Name = "Countering Terrorist Radicalization Act", theBill = "https://www.govtrack.us/congress/bills/114/hr5471/text", HouseID = "hr5471" },
                new Bill { Name = "Smarter Sentancing Act of 2015", theBill = "https://www.govtrack.us/congress/bills/114/s502/text", SenateID = "s502" },
                new Bill { Name = "Pilot's Bill of Rights", theBill = "https://www.govtrack.us/congress/bills/114/hr1062/text", HouseID = "hr1062", SenateID = "s571" },
                new Bill { Name = "Commerce, Justice, Science, and Related Agencies Appropriations Act, 2016", theBill = "https://www.govtrack.us/congress/bills/114/hr2578/text", HouseID = "hr2578" },
                new Bill { Name = "Separation of Powers Restoration Act of 2016", theBill = "https://www.govtrack.us/congress/bills/114/hr4768/text", HouseID = "hr4768" },
                new Bill { Name = "Restoring Access to Medication Act of 2015", theBill = "https://www.govtrack.us/congress/bills/114/hr1270/text", HouseID = "hr1270" }
            );

            context.Votes.AddOrUpdate(
                v => v.issue_name,
                new Vote { District = "tn5", issue_name = "economy", video_id = "9bZkp7q19f0" },
                new Vote { District = "tn5", issue_name = "education", video_id = "74Wei0-vAZs" },
                new Vote { District = "tn5", issue_name = "iran deal", video_id = "CmoERR3kSa4" },
                new Vote { District = "tn5", issue_name = "energy and environment", video_id = "TfkUKb6IGFE" },
                new Vote { District = "tn5", issue_name = "immigration", video_id = "c0rK2bLTimQ" }
            );
        }
    }
}
