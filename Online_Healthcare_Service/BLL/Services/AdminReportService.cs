using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AdminReportService
    {
        public static List<AdminReportDTO> Get()
        {
            var data = DataAccessFactory.ReportDataAccess().Get();
            var Reports = new List<AdminReportDTO>();

            foreach (var item in data)
            {
                AdminReportDTO rep = new AdminReportDTO()
                {

                    ReportId = item.ReportId,
                    sender = item.sender,
                    Receiver = item.Receiver,
                    Title = item.Title,
                    Description = item.Description,
                    Report_Time = item.Report_Time,
                    Status = item.Status

                };
                Reports.Add(rep);

            }

            return Reports;
        }
        public static List<AdminReportDTO> sendByEmails(string email)
        {
            var data = DataAccessFactory.ReportgetSRDataAccess().sendByEmails(email);
            var Reports = new List<AdminReportDTO>();

            foreach (var item in data)
            {
                AdminReportDTO rep = new AdminReportDTO()
                {
                    ReportId = item.ReportId,
                    sender = item.sender,
                    Receiver = item.Receiver,
                    Title = item.Title,
                    Description = item.Description,
                    Report_Time = item.Report_Time,
                    Status = item.Status
                };
                Reports.Add(rep);
            }
            return Reports;
        }
        public static List<AdminReportDTO> recivedByEmails(string email)
        {
            var data = DataAccessFactory.ReportgetSRDataAccess().recivedByEmails(email);
            var Reports = new List<AdminReportDTO>();

            foreach (var item in data)
            {
                AdminReportDTO rep = new AdminReportDTO()
                {
                    ReportId = item.ReportId,
                    sender = item.sender,
                    Receiver = item.Receiver,
                    Title = item.Title,
                    Description = item.Description,
                    Report_Time = item.Report_Time,
                    Status = item.Status
                };
                Reports.Add(rep);
            }
            return Reports;
        }
        public static List<AdminReportDTO> sortByIdInc()
        {
            var data = DataAccessFactory.ReportgetSRDataAccess().sortByIdInc();
            var Reports = new List<AdminReportDTO>();

            foreach (var item in data)
            {
                AdminReportDTO rep = new AdminReportDTO()
                {

                    ReportId = item.ReportId,
                    sender = item.sender,
                    Receiver = item.Receiver,
                    Title = item.Title,
                    Description = item.Description,
                    Report_Time = item.Report_Time,
                    Status = item.Status

                };
                Reports.Add(rep);

            }

            return Reports;
        }

        public static List<AdminReportDTO> sortByIdDec()
        {
            var data = DataAccessFactory.ReportgetSRDataAccess().sortByIdDec();
            var Reports = new List<AdminReportDTO>();

            foreach (var item in data)
            {
                AdminReportDTO rep = new AdminReportDTO()
                {

                    ReportId = item.ReportId,
                    sender = item.sender,
                    Receiver = item.Receiver,
                    Title = item.Title,
                    Description = item.Description,
                    Report_Time = item.Report_Time,
                    Status = item.Status

                };
                Reports.Add(rep);

            }

            return Reports;
        }

        public static bool Create(AdminReportDTO item)
        {
            AdminReport AD = new AdminReport()
            {

                sender = item.sender,
                Receiver = item.Receiver,
                Title = item.Title,
                Description = item.Description,
                Report_Time = item.Report_Time,
                Status = item.Status

            };
            return DataAccessFactory.ReportDataAccess().Create(AD);
        }

        public static bool InCreate(AdminReportDTO item)
        {
            AdminReport AD = new AdminReport()
            {

                sender = item.sender,
                Receiver = item.Receiver,
                Title = item.Title,
                Description = item.Description,
                Report_Time = DateTime.Now,
                Status = "Sent"

            };
            return DataAccessFactory.ReportDataAccess().Create(AD);
        }

        public static bool Update(AdminReportDTO item)
        {
            AdminReport AD = new AdminReport()
            {

                sender = item.sender,
                Receiver = item.Receiver,
                Title = item.Title,
                Description = item.Description,
                Report_Time = item.Report_Time,
                Status = item.Status

            };
            return DataAccessFactory.ReportDataAccess().Update(AD);

        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.ReportDataAccess().Delete(id);
        }
    }
}
