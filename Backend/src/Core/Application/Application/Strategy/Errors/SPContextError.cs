using Core.Data.Models;

namespace Core.Application.Strategy.Errors
{
  public class SPContextError : Error
    {

        public override Error GetError()
        {

            Code = 01;
            Message = "Houve problemas para acessar o contexto do site Sharepoint de origem, " +
                "por gentileza acesse o aplicativo novamente através do site Sharepoint de Origem";

            return this;

        }


    }
}