using System.Collections.Generic;
using System.Linq;
using Core.Data.Models;

namespace Core.Data.Repositories
{
  public class FormAcademicaRepository : RepositoryTemplate
    {
      

        public FormAcademicaRepository()
        {

        }

        public IList<FormAcademica> GetFormAcademicas()
        {

            return this.Context.FormAcademicas.ToList();

        }

        public FormAcademica FindFormAcademica(int Id)
        {

            return this.Context.FormAcademicas.Where(c => c.Id == Id).FirstOrDefault();
        }

        internal FormAcademica FindFormAcademicaByUsuarioId(int UsuarioId)
        {
            return this.Context.FormAcademicas.Where(f => f.UsuarioId == UsuarioId).FirstOrDefault();
        }

        public IList<FormAcademica> GetFormAcademicasByUsuarioId(int UsuarioId)
        {

            return this.Context.FormAcademicas.Where(c => c.UsuarioId == UsuarioId).ToList();
        }

        public FormAcademica FindFormAcademicaByBothIds(int Id, int UsuarioId)
        {

            return this.Context.FormAcademicas.Where(c => c.UsuarioId == UsuarioId && c.Id == Id).FirstOrDefault();
        }

        public void UpdateFormAcademica(FormAcademica FormAcademicaData)
        {
            FormAcademicaData.Atualizado_em = System.DateTime.Now;
            this.Context.FormAcademicas.Update(FormAcademicaData);

        }

        public void InsertFormAcademica(FormAcademica FormAcademica)
        {
            this.Context.FormAcademicas.Add(FormAcademica);


        }

        public void DeleteFormAcademica(FormAcademica FormAcademica)
        {
            this.Context.FormAcademicas.Remove(FormAcademica);

        }

    }
}