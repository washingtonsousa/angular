using Core.Application.Abstractions;
using Core.Application.Interfaces;
using Core.Application.Specification;
using Core.Data.Interfaces;
using Core.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application
{
    public class ExpProfissionalAppService : AppService, IExpProfissionalAppService
    {

        private IExpProfissionalRepository _expRepo;
        private IUsuarioAppService _usuarioAppService;

        public ExpProfissionalAppService(IUnityOfWork unitOfWork, IExpProfissionalRepository expRepo, IUsuarioAppService usuarioAppService) : base(unitOfWork)
        {
            _expRepo = expRepo;
            _usuarioAppService = usuarioAppService;
        }

        public IList<ExpProfissional> Get()
        {

            IList<ExpProfissional> ExpProfissionais = _expRepo.Get();


            return ExpProfissionais;
        }




        public IList<ExpProfissional> GetSingle()
        {

            IList<ExpProfissional> ExpProfissionais = _expRepo.Get().Where(c => c.UsuarioId == _usuarioAppService.GetUsuarioLoggedInId()).ToList();

            return ExpProfissionais;

        }






        public ExpProfissional InsertSingle(ExpProfissional ExpProfissional)
        {


            int UsuarioId = _usuarioAppService.GetUsuarioLoggedInId();
            ExpProfissional.UsuarioId = UsuarioId;

            _expRepo.Insert(ExpProfissional);
            _unityOfWork.Commit();

            return ExpProfissional;


        }




        public ExpProfissional UpdateSingle(ExpProfissional ExpProfissional)
        {



            ExpProfissional ExpProfissionalFromDb = _expRepo.FindByBothIds(ExpProfissional.Id, _usuarioAppService.GetUsuarioLoggedInId());

            if (ExpProfissionalFromDb.NotExists())
                return null;

            ExpProfissional.UsuarioId = _usuarioAppService.GetUsuarioLoggedInId();
            ExpProfissionalFromDb.Cargo = ExpProfissional.Cargo;
            ExpProfissionalFromDb.Descricao = ExpProfissional.Descricao;
            ExpProfissionalFromDb.Empresa = ExpProfissional.Empresa;
            ExpProfissionalFromDb.Fim = ExpProfissional.Fim;
            ExpProfissionalFromDb.UltimoSalario = ExpProfissional.UltimoSalario;
            ExpProfissionalFromDb.Inicio = ExpProfissional.Inicio;
            ExpProfissionalFromDb.Atualizado_em = DateTime.Now;
            _expRepo.Update(ExpProfissionalFromDb);
            _unityOfWork.Commit();

            return ExpProfissionalFromDb;



        }





        public void DeleteSingle(int Id)
        {

            ExpProfissional ExpProfissionalFromDb = _expRepo.FindByBothIds(Id, _usuarioAppService.GetUsuarioLoggedInId());

            if (ExpProfissionalFromDb.NotExists())
                return;


            _expRepo.Delete(ExpProfissionalFromDb);
            _unityOfWork.Commit();
            ;

        }





        public ExpProfissional Update(ExpProfissional ExpProfissional)
        {

            ExpProfissional ExpProfissionalFromDb = _expRepo.FindByBothIds(ExpProfissional.Id, ExpProfissional.UsuarioId);

            if (ExpProfissionalFromDb.NotExists())
                return null;

            ExpProfissional.UsuarioId = _usuarioAppService.GetUsuarioLoggedInId();
            ExpProfissionalFromDb.Cargo = ExpProfissional.Cargo;
            ExpProfissionalFromDb.Descricao = ExpProfissional.Descricao;
            ExpProfissionalFromDb.Empresa = ExpProfissional.Empresa;
            ExpProfissionalFromDb.Fim = ExpProfissional.Fim;
            ExpProfissionalFromDb.UltimoSalario = ExpProfissional.UltimoSalario;
            ExpProfissionalFromDb.Inicio = ExpProfissional.Inicio;
            ExpProfissionalFromDb.Atualizado_em = DateTime.Now;
            _expRepo.Update(ExpProfissionalFromDb);
            _unityOfWork.Commit();

            return ExpProfissionalFromDb;

            ;

        }




        public ExpProfissional Insert(ExpProfissional ExpProfissional)
        {

            _expRepo.Insert(ExpProfissional);
            _unityOfWork.Commit();

            return ExpProfissional;
        }




        public void Delete(int Id)
        {

            ExpProfissional ExpProfissionalFromDb = _expRepo.Find(Id);

            if (ExpProfissionalFromDb.NotExists())
                return;

            _expRepo.Delete(ExpProfissionalFromDb);
            _unityOfWork.Commit();

        }
    }
}
