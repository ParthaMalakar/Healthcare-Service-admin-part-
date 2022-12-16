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
    public class DonateMoneyService
    {
        public static List<DonateMoneyDTO> Get()
        {

            var data = DataAccessFactory.DonateMoneyDataAccess().Get();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Donate_Money, DonateMoneyDTO>();
            });
            var mapper = new Mapper(config);
            var converted = mapper.Map<List<DonateMoneyDTO>>(data);
            return converted;
        }
        public static DonateMoneyDTO Get(int id)
        {
            var data = DataAccessFactory.DonateMoneyDataAccess().Get(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Donate_Money, DonateMoneyDTO>();
            });
            var mapper = new Mapper(config);
            var converted = mapper.Map<DonateMoneyDTO>(data);
            return converted;
        }
        public static DonateMoneyDTO Add(DonateMoneyDTO obj)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DonateMoneyDTO, Donate_Money>();
                cfg.CreateMap<Donate_Money, DonateMoneyDTO>();
            });
            var mapper = new Mapper(config);
            var converted = mapper.Map<Donate_Money>(obj);
            var rs = DataAccessFactory.DonateMoneyDataAccess().Add(converted);
            var rtrs = mapper.Map<DonateMoneyDTO>(rs);
            return rtrs;
        }
        public static DonateMoneyDTO Update(DonateMoneyDTO obj)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DonateMoneyDTO, Donate_Money>();
                cfg.CreateMap<Donate_Money, DonateMoneyDTO>();
            });
            var mapper = new Mapper(config);
            var converted = mapper.Map< Donate_Money>(obj);
            var rs = DataAccessFactory.DonateMoneyDataAccess().Update(converted);
            var rtrs = mapper.Map<DonateMoneyDTO>(rs);
            return rtrs;
        }
        public static bool Delete(int id)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DonateMoneyDTO, Donate_Money>();
                cfg.CreateMap<Donate_Money, DonateMoneyDTO>();
            });
            return DataAccessFactory.DonateMoneyDataAccess().Delete(id);
        }
    }
}
