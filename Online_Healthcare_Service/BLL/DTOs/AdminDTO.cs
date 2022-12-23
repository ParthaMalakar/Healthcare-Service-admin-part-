using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class AdminDTO
    {
        public int Admin_Id { get; set; }
        public string Name { get; set; }
        public string User_Type { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string EmailValidation { get; set; }
    }
}
