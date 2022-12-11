using AutoMapper;
using BLL.DTOs;
using DAL.EF;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    internal class AuthService
    {
        public static Token_AdminDTO Authenticate(int uname, string pass)
        {
            var rs = DataAccessFactory.AuthDataAccess().Authenticate(uname, pass);
            if (rs)
            {
                var tk = new Token_Admin();
                tk.A_Id = uname;
                tk.Token_CreatedAt = DateTime.Now;
                tk.Token_ExpiredAt = null;
                tk.Token = Guid.NewGuid().ToString();
                var rt = DataAccessFactory.TokenDataAccess().Add(tk);
                if (rt != null)
                {
                    var config = new MapperConfiguration(cfg => {
                        cfg.CreateMap<Token_Admin, Token_AdminDTO>();
                    });
                    var mapper = new Mapper(config);
                    var data = mapper.Map<Token_AdminDTO>(rt);
                    return data;
                }
            }
            return null;
        }

        public static bool IsTokenValid(string token)
        {
            var tk = DataAccessFactory.TokenDataAccess().Get(token);
            if (tk != null && tk.Token_ExpiredAt == null)
            {
                return true;
            }
            return false;

        }

    }
}
