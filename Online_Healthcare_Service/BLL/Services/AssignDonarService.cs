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
    public class AssignDonarService
    {
        public static List<Donor_InfoDTO> AvailableGet()
        {
            //return new List<PatientDTO>();
            var data = DataAccessFactory.assignDoctorDataAccess().AvailableGet();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Donar_Info, Donor_InfoDTO>();
            });
            var mapper = new Mapper(config);
            var converted = mapper.Map<List<Donor_InfoDTO>>(data);
            return converted;
        }
        public static List<Donor_InfoDTO> CollectedbonarGet()
        {
            //return new List<PatientDTO>();
            var data = DataAccessFactory.assignDoctorDataAccess().AlldonarcollectedGet();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Donar_Info, Donor_InfoDTO>();
            });
            var mapper = new Mapper(config);
            var converted = mapper.Map<List<Donor_InfoDTO>>(data);
            return converted;
        }
        public static bool Assign(int item,int pid)
        {
            return DataAccessFactory.assignDoctorDataAccess().Assign(item,pid);
        }
    }
}
