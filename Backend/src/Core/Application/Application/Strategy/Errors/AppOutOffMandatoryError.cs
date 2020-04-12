using Core.Data.Models;

namespace Core.Application.Strategy.Errors
{
  public class AppOutOffMandatoryError : Error
    {
        public override Error GetError()
        {
            

            Code = 04;

            Message = "Você está tentando acessar um recurso não configurado para o site contexto de origem, você precisa acessar" +
                " este recurso através do site mandatório configurado pelo administrador";

            return this;
        }
    }
   
}