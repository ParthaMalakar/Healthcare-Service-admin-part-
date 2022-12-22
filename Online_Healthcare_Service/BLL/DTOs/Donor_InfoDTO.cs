using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class Donor_InfoDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Blood_group { get; set; }
        public string Phone { get; set; }
        public int Bid { get; set; }
        public string Status { get; set; }
        public Nullable<int> Donar_Id { get; set; }
        //  public virtual ICollection<Blood_Bank> Blood_Bank { get; set; }

    }
}
