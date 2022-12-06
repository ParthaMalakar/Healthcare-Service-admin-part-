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
    public class AppointmentService
    {
        public static List<AppointmentDTO> Get()
        {
            //return new List<AppointmentDTO>();
            var data = DataAccessFactory.AppointmentDataAccess().Get();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Appointment, AppointmentDTO>();
            });
            var mapper = new Mapper(config);
            var converted = mapper.Map<List<AppointmentDTO>>(data);
            return converted;
        }
        public static AppointmentDTO Get(int id)
        {
            var data = DataAccessFactory.AppointmentDataAccess().Get(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Appointment, AppointmentDTO>();
            });
            var mapper = new Mapper(config);
            var converted = mapper.Map<AppointmentDTO>(data);
            return converted;
        }
        public static AppointmentDTO Add(AppointmentDTO obj)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AppointmentDTO, Appointment>();
                cfg.CreateMap<Appointment, AppointmentDTO>();
            });
            var mapper = new Mapper(config);
            var converted = mapper.Map<Appointment>(obj);
            var rs = DataAccessFactory.AppointmentDataAccess().Add(converted);
            var rtrs = mapper.Map<AppointmentDTO>(rs);
            return rtrs;
        }
        public static AppointmentDTO Update(AppointmentDTO obj)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AppointmentDTO, Appointment>();
                cfg.CreateMap<Appointment, AppointmentDTO>();
            });
            var mapper = new Mapper(config);
            var converted = mapper.Map<Appointment>(obj);
            var rs = DataAccessFactory.AppointmentDataAccess().Update(converted);
            var rtrs = mapper.Map<AppointmentDTO>(rs);
            return rtrs;
        }
        public static bool Delete(int id)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AppointmentDTO, Appointment>();
                cfg.CreateMap<Appointment, AppointmentDTO>();
            });
            return DataAccessFactory.AppointmentDataAccess().Delete(id);
        }
    }
}
