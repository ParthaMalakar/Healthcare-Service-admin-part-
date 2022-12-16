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
    public class PrescriptionService
    {
        public static List<PrescriptionDTO> Get()
        {

            var data = DataAccessFactory.PrescriptionDataAccess().Get();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Prescription, PrescriptionDTO>();
            });
            var mapper = new Mapper(config);
            var converted = mapper.Map<List<PrescriptionDTO>>(data);
            return converted;
        }
        public static PrescriptionDTO Get(int id)
        {
            var data = DataAccessFactory.PrescriptionDataAccess().Get(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Prescription, PrescriptionDTO>();
            });
            var mapper = new Mapper(config);
            var converted = mapper.Map<PrescriptionDTO>(data);
            return converted;
        }
        public static PrescriptionDTO Add(PrescriptionDTO obj)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PrescriptionDTO, Prescription>();
                cfg.CreateMap<Prescription, PrescriptionDTO>();
            });
            var mapper = new Mapper(config);
            var converted = mapper.Map<Prescription>(obj);
            var rs = DataAccessFactory.PrescriptionDataAccess().Add(converted);
            var rtrs = mapper.Map<PrescriptionDTO>(rs);
            return rtrs;
        }
        public static PrescriptionDTO Update(PrescriptionDTO obj)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PrescriptionDTO, Prescription>();
                cfg.CreateMap<Prescription, PrescriptionDTO>();
            });
            var mapper = new Mapper(config);
            var converted = mapper.Map<Prescription>(obj);
            var rs = DataAccessFactory.PrescriptionDataAccess().Update(converted);
            var rtrs = mapper.Map<PrescriptionDTO>(rs);
            return rtrs;
        }
        public static bool Delete(int id)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PrescriptionDTO, Prescription>();
                cfg.CreateMap<Prescription, PrescriptionDTO>();
            });
            return DataAccessFactory.PrescriptionDataAccess().Delete(id);
        }


        public static List<PrescriptionDTO> GetByPid(int id)
        {
            //return new List<AppointmentDTO>();
            var data = DataAccessFactory.PrescriptionIdDataAccess().GetByPid(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Prescription, PrescriptionDTO>();
            });
            var mapper = new Mapper(config);
            var converted = mapper.Map<List<PrescriptionDTO>>(data);
            return converted;
        }

    }
}
