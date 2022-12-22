using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class AssignDonarRepo : IAssignDonar<Donar_Info, int> { 
        HealthcareEntities1 db;
        internal AssignDonarRepo()
        {
            db = new HealthcareEntities1();
        }

        public bool Assign(int obj,int pid)
        {
            var AD = (from I in db.Donar_Info where I.Id.Equals(obj) select I).FirstOrDefault();
            AD.Status = "Collected";
            var o = (from I in db.Blood_Bank where I.Id.Equals(pid) select I).FirstOrDefault();
            o.Donar_Id=AD.Id;
            o.Status = "received";
            o.BGroup = AD.Blood_group;
            

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

        public List<Donar_Info> AvailableGet()
        {
            var AD = (from I in db.Donar_Info where I.Status.Equals("Pending") select I).ToList();
            return AD;
        }

        public Donar_Info AvailableGet(int id)
        {
            var AD = (from I in db.Donar_Info where I.Id.Equals(id) select I).SingleOrDefault();
            return AD;
        }

        public List<Donar_Info> AlldonarcollectedGet()
        {
            var AD = (from I in db.Donar_Info where I.Status.Equals("Collected") select I).ToList();
            return AD;
        }

        public Donar_Info AlldonarcollectedGet(int id)
        {
            var AD = (from I in db.Donar_Info where I.Id.Equals(id) select I).SingleOrDefault();
            return AD;
        }

    }
}
