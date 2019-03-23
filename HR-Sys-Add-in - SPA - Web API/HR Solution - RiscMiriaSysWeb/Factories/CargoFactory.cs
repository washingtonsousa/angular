using RiscServicesHRSharepointAddIn.Models;

namespace RiscServicesHRSharepointAddIn.Factories
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