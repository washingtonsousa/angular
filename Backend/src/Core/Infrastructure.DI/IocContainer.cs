using Application;
using Core.Application;
using Core.Application.Interfaces;
using Core.Application.Operations;
using Core.Application.Sharepoint.Services;
using Core.Data.Interfaces;
using Core.Data.ORM;
using Core.Data.Repositories;
using Ninject;
using Ninject.Web.Common;

namespace Infrastructure.DI
{
    public static class IocContainer
    {

        public static void InjectDataDriven(IKernel kernel)
        {

            kernel.Bind<HrDbContext>().ToSelf().InRequestScope();
            kernel.Bind<IUnityOfWork>().To<UnityOfWork>().InRequestScope();
            kernel.Bind<IUsuarioRepository>().To<UsuarioRepository>();
            kernel.Bind<IAreaRepository>().To<AreaRepository>();
            kernel.Bind<IIdiomaRepository>().To<IdiomaRepository>();
            kernel.Bind<IArquivoRepository>().To<ArquivoRepository>();
            kernel.Bind<ICargoRepository>().To<CargoRepository>();
            kernel.Bind<IDepartamentoRepository>().To<DepartamentoRepository>();
            kernel.Bind<IFormAcademicaRepository>().To<FormAcademicaRepository>();
            kernel.Bind<INivelAcessoRepository>().To<NivelAcessoRepository>();
            kernel.Bind<IResumoRepository>().To<ResumoRepository>();
            kernel.Bind<IStatusRepository>().To<StatusRepository>();
            kernel.Bind<IUsuarioConhecimentoRepository>().To<UsuarioConhecimentoRepository>();
            kernel.Bind<IConhecimentoRepository>().To<ConhecimentoRepository>();
            kernel.Bind<ILog_ActionRepository>().To<Log_ActionRepository>();
            kernel.Bind<IExpProfissionalRepository>().To<ExpProfissionalRepository>();

        }

        public static void InjectServices(IKernel kernel)
        {

            kernel.Bind<ITokenAppService>().To<TokenAppService>();
            kernel.Bind<IAuthAppService>().To<AuthAppService>();
            kernel.Bind<IUsuarioAppService>().To<UsuarioAppService>();
            kernel.Bind<IAreaAppService>().To<AreaAppService>();
            kernel.Bind<ICargoAppService>().To<CargoAppService>();
            kernel.Bind<IApplicationContextManager>().To<ApplicationContextManager>();
            kernel.Bind<IDepartamentoAppService>().To<DepartamentoAppService>();
            kernel.Bind<IArquivoAppService>().To<ArquivoAppService>();
            kernel.Bind<ICategoriaConhecimentoAppService>().To<CategoriaConhecimentoAppService>();
            kernel.Bind<ICertCursoAppService>().To<CertCursoAppService>();
        }

        public static void InjectSharepointServices(IKernel kernel)
        {
            kernel.Bind<ISharepointAuthAppService>().To<SharepointAuthAppService>();
            kernel.Bind<ISharepointUsersService>().To<SharepointAppUsersService>();
            kernel.Bind<ISharepointPeopleManagerAppService>().To<SharepointPeopleManagerAppService>();
        }

    }
}
