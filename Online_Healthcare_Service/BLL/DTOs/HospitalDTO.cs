using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class HospitalDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
     //   public virtual ICollection<Blood_Bank> Blood_Bank { get; set; }
    }
}
