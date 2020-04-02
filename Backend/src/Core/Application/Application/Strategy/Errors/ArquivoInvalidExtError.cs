using Core.Data.Models;

namespace Core.Application.Strategy.Errors
{
  public class ArquivoInvalidExtError : IError
    {
        public override Error getError()
        {
            Error error = new Error();

        error.code = 12;

        error.message = "Extensão ou tipo de arquivo inválidos";


        return error;
        }
    }
}