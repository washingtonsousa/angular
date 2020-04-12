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
    public class NivelAcessoAppService : AppService, INivelAcessoAppService
    {
        public NivelAcessoAppService(IUnityOfWork unitOfWork, INivelAcessoRepository nivelAcessoRepo) : base(unitOfWork)
        {
            _nivelAcessoRepo = nivelAcessoRepo;
        }

        private INivelAcessoRepository _nivelAcessoRepo;


        public IList<NivelAcesso> Get()
        {

            IList<NivelAcesso> NivelAcessos = _nivelAcessoRepo.Get();


            return NivelAcessos;
        }


        public NivelAcesso Get(int id)
        {

            NivelAcesso NivelAcesso = _nivelAcessoRepo.Find(id);


            return NivelAcesso;

        }




 
        public NivelAcesso Insert(NivelAcesso NivelAcesso)
        {

            _nivelAcessoRepo.Insert(NivelAcesso);

            return NivelAcesso;

        }



        public void Delete(int id)
        {

            NivelAcesso NivelAcesso = _nivelAcessoRepo.Find(id);

            if (NivelAcesso.NotExists())
                return;

         
                _nivelAcessoRepo.Delete(NivelAcesso);
                _unityOfWork.Commit();

        }


        public NivelAcesso Update(NivelAcesso NivelAcesso)
        {
            NivelAcesso NivelAcessoFromDb = _nivelAcessoRepo.Find(NivelAcesso.Id);

            if (NivelAcessoFromDb.NotExists())
                return null;

            NivelAcessoFromDb.Nivel = NivelAcesso.Nivel;
                NivelAcessoFromDb.Atualizado_em = DateTime.Now;
                _nivelAcessoRepo.Update(NivelAcessoFromDb);
            _unityOfWork.Commit();

            return NivelAcessoFromDb;

           

        } // Fim método
    }
}
