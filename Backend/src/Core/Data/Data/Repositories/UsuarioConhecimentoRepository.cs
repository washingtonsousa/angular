using Core.Data.ORM;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Data.Interfaces;
using Core.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Core.Data.Repositories
{
  public class UsuarioConhecimentoRepository :  IUsuarioConhecimentoRepository
    {
        private HrDbContext Context;
        public UsuarioConhecimentoRepository(HrDbContext context)
        {
            Context = context;
        }


        public IList<UsuarioConhecimento> Get()
        {

            return this.Context.UsuarioConhecimentos.Include(us=>us.Usuario)
                .Include(u => u.Conhecimento)
                .ToList();



        }

        public void Insert(UsuarioConhecimento UsuarioConhecimento)
        {
        

            this.Context.UsuarioConhecimentos.Add(UsuarioConhecimento);

        }

        public void Delete(UsuarioConhecimento UsuarioConhecimento)
        {

            this.Context.UsuarioConhecimentos.Remove(UsuarioConhecimento);

        }

        public void Update(UsuarioConhecimento UsuarioConhecimentoData)
        {

            UsuarioConhecimentoData.Atualizado_em = System.DateTime.Now;

            this.Context.UsuarioConhecimentos.Update(UsuarioConhecimentoData);

        }



        public UsuarioConhecimento Find(int Id)
        {

            return this.Context.UsuarioConhecimentos.Where(c => c.Id == Id).FirstOrDefault();
        }

        public Task<UsuarioConhecimento> FindAsync(int Id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IList<UsuarioConhecimento>> GetAsync()
        {
            throw new System.NotImplementedException();
        }

        public int GetCount()
        {
            throw new System.NotImplementedException();
        }
    }
}
