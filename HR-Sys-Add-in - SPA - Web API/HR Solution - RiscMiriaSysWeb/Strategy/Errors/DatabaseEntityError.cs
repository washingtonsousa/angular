using RiscServicesHRSharepointAddIn.Models;

namespace RiscServicesHRSharepointAddIn.Strategy.Errors
{
  public class DatabaseEntityError : IError
    {

        public override Error getError()
        {
            Error error = new Error();

            error.code = 03;

            error.message = "Não foi possível realizar esta operação de dados, pois esta entidade possui outras entidades relacionadas " +
                "que precisam ser deletadas para haver a exclusão desta entidade ou esta entidade é mandatória para funcionamento do sistema" +
                " e não pode sofrer operações de CRUD.";

            return error;

        }
    }
    }