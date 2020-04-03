using Core.Data.Models;
using System.Collections.Generic;

namespace Core.Data.Interfaces
{
     public interface IArquivoRepository : IRepository<Arquivo>
    {

        Arquivo FindByBothIds(int Id, int UsuarioId);
        IList<Arquivo> GetByBothIds(int Id, int UsuarioId);
        IList<Arquivo> GetByUsuarioId(int UsuarioId);

    }
}
