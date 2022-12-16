using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class TokenRepo : IRepo<Token, string, Token>
    {
        HealthcareEntities1 db;
        internal TokenRepo()
        {
            db = new HealthcareEntities1();
        }
        public Token Add(Token obj)
        {
            db.Tokens.Add(obj);
            if (db.SaveChanges() > 0)
            {
                return obj;
            }
            return null;
        }

        public bool Delete(string id)
        {
            var token = db.Tokens.Where(t => t.Token1 == id).SingleOrDefault();

            if (token == null)
            {
                return false;
            }

            db.User_Table.Attach(token.User_Table);

            return db.SaveChanges() > 0;
        }
    

        public List<Token> Get()
        {
            throw new NotImplementedException();
        }

        public Token Get(string id)
        {
            return db.Tokens.FirstOrDefault(t => t.Token1.Equals(id));
        }

        public Token Update(Token obj)
        {
            var dbtk = Get(obj.Token1);
            db.Entry(dbtk).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
