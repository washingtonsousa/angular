using RiscServicesHRSharepointAddIn.Models;

namespace RiscServicesHRSharepointAddIn.Strategy.Errors
{
  public class BasicComponentsInstallError : IError
    {

        public override Error getError()
        {
            Error error = new Error();

            error.code = 211;

            error.message = "Erro durante instalação dos componentes básicos";

            return error;

        }
    }
}