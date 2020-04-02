using Core.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.Queries.Joins
{
    public static class UsuarioJoins
    {

        public static IIncludableQueryable<Usuario, CategoriaConhecimento> BuildFullJoin(this IQueryable<Usuario> usuarioQueryable) {
            
            return usuarioQueryable.Include(u => u.FormAcademicas).Include(u => u.NivelAcesso)
                 .Include(u => u.Status).Include(u => u.CertCursos).Include(u => u.Contatos).Include(u => u.Resumo)
                 .Include(u => u.CertCursos).Include(u => u.Cargo).ThenInclude(u => u.Departamento).Include(u => u.Endereco)
                 .Include(u => u.ExpProfissionais).Include(u => u.Idiomas).Include(u => u.UsuarioConhecimentos)
                 .ThenInclude(u => u.Conhecimento).ThenInclude(c => c.CategoriaConhecimento);
        }        


    }
}
