using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Data.Interfaces;
using Core.Data.Models;
using Core.Data.ORM;

namespace Core.Data.Repositories
{
  public class ExpProfissionalRepository :  IExpProfissionalRepository
    {



        private HrDbContext Context;
        public ExpProfissionalRepository(HrDbContext context)
        {
            Context = context;
        }




        public IList<ExpProfissional> Get()
        {

            return this.Context.ExpProfissionais.ToList();



        }

        public void Insert(ExpProfissional ExpProfissional)
        {
            

            this.Context.ExpProfissionais.Add(ExpProfissional);

        }

        internal ExpProfissional FindByUsuarioId(int UsuarioId)
        {
            return this.Context.ExpProfissionais.Where(e => e.UsuarioId == UsuarioId).FirstOrDefault();
        }

        public void Delete(ExpProfissional ExpProfissional)
        {

            this.Context.ExpProfissionais.Remove(ExpProfissional);

        }

        public void Update(ExpProfissional ExpProfissionalData)
        {

            ExpProfissionalData.Atualizado_em = System.DateTime.Now;

            this.Context.ExpProfissionais.Update(ExpProfissionalData);

        }



        public ExpProfissional Find(int id)
        {

            return this.Context.ExpProfissionais.Where(c => c.Id == id).FirstOrDefault();
        }

        internal ExpProfissional FindByBothIds(int Id, int UsuarioId)
        {
            return this.Context.ExpProfissionais.Where(c => c.UsuarioId == UsuarioId && c.Id == Id).FirstOrDefault();
        }

        internal IList<ExpProfissional> GetByUsuarioId(int UsuarioId)
        {
            return this.Context.ExpProfissionais.Where(e => e.UsuarioId == UsuarioId).ToList();
        }

        public Task<ExpProfissional> FindAsync(int Id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IList<ExpProfissional>> GetAsync()
        {
            throw new System.NotImplementedException();
        }

        public int GetCount()
        {
            throw new System.NotImplementedException();
        }
    }
}