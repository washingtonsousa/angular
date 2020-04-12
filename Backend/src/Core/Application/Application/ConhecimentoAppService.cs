using Core.Application.Abstractions;
using Core.Application.Interfaces;
using Core.Application.Specification;
using Core.Data.Interfaces;
using Core.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Core.Application
{
    public class ConhecimentoAppService : AppService, IConhecimentoAppService
    {


        private IConhecimentoRepository _conhecimentoRepo;
        private IUsuarioConhecimentoRepository _usuarioConhecimentoRepo;

        public ConhecimentoAppService(IUnityOfWork unityOfWork, IUsuarioConhecimentoRepository usuarioConhecimentoRepo, IConhecimentoRepository conhecimentoRepo) : base(unityOfWork)
        {
            _usuarioConhecimentoRepo = usuarioConhecimentoRepo;
            _conhecimentoRepo = conhecimentoRepo;
        }

        public IList<Conhecimento> Get()
        {

            IList<Conhecimento> Conhecimentos = _conhecimentoRepo.Get();

            return Conhecimentos;

        }



        public void Delete(int Id)
        {
            Conhecimento conhecimento = _conhecimentoRepo.Find(Id);

            if (conhecimento.NotExists())
                return;

            IList<UsuarioConhecimento> usuarioConhecimentosByConhecimentoId =
            _usuarioConhecimentoRepo.Get().Where(u => u.ConhecimentoId == Id).ToList();

            foreach (var usuarioConhecimento in usuarioConhecimentosByConhecimentoId)
            {
                _usuarioConhecimentoRepo.Delete(usuarioConhecimento);
            }

            _conhecimentoRepo.Delete(conhecimento);
            _unityOfWork.Commit();


        }


        public Conhecimento Update(Conhecimento conhecimento)
        {

            Conhecimento conhecimentoFromDb = _conhecimentoRepo.Find(conhecimento.Id);

            if (conhecimentoFromDb.NotExists())
                return null;


            conhecimentoFromDb.Nome = conhecimento.Nome;

            conhecimentoFromDb.CategoriaConhecimentoId = conhecimento.CategoriaConhecimentoId;

            _conhecimentoRepo.Update(conhecimentoFromDb);

            _unityOfWork.Commit();

            return conhecimentoFromDb;

        }


        public Conhecimento Insert(Conhecimento conhecimento)
        {

            Conhecimento conhecimentoFromDb = _conhecimentoRepo.Get().Where(c => c.Nome == conhecimento.Nome).FirstOrDefault();


            if (conhecimentoFromDb.Exists())
                return null;


            _conhecimentoRepo.Insert(conhecimento);

            _unityOfWork.Commit();

            return conhecimento;



        }


    }
}
