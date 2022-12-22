using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserNameService
    {
        public static string Get(string auth)
        {
            return DataAccessFactory.UserDataAccess().Get(DataAccessFactory.TokenDataAccess().Get(auth).User_Id).Email;
        }
    }
}
