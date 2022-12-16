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
    public class UserService
    {
        public static List<UserDTO> Get()
        {
            //return new List<UserDTO>();
            var data = DataAccessFactory.UserDataAccess().Get();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User_Table, UserDTO>();
            });
            var mapper = new Mapper(config);
            var converted = mapper.Map<List<UserDTO>>(data);
            return converted;
        }
        public static UserDTO Get(int id)
        {
            var data = DataAccessFactory.UserDataAccess().Get(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User_Table, UserDTO>();
                // cfg.CreateMap<Hospital, HospitalDTO>();
            });
            var mapper = new Mapper(config);
            var converted = mapper.Map<UserDTO>(data);
            return converted;
        }
        public static UserDTO Add(UserDTO obj)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserDTO, User_Table>();
                cfg.CreateMap<User_Table, UserDTO>();
            });
            var mapper = new Mapper(config);
            var converted = mapper.Map<User_Table>(obj);
            var rs = DataAccessFactory.UserDataAccess().Add(converted);
            var rtrs = mapper.Map<UserDTO>(rs);
            return rtrs;
        }
        public static UserDTO Update(UserDTO obj)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserDTO, User_Table>();
                cfg.CreateMap<User_Table, UserDTO>();
            });
            var mapper = new Mapper(config);
            var converted = mapper.Map<User_Table>(obj);
            var rs = DataAccessFactory.UserDataAccess().Update(converted);
            var rtrs = mapper.Map<UserDTO>(rs);
            return rtrs;
        }
        public static bool Delete(int id)
        {
            return DataAccessFactory.UserDataAccess().Delete(id);
        }
    
}
}
