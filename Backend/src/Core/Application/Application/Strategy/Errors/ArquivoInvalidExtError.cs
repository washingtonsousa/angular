using Core.Data.Models;

namespace Core.Application.Strategy.Errors
{
  public class ArquivoInvalidExtError : Error
    {
        public override Error GetError()
        {
            

        Code = 12;

        Message = "Extensão ou tipo de arquivo inválidos";


        return this;
        }
    }
}