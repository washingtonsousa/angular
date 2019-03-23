using RiscServicesHRSharepointAddIn.Models;

namespace RiscServicesHRSharepointAddIn.Strategy.Errors

{
  public class DatabaseUserCannotBeSelfDeleted : IError
    {

        public override Error getError()
        {
            Error error = new Error();

            error.code = 16;

            error.message = "Você não pode se auto deletar";

            return error;

        }


    }
}