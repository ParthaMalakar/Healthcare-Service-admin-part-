using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class PrescriptionRepo : IRepo<Prescription, int, Prescription>,IGet<Prescription,int>
    {
        HealthcareEntities1 db;
        internal PrescriptionRepo()
        {
            db = new HealthcareEntities1();
        }
        public Prescription Add(Prescription obj)
        {
            db.Prescriptions.Add(obj);
            if (db.SaveChanges() > 0)
            {
                return obj;
            }
            return null;
        }

        public bool Delete(int id)
        {
            var dbobj = Get(id);
            db.Prescriptions.Remove(dbobj);
            return db.SaveChanges() > 0;
        }

        public List<Prescription> Get()
        {
            return db.Prescriptions.ToList();
        }

        public Prescription Get(int id)
        {
            return db.Prescriptions.Find(id);
        }

        public List<Prescription> GetByPid(int id)
        {
            var data = (from a in db.Prescriptions where a.Medicine_Id == id select a).ToList();
            return data;
        }

        public Prescription Update(Prescription obj)
        {
            var dbobbj = db.Prescriptions.Find(obj.Medicine_Id);
            db.Entry(dbobbj).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public List<Prescription> GetById(int id)
        {
            var data = (from a in db.Prescriptions where a.Medicine_Id == id select a).ToList();
            return data;
        }


    }
}
