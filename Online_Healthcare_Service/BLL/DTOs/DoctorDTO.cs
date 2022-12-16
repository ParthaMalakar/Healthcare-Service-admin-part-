using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class DoctorDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Specaility { get; set; }
        public string Visiting_Hour { get; set; }
        public int Hid { get; set; }
        public Nullable<int> Fees { get; set; }
      //  public virtual Hospital Hospital { get; set; }
    }
}
