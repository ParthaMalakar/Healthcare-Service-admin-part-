using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class PatientFeedbackRepo : IRepo<PatientFeedback, int, PatientFeedback>
    {
        HealthcareEntities1 db;
        internal PatientFeedbackRepo()
        {
            db = new HealthcareEntities1();
        }
     

        public PatientFeedback Add(PatientFeedback obj)
        {
            db.PatientFeedbacks.Add(obj);
            if (db.SaveChanges() > 0)
            {
                return obj;
            }
            return null;
        }

        public bool Delete(int id)
        {
            var dbobj = Get(id);
            db.PatientFeedbacks.Remove(dbobj);
            return db.SaveChanges() > 0;
        }

        public List<PatientFeedback> Get()
        {
            return db.PatientFeedbacks.ToList();
        }

        public PatientFeedback Get(int id)
        {
            return db.PatientFeedbacks.Find(id);
        }

        public PatientFeedback Update(PatientFeedback obj)
        {
            var dbobbj = db.PatientFeedbacks.Find(obj.Id);
            db.Entry(dbobbj).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

    }
}
