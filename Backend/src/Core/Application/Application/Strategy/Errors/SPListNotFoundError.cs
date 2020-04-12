using Core.Data.Models;

namespace Core.Application.Strategy.Errors
{
  public class SPListNotFoundError : Error
    {

        public override Error GetError()
        {
      

            Code = 10;

            Message = "A lista de dados desta função não existe ou não foi encontrada, " +
                "por favor verifique se ela existe e se está corretamente configurada ou caso necessário use a função de " +
                "criação de listas base";

            return this;

        }


    }
}