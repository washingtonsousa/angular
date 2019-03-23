using RiscServicesHRSharepointAddIn.Models;

namespace RiscServicesHRSharepointAddIn.Strategy.Errors
{
  public class ModelStateGenericError : IError
    {


        public override Error getError()
        {
            Error error = new Error();

            error.code = 07;

            error.message = "Erro ao realizar esta operação de inserção/atualização." +
                " Verifique os dados preenchidos e tente novamente";

            return error;

        }



    }
}