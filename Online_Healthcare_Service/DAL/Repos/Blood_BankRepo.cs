using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class Blood_BankRepo : IRepo<Blood_Bank, int, Blood_Bank>
    {
        HealthcareEntities db;
        internal Blood_BankRepo()
        {
            db = new HealthcareEntities();
        }
        public Blood_Bank Add(Blood_Bank obj)
        {
            db.Blood_Bank.Add(obj);
            if (db.SaveChanges() > 0)
            {
                return obj;
            }
            return null;
        }

      
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Blood_Bank> Get()
        {
            return db.Blood_Bank.ToList();
        }

        public Blood_Bank Get(int id)
        {
            return db.Blood_Bank.Find(id);
        }

        public Blood_Bank Update(Blood_Bank obj)
        {
            var dbobbj = db.Blood_Bank.Find(obj.Id);
            db.Entry(dbobbj).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
