using Core.Data.Models;

namespace Core.Application.Factories
{



  public class CargoFactory
    {

    
        


        public Cargo DefaultCargoInstallObjFactory(int DepartamentoId)
        {

            Cargo novocargo = new Cargo();

            novocargo.Nome ="Default";

            novocargo.DepartamentoId = DepartamentoId;

            return novocargo;

        }


    }
}