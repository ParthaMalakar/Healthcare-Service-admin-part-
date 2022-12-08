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

       
    }
}
