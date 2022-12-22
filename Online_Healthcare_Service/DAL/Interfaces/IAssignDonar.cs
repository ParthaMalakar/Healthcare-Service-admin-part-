using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IAssignDonar<CLASS, ID>
    {
        List<CLASS> AvailableGet();
        CLASS AvailableGet(ID id);
        List<CLASS> AlldonarcollectedGet();
        CLASS AlldonarcollectedGet(ID id);
        bool Assign(ID obj,int pid);
    }
}
