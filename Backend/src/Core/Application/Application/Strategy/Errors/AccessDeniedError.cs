using Core.Data.Models;

namespace Core.Application.Strategy.Errors
{
  public class AccessDeniedError : Error
    {
        public override Error GetError()
        {
            

            Code = 02;

            Message = "Acesso negado, você não tem acesso para este aplicativo ou sessão";

            return this;
        }
    }
}