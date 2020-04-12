using Core.Data.Models;

namespace Core.Application.Strategy.Errors
{
  public class DatabaseNullResultError : Error
    {

        public override Error GetError()
        {
            

            Code = 08;

            Message = "Não foi encontrado nenhum resultado para esta entidade, a entidade foi deletada e não existe mais";

            return this;

        }


    }
}