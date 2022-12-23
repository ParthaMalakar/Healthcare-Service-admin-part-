using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class NoticeDTO
    {
        public int Notice_Id { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public System.DateTime Issue_time { get; set; }
        public System.DateTime Due_time { get; set; }
        public string Status { get; set; }
    }
}
