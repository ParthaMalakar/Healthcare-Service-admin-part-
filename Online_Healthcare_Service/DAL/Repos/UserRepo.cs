using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class UserRepo : IRepo<User_Table, int, User_Table>
    {
        HealthcareEntities1 db;
        internal UserRepo()
        {
            db = new HealthcareEntities1();
        }
        public User_Table Add(User_Table obj)
        {
            db.User_Table.Add(obj);



            db.SaveChanges();
            return obj;
        }

        public bool Delete(int id)
        {
            db.User_Table.Remove(db.User_Table.Find(id));
            return db.SaveChanges() > 0;
        }

        public List<User_Table> Get()
        {
            return db.User_Table.ToList();
        }

        public User_Table Get(int id)
        {
            return db.User_Table.Find(id);
        }

        public User_Table Update(User_Table obj)
        {
            var ext = db.User_Table.Find(obj.Id);
            db.Entry(ext).CurrentValues.SetValues(obj);
            db.SaveChanges();
            return obj;
        }
    }
}
