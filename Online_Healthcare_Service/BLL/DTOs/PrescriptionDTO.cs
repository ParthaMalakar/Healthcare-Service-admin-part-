using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class PrescriptionDTO
    {
        public int Id { get; set; }
        public int D_Id { get; set; }
        public int P_Id { get; set; }
        public int H_Id { get; set; }
        public string Test { get; set; }
        public string Medicine { get; set; }
    }
}
