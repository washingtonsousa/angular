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
    public class IdiomaAppService : AppService, IIdiomaAppService
    {



        public IdiomaAppService(IUnityOfWork unitOfWork, IIdiomaRepository idiomaRepo, IUsuarioAppService usuarioAppService) : base(unitOfWork)
        {
            _idiomaRepo = idiomaRepo;
            _usuarioAppService = usuarioAppService;

        }

        private IIdiomaRepository _idiomaRepo;
        private IUsuarioAppService _usuarioAppService;



        public Idioma InsertSingle(Idioma Idioma)
        {

            Idioma.UsuarioId = _usuarioAppService.GetUsuarioLoggedInId();
            _idiomaRepo.Insert(Idioma);
            _unityOfWork.Commit();

            return Idioma;
        }


        public Idioma UpdateSingle(Idioma Idioma)
        {


            Idioma IdiomaFromDb = _idiomaRepo.FindByBothIds(Idioma.Id, _usuarioAppService.GetUsuarioLoggedInId());

            if (IdiomaFromDb.NotExists())
                return null;


            IdiomaFromDb.Nome = Idioma.Nome;
            IdiomaFromDb.Fluencia = Idioma.Fluencia;
            IdiomaFromDb.Atualizado_em = DateTime.Now;
            _idiomaRepo.Update(IdiomaFromDb);
            _unityOfWork.Commit();




            return IdiomaFromDb;

        }


        public void DeleteSingle(int Id)
        {

            Idioma IdiomaFromDb = _idiomaRepo.FindByBothIds(Id, _usuarioAppService.GetUsuarioLoggedInId());

            if (IdiomaFromDb.NotExists())
                return;



            _idiomaRepo.Delete(IdiomaFromDb);
            _unityOfWork.Commit();


        }

        public Idioma Insert(Idioma Idioma)
        {

            Idioma IdiomaFromDb = _idiomaRepo.FindByBothIds(Idioma.Id, Idioma.UsuarioId);

            if (IdiomaFromDb.Exists())
                return null;


            _idiomaRepo.Insert(Idioma);
            _unityOfWork.Commit();
            return Idioma;


        }


        public Idioma Update(Idioma Idioma)
        {

            Idioma IdiomaFromDb = _idiomaRepo.FindByBothIds(Idioma.Id, Idioma.UsuarioId);

            if (IdiomaFromDb.NotExists())
                return null;

            IdiomaFromDb.Nome = Idioma.Nome;
            IdiomaFromDb.Fluencia = Idioma.Fluencia;
            _idiomaRepo.Update(IdiomaFromDb);
            _unityOfWork.Commit();

            return IdiomaFromDb;




        }

        public void Delete(int Id)
        {

            Idioma IdiomaFromDb = _idiomaRepo.Find(Id);

            if (IdiomaFromDb.NotExists())
                return;

            _idiomaRepo.Delete(IdiomaFromDb);
            _unityOfWork.Commit();


        }



    }
}
