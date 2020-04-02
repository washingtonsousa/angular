using Core.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.Interfaces
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Usuario AuthVerify(string userName, bool checkPassword, string password);
        Usuario FindUsuarioByEmail(string Email);

        Usuario FindUsuarioByMatricula(string Matricula);
    }
}
