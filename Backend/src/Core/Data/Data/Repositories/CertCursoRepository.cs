using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Data.Interfaces;
using Core.Data.Models;
using Core.Data.ORM;

namespace Core.Data.Repositories
{
  public class CertCursoRepository :  ICertCursoRepository
    {



        private HrDbContext Context;
        public CertCursoRepository(HrDbContext context)
        {
            Context = context;
        }

        public IList<CertCurso> Get()
        {

            return this.Context.CertCursos.ToList();

        }

        public CertCurso Find(int Id)
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

        public void Update(CertCurso CertCursoData)
        {
            CertCursoData.Atualizado_em = System.DateTime.Now;
            this.Context.CertCursos.Update(CertCursoData);

        }

        public void Insert(CertCurso CertCurso)
        {
            this.Context.CertCursos.Add(CertCurso);


        }

        public void Delete(CertCurso CertCurso)
        {
            this.Context.CertCursos.Remove(CertCurso);

        }

        public Task<CertCurso> FindAsync(int Id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IList<CertCurso>> GetAsync()
        {
            throw new System.NotImplementedException();
        }

        public int GetCount()
        {
            throw new System.NotImplementedException();
        }
    }
}