using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class DonateMoneyRepo : IRepo<Donate_Money, int, Donate_Money>
    {
        HealthcareEntities1 db;
        internal DonateMoneyRepo()
        {
            db = new HealthcareEntities1();
        }
        public Donate_Money Add(Donate_Money obj)
        {
            db.Donate_Money.Add(obj);
            if (db.SaveChanges() > 0)
            {
                return obj;
            }
            return null;
        }

        public bool Delete(int id)
        {
            var dbobj = Get(id);
            db.Donate_Money.Remove(dbobj);
            return db.SaveChanges() > 0;
        }

        public List<Donate_Money> Get()
        {
            return db.Donate_Money.ToList();
        }

        public Donate_Money Get(int id)
        {
            return db.Donate_Money.Find(id);
        }

        public Donate_Money Update(Donate_Money obj)
        {
            var dbobbj = db.Donate_Money.Find(obj.Transaction_Id);
            db.Entry(dbobbj).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
