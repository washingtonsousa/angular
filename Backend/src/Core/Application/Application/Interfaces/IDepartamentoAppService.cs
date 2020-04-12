using Core.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Interfaces
{
    public interface IDepartamentoAppService
    {
        IList<Departamento> Get();


        Departamento Get(int Id);

        Departamento Insert(Departamento departamento);


        void Delete(int Id);

        Departamento Update(Departamento departamento);
    }
}
