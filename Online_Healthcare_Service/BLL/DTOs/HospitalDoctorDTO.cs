using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class HospitalDoctorDTO : HospitalDTO
    {
        public virtual List<DoctorDTO> Doctors { get; set; }
        public HospitalDoctorDTO()
        {
            Doctors = new List<DoctorDTO>();
        }
    }
}
