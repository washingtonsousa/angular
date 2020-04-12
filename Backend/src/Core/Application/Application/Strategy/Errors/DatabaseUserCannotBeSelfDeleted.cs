using Core.Data.Models;

namespace Core.Application.Strategy.Errors

{
  public class DatabaseUserCannotBeSelfDeleted : Error
    {

        public override Error GetError()
        {
            

            Code = 16;

            Message = "Você não pode se auto deletar";

            return this;

        }


    }
}