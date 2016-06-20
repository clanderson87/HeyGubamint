using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FaceYourNation.Models;
using System.Data.Entity;

namespace FaceYourNation.DAL
{
    public class HGRepo
    {
        public HGContext context { get; set; }
        public HGRepo()
        {
            context = new HGContext();
        }

        public HGRepo(HGContext _context)
        {
            context = _context;
        }

        private Issue GetIssueByName(string iss_name)
        {
            IQueryable<Issue> query =
                from issue in context.Issues
                where issue.Name == iss_name
                select issue;
            return query as Issue;
        }

        private Bill GetBillById(string id)
        {
            IQueryable<Bill> query =
                from bill in context.Bills
                where ((bill.HouseID == id) || (bill.SenateID == id))
                select bill;
            return query as Bill;
        }

        public void AddIssueSupport(string iss_name)
        {
            Issue iss = GetIssueByName(iss_name);
            iss.IncrementPublicSupport();
        }

        public void AddIssueOpposition(string iss_name)
        {
            Issue iss = GetIssueByName(iss_name);
            iss.IncrementPublicOpposition();
        }

        public string GetIssuePublicPosition(string iss_name)
        {
            Issue iss = GetIssueByName(iss_name);
            return "For: " + iss.PublicSupport.ToString() + "/ Against: " + iss.PublicOpposition.ToString();
        }

        public string GetIssuePresidentialPosition(string iss_name)
        {
            Issue iss = GetIssueByName(iss_name);
            return iss.PresidentialPosition;
        }

        public string GetIssuePresidentialURL(string iss_name)
        {
            Issue iss = GetIssueByName(iss_name);
            return iss.PresPositionURL;
        }

        public void SetIssuePresidentialPosition(string iss_name, string url)
        {
            Issue iss = GetIssueByName(iss_name);
            iss.AddPresidentialPosition(url);
        }

        public void AddBill(string name, string the_bill, string house = "", string senate = "", bool pres_support = false)
        {
            
            Bill bill = new Bill();
            bill.Name = name;
            bill.theBill = the_bill;
            if (house != "")
            {
                bill.HouseID = house;
                if (GetBillById(house) != null)
                {
                    bill = null;
                    return;
                }
            }
            if (senate != "")
            {
                bill.SenateID = senate;
                if (GetBillById(senate) != null)
                {
                    bill = null;
                    return;
                }
            }
            bill.PresidentialSupport = pres_support;
            context.Bills.Add(bill);
            context.SaveChanges();
        }

    }
}