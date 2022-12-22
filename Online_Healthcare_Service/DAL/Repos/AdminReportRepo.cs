using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class AdminReportRepo : IRepo_Admin<AdminReport, int>, IReport<AdminReport, string>
    {
        HealthcareEntities1 db;
        internal AdminReportRepo()
        {
            db = new HealthcareEntities1();
        }
        public bool Create(AdminReport obj)
        {
            db.AdminReports.Add(obj);
            var l = db.SaveChanges();
            if (l > 0)
            {
                return true;
            }
            return false;
        }

        public bool Delete(int ID)
        {
            var Report = Get(ID);
            db.AdminReports.Remove(Report);
            var l = db.SaveChanges();
            if (l > 0)
            {
                return true;
            }
            return false;
        }

        public List<AdminReport> Get()
        {

            return db.AdminReports.ToList();
        }

        public AdminReport Get(int ID)
        {
            return db.AdminReports.FirstOrDefault(s => s.ReportId.Equals(ID));
        }

        public List<AdminReport> recivedByEmails(String RC_email)
        {
            var REPO = (from I in db.AdminReports where I.Receiver.Equals(RC_email) select I).ToList();
            return REPO;

        }

        public List<AdminReport> sendByEmails(string SD_email)
        {
            var REPO = (from I in db.AdminReports where I.sender.Equals(SD_email) select I).ToList();
            return REPO;
        }

        public List<AdminReport> sortByIdDec()
        {
            var REPO = (from I in db.AdminReports orderby I.ReportId descending select I).ToList();
            return REPO;
        }

        public List<AdminReport> sortByIdInc()
        {
            var REPO = (from I in db.AdminReports orderby I.ReportId ascending select I).ToList();
            return REPO;
        }

        public bool Update(AdminReport Ads)
        {
            var RE = (from I in db.AdminReports where I.ReportId.Equals(Ads.ReportId) select I).FirstOrDefault();
            if (RE != null)
            {
                RE.sender = Ads.sender;
                RE.Receiver = Ads.Receiver;
                RE.Title = Ads.Title;
                RE.Description = Ads.Description;
                RE.Report_Time = Ads.Report_Time;
                RE.Status = Ads.Status;
            }
            try
            {
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
