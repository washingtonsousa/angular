using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Data.Interfaces;
using Core.Data.Models;
using Core.Data.ORM;
using Microsoft.EntityFrameworkCore;

namespace Core.Data.Repositories
{
  public class ArquivoRepository :  IArquivoRepository
    {
        private HrDbContext Context;
        public ArquivoRepository(HrDbContext context)
        {
            Context = context;
        }


        public Arquivo FindByBothIds(int Id, int UsuarioId)
        {

            return this.Context.Arquivos.Where(e => e.Id == Id && e.UsuarioId == UsuarioId).FirstOrDefault();

        }

        public IList<Arquivo> GetByBothIds(int Id, int UsuarioId)
        {

            return this.Context.Arquivos.Where(e => e.Id == Id && e.UsuarioId == UsuarioId).ToList();

        }



        public IList<Arquivo> GetByUsuarioId(int UsuarioId)
        {

            return Context.Arquivos.Include(a => a.Usuario).Where(e => e.UsuarioId == UsuarioId).OrderBy(a => a.Criado_em).ToList();

        }




        public IList<Arquivo> Get()
        {
            return this.Context.Arquivos.Include(a => a.Usuario).OrderByDescending(a=> a.Criado_em).ToList();

        }



        public async Task<IList<Arquivo>> GetAsync()
        {
            return await Context.Arquivos.Include(a => a.Usuario).OrderByDescending(a => a.Criado_em).ToListAsync();

        }

        public Arquivo Find(int Id)
        {
            return this.Context.Arquivos.Include(a => a.Usuario).Where(e => e.Id == Id).FirstOrDefault();

        }

        public async Task<Arquivo> FindAsync(int Id)
        {
            return await Context.Arquivos.Include(a => a.Usuario).Where(e => e.Id == Id).FirstOrDefaultAsync();

        }


        public void Insert(Arquivo Arquivo)
        {
            this.Context.Arquivos.Add(Arquivo);
        }


        public void Delete(Arquivo Arquivo)
        {
            this.Context.Arquivos.Remove(Arquivo);

        }

        public void Update(Arquivo ArquivoData)
        {
            ArquivoData.Atualizado_em = System.DateTime.Now;
            this.Context.Arquivos.Update(ArquivoData);

        }

        public int GetCount()
        {
            throw new System.NotImplementedException();
        }
    }
}
