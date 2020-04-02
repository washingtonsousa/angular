using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.Interfaces
{
    public interface IRepository<T>
    {
      
        T Find(int Id);

        Task<T> FindAsync(int Id);

        void Delete(T model);


        void Update(T model, T modelFromDb);


        void Insert(T model);

        IList<T> Get();

        Task<IList<T>> GetAsync();
    }
}
