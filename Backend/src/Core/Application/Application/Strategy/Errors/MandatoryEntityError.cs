using Core.Data.Models;

namespace Core.Application.Strategy.Errors
{
  public class MandatoryEntityError : IError
    {

        public override Error getError()
        {
            Error error = new Error();

            error.code = 11;

            error.message = "A operação não pode ser realizada, pois a entidade é mandatória, contate o administrador para mais detalhes";

            return error;

        }


    }
}