using Core.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Interfaces
{
    public interface INivelAcessoAppService
    {
        IList<NivelAcesso> Get();


        NivelAcesso Get(int id);





        NivelAcesso Insert(NivelAcesso NivelAcesso);


        void Delete(int id);

        NivelAcesso Update(NivelAcesso NivelAcesso);
    }
}
