using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class AdminRepo : IRepo<Admin, int, Admin>,IAuth
    {

        HealthcareEntities db;
        internal AdminRepo()
        {
            db = new HealthcareEntities();
        }

        public Admin Add(Admin obj)
        {
            db.Admins.Add(obj);
            if (db.SaveChanges() > 0)
            {
                return obj;
            }
            return null;
        }

        public bool Delete(int id)
        {
            var dbobj = Get(id);
            db.Admins.Remove(dbobj);
            return db.SaveChanges() > 0;
        }

        public List<Admin> Get()
        {
            return db.Admins.ToList();
        }

        public Admin Get(int id)
        {
            return db.Admins.Find(id);
        }

        public Admin Update(Admin obj)
        {
            var dbobbj = db.Admins.Find(obj.Admin_Id);
            db.Entry(dbobbj).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
        public bool Authenticate(string uname, string pass)
        {
            var data = db.Admins.FirstOrDefault(u => u.Name.Equals(uname) && u.Password.Equals(pass));
            if (data != null) return true;
            return false;
        }
    }
}
