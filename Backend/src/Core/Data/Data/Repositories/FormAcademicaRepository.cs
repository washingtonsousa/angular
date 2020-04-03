using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Data.Interfaces;
using Core.Data.Models;
using Core.Data.ORM;

namespace Core.Data.Repositories
{
  public class FormAcademicaRepository :  IFormAcademicaRepository
    {


        private HrDbContext Context;
        public FormAcademicaRepository(HrDbContext context)
        {
            Context = context;
        }


        public IList<FormAcademica> Get()
        {

            return this.Context.FormAcademicas.ToList();

        }

        public FormAcademica Find(int Id)
        {

            return this.Context.FormAcademicas.Where(c => c.Id == Id).FirstOrDefault();
        }

        internal FormAcademica FindByUsuarioId(int UsuarioId)
        {
            return this.Context.FormAcademicas.Where(f => f.UsuarioId == UsuarioId).FirstOrDefault();
        }

        public IList<FormAcademica> GetByUsuarioId(int UsuarioId)
        {

            return this.Context.FormAcademicas.Where(c => c.UsuarioId == UsuarioId).ToList();
        }

        public FormAcademica FindByBothIds(int Id, int UsuarioId)
        {

            return this.Context.FormAcademicas.Where(c => c.UsuarioId == UsuarioId && c.Id == Id).FirstOrDefault();
        }

        public void Update(FormAcademica FormAcademicaData)
        {
            FormAcademicaData.Atualizado_em = System.DateTime.Now;
            this.Context.FormAcademicas.Update(FormAcademicaData);

        }

        public void Insert(FormAcademica FormAcademica)
        {
            this.Context.FormAcademicas.Add(FormAcademica);


        }

        public void Delete(FormAcademica FormAcademica)
        {
            this.Context.FormAcademicas.Remove(FormAcademica);

        }

        public Task<FormAcademica> FindAsync(int Id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IList<FormAcademica>> GetAsync()
        {
            throw new System.NotImplementedException();
        }

        public int GetCount()
        {
            throw new System.NotImplementedException();
        }
    }
}