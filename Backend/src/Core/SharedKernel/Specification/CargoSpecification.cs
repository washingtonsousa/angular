using Core.Data.Models;
using Core.Shared.Kernel.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.SharedKernel.Specification
{
    public static class CargoSpecification
    {

        public static bool ValidForDeletion(this Cargo cargo)
        {
          return  AssertionConcern.IsSatisfiedBy(
                        AssertionConcern.AssertNull(cargo.Usuarios, "Cargo Possue Funcionários cadastrados que dependem dele e não pode ser deletado")
            );
        }

    }
}
