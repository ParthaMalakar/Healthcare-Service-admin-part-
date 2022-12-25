using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class AppointmentDTO
    {
        public int Id { get; set; }
        public int Did { get; set; }
        public int Pid { get; set; }
        public string Status { get; set; }
        public string Name { get; set; }
        public int P_Age { get; set; }
        public System.DateTime AppointmentDate { get; set; }
        public string DName { get; set; }
        public string Dsepciality { get; set; }
        public string PEmail { get; set; }
        public string DEmail { get; set; }
    }
}
