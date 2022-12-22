using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
     public class AmbulanceDTO
    {
        public int Id { get; set; }
        public string Driver_Name { get; set; }
        public string Phone { get; set; }
        public string Rent { get; set; }
        public string Status { get; set; }
        public int Hid { get; set; }
        public Nullable<int> Pid { get; set; }
        public string Location { get; set; }
    }
}
