using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class AdminTokenRepo : IRepo<Token_Admin, string, Token_Admin>
    {
        HealthcareEntities db;
        internal AdminTokenRepo()
        {
            db = new HealthcareEntities();
        }
        public Token_Admin Add(Token_Admin obj)
        {
            db.Token_Admin.Add(obj);
            if (db.SaveChanges() > 0)
            {
                return obj;
            }
            return null;
        }

        public bool Delete(string id)
        {
            throw new NotImplementedException();
        }

        public List<Token_Admin> Get()
        {
            throw new NotImplementedException();
        }

        public Token_Admin Get(string id)
        {
            return db.Token_Admin.FirstOrDefault(t => t.Token.Equals(id));
        }

        public Token_Admin Update(Token_Admin obj)
        {
            var dbtk = Get(obj.Token);
            db.Entry(dbtk).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
    }
