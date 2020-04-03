using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Data.Interfaces;
using Core.Data.Models;
using Core.Data.ORM;
using Microsoft.EntityFrameworkCore;

namespace Core.Data.Repositories
{
  public class ConhecimentoRepository :  IConhecimentoRepository
    {


        private HrDbContext Context;
        public ConhecimentoRepository(HrDbContext context)
        {
            Context = context;
        }

        public int getTotalNumberCountRegisters()
        {

            return this.Context.Conhecimentos.Count();

        }

        public IList<Conhecimento> Get()
        {

            IList<Conhecimento> conhecimentos = this.Context.Conhecimentos.Include(c => c.UsuarioConhecimentos).Include(c => c.CategoriaConhecimento)
        .Include(c => c.CategoriaConhecimento).OrderBy(c => c.Nome).ToList();

            return conhecimentos;

        }

        public Conhecimento Find(int Id)
        {
            return this.Context.Conhecimentos.Include(c => c.CategoriaConhecimento).FirstOrDefault(e => e.Id == Id);

        }

        public void Insert(Conhecimento Conhecimento)
        {
        
            this.Context.Conhecimentos.Add(Conhecimento);
        }


        public void Delete(Conhecimento Conhecimento)
        {
            this.Context.Conhecimentos.Remove(Conhecimento);

        }

        public void Update(Conhecimento ConhecimentoData)
        {
            ConhecimentoData.Atualizado_em = System.DateTime.Now;
      ConhecimentoData.Atualizado_em = System.DateTime.Now;
      this.Context.Conhecimentos.Update(ConhecimentoData);

        }

        public Task<Conhecimento> FindAsync(int Id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IList<Conhecimento>> GetAsync()
        {
            throw new System.NotImplementedException();
        }

        public int GetCount()
        {
            throw new System.NotImplementedException();
        }
    }
}
