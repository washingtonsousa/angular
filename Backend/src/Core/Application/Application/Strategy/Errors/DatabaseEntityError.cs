using Core.Data.Models;

namespace Core.Application.Strategy.Errors
{
  public class DatabaseEntityError : Error
    {

        public override Error GetError()
        {
            

            Code = 03;

            Message = "Não foi possível realizar esta operação de dados, pois esta entidade possui outras entidades relacionadas " +
                "que precisam ser deletadas para haver a exclusão desta entidade ou esta entidade é mandatória para funcionamento do sistema" +
                " e não pode sofrer operações de CRUD.";

            return this;

        }
    }
    }