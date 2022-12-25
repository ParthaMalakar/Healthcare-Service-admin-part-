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
    public class AdminService
    {
        public static List<AdminDTO> Get()
        {

            var data = DataAccessFactory.AdminDataAccess().Get();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Admin, AdminDTO>();
            });
            var mapper = new Mapper(config);
            var converted = mapper.Map<List<AdminDTO>>(data);
            return converted;
        }
        public static AdminDTO Get(int id)
        {
            var data = DataAccessFactory.AdminDataAccess().Get(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Admin, AdminDTO>();
            });
            var mapper = new Mapper(config);
            var converted = mapper.Map<AdminDTO>(data);
            return converted;
        }
        public static AdminDTO Add(AdminDTO obj)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AdminDTO, Admin>();
                cfg.CreateMap<Admin, AdminDTO>();
            });
            var mapper = new Mapper(config);
            var converted = mapper.Map<Admin>(obj);
            User_Table AD = new User_Table()
            {
                Admin_Name = obj.Name,
                Email = obj.Email,
                Password = obj.Password,
                User_Type = "Admin"
            };
            DataAccessFactory.UserDataAccess().Add(AD);
            var rs = DataAccessFactory.AdminDataAccess().Add(converted);
            var rtrs = mapper.Map<AdminDTO>(rs);
            return rtrs;
        }
        public static AdminDTO Update(AdminDTO obj)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AdminDTO, Admin>();
                cfg.CreateMap<Admin, AdminDTO>();
            });
            var mapper = new Mapper(config);
            var converted = mapper.Map<Admin>(obj);
            var rs = DataAccessFactory.AdminDataAccess().Update(converted);
            var rtrs = mapper.Map<AdminDTO>(rs);
            return rtrs;
        }
        public static bool Delete(int id)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AdminDTO, Admin>();
                cfg.CreateMap<Admin, AdminDTO>();
            });
            return DataAccessFactory.AdminDataAccess().Delete(id);
        }
        public static int GetByEmail(string id)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AdminDTO, Admin>();
                cfg.CreateMap<Admin, AdminDTO>();
            });
            return DataAccessFactory.GetbyemailADDataAccess().GetByEmail(id);
        }

    }
}
