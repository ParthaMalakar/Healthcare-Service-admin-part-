using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IGet<CLASS, ID>
    {
        List<CLASS> GetByPid(ID id);
    }
}
