using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class AppointmentRepo : IRepo<Appointment, int, Appointment>
    {
        HealthcareEntities db;
        internal AppointmentRepo()
        {
            db = new HealthcareEntities();
        }
        public Appointment Add(Appointment obj)
        {
            db.Appointments.Add(obj);
            if (db.SaveChanges() > 0)
            {
                return obj;
            }
            return null;
        }

        public bool Delete(int id)
        {
            var dbobj = Get(id);
            db.Appointments.Remove(dbobj);
            return db.SaveChanges() > 0;
        }

        public List<Appointment> Get()
        {
            return db.Appointments.ToList();
        }

        public Appointment Get(int id)
        {
            return db.Appointments.Find(id);
        }

        public Appointment Update(Appointment obj)
        {
            var dbobbj = db.Appointments.Find(obj.Id);
            db.Entry(dbobbj).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
