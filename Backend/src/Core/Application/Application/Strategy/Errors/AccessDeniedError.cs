using Core.Data.Models;

namespace Core.Application.Strategy.Errors
{
  public class AccessDeniedError : IError
    {
        public override Error getError()
        {
            Error error = new Error();

            error.code = 02;

            error.message = "Acesso negado, você não tem acesso para este aplicativo ou sessão";

            return error;
        }
    }
}