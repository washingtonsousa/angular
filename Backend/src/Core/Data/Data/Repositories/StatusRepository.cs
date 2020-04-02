using System.Collections.Generic;
using System.Linq;
using Core.Data.Models;

namespace Core.Data.Repositories
{
  public class StatusRepository: RepositoryTemplate
    {

  

        public StatusRepository()
        { 

        }

        public void DeleteStatus(Status status)
        {

            this.Context.Status.Remove(status);
        }


        public void UpdateStatus(Status status)
        {
            status.Atualizado_em = System.DateTime.Now;
            this.Context.Status.Update(status);

        }

        public void InsertStatus(Status status)
        {

            this.Context.Status.Add(status);

        }

        public IList<Status> GetStatus()
        {

            return this.Context.Status.ToList();
        }

        internal Status FindStatus(int id)
        {
            return this.Context.Status.Find(id);
        }
    }


}
