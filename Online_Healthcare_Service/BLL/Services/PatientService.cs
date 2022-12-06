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
    public class PatientService
    {
        public static List<PatientDTO> Get()
        {
            //return new List<PatientDTO>();
            var data = DataAccessFactory.PatientDataAccess().Get();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Patient, PatientDTO>();
            });
            var mapper = new Mapper(config);
            var converted = mapper.Map<List<PatientDTO>>(data);
            return converted;
        }
        public static PatientDTO Get(int id)
        {
            var data = DataAccessFactory.PatientDataAccess().Get(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Patient, PatientDTO>();
            });
            var mapper = new Mapper(config);
            var converted = mapper.Map<PatientDTO>(data);
            return converted;
        }
        public static PatientDTO Add(PatientDTO obj)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PatientDTO, Patient>();
                cfg.CreateMap<Patient, PatientDTO>();
            });
            var mapper = new Mapper(config);
            var converted = mapper.Map<Patient>(obj);
            var rs = DataAccessFactory.PatientDataAccess().Add(converted);
            var rtrs = mapper.Map<PatientDTO>(rs);
            return rtrs;
        }
        public static PatientDTO Update(PatientDTO obj)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PatientDTO, Patient>();
                cfg.CreateMap<Patient, PatientDTO>();
            });
            var mapper = new Mapper(config);
            var converted = mapper.Map<Patient>(obj);
            var rs = DataAccessFactory.PatientDataAccess().Update(converted);
            var rtrs = mapper.Map<PatientDTO>(rs);
            return rtrs;
        }
        public static bool Delete(int id)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PatientDTO, Patient>();
                cfg.CreateMap<Patient, PatientDTO>();
            });
            return DataAccessFactory.PatientDataAccess().Delete(id);
        }
    }
}
