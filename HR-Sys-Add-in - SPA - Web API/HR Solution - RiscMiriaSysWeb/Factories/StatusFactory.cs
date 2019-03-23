using RiscServicesHRSharepointAddIn.Models;

namespace RiscServicesHRSharepointAddIn.Factories
{
  public class StatusFactory
    {

 



        public Status DefaultAtivoStatusFactory()
        {
          
            return new Status { Nome  = "ativo", Codigo = 1 } ;

        }

        public Status DefaultDesativadoStatusFactory()
        {

           return new Status { Nome = "desativado", Codigo = 0 };

        }





    }
}
