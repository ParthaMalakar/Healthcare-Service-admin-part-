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
    public class BlockPatientService
    {
        public static List<PatientDTO> ActiveGet()
        {
            //return new List<PatientDTO>();
            var data = DataAccessFactory.BlockpatientDataAccess().ActiveGet();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Patient, PatientDTO>();
            });
            var mapper = new Mapper(config);
            var converted = mapper.Map<List<PatientDTO>>(data);
            return converted;
        }
        public static List<PatientDTO> BlockGet()
        {
            //return new List<PatientDTO>();
            var data = DataAccessFactory.BlockpatientDataAccess().BlockGet();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Patient, PatientDTO>();
            });
            var mapper = new Mapper(config);
            var converted = mapper.Map<List<PatientDTO>>(data);
            return converted;
        }
        public static bool Block(int item)
        { 
            return DataAccessFactory.BlockpatientDataAccess().Block(item);
        }
    }
}
