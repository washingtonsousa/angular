using Core.Data.Models;

namespace Core.Application.Strategy.Errors
{
  public class DatabaseDuplicatedEntryError : Error
    {

        public override Error GetError()
        {
            

            Code = 14;

            Message = "Esta entidade não pode ter valores duplicados na base";

            return this;

        }


    }
}