using Core.Data.Models;

namespace Core.Application.Strategy.Errors
{
  public class SPUserNotFoundError : IError
    {

        public override Error getError()
        {
            Error error = new Error();

            error.code = 05;

            error.message = "Usuário não existe na Base do Office 365, por favor verifique";

            return error;

        }
    }
}