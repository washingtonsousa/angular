using Core.Application.Entities;
using Core.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Interfaces
{
    public interface IStatisticsAppService
    {

         object GetUsuarioBasic();

         EntitiesStatistics GetEntidadesBasic();


         IList<LogActionStatistics> GetLogActionStatistics(string Year = null, string Month = null, string Day = null);

         IList<Log_Action> GetLogActionLimitedList(string Year = null, string Month = null, string Day = null);

    }
}
