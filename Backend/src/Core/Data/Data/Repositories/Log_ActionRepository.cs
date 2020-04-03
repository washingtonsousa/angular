using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Data.Interfaces;
using Core.Data.Models;
using Core.Data.ORM;

namespace Core.Data.Repositories
{
  public class Log_ActionRepository :  ILog_ActionRepository
    {



        private HrDbContext Context;
        public Log_ActionRepository(HrDbContext context)
        {
            Context = context;
        }


        public IList<Log_Action> GetOrderedByData_Acesso()
    {

      return this.Context.Log_Actions.OrderByDescending(l => l.Data_Acesso).ToList();



    }

    public IList<Log_Action> Get()
        {

            return this.Context.Log_Actions.ToList();



        }

        public void Insert(Log_Action Log_Action)
        {

            this.Context.Log_Actions.Add(Log_Action);

        }

        public void Delete(Log_Action Log_Action)
        {

            this.Context.Log_Actions.Remove(Log_Action);

        }

        public void Update(Log_Action Log_ActionData)
        {


            this.Context.Log_Actions.Update(Log_ActionData);

        }



        public Log_Action Find(int id)
        {

            return this.Context.Log_Actions.Where(c => c.Id == id).FirstOrDefault();
        }

        public Task<Log_Action> FindAsync(int Id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IList<Log_Action>> GetAsync()
        {
            throw new System.NotImplementedException();
        }

        public int GetCount()
        {
            throw new System.NotImplementedException();
        }
    }
}
