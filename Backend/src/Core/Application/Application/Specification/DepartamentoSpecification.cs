using Core.Data.Models;
using Core.Shared.Kernel.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Specification
{
    public static class DepartamentoSpecification
    {

        public static bool ValidDeletion(this Departamento departamento)
        {
           return AssertionConcern.IsSatisfiedBy(

                AssertionConcern.AssertNull(departamento.Cargos, "Departamento possue cargos cadastrados e portanto não pode ser deletado")

                );
        }

    }
}
