using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class AdminRepo : IRepo<Admin, int, Admin> , In_VarIRepo<Admin, string>, IGetbyemailI<int, string>
    {

        HealthcareEntities1 db;
        internal AdminRepo()
        {
            db = new HealthcareEntities1();
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

        public bool createVar(string email, string code)
        {
            var Ed = (from I in db.Admins where I.Email.Equals(email) select I).FirstOrDefault();

            if (Ed != null)
            {
                Ed.EmailValidation = code;
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
            return false;
        }

        public bool checkVar(string email, string code)
        {
            var Ed = (from I in db.Admins where I.Email.Equals(email) select I).FirstOrDefault();

            if (Ed != null)
            {
                if (Ed.EmailValidation.Equals(code))
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        public bool checkMail(string email)
        {
            var Ed = (from I in db.Admins where I.Email.Equals(email) && !I.EmailValidation.Equals("Yes") select I).FirstOrDefault();
            if (Ed != null)
            {
                return true;
            }
            return true;
        }

        public int GetByEmail(string id)
        {
            var data = (from a in db.Admins where a.Email == id select a).SingleOrDefault();

            return data.Admin_Id;
        }
    }
}
