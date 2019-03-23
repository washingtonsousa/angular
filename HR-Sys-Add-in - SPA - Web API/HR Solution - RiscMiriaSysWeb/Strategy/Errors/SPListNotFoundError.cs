using RiscServicesHRSharepointAddIn.Models;

namespace RiscServicesHRSharepointAddIn.Strategy.Errors
{
  public class SPListNotFoundError : IError
    {

        public override Error getError()
        {
            Error error = new Error();

            error.code = 10;

            error.message = "A lista de dados desta função não existe ou não foi encontrada, " +
                "por favor verifique se ela existe e se está corretamente configurada ou caso necessário use a função de " +
                "criação de listas base";

            return error;

        }


    }
}