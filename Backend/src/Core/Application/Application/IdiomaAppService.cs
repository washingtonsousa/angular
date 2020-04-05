using Core.Application.Abstractions;
using Core.Application.Interfaces;
using Core.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application
{
    public class IdiomaAppService : AppService, IIdiomaAppService
    {
        public IdiomaAppService(IUnityOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
