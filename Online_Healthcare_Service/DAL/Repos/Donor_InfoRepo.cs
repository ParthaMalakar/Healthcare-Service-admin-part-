using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class Donor_InfoRepo : IRepo<Donar_Info, int, Donar_Info>
    {
        HealthcareEntities db;

        internal Donor_InfoRepo()
        {
            db = new HealthcareEntities();
        }
        public Donar_Info Add(Donar_Info obj)
        {
            db.Donar_Info.Add(obj);
            if (db.SaveChanges() > 0)
            {
                return obj;
            }
            return null;
        }

        public bool Delete(int id)
        {
            var dbobj = Get(id);
            db.Donar_Info.Remove(dbobj);
            return db.SaveChanges() > 0;
        }

        public List<Donar_Info> Get()
        {
            return db.Donar_Info.ToList();
        }

        public Donar_Info Get(int id)
        {
            return db.Donar_Info.Find(id);
        }

        public Donar_Info Update(Donar_Info obj)
        {
            var dbobbj = db.Donar_Info.Find(obj.Id);
            db.Entry(dbobbj).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
