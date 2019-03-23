using System.Collections.Generic;
using System.Linq;
using RiscServicesHRSharepointAddIn.Models;

namespace RiscServicesHRSharepointAddIn.Repositories
{
  public class ResumoRepository : RepositoryTemplate
    {


        public ResumoRepository()
        {
         
        }

        public IList<Resumo> GetResumos()
        {

            return this.Context.Resumos.ToList();

        }

        public Resumo FindResumo(int Id)
        {

            return this.Context.Resumos.Where(c => c.Id == Id).FirstOrDefault();
        }

        public Resumo FindResumoByUsuarioId(int UsuarioId)
        {

            return this.Context.Resumos.Where(c => c.UsuarioId == UsuarioId).FirstOrDefault();
        }

        public Resumo FindResumoByBothIds(int Id, int UsuarioId)
        {

            return this.Context.Resumos.Where(c => c.UsuarioId == UsuarioId && c.Id == Id).FirstOrDefault();
        }

        public void UpdateResumo(Resumo ResumoData)
        {
            ResumoData.Atualizado_em = System.DateTime.Now;
            this.Context.Resumos.Update(ResumoData);

        }

      

        public void InsertResumo(Resumo Resumo)
        {
            this.Context.Resumos.Add(Resumo);


        }

        public void DeleteResumo(Resumo Resumo)
        {
            this.Context.Resumos.Remove(Resumo);

        }

    }
}