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

        private void S()
        {
            context.SaveChanges();
        }

        private string san(string str) //sanitize the data
        {
            str = str.ToLower();
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '.') //remember to sanitize incoming data for things other than dots on frontend.
                {
                    str = str.Remove(i, 1);
                }
            }
            return str;
        }

        private Issue GetIssueByName(string iss_name)
        {
            iss_name = san(iss_name);
            IQueryable<Issue> query =
                from issue in context.Issues
                where issue.Name == iss_name
                select issue;
            return query as Issue;
        }

        private Bill GetBillById(string id)
        {
            id = san(id);
            IQueryable<Bill> query =
                from bill in context.Bills
                where ((bill.HouseID == id) || (bill.SenateID == id))
                select bill;
            return query as Bill;
        }

        private Vote SetVote(string dis, string vid, bool _bool)
        {
            dis = san(dis);
            Vote vote = new Vote();
            vote.District = dis;
            vote.video_id = vid;
            vote.LogPublicPosition(_bool);
            return vote;
        }

        public void AddIssuePosition(string iss_name, string dis, string vid, bool _bool)
        {
            iss_name = san(iss_name);
            dis = san(dis);
            Issue iss = GetIssueByName(iss_name);
            Vote vote = SetVote(dis, vid, _bool);
            vote.issue_name = iss_name;
            iss.AddVote(vote);
            S();
        }

        public int GetIssuePublicPosition(string iss_name, string dis = "")
        {
            iss_name = san(iss_name);
            Issue iss = GetIssueByName(iss_name);
            IQueryable<Vote> q = context.Votes.AsQueryable<Vote>();
            q.Where(v => v.issue_name == iss_name);
            if(dis != "")
            {
                dis = san(dis);
                q.Where(v => v.District == dis);
            }
            
            return q.Count();
        }

        public string GetIssuePresidentialPosition(string iss_name)
        {
            iss_name = san(iss_name);
            Issue iss = GetIssueByName(iss_name);
            return iss.PresidentialPosition;
        }

        public string GetIssuePresidentialURL(string iss_name)
        {
            iss_name = san(iss_name);
            Issue iss = GetIssueByName(iss_name);
            return iss.PresPositionURL;
        }

        public void SetIssuePresidentialPosition(string iss_name, string url)
        {
            iss_name = san(iss_name);
            Issue iss = GetIssueByName(iss_name);
            iss.AddPresidentialPosition(url);
            S();
        }

        public void AddBill(string name, string the_bill, string house = "", string senate = "", bool pres_support = false)
        {

            house = san(house);
            senate = san(senate);
            Bill bill = new Bill();
            bill.Name = name;
            bill.theBill = the_bill;
            if (house != "")
            {
                if (GetBillById(house) != null)
                {
                    bill = null;
                    return;
                }
                bill.HouseID = house;
            }
            if (senate != "")
            {
                if (GetBillById(senate) != null)
                {
                    bill = null;
                    return;
                }
                bill.SenateID = senate;
            }
            bill.PresidentialSupport = pres_support;
            context.Bills.Add(bill);
            S();
        }

        public int GetBillPublicPosition(string house = "", string senate = "", string dis = "")
        {
            IQueryable<Vote> q = context.Votes.AsQueryable<Vote>();
            if (house != "")
            {
                house = san(house);
                q.Where(v => v.house_id == house);
            }
            else if (senate != "")
            {
                senate = san(senate);
                q.Where(v => v.senate_id == senate);
            }
            else
            {
                throw new ArgumentException("Resolution not found. Please enter a valid House or Senate Resolution number. Ex: hr14202");
            }
            if (dis != "")
            {
                dis = san(dis);
                q.Where(v => v.District == dis);
            }
            return q.Count();
        }

        public void AddBillPosition(string vid, string dis, bool _bool, string house = "", string senate = "")
        {
            Bill bill = null;
            dis = san(dis);
            Vote vote = SetVote(dis, vid, _bool);
            if (house != "")
            {
                house = san(house);
                bill = GetBillById(house);
                vote.house_id = house;
            } else if (senate != "")
            {
                senate = san(senate);
                bill = GetBillById(senate);
                vote.senate_id = senate;
            }
            bill.AddVote(vote);
            S();
        }
    }
}