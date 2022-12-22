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
    public class BloodBankService
    {
        public static List<BloodBankDTO> Get()
        {
            
            var data = DataAccessFactory.BloodBankDataAccess().Get();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Blood_Bank, BloodBankDTO>();
            });
            var mapper = new Mapper(config);
            var converted = mapper.Map<List<BloodBankDTO>>(data);
            return converted;
        }
        public static BloodBankDTO Get(int id)
        {
            var data = DataAccessFactory.BloodBankDataAccess().Get(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Blood_Bank, BloodBankDTO>();
            });
            var mapper = new Mapper(config);
            var converted = mapper.Map<BloodBankDTO>(data);
            return converted;
        }
        public static BloodBankDTO Add(BloodBankDTO obj)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<BloodBankDTO, Blood_Bank>();
                cfg.CreateMap<Blood_Bank, BloodBankDTO>();
            });
            var mapper = new Mapper(config);
            var converted = mapper.Map<Blood_Bank>(obj);
            var rs = DataAccessFactory.BloodBankDataAccess().Add(converted);
            var rtrs = mapper.Map<BloodBankDTO>(rs);
            return rtrs;
        }
        public static BloodBankDTO Update(BloodBankDTO obj)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<BloodBankDTO, Blood_Bank>();
                cfg.CreateMap<Blood_Bank, BloodBankDTO>();
            });
            var mapper = new Mapper(config);
            var converted = mapper.Map<Blood_Bank>(obj);
            var rs = DataAccessFactory.BloodBankDataAccess().Update(converted);
            var rtrs = mapper.Map<BloodBankDTO>(rs);
            return rtrs;
        }
        public static bool Delete(int id)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<BloodBankDTO, Blood_Bank>();
                cfg.CreateMap<Blood_Bank, BloodBankDTO>();
            });
            return DataAccessFactory.BloodBankDataAccess().Delete(id);
        }
        public static List<BloodBankDTO> AvailableGet()
        {
            //return new List<PatientDTO>();
            var data = DataAccessFactory.requestbloodDataAccess().AvailableGet();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Blood_Bank, BloodBankDTO>();
            });
            var mapper = new Mapper(config);
            var converted = mapper.Map<List<BloodBankDTO>>(data);
            return converted;
        }
    }
}
