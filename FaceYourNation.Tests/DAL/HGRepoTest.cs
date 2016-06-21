using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FaceYourNation.DAL;
using Moq;
using System.Collections.Generic; // For List<>
using FaceYourNation.Models;
using System.Linq; // For IQueryable and List.AsQueryable()
using System.Data.Entity; // For DbSet
namespace FaceYourNation.Tests.DAL
{
    [TestClass]
    public class HGRepoTest
    {
        Mock<HGContext> mock_context { get; set; }
        HGRepo Repo { get; set; }

        //Users Mocks
        Mock<DbSet<ApplicationUser>> mock_user_table { get; set; }
        IQueryable<ApplicationUser> user_data { get; set; }
        List<ApplicationUser> user_datasource { get; set; }

        //Bill Mocks
        Mock<DbSet<Bill>> mock_bill_table { get; set; }
        IQueryable<Bill> bill_data { get; set; }
        List<Bill> bill_datasource { get; set; }
        
        //Issue Mocks
        Mock<DbSet<Issue>> mock_issue_table { get; set; }
        IQueryable<Issue> issue_data { get; set; }
        List<Issue> issue_datasource { get; set; }
        
        //Votes Mocks
        Mock<DbSet<Vote>> mock_vote_table { get; set; }
        IQueryable<Vote> vote_data { get; set; }
        List<Vote> vote_datasource { get; set; }


        [TestInitialize]
        public void Initialize()
        {
            mock_bill_table = new Mock<DbSet<Bill>>();
            mock_issue_table = new Mock<DbSet<Issue>>();
            mock_user_table = new Mock<DbSet<ApplicationUser>>();
            mock_vote_table = new Mock<DbSet<Vote>>();

            mock_context = new Mock<HGContext>();
            Repo = new HGRepo(mock_context.Object);

            bill_datasource = new List<Bill>();
            issue_datasource = new List<Issue>();
            user_datasource = new List<ApplicationUser>();
            vote_datasource = new List<Vote>();

            bill_data = bill_datasource.AsQueryable();
            issue_data = issue_datasource.AsQueryable();
            user_data = user_datasource.AsQueryable();
            vote_data = vote_datasource.AsQueryable();
            
        }

         /*  Bill _bill = new Bill();
            _bill.Name = "BILL!";
            _bill.PresidentialSupport = true;
            _bill.HouseID = "hr1134";
            _bill.SenateID = "sr1234";
            _bill.theBill = "https://www.google.com";

            Issue _iss = new Issue();
            _iss.Name = "ISS NOT ISIS!";
            _iss.PresidentialPosition = "I Like Iss! - Obama";
            _iss.PresPositionURL = "https://www.nasa.gov";
            _iss.Legislation = { _bill };
            
            Vote _vote = new Vote();
            _vote.District = "TN5";
            _vote.house_id = "hr1134";
            _vote.senate_id = "sr1234";
            _vote.video_id = "abc123";

            Vote vote_2 = new Vote();
            vote_2.District = "NY8";
            vote_2.house_id = "hr9595";
            vote_2.senate_id = "sr0002";
            vote_2.video_id = "xyz987";

        */

        [TestCleanup]
        public void Cleanup()
        {
            bill_datasource = null;
            issue_datasource = null;
            user_datasource = null;
            vote_datasource = null;
        }

        void ConnectMocks()
        {
            mock_bill_table.As<IQueryable<Bill>>().Setup(p => p.GetEnumerator()).Returns(bill_data.GetEnumerator());
            mock_bill_table.As<IQueryable<Bill>>().Setup(p => p.ElementType).Returns(bill_data.ElementType);
            mock_bill_table.As<IQueryable<Bill>>().Setup(p => p.Expression).Returns(bill_data.Expression);
            mock_bill_table.As<IQueryable<Bill>>().Setup(p => p.Provider).Returns(bill_data.Provider);
            mock_bill_table.Setup(bill => bill.Add(It.IsAny<Bill>())).Callback((Bill bill) => bill_datasource.Add(bill));

            mock_issue_table.As<IQueryable<Issue>>().Setup(p => p.GetEnumerator()).Returns(issue_data.GetEnumerator());
            mock_issue_table.As<IQueryable<Issue>>().Setup(p => p.ElementType).Returns(issue_data.ElementType);
            mock_issue_table.As<IQueryable<Issue>>().Setup(p => p.Expression).Returns(issue_data.Expression);
            mock_issue_table.As<IQueryable<Issue>>().Setup(p => p.Provider).Returns(issue_data.Provider);
            mock_issue_table.Setup(issue => issue.Add(It.IsAny<Issue>())).Callback((Issue issue) => issue_datasource.Add(issue));

            mock_user_table.As<IQueryable<ApplicationUser>>().Setup(p => p.GetEnumerator()).Returns(user_data.GetEnumerator());
            mock_user_table.As<IQueryable<ApplicationUser>>().Setup(p => p.ElementType).Returns(user_data.ElementType);
            mock_user_table.As<IQueryable<ApplicationUser>>().Setup(p => p.Expression).Returns(user_data.Expression);
            mock_user_table.As<IQueryable<ApplicationUser>>().Setup(p => p.Provider).Returns(user_data.Provider);
            mock_user_table.Setup(user => user.Add(It.IsAny<ApplicationUser>())).Callback((ApplicationUser user) => user_datasource.Add(user));

            mock_vote_table.As<IQueryable<Vote>>().Setup(p => p.GetEnumerator()).Returns(vote_data.GetEnumerator());
            mock_vote_table.As<IQueryable<Vote>>().Setup(p => p.ElementType).Returns(vote_data.ElementType);
            mock_vote_table.As<IQueryable<Vote>>().Setup(p => p.Expression).Returns(vote_data.Expression);
            mock_vote_table.As<IQueryable<Vote>>().Setup(p => p.Provider).Returns(vote_data.Provider);
            mock_vote_table.Setup(vote => vote.Add(It.IsAny<Vote>())).Callback((Vote vote) => vote_datasource.Add(vote));

        }


    }
}
