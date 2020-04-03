using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Data.Interfaces;
using Core.Data.Models;
using Core.Data.ORM;

namespace Core.Data.Repositories
{
  public class IdiomaRepository :  IIdiomaRepository
    {


        private HrDbContext Context;
        public IdiomaRepository(HrDbContext context)
        {
            Context = context;
        }


        public IList<Idioma> Get()
        {

            return this.Context.Idiomas.ToList();

        }

        public Idioma Find(int Id)
        {

            return this.Context.Idiomas.Where(c => c.Id == Id).FirstOrDefault();
        }

       

        public IList<Idioma> GetByUsuarioId(int UsuarioId)
        {

            return this.Context.Idiomas.Where(c => c.UsuarioId == UsuarioId).ToList();
        }

        public Idioma FindByBothIds(int Id, int UsuarioId)
        {

            return this.Context.Idiomas.Where(c => c.UsuarioId == UsuarioId && c.Id == Id).FirstOrDefault();
        }

        public void Update(Idioma IdiomaData)
        {
            IdiomaData.Atualizado_em = System.DateTime.Now;
            this.Context.Idiomas.Update(IdiomaData);

        }



        public void Insert(Idioma Idioma)
        {
            this.Context.Idiomas.Add(Idioma);


        }

        public void Delete(Idioma Idioma)
        {
            this.Context.Idiomas.Remove(Idioma);

        }

        public Task<Idioma> FindAsync(int Id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IList<Idioma>> GetAsync()
        {
            throw new System.NotImplementedException();
        }

        public int GetCount()
        {
            throw new System.NotImplementedException();
        }
    }
}