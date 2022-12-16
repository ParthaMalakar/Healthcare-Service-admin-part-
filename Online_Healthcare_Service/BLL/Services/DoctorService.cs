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
    public class DoctorService
    {
        public static List<DoctorDTO> Get()
        {
            //return new List<DoctorDTO>();
            var data = DataAccessFactory.DoctorDataAccess().Get();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Doctor, DoctorDTO>();
            });
            var mapper = new Mapper(config);
            var converted = mapper.Map<List<DoctorDTO>>(data);
            return converted;
        }
        public static DoctorDTO Get(int id)
        {
            var data = DataAccessFactory.DoctorDataAccess().Get(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Doctor, DoctorDTO>();
               // cfg.CreateMap<Hospital, HospitalDTO>();
            });
            var mapper = new Mapper(config);
            var converted = mapper.Map<DoctorDTO>(data);
            return converted;
        }
        public static DoctorDTO Add(DoctorDTO obj)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DoctorDTO, Doctor>();
                cfg.CreateMap<Doctor, DoctorDTO>();
            });
            var mapper = new Mapper(config);
            var converted = mapper.Map<Doctor>(obj);
            var rs = DataAccessFactory.DoctorDataAccess().Add(converted);
            var rtrs = mapper.Map<DoctorDTO>(rs);
            return rtrs;
        }
        public static DoctorDTO Update(DoctorDTO obj)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DoctorDTO, Doctor>();
                cfg.CreateMap<Doctor, DoctorDTO>();
            });
            var mapper = new Mapper(config);
            var converted = mapper.Map<Doctor>(obj);
            var rs = DataAccessFactory.DoctorDataAccess().Update(converted);
            var rtrs = mapper.Map<DoctorDTO>(rs);
            return rtrs;
        }
        public static bool Delete(int id)
        {       
            return DataAccessFactory.DoctorDataAccess().Delete(id);
        }
    }
    }
