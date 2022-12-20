using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string User_Type { get; set; }
        public Nullable<int> Admin_Id { get; set; }
        public Nullable<int> Patient_Id { get; set; }
        public Nullable<int> Doctor_Id { get; set; }
        public string Password { get; set; }
    }
}
