using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FaceYourNation.Models;

namespace FaceYourNation.Tests.Models
{
	[TestClass]
	public class IssueTest
	{
		[TestMethod]
		public void IssueEnsureICanCreateAnInstance()
		{
            Issue iss = new Issue();
            Assert.IsNotNull(iss);
		}

        [TestMethod]
        public void IssueEnsureICanAddLegislation()
        {
            Bill bill = new Bill();
            bill.HouseID = "hr1234";
            Issue iss = new Issue();

            iss.AddLegislation(bill);
            iss.AddLegislation(bill);

            Assert.AreEqual(1, iss.Legislation.Count);
            Assert.AreEqual("hr1234", iss.Legislation[0].HouseID);
        }

        [TestMethod]
        public void IssueEnsureICanAddAPresidentialPosition()
        {
            Issue iss = new Issue();
            iss.Name = "CivilRights";

            iss.AddPresidentialPositionURL("whitehouse.gov/issues/CivilRights");

            Assert.AreEqual("whitehouse.gov/issues/CivilRights", iss.PresPositionURL);
        }
	}
}
