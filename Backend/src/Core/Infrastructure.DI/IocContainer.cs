using Application;
using Core.Application;
using Core.Application.Interfaces;
using Core.Application.Operations;
using Core.Application.Sharepoint.Services;
using Core.Data.Interfaces;
using Core.Data.ORM;
using Core.Data.Repositories;
using Core.Shared.Kernel.Events;
using Core.Shared.Kernel.Handles;
using Core.Shared.Kernel.Interfaces;
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
            kernel.Bind<ICategoriaConhecimentoRepository>().To<CategoriaConhecimentoRepository>();
            kernel.Bind<IEnderecoRepository>().To<EnderecoRepository>();
            kernel.Bind<ICertCursoRepository>().To<CertCursoRepository>();
            kernel.Bind<IContatoRepository>().To<ContatoRepository>();

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
            kernel.Bind<IConhecimentoAppService>().To<ConhecimentoAppService>();
            kernel.Bind<IStatusAppService>().To<StatusAppService>();
            kernel.Bind<IResumoAppService>().To<ResumoAppService>();
            kernel.Bind<IStatisticsAppService>().To<StatisticsAppService>();
            kernel.Bind<IRelatoriosAppService>().To<RelatoriosAppService>();
            kernel.Bind<IProfilePictureAppService>().To<ProfilePictureAppService>();
            kernel.Bind<INivelAcessoAppService>().To<NivelAcessoAppService>();
            kernel.Bind<IIdiomaAppService>().To<IdiomaAppService>();
            kernel.Bind<IContatoAppService>().To<ContatoAppService>();
            kernel.Bind<IExpProfissionalAppService>().To<ExpProfissionalAppService>();
            kernel.Bind<IFormAcademicaAppService>().To<FormAcademicaAppService>();
            kernel.Bind<IEnderecoAppService>().To<EnderecoAppService>();
            kernel.Bind<IDomainNotificationHandler<DomainNotification>>().To<DomainNotificationHandler>().InRequestScope();
            kernel.Bind<IInstallAppService>().To<InstallAppService>();
            kernel.Bind<ILogAppService>().To<LogAppService>();
            kernel.Bind<IEmailAppService>().To<EmailAppService>();
        }

        public static void InjectSharepointServices(IKernel kernel)
        {
            kernel.Bind<ISharepointAuthAppService>().To<SharepointAuthAppService>();
            kernel.Bind<ISharepointUsersService>().To<SharepointAppUsersService>();
            kernel.Bind<ISharepointPeopleManagerAppService>().To<SharepointPeopleManagerAppService>();
        }

    }
}
