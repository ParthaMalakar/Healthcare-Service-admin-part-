using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class DoctorWithAppointmentDTO :DoctorDTO
    {
      
        public virtual List<AppointmentDTO> Appointments { get; set; }
        public DoctorWithAppointmentDTO()
        {
            Appointments = new List<AppointmentDTO>();
        }
    }
}
