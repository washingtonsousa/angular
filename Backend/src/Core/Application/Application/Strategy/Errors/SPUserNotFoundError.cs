using Core.Data.Models;

namespace Core.Application.Strategy.Errors
{
  public class SPUserNotFoundError : Error
    {

        public override Error GetError()
        {
            

            Code = 05;

            Message = "Usuário não existe na Base do Office 365, por favor verifique";

            return this;

        }
    }
}