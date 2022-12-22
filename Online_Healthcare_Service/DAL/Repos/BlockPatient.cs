using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DAL.Repos
{
    internal class BlockPatient : IBlockPatient<Patient, int>
    {
        HealthcareEntities1 db;
        internal BlockPatient()
        {
            db = new HealthcareEntities1();
        }
        public List<Patient> ActiveGet()
        {
            var AD = (from I in db.Patients where I.Status.Equals("Active") select I).ToList();
            return AD;
        }

        public Patient ActiveGet(int id)
        {
            throw new NotImplementedException();
        }

        public bool Block(int item)
        {
            var AD = (from I in db.Patients where I.Id.Equals(item) select I).FirstOrDefault();          
            AD.Status = "Block";
            try
            {
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Patient> BlockGet()
        {
            var AD = (from I in db.Patients where I.Status.Equals("Block") select I).ToList();
            return AD;
        }

        public Patient BlockGet(int id)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
