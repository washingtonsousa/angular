using Core.Data.Models;

namespace Core.Data.Interfaces
{
    public interface IFormAcademicaRepository : IRepository<FormAcademica>
    {
        FormAcademica FindByBothIds(int Id, int UsuarioId);
    }
}
