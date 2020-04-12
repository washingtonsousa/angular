using Core.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Interfaces
{
    public interface IIdiomaAppService
    {


         Idioma InsertSingle(Idioma Idioma);

         Idioma UpdateSingle(Idioma Idioma);


         void DeleteSingle(int Id);

         Idioma Insert(Idioma Idioma);

         Idioma Update(Idioma Idioma);

         void Delete(int Id);



    }
}
