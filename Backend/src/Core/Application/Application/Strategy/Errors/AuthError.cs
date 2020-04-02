using Core.Data.Models;

namespace Core.Application.Strategy.Errors
{
  public class AuthError : IError
    {
        public override Error getError()
        {
            Error error = new Error();

            error.code = 06;

            error.message = "Falha de autenticação";

            return error;
        }
    }

}