using Core.Data.Models;

namespace Core.Application.Strategy.Errors
{
  public class BasicComponentsInstallError : Error
    {

        public override Error GetError()
        {
            
            Code = 211;
            Message = "Erro durante instalação dos componentes básicos";
            return this;

        }
    }
}