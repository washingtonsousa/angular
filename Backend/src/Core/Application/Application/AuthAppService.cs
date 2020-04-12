using Core.Application.Aggregates;
using Core.Application.Interfaces;
using Core.Data.Interfaces;
using Core.Data.Models;
using Microsoft.Owin.Security;

namespace Application
{
    public class AuthAppService : IAuthAppService
    {

        private IUsuarioRepository _usuarioRepository;
        private readonly ITokenAppService _tokenAppService;

        public AuthAppService(IUsuarioRepository usuarioRepository, ITokenAppService tokenAppService)
        {
            _usuarioRepository = usuarioRepository;
            _tokenAppService = tokenAppService;
        }

        public UsuarioAuthenticationTicketAggregate Authenticate(string userName, string password)
        {
           AuthenticationTicket ticket = null;
           var usuario = _usuarioRepository.AuthVerify(userName, true, password);

            if (usuario != null)
                ticket = _tokenAppService.BuildAuthTicketForUsuario(usuario);

            if (usuario == null && ConfigData.InstallEmailAccount == userName && ConfigData.InstallPassword == password)
                ticket = _tokenAppService.BuildAuthTicketForInstaller(ConfigData.InstallEmailAccount);

            return new UsuarioAuthenticationTicketAggregate(usuario, ticket);
        }

    }
}
