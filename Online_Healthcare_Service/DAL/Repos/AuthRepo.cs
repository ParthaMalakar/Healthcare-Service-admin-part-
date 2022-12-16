using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class AuthRepo : IAuth
    {
        HealthcareEntities1 db;
        internal AuthRepo()
        {
            db = new HealthcareEntities1();
        }

        public Token Authenticate(string username, string password)
        {
            var u = db.User_Table.FirstOrDefault(e => e.Name == username && e.Password == password);
            if (u != null)
            {
                var g = Guid.NewGuid();
                var token = g.ToString();
                var t = new Token()
                {
                    User_Id = u.Id,
                    Token1 = token,
                    Token_CreatedAt = DateTime.Now,
                    Token_ExpiredAt = DateTime.Now.AddMinutes(10)
                };
                db.Tokens.Add(t);
                db.SaveChanges();
                return t;
            }
            else
            {
                return null;
            }
        }

        public bool IsAuthenticate(string token)
        {
            var ac_token = db.Tokens.FirstOrDefault(e => e.Token1.Equals(token) && e.Token_ExpiredAt == null);
            if (ac_token != null)
            {
                return true;
            }
            return false;
        }

        public bool Logout(int id)
        {
            var data = db.Tokens.FirstOrDefault(e => e.User_Id == id);
            if (data != null)
            {
                db.Tokens.Remove(data);
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
