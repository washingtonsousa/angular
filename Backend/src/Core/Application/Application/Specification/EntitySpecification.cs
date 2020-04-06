using Core.Data.Models;
using Core.Shared.Kernel.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Specification
{
    public static class EntitySpecification
    {

        public static bool Exists(this Entity entity)
        {
            return !AssertionConcern.IsSatisfiedBy(

                AssertionConcern.AssertNull(entity, "Entidade já existe no sistema e operação não pode ser realizada")


            );
        }


        public static bool NotExists(this Entity entity)
        {
            return !AssertionConcern.IsSatisfiedBy(

                AssertionConcern.AssertNotNull(entity, "Entidade não existe no sistema ou não foi encontrado e operação não pode ser realizada")


            );
        }



    }
}
