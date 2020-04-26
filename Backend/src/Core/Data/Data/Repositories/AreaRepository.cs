using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Data.Interfaces;
using Core.Data.Models;
using Core.Data.ORM;
using Microsoft.EntityFrameworkCore;

namespace Core.Data.Repositories
{
  public class AreaRepository : IAreaRepository
    {
        private HrDbContext Context;
        public AreaRepository(HrDbContext context) 
        {
            Context = context;
        }

        public IList<Area> Get()
        {
            return this.Context.Areas.OrderBy(a => a.Nome).ToList();

        }

        public Area Find(int Id)
        {
            return this.Context.Areas
                .Include(u => u.Departamentos)
                .FirstOrDefault(e => e.Id == Id);

        }

        public void Insert(Area Area)
        {
           
            this.Context.Add(Area);
        }


        public void Delete(Area Area)
        {
            this.Context.Areas.Remove(Area);

        }

        public void Update(Area AreaData)
        {
            AreaData.Atualizado_em = System.DateTime.Now;
            this.Context.Areas.Update(AreaData);

        }

        public Task<Area> FindAsync(int Id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Area model, Area modelFromDb)
        {
            throw new System.NotImplementedException();
        }

        public Task<IList<Area>> GetAsync()
        {
            throw new System.NotImplementedException();
        }

        public int GetCount()
        {
            return this.Context.Areas.Count();
        }
    }
}