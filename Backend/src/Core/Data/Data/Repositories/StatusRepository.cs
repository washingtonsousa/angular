using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Data.Interfaces;
using Core.Data.Models;
using Core.Data.ORM;

namespace Core.Data.Repositories
{
  public class StatusRepository:  IStatusRepository
    {



        private HrDbContext Context;
        public StatusRepository(HrDbContext context)
        {
            Context = context;
        }


        public void Delete(Status status)
        {

            this.Context.Status.Remove(status);
        }


        public void Update(Status status)
        {
            status.Atualizado_em = System.DateTime.Now;
            this.Context.Status.Update(status);

        }

        public void Insert(Status status)
        {

            this.Context.Status.Add(status);

        }

        public IList<Status> Get()
        {

            return this.Context.Status.ToList();
        }

        public Status Find(int id)
        {
            return this.Context.Status.Find(id);
        }

        public Task<Status> FindAsync(int Id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IList<Status>> GetAsync()
        {
            throw new System.NotImplementedException();
        }

        public int GetCount()
        {
            throw new System.NotImplementedException();
        }
    }


}
