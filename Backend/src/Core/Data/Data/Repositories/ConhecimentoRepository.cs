using System.Collections.Generic;
using System.Linq;
using Core.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Core.Data.Repositories
{
  public class ConhecimentoRepository : RepositoryTemplate
    {
    
        public ConhecimentoRepository() { }

      public int getTotalNumberCountRegisters()
        {

            return this.Context.Conhecimentos.Count();

        }

        public IList<Conhecimento> GetConhecimentos()
        {

            IList<Conhecimento> conhecimentos = this.Context.Conhecimentos.Include(c => c.UsuarioConhecimentos).Include(c => c.CategoriaConhecimento)
        .Include(c => c.CategoriaConhecimento).OrderBy(c => c.Nome).ToList();

            return conhecimentos;

        }

        public Conhecimento FindConhecimento(int Id)
        {
            return this.Context.Conhecimentos.Include(c => c.CategoriaConhecimento).FirstOrDefault(e => e.Id == Id);

        }

        public void InsertConhecimento(Conhecimento Conhecimento)
        {
        
            this.Context.Conhecimentos.Add(Conhecimento);
        }


        public void DeleteConhecimento(Conhecimento Conhecimento)
        {
            this.Context.Conhecimentos.Remove(Conhecimento);

        }

        public void UpdateConhecimento(Conhecimento ConhecimentoData)
        {
            ConhecimentoData.Atualizado_em = System.DateTime.Now;
      ConhecimentoData.Atualizado_em = System.DateTime.Now;
      this.Context.Conhecimentos.Update(ConhecimentoData);

        }
    }
}
