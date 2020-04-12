using Core.Data.Models;
using Core.Shared.Kernel.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Specification
{
    public static class CategoriaConhecimentoSpecification
    {

        public static bool ValidForDeletion(this CategoriaConhecimento categoriaConhecimento)
        {
            return AssertionConcern.IsSatisfiedBy(
                            AssertionConcern.AssertNotNull(categoriaConhecimento.Conhecimentos, "Categoria não pode ser deletada, apague os conhecimentos que estão associados a ela")
                );
        }

    }
}
