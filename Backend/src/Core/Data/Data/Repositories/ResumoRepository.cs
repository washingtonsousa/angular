using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Data.Interfaces;
using Core.Data.Models;
using Core.Data.ORM;

namespace Core.Data.Repositories
{
  public class ResumoRepository :  IResumoRepository
    {


        private HrDbContext Context;
        public ResumoRepository(HrDbContext context)
        {
            Context = context;
        }


        public IList<Resumo> Get()
        {

            return this.Context.Resumos.ToList();

        }

        public Resumo Find(int Id)
        {

            return this.Context.Resumos.Where(c => c.Id == Id).FirstOrDefault();
        }

        public Resumo FindByUsuarioId(int UsuarioId)
        {

            return this.Context.Resumos.Where(c => c.UsuarioId == UsuarioId).FirstOrDefault();
        }

        public Resumo FindByBothIds(int Id, int UsuarioId)
        {

            return this.Context.Resumos.Where(c => c.UsuarioId == UsuarioId && c.Id == Id).FirstOrDefault();
        }

        public void Update(Resumo ResumoData)
        {
            ResumoData.Atualizado_em = System.DateTime.Now;
            this.Context.Resumos.Update(ResumoData);

        }

      

        public void Insert(Resumo Resumo)
        {
            this.Context.Resumos.Add(Resumo);


        }

        public void Delete(Resumo Resumo)
        {
            this.Context.Resumos.Remove(Resumo);

        }

        public Task<Resumo> FindAsync(int Id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IList<Resumo>> GetAsync()
        {
            throw new System.NotImplementedException();
        }

        public int GetCount()
        {
            throw new System.NotImplementedException();
        }
    }
}