using Core.Data.Models;

namespace Core.Application.Strategy.Errors
{
  public class ModelStateGenericError : Error
    {

        public override Error GetError()
        {
            

            Code = 07;

            Message = "Erro ao realizar esta operação de inserção/atualização." +
                " Verifique os dados preenchidos e tente novamente";

            return this;

        }



    }
}