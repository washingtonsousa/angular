using System;
using System.Collections.Generic;
using System.Linq;
using RiscServicesHRSharepointAddIn.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace RiscServicesHRSharepointAddIn.Repositories
{
  public class UsuariosRepository : RepositoryTemplate
    {
       
      
        public UsuariosRepository()
        {    
        }

        public Usuario FindUsuario(int Id)
        {


       return  this.Context.Usuarios.Where(u => u.Id == Id).Include(u => u.FormAcademicas).Include(u => u.NivelAcesso)
                .Include(u => u.Status).Include(u => u.CertCursos).Include(u => u.Contatos).Include(u => u.Resumo)
                .Include(u => u.CertCursos).Include(u => u.Cargo).ThenInclude(u => u.Departamento).Include(u => u.Endereco)
                .Include(u => u.ExpProfissionais).Include(u => u.Idiomas).Include(u => u.UsuarioConhecimentos)
                .ThenInclude(u => u.Conhecimento).ThenInclude(c => c.CategoriaConhecimento).FirstOrDefault();
        }


        public async Task<Usuario> FindUsuarioAsync(int Id)
        {


            return await this.Context.Usuarios.Where(u => u.Id == Id).Include(u => u.FormAcademicas).Include(u => u.NivelAcesso)
                     .Include(u => u.Status).Include(u => u.CertCursos).Include(u => u.Contatos).Include(u => u.Resumo)
                     .Include(u => u.CertCursos).Include(u => u.Cargo).ThenInclude(u => u.Departamento).Include(u => u.Endereco)
                     .Include(u => u.ExpProfissionais).Include(u => u.Idiomas).Include(u => u.UsuarioConhecimentos)
                     .ThenInclude(u => u.Conhecimento).FirstOrDefaultAsync();

        }

        public void DeleteUsuario(Usuario usuario)
        {

            this.Context.Usuarios.Remove(usuario);

        }

        public DbSet<Usuario> getRepoContext()
        {
            return this.Context.Usuarios;
        }

        public Usuario FindUsuarioByEmail(String Email)
        {
            return this.Context.Usuarios.Include(u => u.FormAcademicas).Include(u => u.NivelAcesso).Include( u => u.Status)
                .Include( u => u.CertCursos).Include( u => u.Contatos).Include( u => u.CertCursos).Include(u => u.Resumo)
                .Include( u => u.Cargo).ThenInclude(u => u.Departamento).Include( u => u.Endereco).Include( u => u.ExpProfissionais)
                .Include( u => u.Idiomas).Include( u => u.UsuarioConhecimentos).ThenInclude(u => u.Conhecimento).FirstOrDefault(u => u.Email == Email);

             

        }

        public void UpdateUsuario(Usuario Usuario, Usuario usuarioFromDb)
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



        public void InsertUsuario(Usuario usuario)
        {

            this.Context.Usuarios.Add(usuario);

        }

        public IList<Usuario> GetUsuarios()
        {

      IList<Usuario> usuarios = this.Context.Usuarios.Include(u => u.FormAcademicas).Include(u => u.NivelAcesso).Include(u => u.Status)
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

            return await this.Context.Usuarios.Include(u => u.FormAcademicas).Include(u => u.NivelAcesso).Include(u => u.Status)
                .Include(u => u.CertCursos).Include(u => u.Contatos).Include(u => u.CertCursos).Include(u => u.Resumo)
                .Include(u => u.Cargo).ThenInclude(u => u.Departamento).ThenInclude(u => u.Area).Include(u => u.Endereco).Include(u => u.ExpProfissionais)
                .Include(u => u.Idiomas).Include(u => u.UsuarioConhecimentos).ThenInclude(u => u.Conhecimento).ThenInclude(u => u.CategoriaConhecimento)
                .ToListAsync();


        }

    }
}
