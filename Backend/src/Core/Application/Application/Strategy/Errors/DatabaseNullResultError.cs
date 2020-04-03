using Core.Data.Models;

namespace Core.Application.Strategy.Errors
{
  public class DatabaseNullResultError : IError
    {

        public override Error GetError()
        {
            Error error = new Error();

            error.code = 08;

            error.message = "Não foi encontrado nenhum resultado para esta entidade, a entidade foi deletada e não existe mais";

            return error;

        }


    }
}