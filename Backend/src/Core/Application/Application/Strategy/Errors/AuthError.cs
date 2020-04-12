using Core.Data.Models;

namespace Core.Application.Strategy.Errors
{
  public class AuthError : Error
    {
        public override Error GetError()
        {
            

            Code = 06;

            Message = "Falha de autenticação";

            return this;
        }
    }

}