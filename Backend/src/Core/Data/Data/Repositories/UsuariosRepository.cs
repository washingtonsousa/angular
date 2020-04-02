using System;
using System.Collections.Generic;
using System.Linq;
using Core.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Core.Data.Repositories
{
  public class UsuariosRepository : RepositoryTemplate
    {
       
        public UsuariosRepository()
        {    
        }
        public Usuario AuthVerify(string userName)
        {
          return  Context.Usuarios.Include(u => u.Status).Include(u => u.NivelAcesso)
              .FirstOrDefault(u => u.Email == userName && u.Status.Codigo == 1);
        }
        public Usuario Find(int Id) =>  Context.Usuarios.Where(u => u.Id == Id).Include(u => u.FormAcademicas).Include(u => u.NivelAcesso)
                .Include(u => u.Status).Include(u => u.CertCursos).Include(u => u.Contatos).Include(u => u.Resumo)
                .Include(u => u.CertCursos).Include(u => u.Cargo).ThenInclude(u => u.Departamento).Include(u => u.Endereco)
                .Include(u => u.ExpProfissionais).Include(u => u.Idiomas).Include(u => u.UsuarioConhecimentos)
                .ThenInclude(u => u.Conhecimento).ThenInclude(c => c.CategoriaConhecimento).FirstOrDefault();
        


        public async Task<Usuario> FindUsuarioAsync(int Id) => await Context.Usuarios.Where(u => u.Id == Id).Include(u => u.FormAcademicas).Include(u => u.NivelAcesso)
                     .Include(u => u.Status).Include(u => u.CertCursos).Include(u => u.Contatos).Include(u => u.Resumo)
                     .Include(u => u.CertCursos).Include(u => u.Cargo).ThenInclude(u => u.Departamento).Include(u => u.Endereco)
                     .Include(u => u.ExpProfissionais).Include(u => u.Idiomas).Include(u => u.UsuarioConhecimentos)
                     .ThenInclude(u => u.Conhecimento).FirstOrDefaultAsync();

        

        public void Delete(Usuario usuario)
        {

            Context.Usuarios.Remove(usuario);

        }

        public DbSet<Usuario> getRepoContext()
        {
            return Context.Usuarios;
        }

        public Usuario FindUsuarioByEmail(String Email)
        {
            return Context.Usuarios.Include(u => u.FormAcademicas).Include(u => u.NivelAcesso).Include( u => u.Status)
                .Include( u => u.CertCursos).Include( u => u.Contatos).Include( u => u.CertCursos).Include(u => u.Resumo)
                .Include( u => u.Cargo).ThenInclude(u => u.Departamento).Include( u => u.Endereco).Include( u => u.ExpProfissionais)
                .Include( u => u.Idiomas).Include( u => u.UsuarioConhecimentos).ThenInclude(u => u.Conhecimento).FirstOrDefault(u => u.Email == Email);

             

        }

        public void Update(Usuario Usuario, Usuario usuarioFromDb)
        {
            usuarioFromDb.CargoId = Usuario.CargoId;
            usuarioFromDb.NivelAcessoId = Usuario.NivelAcessoId;
            usuarioFromDb.Nome = Usuario.Nome;
            usuarioFromDb.StatusId = Usuario.StatusId;
            usuarioFromDb.Email = Usuario.Email;
            usuarioFromDb.Matricula = Usuario.Matricula;
            usuarioFromDb.DataAdmissao = Usuario.DataAdmissao;
            usuarioFromDb.DataNasc = Usuario.DataNasc;
            usuarioFromDb.EstadoCivil = Usuario.EstadoCivil;
            usuarioFromDb.Ramal = Usuario.Ramal;
            usuarioFromDb.Sexo = Usuario.Sexo;
        }



        public void Insert(Usuario usuario)
        {

            Context.Usuarios.Add(usuario);

        }

        public IList<Usuario> GetUsuarios()
        {

      IList<Usuario> usuarios = Context.Usuarios.Include(u => u.FormAcademicas).Include(u => u.NivelAcesso).Include(u => u.Status)
   .Include(u => u.CertCursos).Include(u => u.Contatos).Include(u => u.CertCursos).Include(u => u.Resumo)
   .Include(u => u.Cargo).ThenInclude(u => u.Departamento).ThenInclude(u => u.Area).Include(u => u.Endereco).Include(u => u.ExpProfissionais)
   .Include(u => u.Idiomas).Include(u => u.UsuarioConhecimentos).ThenInclude(u => u.Conhecimento).ThenInclude(c => c.CategoriaConhecimento)
   .ToList();

      /*
       *
       * Burlar problema com as strings de imagens ao fazer joins com a tabela de áreas
       */
      foreach (var usuario in usuarios)
      {
        usuarios.FirstOrDefault(u => u.Id == usuario.Id).Cargo.Departamento.Area.imgStr = null; // string de imagem das áreas
      }

      return usuarios;


    }



        public async Task<IList<Usuario>> GetUsuariosAsync()
        {

            return await Context.Usuarios.Include(u => u.FormAcademicas).Include(u => u.NivelAcesso).Include(u => u.Status)
                .Include(u => u.CertCursos).Include(u => u.Contatos).Include(u => u.CertCursos).Include(u => u.Resumo)
                .Include(u => u.Cargo).ThenInclude(u => u.Departamento).ThenInclude(u => u.Area).Include(u => u.Endereco).Include(u => u.ExpProfissionais)
                .Include(u => u.Idiomas).Include(u => u.UsuarioConhecimentos).ThenInclude(u => u.Conhecimento).ThenInclude(u => u.CategoriaConhecimento)
                .ToListAsync();


        }

    }
}
