using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AuthService
    {
        public static TokenDTO Authenticate(string username, string password)
        {
            var data = DataAccessFactory.AuthDataAccess().Authenticate(username, password);
            if (data != null)
            {
                TokenDTO tokenModel = new TokenDTO()
                {
                    Id = data.Id,
                    User_Id = data.User_Id,
                    Token1 = data.Token1,
                    Token_CreatedAt = data.Token_CreatedAt,
                    Token_ExpiredAt = data.Token_ExpiredAt
                };
                return tokenModel;
            }
            return null;
        }
        public static bool CheckValidityToken(string token)
        {
            var authCheck = DataAccessFactory.AuthDataAccess().IsAuthenticate(token);
            return authCheck;
        }
        public static bool Logout(int uid)
        {
            var logout = DataAccessFactory.AuthDataAccess().Logout(uid);
            return logout;
        }
    }

}

