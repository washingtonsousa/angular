using Core.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Interfaces
{
    public  interface IAreaAppService
    {
         IList<Area> Get();



         Area Get(int Id);


         Area Insert(Area Area);

         void Delete(int Id);



         Area Update(Area Area);
        

    }
}
