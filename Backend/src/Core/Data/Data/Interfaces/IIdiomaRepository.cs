using Core.Data.Models;

namespace Core.Data.Interfaces
{
    public interface IIdiomaRepository : IRepository<Idioma>
    {
        Idioma FindByBothIds(int Id, int UsuarioId);



    }
}
