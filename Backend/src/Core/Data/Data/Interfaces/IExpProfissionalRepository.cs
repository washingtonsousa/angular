using Core.Data.Models;

namespace Core.Data.Interfaces
{
    public interface IExpProfissionalRepository : IRepository<ExpProfissional>
    {
        ExpProfissional FindByBothIds(int Id, int UsuarioId);
    }
}
