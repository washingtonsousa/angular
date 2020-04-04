using Core.Data.Models;
using System.Collections.Generic;

namespace Core.Application.Interfaces
{
    public interface ICargoAppService
    {

        IList<Cargo> Get();

        Cargo Get(int id);

        Cargo Insert(Cargo cargo);


        void Delete(int id);

         Cargo Update(Cargo cargo);

    }
}
