using System.Collections.Generic;
using System.Linq;
using Core.Data.Models;

namespace Core.Data.Repositories
{
  public class ExpProfissionalRepository : RepositoryTemplate
    {

   

        public ExpProfissionalRepository()
        {

        
        }



        public IList<ExpProfissional> GetExpProfissionais()
        {

            return this.Context.ExpProfissionais.ToList();



        }

        public void InsertExpProfissional(ExpProfissional ExpProfissional)
        {
            

            this.Context.ExpProfissionais.Add(ExpProfissional);

        }

        internal ExpProfissional FindExpProfissionalByUsuarioId(int UsuarioId)
        {
            return this.Context.ExpProfissionais.Where(e => e.UsuarioId == UsuarioId).FirstOrDefault();
        }

        public void DeleteExpProfissional(ExpProfissional ExpProfissional)
        {

            this.Context.ExpProfissionais.Remove(ExpProfissional);

        }

        public void UpdateExpProfissional(ExpProfissional ExpProfissionalData)
        {

            ExpProfissionalData.Atualizado_em = System.DateTime.Now;

            this.Context.ExpProfissionais.Update(ExpProfissionalData);

        }



        public ExpProfissional FindExpProfissionalById(int id)
        {

            return this.Context.ExpProfissionais.Where(c => c.Id == id).FirstOrDefault();
        }

        internal ExpProfissional FindExpProfissionalByBothIds(int Id, int UsuarioId)
        {
            return this.Context.ExpProfissionais.Where(c => c.UsuarioId == UsuarioId && c.Id == Id).FirstOrDefault();
        }

        internal IList<ExpProfissional> GetExpProfissionaisByUsuarioId(int UsuarioId)
        {
            return this.Context.ExpProfissionais.Where(e => e.UsuarioId == UsuarioId).ToList();
        }
    }
}