using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class HospitalDoctorDTOs : HospitalDTO
    {
        public virtual List<DoctorDTO> Doctors { get; set; }
        public HospitalDoctorDTOs()
        {
            Doctors = new List<DoctorDTO>();
        }
    }
}
