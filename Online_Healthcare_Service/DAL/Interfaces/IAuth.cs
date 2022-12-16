using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IAuth
    {
        Token Authenticate(string username, string password);
        bool IsAuthenticate(string token);

        bool Logout(int id);
    }
}

