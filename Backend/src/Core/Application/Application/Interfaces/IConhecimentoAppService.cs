using Core.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Interfaces
{
    public interface IConhecimentoAppService
    {
        IList<Conhecimento> Get();


        void Delete(int Id);


        Conhecimento Update(Conhecimento conhecimento);

        Conhecimento Insert(Conhecimento conhecimento);

    }
}
