using Core.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Helpers
{
    public static class UsuarioHelper
    {

        public static string GenerateDefaultPassword(this Usuario usuario)
        {
            return $@"{usuario.Nome.Substring(0, 1).ToUpper()}{usuario.DataNasc.Date.ToString("dd/MM/yyyy").Replace("/", "")}";
        }

    }
}
