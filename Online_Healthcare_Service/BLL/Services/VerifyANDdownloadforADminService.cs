using ClosedXML.Excel;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BLL.DTOs;

namespace BLL.Services
{

 
    public class VerifyANDdownloadforADminService
    {
        public static bool DownloadList()
        {
            var data = AppointmentService.Get();
            DataTable DT_A_A = new DataTable("Grid");
            DT_A_A.Columns.AddRange(new DataColumn[8]
            {
               new DataColumn("Patient Name"),
               new DataColumn("Patient Age"),
               new DataColumn("Patient Status"),
               new DataColumn("AppointmentDate"),
               new DataColumn("Doctor Name"),
               new DataColumn("Doctor Specaility"),
               new DataColumn("Doctor Email"),
               new DataColumn("Patient_Email")
            });
            
            foreach (var In in data)
            {
                
                var ab = DoctorService.Get(In.Did);
                var pa =PatientService.Get(In.Pid);
                DT_A_A.Rows.Add(
                    In.Name,
                    In.P_Age,
                    In.Status,
                    In.AppointmentDate,
                    ab.Name,
                    ab.Specaility,
                    ab.Email,
                    pa.Email
                    ); 

            }

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(DT_A_A);

               
                try
                {
                    wb.SaveAs("C:\\Users\\HP\\Downloads\\AppointmentList.xlsx");
                    return true;
                }
                catch
                {
                    return false;
                }

            }
        }
        public static List<AppointmentDTO> getallappointment()
        {
            var data = AppointmentService.Get();
            var Notices = new List<AppointmentDTO>();
            foreach (var In in data)
            {
                var dto = new AppointmentDTO();
                var ab = DoctorService.Get(In.Did);
                var pa = PatientService.Get(In.Pid);
                {
                    dto.Name = In.Name;
                    dto.P_Age = In.P_Age;
                    dto.Status = In.Status;
                    dto.AppointmentDate = In.AppointmentDate;
                    dto.DName = ab.Name;
                    dto.Dsepciality = ab.Specaility;
                    dto.DEmail = ab.Email;
                    dto.PEmail = pa.Email;
                    dto.Did = ab.Id;
                    dto.Pid = pa.Id;
                    dto.Id =In.Id;
                };
                Notices.Add(dto);

            }
            return Notices;
        }

        public static bool Mail(string subject, string body, string To)
        {

            /* try
             {
                 using (SmtpClient client = new SmtpClient("smtp.gmail.com", 587))
                 {
                     client.EnableSsl = true;
                     client.DeliveryMethod = SmtpDeliveryMethod.Network;
                     client.UseDefaultCredentials = false;
                     client.Credentials = new NetworkCredential("parthamalakar4321@gmail.com", "partha1234");
                     MailMessage msgObj = new MailMessage();
                     msgObj.To.Add(To);
                     msgObj.From = new MailAddress("parthamalakar4321@gmail.com");
                     msgObj.Subject = subject;
                     msgObj.Body = body;
                     client.Send(msgObj);
                     return true;
                 }
             }
             catch
             {
                 return false;
             }*/
            MailMessage mm = new MailMessage();
            mm.From = new MailAddress("parthamalakar4321@gmail.com");
            mm.To.Add(To);
            mm.Subject = subject;
            mm.Body = body;
            mm.IsBodyHtml = false;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.UseDefaultCredentials = true;
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.Credentials = new System.Net.NetworkCredential("parthamalakar4321@gmail.com", "jjlxpqqervnnymuo");
            smtp.Send(mm);
            return true;
        }
        private static Random random = new Random();

        public static string VarificationString()
        {
            int length = 5;
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public static bool createVarification(VarificationDTO V)
        {
            if (DataAccessFactory.ADMINVERIFYDataAccess().checkMail(V.Email))
            {
                V.Code =VarificationString();
                if (DataAccessFactory.ADMINVERIFYDataAccess().createVar(V.Email, V.Code))
                {
                    var subject = " Email Verification FOR Update password";
                    var body = "Your Verification code is:" + V.Code;
                    return Mail(subject, body, V.Email);
                }
            }
            return false;
        }

        public static bool checkVarification(VarificationDTO V)
        {
            if (DataAccessFactory.ADMINVERIFYDataAccess().checkVar(V.Email, V.Code))
            {
                return DataAccessFactory.ADMINVERIFYDataAccess().createVar(V.Email, "Yes");
            }
            return false;
        }

    }
}
