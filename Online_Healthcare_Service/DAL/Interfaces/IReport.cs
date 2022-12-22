using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
   public  interface IReport<CLASS, ID>
    {
       
            List<CLASS> sendByEmails(ID email);
            List<CLASS> recivedByEmails(ID email);

            List<CLASS> sortByIdInc();

            List<CLASS> sortByIdDec();

        
    }
}
