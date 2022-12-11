using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class Token_AdminDTO
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public System.DateTime Token_CreatedAt { get; set; }
        public Nullable<System.DateTime> Token_ExpiredAt { get; set; }
        public int A_Id { get; set; }
    }
}
