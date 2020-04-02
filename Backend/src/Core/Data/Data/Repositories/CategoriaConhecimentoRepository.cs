using System.Collections.Generic;
using System.Linq;
using Core.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Core.Data.Repositories
{
  public class CategoriaConhecimentoRepository : RepositoryTemplate
    {
    
        public CategoriaConhecimentoRepository() { }

      public int getTotalNumberCountRegisters()
        {

            return this.Context.CategoriaConhecimentos.Count();

        }

        public IList<CategoriaConhecimento> GetCategoriaConhecimentos()
        {

      IList<CategoriaConhecimento> categoriaConhecimentos = this.Context.CategoriaConhecimentos.Include(c => c.Conhecimentos).OrderBy(c => c.Categoria).ToList();

            return categoriaConhecimentos;

        }

        public CategoriaConhecimento FindCategoriaConhecimento(int Id)
        {
            return this.Context.CategoriaConhecimentos.Include(c => c.Conhecimentos).FirstOrDefault(e => e.Id == Id);

        }

        public void InsertCategoriaConhecimento(CategoriaConhecimento CategoriaConhecimento)
        {
        
            this.Context.CategoriaConhecimentos.Add(CategoriaConhecimento);
        }


        public void DeleteCategoriaConhecimento(CategoriaConhecimento CategoriaConhecimento)
        {
            this.Context.CategoriaConhecimentos.Remove(CategoriaConhecimento);

        }

        public void UpdateCategoriaConhecimento(CategoriaConhecimento CategoriaConhecimentoData)
        {
            CategoriaConhecimentoData.Atualizado_em = System.DateTime.Now;
            this.Context.CategoriaConhecimentos.Update(CategoriaConhecimentoData);

        }
    }
}
