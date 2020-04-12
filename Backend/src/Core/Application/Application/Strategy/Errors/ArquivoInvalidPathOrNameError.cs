using Core.Data.Models;

namespace Core.Application.Strategy.Errors
{
  public class ArquivoInvalidPathOrNameError : Error
    {
        public override Error GetError()
        {
            

            Code = 13;

            Message = "Arquivo já existe ou possue nomenclatura inválida";

            return this;

        }
    }
}