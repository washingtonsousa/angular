using Core.Application.Abstractions;
using Core.Application.Interfaces;
using Core.Data.Interfaces;
using Core.Data.Models;
using Core.Hubs;
using Core.SharedKernel.Specification;
using Microsoft.Owin;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace Core.Application
{
    public class UsuarioAppService : AppServiceWithHub<UsuariosHub>, IUsuarioAppService
    {
        private IUsuarioRepository _usuarioRepo;
        private ISharepointPeopleManagerAppService _sharepointPeopleManagerAppService;
        public UsuarioAppService(IUsuarioRepository usuarioRepo, IUnityOfWork unityOfWork, ISharepointPeopleManagerAppService sharepointPeopleManagerAppService) : base(unityOfWork)
        {
            _usuarioRepo = usuarioRepo;
            _sharepointPeopleManagerAppService = sharepointPeopleManagerAppService;
        }

        public Usuario GetUsuarioLoggedIn()
        {

            var usuario = GetUsuarioById(GetUsuarioLoggedInId());
            return usuario;

        }

        public Usuario Atualizar(Usuario usuario)
        {
            Usuario usuarioFromDb = _usuarioRepo.FindByMatriculaOrEmail(usuario.Matricula, usuario.Email);

            if (usuarioFromDb.NotExists())
                return null;

            usuarioFromDb.CargoId = usuario.CargoId;
            usuarioFromDb.NivelAcessoId = usuario.NivelAcessoId;
            usuarioFromDb.Nome = usuario.Nome;
            usuarioFromDb.StatusId = usuario.StatusId;
            usuarioFromDb.Email = usuario.Email;
            usuarioFromDb.Matricula = usuario.Matricula;
            usuarioFromDb.DataAdmissao = usuario.DataAdmissao;
            usuarioFromDb.DataNasc = usuario.DataNasc;
            usuarioFromDb.EstadoCivil = usuario.EstadoCivil;
            usuarioFromDb.Ramal = usuario.Ramal;
            usuarioFromDb.Sexo = usuario.Sexo;

            bool result = _unityOfWork.Commit();

            if (result)
            {
                UsuariosHub.updateUsuario(usuarioFromDb);
                usuarioFromDb.Status.Usuarios = null;
                usuarioFromDb.Cargo.Departamento.Area.Departamentos = null;
            }

            return usuarioFromDb;

        }

        public Usuario AtualizarParcial(Usuario usuario)
        {
            Usuario usuarioFromDb = GetUsuarioById(usuario.Id);

            if (usuarioFromDb.NotExists())
                return null;


            usuarioFromDb.Email_Secundario_Notificacao = usuario.Email_Secundario_Notificacao;
            _unityOfWork.Commit();

            return usuario;

        }

        public void Delete(int id)
        {
            Usuario usuario = _usuarioRepo.Find(id);

            if (usuario.NotExists())
                return;

            _usuarioRepo.Delete(usuario);
            bool result = _unityOfWork.Commit();

            if (result)
                UsuariosHub.deleteUsuario(usuario);
        }

        public Usuario GetByMatricula(string matricula)
        {

            Usuario usuario = _usuarioRepo.FindUsuarioByMatricula(matricula);

            ///Validação sem if apenas para gerar notificação se necessário
            usuario.NotExists();

            return usuario;

        }

        public Usuario InsertUsuario(Usuario usuario)
        {
            Usuario usuarioFromDb = _usuarioRepo.FindByMatriculaOrEmail(usuario.Matricula, usuario.Email);

            if (usuarioFromDb.NotExists())
                return null;

            //Funções de Sharepoint comentadas temporariamente
            //_sharepointPeopleManagerAppService.GetPersonPropertiesByEmail(usuario.Email);
            //bool result = _sharepointPeopleManagerAppService.ExecuteRequest();

            //if (result)
            //{

            _usuarioRepo.Insert(usuario);
            bool result  = _unityOfWork.Commit();


            if (result)
            {
                usuarioFromDb = _usuarioRepo.FindUsuarioByEmail(usuario.Email);
                usuarioFromDb.Status.Usuarios = null;
                usuarioFromDb.Cargo.Departamento.Area.Departamentos = null;
            }
            UsuariosHub.newUsuario(usuarioFromDb);

            return usuarioFromDb;
            //}

        }

        public IList<Usuario> Get()
        {
            return _usuarioRepo.Get();
        }

        public Usuario GetUsuarioById(int Id) => _usuarioRepo.Find(Id);

        public int GetUsuarioLoggedInId()
        {
            OwinContext context = (OwinContext)HttpContext.Current.GetOwinContext();
            ClaimsPrincipal user = context.Authentication.User;

            if (user.Identity.IsAuthenticated)
                return int.Parse(user.Claims.Where(u => u.ValueType == "Id").FirstOrDefault().Value);


            return 0;
        }

    }
}
