using Core.Data.Models;
using Core.Shared.Kernel.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Specification
{
    public static class UsuarioSpecification
    {
        public static bool ValidForDeletion(this Usuario usuario)
        {
            return AssertionConcern.IsSatisfiedBy(
                        AssertionConcern.AssertFalse(usuario.Idiomas.Count > 0, "Usuario possue idiomas cadastrados que dependem dele e não pode ser deletado"),
                        AssertionConcern.AssertFalse(usuario.CertCursos.Count > 0, "Usuario possue cursos cadastrados que dependem dele e não pode ser deletado"),
                        AssertionConcern.AssertFalse(usuario.ExpProfissionais.Count > 0, "Usuario possue experiencias cadastradas  que dependem dele e não pode ser deletado"),
                        AssertionConcern.AssertFalse(usuario.Contatos.Count > 0, "Usuario possue contatos cadastrados cadastrados que dependem dele e não pode ser deletado"),
                        AssertionConcern.AssertNull(usuario.Endereco, "Usuario possue endereço cadastrado que dependem dele e não pode ser deletado"),
                        AssertionConcern.AssertNull(usuario.Resumo, "Usuario possue resumo cadastrado que dependem dele e não pode ser deletado"),
                        AssertionConcern.AssertFalse(usuario.UsuarioConhecimentos.Count > 0, "Usuario possue conhecimentos associados que dependem dele e não pode ser deletado")
            );
        }

    }
}
