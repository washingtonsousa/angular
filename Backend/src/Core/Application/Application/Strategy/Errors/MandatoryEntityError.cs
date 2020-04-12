using Core.Data.Models;

namespace Core.Application.Strategy.Errors
{
  public class MandatoryEntityError : Error
    {

        public override Error GetError()
        {
            

            Code = 11;

            Message = "A operação não pode ser realizada, pois a entidade é mandatória, contate o administrador para mais detalhes";

            return this;

        }


    }
}