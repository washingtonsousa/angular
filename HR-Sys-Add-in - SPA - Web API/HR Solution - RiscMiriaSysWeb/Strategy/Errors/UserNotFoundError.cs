using RiscServicesHRSharepointAddIn.Models;

namespace RiscServicesHRSharepointAddIn.Strategy.Errors
{
  public class UserNotFoundError : IError
    {

        public override Error getError()
        {
            Error error = new Error();

            error.code = 09;

            error.message = "O usuário precisa estar cadastrado na base SQL para acessar esta função";

            return error;

        }


    }
}