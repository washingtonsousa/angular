using System.Collections.Generic;
using System.Linq;
using RiscServicesHRSharepointAddIn.Models;

namespace RiscServicesHRSharepointAddIn.Repositories
{
  public class CertCursoRepository : RepositoryTemplate
    {
 

        public CertCursoRepository() 
        {
    
        }

        public IList<CertCurso> GetCertCursos()
        {

            return this.Context.CertCursos.ToList();

        }

        public CertCurso FindCertCurso(int Id)
        {

            return this.Context.CertCursos.Where(c => c.Id == Id).FirstOrDefault();
        }

        internal CertCurso FindCertCursoByUsuarioId(int UsuarioId)
        {
            return this.Context.CertCursos.Where(c => c.UsuarioId == UsuarioId).FirstOrDefault();
        }

        public IList<CertCurso> GetCertCursosByUsuarioId(int UsuarioId)
        {

            return this.Context.CertCursos.Where(c => c.UsuarioId == UsuarioId).ToList();
        }

        public CertCurso FindCertCursoByBothIds(int Id, int UsuarioId)
        {

            return this.Context.CertCursos.Where(c => c.UsuarioId == UsuarioId && c.Id == Id).FirstOrDefault();
        }

        public void UpdateCertCurso(CertCurso CertCursoData)
        {
            CertCursoData.Atualizado_em = System.DateTime.Now;
            this.Context.CertCursos.Update(CertCursoData);

        }

        public void InsertCertCurso(CertCurso CertCurso)
        {
            this.Context.CertCursos.Add(CertCurso);


        }

        public void DeleteCertCurso(CertCurso CertCurso)
        {
            this.Context.CertCursos.Remove(CertCurso);

        }

    }
}