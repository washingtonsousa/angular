using RiscServicesHRSharepointAddIn.Models;

namespace RiscServicesHRSharepointAddIn.Strategy.Errors
{
  public class DatabaseNullResultError : IError
    {

        public override Error getError()
        {
            Error error = new Error();

            error.code = 08;

            error.message = "Não foi encontrado nenhum resultado para esta entidade, a entidade foi deletada e não existe mais";

            return error;

        }


    }
}