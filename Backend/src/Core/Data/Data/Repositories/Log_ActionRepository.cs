using System.Collections.Generic;
using System.Linq;
using Core.Data.Models;

namespace Core.Data.Repositories
{
  public class Log_ActionRepository : RepositoryTemplate
    {




        public Log_ActionRepository()
        {

        }

    public IList<Log_Action> GetLog_ActionsOrderedByData_Acesso()
    {

      return this.Context.Log_Actions.OrderByDescending(l => l.Data_Acesso).ToList();



    }

    public IList<Log_Action> GetLog_Actions()
        {

            return this.Context.Log_Actions.ToList();



        }

        public void InsertLog_Action(Log_Action Log_Action)
        {

            this.Context.Log_Actions.Add(Log_Action);

        }

        public void DeleteLog_Action(Log_Action Log_Action)
        {

            this.Context.Log_Actions.Remove(Log_Action);

        }

        public void UpdateLog_Action(Log_Action Log_ActionData)
        {


            this.Context.Log_Actions.Update(Log_ActionData);

        }



        public Log_Action FindLog_ActionById(int id)
        {

            return this.Context.Log_Actions.Where(c => c.Id == id).FirstOrDefault();
        }



    }
}
