using Core.Data.Interfaces;
using Core.Data.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Abstractions
{
    public class AppService
    {
        protected readonly IUnityOfWork _unityOfWork;

        public AppService(IUnityOfWork unitOfWork)
        {
            _unityOfWork = unitOfWork;
        }
        



    }
}
