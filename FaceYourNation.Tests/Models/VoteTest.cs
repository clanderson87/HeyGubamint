using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FaceYourNation.Models;

namespace FaceYourNation.Tests.Models
{
    [TestClass]
    public class VoteTest
    {

        [TestMethod]
        public void VoteEnsureICanCreateAnInstance()
        {
            Vote vote = new Vote();
            Assert.IsNotNull(vote);
        }

        [TestMethod]
        public void VoteEnsureICanLogSupport()
        {
            //Arrange
            Vote vote = new Vote();

            //Act
            vote.LogPublicSupport(true);

            //Assert
            Assert.AreEqual("For", vote.support);
        }
    }
}
