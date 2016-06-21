using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FaceYourNation.Models;

namespace FaceYourNation.Tests.Models
{
    [TestClass]
    public class BillTest
    {
        [TestMethod]
        public void BillEnsureICanCreateAnInstance()
        {
            Bill bill = new Bill();
            Assert.IsNotNull(bill);
        }

        [TestMethod]
        public void BillEnsureICanLogSupport()
        {
            Vote vote = new Vote();
            Bill bill = new Bill();
            bill.AddVote(vote);
        }
    }
}
