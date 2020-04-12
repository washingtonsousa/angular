using Core.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Interfaces
{
    public interface IUsuarioAppService
    {
        IList<Usuario> Get();
        void Delete(int id);
        int GetUsuarioLoggedInId();
        Usuario GetUsuarioLoggedIn();
        Usuario GetUsuarioById(int Id);
        Usuario InsertUsuario(Usuario usuario);
        Usuario GetByMatricula(string matricula);
        Usuario PartialyUpdate(Usuario usuario);
        Usuario Update(Usuario usuario);

        void AddConhecimentosForUsuarioLoggedIn(IList<int> ConhecimentoIds);

        void AddConhecimentosForUsuarioByUsuarioId(IList<int> ConhecimentoIds, int UsuarioId);


    }
}
