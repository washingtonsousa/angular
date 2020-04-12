using Core.Data.Models;
using System.Collections.Generic;

namespace Core.Data.Interfaces
{
    public interface ICertCursoRepository : IRepository<CertCurso>
    {
        CertCurso FindCertCursoByUsuarioId(int UsuarioId);
        IList<CertCurso> GetCertCursoByUsuarioId(int UsuarioId);
    }
}
