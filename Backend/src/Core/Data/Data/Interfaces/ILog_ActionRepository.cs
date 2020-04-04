using Core.Data.Models;
using System.Collections.Generic;

namespace Core.Data.Interfaces
{
    public interface ILog_ActionRepository : IRepository<Log_Action>
    {
        IList<Log_Action> GetOrderedByData_Acesso();
    }
}
