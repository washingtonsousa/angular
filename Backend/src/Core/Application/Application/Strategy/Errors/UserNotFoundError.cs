using Core.Data.Models;

namespace Core.Application.Strategy.Errors
{
  public class UserNotFoundError : Error
    {

        public override Error GetError()
        {
            

            Code = 09;

            Message = "O usuário precisa estar cadastrado na base SQL para acessar esta função";

            return this;

        }


    }
}