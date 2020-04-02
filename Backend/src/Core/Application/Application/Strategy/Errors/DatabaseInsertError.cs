using Core.Data.Models;

namespace Core.Application.Strategy.Errors
{
  public class DatabaseDuplicatedEntryError : IError
    {

        public override Error getError()
        {
            Error error = new Error();

            error.code = 14;

            error.message = "Esta entidade não pode ter valores duplicados na base";

            return error;

        }


    }
}