using RiscServicesHRSharepointAddIn.Models;

namespace RiscServicesHRSharepointAddIn.Strategy.Errors
{
  public class AppOutOffMandatoryError : IError
    {
        public override Error getError()
        {
            Error error = new Error();

            error.code = 04;

            error.message = "Você está tentando acessar um recurso não configurado para o site contexto de origem, você precisa acessar" +
                " este recurso através do site mandatório configurado pelo administrador";

            return error;
        }
    }
   
}