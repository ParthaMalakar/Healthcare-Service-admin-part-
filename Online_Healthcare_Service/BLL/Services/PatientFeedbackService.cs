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
    public class PatientFeedbackFeedbackService
    {
        public static List<PatientFeedbackDTO> Get()
        {
            //return new List<PatientFeedbackDTO>();
            var data = DataAccessFactory.PatientFeedbackDataAccess().Get();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PatientFeedback, PatientFeedbackDTO>();
            });
            var mapper = new Mapper(config);
            var converted = mapper.Map<List<PatientFeedbackDTO>>(data);
            return converted;
        }
        public static PatientFeedbackDTO Get(int id)
        {
            var data = DataAccessFactory.PatientFeedbackDataAccess().Get(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PatientFeedback, PatientFeedbackDTO>();
            });
            var mapper = new Mapper(config);
            var converted = mapper.Map<PatientFeedbackDTO>(data);
            return converted;
        }
        public static PatientFeedbackDTO Add(PatientFeedbackDTO obj)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PatientFeedbackDTO, PatientFeedback>();
                cfg.CreateMap<PatientFeedback, PatientFeedbackDTO>();
            });
            var mapper = new Mapper(config);
            var converted = mapper.Map<PatientFeedback>(obj);
            var rs = DataAccessFactory.PatientFeedbackDataAccess().Add(converted);
            var rtrs = mapper.Map<PatientFeedbackDTO>(rs);
            return rtrs;
        }
        public static PatientFeedbackDTO Update(PatientFeedbackDTO obj)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PatientFeedbackDTO, PatientFeedback>();
                cfg.CreateMap<PatientFeedback, PatientFeedbackDTO>();
            });
            var mapper = new Mapper(config);
            var converted = mapper.Map<PatientFeedback>(obj);
            var rs = DataAccessFactory.PatientFeedbackDataAccess().Update(converted);
            var rtrs = mapper.Map<PatientFeedbackDTO>(rs);
            return rtrs;
        }
        public static bool Delete(int id)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PatientFeedbackDTO, PatientFeedback>();
                cfg.CreateMap<PatientFeedback, PatientFeedbackDTO>();
            });
            return DataAccessFactory.PatientFeedbackDataAccess().Delete(id);
        }
    }
}
