using Core.Data.Models;
using Core.Shared.Kernel.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Specification
{
    public static class StatusSpecification
    {

        public static bool ValidForUpdateOrDeletion(this Status status)
        {
            return AssertionConcern.IsSatisfiedBy(

                AssertionConcern.AssertFalse(status.Nome == "ativo" || status.Nome == "desativado", "Você não pode deletar status que são padrão do sistema")
                );
        }

    }
}
