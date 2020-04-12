using Core.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Interfaces
{
    public interface ICategoriaConhecimentoAppService
    {

        IList<CategoriaConhecimento> Get();
        void Delete(int Id);



        CategoriaConhecimento Update(CategoriaConhecimento categoriaCategoriaConhecimento);



        CategoriaConhecimento Insert(CategoriaConhecimento categoriaCategoriaConhecimento);

    }
}
