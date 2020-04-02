using System.Collections.Generic;
using System.Linq;
using Core.Data.Models;

namespace Core.Data.Repositories
{
  public class IdiomaRepository : RepositoryTemplate
    {


        public IdiomaRepository()
        {
        }

        public IList<Idioma> GetIdiomas()
        {

            return this.Context.Idiomas.ToList();

        }

        public Idioma FindIdioma(int Id)
        {

            return this.Context.Idiomas.Where(c => c.Id == Id).FirstOrDefault();
        }

       

        public IList<Idioma> GetIdiomasByUsuarioId(int UsuarioId)
        {

            return this.Context.Idiomas.Where(c => c.UsuarioId == UsuarioId).ToList();
        }

        public Idioma FindIdiomaByBothIds(int Id, int UsuarioId)
        {

            return this.Context.Idiomas.Where(c => c.UsuarioId == UsuarioId && c.Id == Id).FirstOrDefault();
        }

        public void UpdateIdioma(Idioma IdiomaData)
        {
            IdiomaData.Atualizado_em = System.DateTime.Now;
            this.Context.Idiomas.Update(IdiomaData);

        }



        public void InsertIdioma(Idioma Idioma)
        {
            this.Context.Idiomas.Add(Idioma);


        }

        public void DeleteIdioma(Idioma Idioma)
        {
            this.Context.Idiomas.Remove(Idioma);

        }

    }
}