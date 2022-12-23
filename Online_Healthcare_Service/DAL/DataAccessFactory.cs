using DAL.EF;
using DAL.Interfaces;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {

        public static IRepo<Doctor, int, Doctor> DoctorDataAccess()
        {
            return new DoctorRepo();
        }
        public static IRepo<Patient, int, Patient> PatientDataAccess()
        {
            return new PatientRepo();
        }
        public static IBlockPatient<Patient, int> BlockpatientDataAccess()
            {
            return new BlockPatient();
             }
        public static IRepo<Appointment, int, Appointment> AppointmentDataAccess()
        {
            return new AppointmentRepo();
        }

        public static IRepo<Donar_Info, int, Donar_Info> DonorInfoDataAccess()
        {
            return new Donor_InfoRepo();
        }

        public static IRepo<Blood_Bank, int, Blood_Bank> BloodBankDataAccess()
        {
            return new Blood_BankRepo();
        }
        public static IRepo<PatientFeedback, int, PatientFeedback> PatientFeedbackDataAccess()
        {
            return new PatientFeedbackRepo();
        }
        public static IRepo<Hospital, int, Hospital> HospitalDataAccess()
        {
            return new HospitalRepo();
        }

        public static IGet<Appointment, int> AppointmentIdDataAccess()
        {
            return new AppointmentRepo();
        }

       
        public static IGet<Prescription, int> PrescriptionIdDataAccess()
        {
            return new PrescriptionRepo();
        }

        public static IRepo<Prescription, int, Prescription> PrescriptionDataAccess()
        {
            return new PrescriptionRepo();
        }

        public static IRepo<Ambulance, int,Ambulance> AmbulanceDataAccess()
        {
            return new AmbulanceRepo();
        }

        public static IRepo<Donate_Money, int, Donate_Money> DonateMoneyDataAccess()
        {
            return new DonateMoneyRepo();
        }
        public static IRepo<Admin, int, Admin> AdminDataAccess()
        {
            return new AdminRepo();
        }
        public static IRepo<User_Table, int, User_Table> UserDataAccess()
        {
            return new UserRepo();
        }
        public static IRepo<Token, string, Token> TokenDataAccess()
        {
            return new TokenRepo();
        }
        public static IAuth AuthDataAccess()
        {
            return new AuthRepo();
        }
        public static IRepo_Admin<AdminReport, int> ReportDataAccess()
        {
            return new AdminReportRepo();
        }

        public static IReport<AdminReport, String> ReportgetSRDataAccess()
        {
            return new AdminReportRepo();
        }
        public static IGetbyemailI<int, String> GetbyemailDataAccess()
        {
            return new PatientRepo();
        }
       public static IAssignDonar<Donar_Info, int> assignDoctorDataAccess()
        {
            return new AssignDonarRepo();
        }
        public static IAssignDonar<Blood_Bank, int> requestbloodDataAccess()
        {
            return new Blood_BankRepo();
        }
      public static IRepo_Admin<Notice, int> NoticeDataAccess()
        {
            return new NoticeRepo();
        }
        public static In_VarIRepo<Admin, string> ADMINVERIFYDataAccess()
        {
            return new AdminRepo();
        }
    }
}
