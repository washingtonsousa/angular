using Application;
using Core.Application;
using Core.Application.Interfaces;
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

            kernel.Bind<HrDbContext>().To<HrDbContext>().InRequestScope();
            kernel.Bind<IUnityOfWork>().To<UnityOfWork>().InRequestScope();
            kernel.Bind<IUsuarioRepository, UsuarioRepository>();
            kernel.Bind<IAreaRepository, AreaRepository>();
            kernel.Bind<IIdiomaRepository, IdiomaRepository>();
            kernel.Bind<IArquivoRepository, ArquivoRepository>();
            kernel.Bind<ICargoRepository, CargoRepository>();
            kernel.Bind<IDepartamentoRepository, DepartamentoRepository>();
            kernel.Bind<IFormAcademicaRepository, FormAcademicaRepository>();
            kernel.Bind<INivelAcessoRepository, NivelAcessoRepository>();
            kernel.Bind<IResumoRepository, ResumoRepository>();
            kernel.Bind<IStatusRepository, StatusRepository>();
            kernel.Bind<IUsuarioConhecimentoRepository, UsuarioConhecimentoRepository>();
            kernel.Bind<IConhecimentoRepository, ConhecimentoRepository>();
            kernel.Bind<ILog_ActionRepository, Log_ActionRepository>();
            kernel.Bind<IExpProfissionalRepository, ExpProfissionalRepository>();
            kernel.Bind<ISharepointAuthAppService>().To<SharepointAuthAppService>();

        }


        public static void InjectServices(IKernel kernel)
        {
            kernel.Bind<ITokenAppService, TokenAppService>();
            kernel.Bind<IAuthAppService, AuthAppService>();
            kernel.Bind<IUsuarioAppService, UsuarioAppService>();
        }


    }
}
