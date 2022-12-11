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
    public class Donor_InfoService
    {
        public static List<Donor_InfoDTO> Get()
        {
            //return new List<DoctorDTO>();
            var data = DataAccessFactory.DonorInfoDataAccess().Get();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Donar_Info, Donor_InfoDTO>();
            });
            var mapper = new Mapper(config);
            var converted = mapper.Map<List<Donor_InfoDTO>>(data);
            return converted;
        }
        public static DoctorDTO Get(int id)
        {
            var data = DataAccessFactory.DoctorDataAccess().Get(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Donar_Info, DoctorDTO>();
            });
            var mapper = new Mapper(config);
            var converted = mapper.Map<DoctorDTO>(data);
            return converted;
        }
    }
}
