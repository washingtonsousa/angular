using Core.Data.Models;
using Core.Shared.Kernel.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Specification
{
    public static class AreaSpecification
    {


        public static bool ValidaParaDeletar(this Area area)
        {
            return AssertionConcern.IsSatisfiedBy(

                AssertionConcern.AssertNull(area?.Departamentos, "Existem departamentos para esta area e que impedem que esta seja deletada")
                

            );
        }

    }
}
