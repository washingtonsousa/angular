using Core.Data.Models;

namespace Core.Application.Strategy.Errors
{
  public class SPContextError : IError
    {

        public override Error getError()
        {
            Error error = new Error();

            error.code = 01;

            error.message = "Houve problemas para acessar o contexto do site Sharepoint de origem, " +
                "por gentileza acesse o aplicativo novamente através do site Sharepoint de Origem";

            return error;

        }


    }
}