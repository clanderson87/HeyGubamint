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
        Mock<DbSet<ApplicationUser>> mock_users_table { get; set; }
        IQueryable<ApplicationUser> users_data { get; set; }
        List<ApplicationUser> users_datasource { get; set; }

        //Bill Mocks
        Mock<DbSet<Bill>> mock_bills_table { get; set; }
        IQueryable<Bill> bills_data { get; set; }
        List<Bill> bills_datasource { get; set; }
        
        //Issue Mocks
        Mock<DbSet<Issue>> mock_issues_table { get; set; }
        IQueryable<Issue> issues_data { get; set; }
        List<Issue> issues_datasource { get; set; }
        
        //Votes Mocks
        Mock<DbSet<Vote>> mock_votes_table { get; set; }
        IQueryable<Vote> votes_data { get; set; }
        List<Vote> votes_datasource { get; set; }


        [TestInitialize]
        public void Initialize()
        {
            mock_bills_table = new Mock<DbSet<Bill>>();
            mock_issues_table = new Mock<DbSet<Issue>>();
            mock_users_table = new Mock<DbSet<ApplicationUser>>();
            mock_votes_table = new Mock<DbSet<Vote>>();

            mock_context = new Mock<HGContext>();
            Repo = new HGRepo(mock_context.Object);

            bills_datasource = new List<Bill>();
            issues_datasource = new List<Issue>();
            users_datasource = new List<ApplicationUser>();
            votes_datasource = new List<Vote>();

            bills_data = bills_datasource.AsQueryable();
            issues_data = issues_datasource.AsQueryable();
            users_data = users_datasource.AsQueryable();
            votes_data = votes_datasource.AsQueryable();
        }

        [TestCleanup]
        public void Cleanup()
        {
            bills_datasource = null;
            issues_datasource = null;
            users_datasource = null;
            votes_datasource = null;
        }
    }
}
