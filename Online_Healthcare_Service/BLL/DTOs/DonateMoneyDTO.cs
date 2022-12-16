using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class DonateMoneyDTO
    {
        public double Transaction_Id { get; set; }
        public double Money_Donate { get; set; }
        public string Status { get; set; }
    }
}
