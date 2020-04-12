using Core.Application.Abstractions;
using Core.Application.Interfaces;
using Core.Application.Specification;
using Core.Data.Interfaces;
using Core.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Core.Application
{
    public class CategoriaConhecimentoAppService : AppService, ICategoriaConhecimentoAppService
    {
        public CategoriaConhecimentoAppService(IUnityOfWork unitOfWork, ICategoriaConhecimentoRepository categoriaCategoriaConhecimentoRepo) : base(unitOfWork)
        {
            _categoriaCategoriaConhecimentoRepo = categoriaCategoriaConhecimentoRepo;
        }

        private ICategoriaConhecimentoRepository _categoriaCategoriaConhecimentoRepo;


        public IList<CategoriaConhecimento> Get()
        {

            IList<CategoriaConhecimento> CategoriaConhecimentos = _categoriaCategoriaConhecimentoRepo.Get();
            return CategoriaConhecimentos;

        }
        public void Delete(int Id)
        {
            CategoriaConhecimento categoriaCategoriaConhecimento = _categoriaCategoriaConhecimentoRepo.Find(Id);

            if (categoriaCategoriaConhecimento.NotExists())
                return;

            if (!categoriaCategoriaConhecimento.ValidForDeletion())
                return;

            _categoriaCategoriaConhecimentoRepo.Delete(categoriaCategoriaConhecimento);
            _unityOfWork.Commit();

        }



        public CategoriaConhecimento Update(CategoriaConhecimento categoriaCategoriaConhecimento)
        {

            CategoriaConhecimento categoriaCategoriaConhecimentoFromDb = _categoriaCategoriaConhecimentoRepo.Find(categoriaCategoriaConhecimento.Id);

            if (categoriaCategoriaConhecimento.NotExists())
                return null;

            categoriaCategoriaConhecimentoFromDb.Categoria = categoriaCategoriaConhecimento.Categoria;

            _categoriaCategoriaConhecimentoRepo.Update(categoriaCategoriaConhecimentoFromDb);
            _unityOfWork.Commit();

            return categoriaCategoriaConhecimentoFromDb;

        }



        public CategoriaConhecimento Insert(CategoriaConhecimento categoriaCategoriaConhecimento)
        {

            CategoriaConhecimento eneityFromDb = _categoriaCategoriaConhecimentoRepo.Get().Where(c => c.Categoria == categoriaCategoriaConhecimento.Categoria).FirstOrDefault();

            if (eneityFromDb.Exists())
                return null;
            
                _categoriaCategoriaConhecimentoRepo.Insert(categoriaCategoriaConhecimento);
                _unityOfWork.Commit();

               return categoriaCategoriaConhecimento;
        
        }



    }
}
