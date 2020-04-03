using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.SharedKernel.Interfaces
{
     public interface IContainer
    {
        object GetService(Type serviceType);
        T GetService<T>();

        IEnumerable<object> GetServices(Type serviceType);

        IEnumerable<T> GetServices<T>();
    }
}
