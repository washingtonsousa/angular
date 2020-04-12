using Core.Application.Abstractions;
using Core.Application.Interfaces;
using Core.Application.Specification;
using Core.Data.Interfaces;
using Core.Data.Models;
using System;


namespace Core.Application
{
    public class ResumoAppService : AppService, IResumoAppService
    {
        public ResumoAppService(IUnityOfWork unitOfWork, IResumoRepository resumoRepo, IUsuarioAppService usuarioAppService) : base(unitOfWork)
        {
            _resumoRepo = resumoRepo;
            _usuarioAppService = usuarioAppService;
        }


        private IResumoRepository _resumoRepo;
        private IUsuarioAppService _usuarioAppService;


        public Resumo InsertSingle(Resumo Resumo)
        {

   
            Resumo.UsuarioId = _usuarioAppService.GetUsuarioLoggedInId();

            _resumoRepo.Insert(Resumo);

            _unityOfWork.Commit();

            return Resumo;

        } // Fim método


 
        public Resumo UpdateSingle(Resumo Resumo)

        {
    
            Resumo ResumoFromDb = _resumoRepo.FindByBothIds(Resumo.Id, _usuarioAppService.GetUsuarioLoggedInId());

            if (ResumoFromDb.NotExists())
                return null;
            
                ResumoFromDb.Atualizado_em = DateTime.Now;
                ResumoFromDb.Conteudo = Resumo.Conteudo;
                _resumoRepo.Update(ResumoFromDb);

                _unityOfWork.Commit();

                return ResumoFromDb;


            



        } // Fim método


        public void DeleteSingle(int Id)
        {
   
            Resumo ResumoFromDb = _resumoRepo.FindByBothIds(Id, _usuarioAppService.GetUsuarioLoggedInId());

            if (ResumoFromDb.NotExists())
                return;


            _resumoRepo.Delete(ResumoFromDb);
            _unityOfWork.Commit();

            
          
        }


        public Resumo Insert(Resumo Resumo)
        {

            Resumo ResumoFromDb = _resumoRepo.FindByUsuarioId(Resumo.UsuarioId);

            if (ResumoFromDb.Exists())
                return null;

            _resumoRepo.Insert(Resumo);
            _unityOfWork.Commit();

            return Resumo;
        }

  
        public Resumo Update(Resumo Resumo)
        {

            Resumo ResumoFromDb = _resumoRepo.FindByBothIds(Resumo.Id, Resumo.UsuarioId);

            if (ResumoFromDb.NotExists())
                return null;
            
                ResumoFromDb.Conteudo = Resumo.Conteudo;
                ResumoFromDb.Atualizado_em = DateTime.Now;
            _resumoRepo.Update(ResumoFromDb);
            _unityOfWork.Commit();
            return Resumo;

          

        }


        public void Delete(Resumo Resumo)
        {

            Resumo ResumoFromDb = _resumoRepo.FindByBothIds(Resumo.Id, Resumo.UsuarioId);

            if (ResumoFromDb.NotExists())
                return;

            _resumoRepo.Delete(ResumoFromDb);
            _unityOfWork.Commit();

        }
    }
}
