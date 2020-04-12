using Core.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Interfaces
{
    public interface IResumoAppService
    {
        Resumo InsertSingle(Resumo Resumo);



        Resumo UpdateSingle(Resumo Resumo);


        void DeleteSingle(int Id);

        Resumo Insert(Resumo Resumo);

        Resumo Update(Resumo Resumo);


        void Delete(Resumo Resumo);
    }
}
