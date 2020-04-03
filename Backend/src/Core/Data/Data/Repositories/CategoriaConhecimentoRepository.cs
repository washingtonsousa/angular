using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Data.Interfaces;
using Core.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Core.Data.Repositories
{
  public class CategoriaConhecimentoRepository : RepositoryTemplate, ICategoriaConhecimentoRepository
    {
    
        public CategoriaConhecimentoRepository() { }

        public IList<CategoriaConhecimento> Get()
        {

      IList<CategoriaConhecimento> categoriaConhecimentos = this.Context.CategoriaConhecimentos.Include(c => c.Conhecimentos).OrderBy(c => c.Categoria).ToList();

            return categoriaConhecimentos;

        }

        public CategoriaConhecimento Find(int Id)
        {
            return this.Context.CategoriaConhecimentos.Include(c => c.Conhecimentos).FirstOrDefault(e => e.Id == Id);

        }

        public void Insert(CategoriaConhecimento CategoriaConhecimento)
        {
        
            this.Context.CategoriaConhecimentos.Add(CategoriaConhecimento);
        }


        public void Delete(CategoriaConhecimento CategoriaConhecimento)
        {
            this.Context.CategoriaConhecimentos.Remove(CategoriaConhecimento);

        }

        public void Update(CategoriaConhecimento CategoriaConhecimentoData)
        {
            CategoriaConhecimentoData.Atualizado_em = System.DateTime.Now;
            this.Context.CategoriaConhecimentos.Update(CategoriaConhecimentoData);

        }

        public Task<CategoriaConhecimento> FindAsync(int Id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IList<CategoriaConhecimento>> GetAsync()
        {
            throw new System.NotImplementedException();
        }

        public int GetCount()
        {
            return this.Context.CategoriaConhecimentos.Count();
        }
    }
}
