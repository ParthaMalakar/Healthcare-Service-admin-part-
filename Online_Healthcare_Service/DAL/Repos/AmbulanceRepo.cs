using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class AmbulanceRepo : IRepo<Ambulance, int, Ambulance>
    {
        HealthcareEntities1 db;
        internal AmbulanceRepo()
        {
            db = new HealthcareEntities1();
        }
        public Ambulance Add(Ambulance obj)
        {
            db.Ambulances.Add(obj);
            if (db.SaveChanges() > 0)
            {
                return obj;
            }
            return null;
        }

        public bool Delete(int id)
        {
            var dbobj = Get(id);
            db.Ambulances.Remove(dbobj);
            return db.SaveChanges() > 0;
        }

        public List<Ambulance> Get()
        {
            return db.Ambulances.ToList();
        }

        public Ambulance Get(int id)
        {
            return db.Ambulances.Find(id);
        }

        public Ambulance Update(Ambulance obj)
        {
            var dbobbj = db.Ambulances.Find(obj.Id);
            db.Entry(dbobbj).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }


        
    }
}

