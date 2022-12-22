using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IBlockPatient<CLASS, ID>
    {
        List<CLASS> BlockGet();
        CLASS BlockGet(ID id);
        List<CLASS> ActiveGet();
        CLASS ActiveGet(ID id);
        bool Block(ID obj);
        bool Delete(ID id);

    }
}
