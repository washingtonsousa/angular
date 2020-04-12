using Core.Data.Models;

namespace Core.Data.Interfaces
{
    public interface IResumoRepository : IRepository<Resumo>
    {
        Resumo FindByBothIds(int Id, int UsuarioId);
        Resumo FindByUsuarioId(int UsuarioId);
    }
}
