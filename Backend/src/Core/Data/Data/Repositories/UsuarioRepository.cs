using System;
using System.Collections.Generic;
using System.Linq;
using Core.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Core.Data.Interfaces;
using Core.Data.Queries.Joins;
using Core.Data.ORM;

namespace Core.Data.Repositories
{
    public class UsuarioRepository :  IUsuarioRepository
    {

        private HrDbContext Context;
        public UsuarioRepository(HrDbContext context)
        {
            Context = context;
        }

        public Usuario AuthVerify(string userName, bool checkPassword, string password)
        {
            var usuario = Context.Usuarios.Include(u => u.Status).Include(u => u.NivelAcesso)
              .FirstOrDefault(u => u.Email == userName && u.Status.Codigo == 1);

            if (checkPassword)
                usuario = usuario?.Password == password ? usuario : null;

            return usuario;
        }
        public Usuario Find(int Id) => Context.Usuarios.Where(u => u.Id == Id).BuildFullJoin().FirstOrDefault();



        public async Task<Usuario> FindAsync(int Id) => await Context.Usuarios.Where(u => u.Id == Id).BuildFullJoin().FirstOrDefaultAsync();



        public void Delete(Usuario usuario)
        {

            Context.Usuarios.Remove(usuario);

        }

        public Usuario FindUsuarioByEmail(string Email)
        {
            return Context.Usuarios.BuildFullJoin().FirstOrDefault(u => u.Email == Email);



        }

        public void Update(Usuario Usuario)
        {
            //usuarioFromDb.CargoId = Usuario.CargoId;
            //usuarioFromDb.NivelAcessoId = Usuario.NivelAcessoId;
            //usuarioFromDb.Nome = Usuario.Nome;
            //usuarioFromDb.StatusId = Usuario.StatusId;
            //usuarioFromDb.Email = Usuario.Email;
            //usuarioFromDb.Matricula = Usuario.Matricula;
            //usuarioFromDb.DataAdmissao = Usuario.DataAdmissao;
            //usuarioFromDb.DataNasc = Usuario.DataNasc;
            //usuarioFromDb.EstadoCivil = Usuario.EstadoCivil;
            //usuarioFromDb.Ramal = Usuario.Ramal;
            //usuarioFromDb.Sexo = Usuario.Sexo;
        }



        public void Insert(Usuario usuario) => Context.Usuarios.Add(usuario);

        public IList<Usuario> Get()
        {

            IList<Usuario> usuarios = Context.Usuarios.BuildFullJoin().ToList();

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

        public async Task<IList<Usuario>> GetAsync() => await Context.Usuarios.BuildFullJoin().ToListAsync();

        public Usuario FindUsuarioByMatricula(string matricula)
        {
          return  Context.Usuarios.FirstOrDefault(u => u.Matricula == matricula);
        }

        public int GetCount()
        {
            throw new NotImplementedException();
        }
    }
}
