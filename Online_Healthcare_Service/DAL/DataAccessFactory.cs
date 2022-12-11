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

        public static IRepo<Hospital, int, Hospital> HospitalDataAccess()
        {
            return new HospitalRepo();
        }
        public static IAuth AuthDataAccess()
        {
            return new AdminRepo();
        }
        public static IRepo<Token_Admin, string, Token_Admin> TokenDataAccess()
        {
            return new AdminTokenRepo();
        }
    }
}
