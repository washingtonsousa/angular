using Core.Application.Interfaces;
using Core.Data.Interfaces;
using Core.Data.Models;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Core.Application
{
    public class UsuarioAppService : IUsuarioAppService
    {
        private IUsuarioRepository _usuarioRepo;

        public UsuarioAppService( IUsuarioRepository usuarioRepo) {
            _usuarioRepo = usuarioRepo;
        }

        public Usuario GetUsuarioLoggedIn()
        {

           var usuario = GetUsuarioById(GetUsuarioLoggedInId());

            return usuario;

        }

        public Usuario InsertUsuario(Usuario usuario)
        {
            IList<Usuario> Usuarios = _usuarioRepo.Get();

            if (Usuarios.Where(u => u.Email == usuario.Email).FirstOrDefault() == null
                && Usuarios.Where(u => u.Email != usuario.Email && u.Matricula == usuario.Matricula).FirstOrDefault() == null
                )
            {
                ClientContext clientContext = TokenHelper.GetClientContextWithAccessToken(ConfigData.ContextAppUrl, spAuthHelper.GetSPAppToken());
                _sharepointPeopleManagerAppService = new SharepointPeopleManagerAppService(clientContext);

                var peopleManager = new PeopleManager(clientContext);

                _sharepointPeopleManagerAppService.GetPersonPropertiesByEmail(Usuario.Email);
                bool result = _sharepointPeopleManagerAppService.ExecuteRequest();

                if (SPPeopleManager.execQuery() == true)
                {

                    usuarioRepo.Insert(Usuario);
                    usuarioRepo.Save();

                    Usuario usuarioFromDb = usuarioRepo.FindUsuarioByEmail(Usuario.Email);



                    usuarioFromDb.Status.Usuarios = null;
                    usuarioFromDb.Cargo.Departamento.Area.Departamentos = null;



                    UsuariosHub.newUsuario(usuarioFromDb);


                    return Request.CreateResponse(System.Net.HttpStatusCode.OK, usuarioFromDb);
                }

                else
                {

                    return Request.CreateResponse(System.Net.HttpStatusCode.BadRequest, new ErrorHelper().getError(new SPUserNotFoundError()));

                }

            }

            return Request.CreateResponse(System.Net.HttpStatusCode.BadRequest, new ErrorHelper().getError(new DatabaseDuplicatedEntryError()));
        }

        public Usuario GetUsuarioById(int Id) => _usuarioRepo.Find(Id);

        public int GetUsuarioLoggedInId()
        {
            OwinContext context = (OwinContext)HttpContext.Current.GetOwinContext();
            ClaimsPrincipal user = context.Authentication.User;

            if(user.Identity.IsAuthenticated)
            return int.Parse(user.Claims.Where(u => u.ValueType == "Id").FirstOrDefault().Value);


            return 0;
        }


    }
}
