using Application;
using Core.Application;
using Core.Application.Interfaces;
using Core.Data.Interfaces;
using Core.Data.Repositories;
using Ninject;

namespace Infrastructure.DI
{
    public static class IocContainer
    {

        public static void InjectRepositories(IKernel kernel)
        {
            kernel.Bind<IUsuarioRepository, UsuarioRepository>();
            kernel.Bind<IUsuarioRepository, AreaRepository>();
            kernel.Bind<IUsuarioRepository, ArquivoRepository>();
            kernel.Bind<IUsuarioRepository, CargoRepository>();
            kernel.Bind<IUsuarioRepository, DepartamentoRepository>();
            kernel.Bind<IUsuarioRepository, IdiomaRepository>();
            kernel.Bind<IUsuarioRepository, FormAcademicaRepository>();
            kernel.Bind<IUsuarioRepository, NivelAcessoRepository>();
            kernel.Bind<IUsuarioRepository, ResumoRepository>();
            kernel.Bind<IUsuarioRepository, StatusRepository>();
            kernel.Bind<IUsuarioRepository, UsuarioConhecimentoRepository>();
        }


        public static void InjectServices(IKernel kernel)
        {
            kernel.Bind<ITokenAppService, TokenAppService>();
            kernel.Bind<IAuthAppService, AuthAppService>();
            kernel.Bind<IUsuarioAppService, UsuarioAppService>();
        }


    }
}
