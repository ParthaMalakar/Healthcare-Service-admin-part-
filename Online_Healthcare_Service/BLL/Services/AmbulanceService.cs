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
    public class AmbulanceService
    {
        public static List<AmbulanceDTO> Get()
        {
           
            var data = DataAccessFactory.AmbulanceDataAccess().Get();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Ambulance, AmbulanceDTO>();
            });
            var mapper = new Mapper(config);
            var converted = mapper.Map<List<AmbulanceDTO>>(data);
            return converted;
        }
        public static AmbulanceDTO Get(int id)
        {
            var data = DataAccessFactory.AmbulanceDataAccess().Get(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Ambulance, AmbulanceDTO>();
            });
            var mapper = new Mapper(config);
            var converted = mapper.Map<AmbulanceDTO>(data);
            return converted;
        }
        public static AmbulanceDTO Add(AmbulanceDTO obj)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AmbulanceDTO, Ambulance>();
                cfg.CreateMap<Ambulance, AmbulanceDTO>();
            });
            var mapper = new Mapper(config);
            var converted = mapper.Map<Ambulance>(obj);
            var rs = DataAccessFactory.AmbulanceDataAccess().Add(converted);
            var rtrs = mapper.Map<AmbulanceDTO>(rs);
            return rtrs;
        }
        public static AmbulanceDTO Update(AmbulanceDTO obj)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AmbulanceDTO, Ambulance>();
                cfg.CreateMap<Ambulance, AmbulanceDTO>();
            });
            var mapper = new Mapper(config);
            var converted = mapper.Map<Ambulance>(obj);
            var rs = DataAccessFactory.AmbulanceDataAccess().Update(converted);
            var rtrs = mapper.Map<AmbulanceDTO>(rs);
            return rtrs;
        }
        public static bool Delete(int id)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AmbulanceDTO, Ambulance>();
                cfg.CreateMap<Ambulance, AmbulanceDTO>();
            });
            return DataAccessFactory.AmbulanceDataAccess().Delete(id);
        }
        public static List<AmbulanceDTO> AGet()
        {
            var data = DataAccessFactory.ADataAccess().ActiveGet();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Ambulance, AmbulanceDTO>();
            });
            var mapper = new Mapper(config);
            var converted = mapper.Map<List<AmbulanceDTO>>(data);
            return converted;
        }
    }
}
