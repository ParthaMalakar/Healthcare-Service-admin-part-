using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class BloodBankDTO
    {
        public int Id { get; set; }
        public string BGroup { get; set; }
        public string collection_Date { get; set; }
        public string Quantity { get; set; }
        public int Hid { get; set; }
        public string Status { get; set; }
        //  public virtual Hospital Hospital { get; set; }
        //  public virtual ICollection<Donar_Info> Donar_Info { get; set; }
    }
}
