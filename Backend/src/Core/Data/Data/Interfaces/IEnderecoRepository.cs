using Core.Data.Models;

namespace Core.Data.Interfaces
{
    public interface IEnderecoRepository : IRepository<Endereco>
    {
        Endereco FindByBothIds(int Id, int UsuarioId);
    }
}
