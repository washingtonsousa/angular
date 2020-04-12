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
    public class StatusAppService : AppService, IStatusAppService
    {
        public StatusAppService(IUnityOfWork unitOfWork, IStatusRepository statusRepo, IUsuarioRepository usuarioRepo) : base(unitOfWork)
        {
            _statusRepo = statusRepo;
            _usuarioRepo = usuarioRepo;
        }

        private IStatusRepository _statusRepo;
        private IUsuarioRepository _usuarioRepo;



        public IList<Status> Get()
        {

            IList<Status> Status = _statusRepo.Get().ToList();


            return Status;
        }


        public Status Get(int Id)
        {

            Status Status = _statusRepo.Find(Id);
            return Status;
        }


        public Status Insert(Status Status)
        {

            Status statusFromDb = _statusRepo.Get().Where(s => s.Nome == Status.Nome).FirstOrDefault();

            if (statusFromDb.Exists())
                return null;

                _statusRepo.Insert(Status);
                _unityOfWork.Commit();

            return Status;

        }


        public void Delete(int Id)
        {
            Status statusFromDb = _statusRepo.Find(Id);

            if (statusFromDb.NotExists())
                return;

            if (!statusFromDb.ValidForUpdateOrDeletion())
                return;

            _statusRepo.Delete(statusFromDb);
            _unityOfWork.Commit();

        }


        public Status Update(Status Status)
        {
            Status statusFromDb = _statusRepo.Find(Status.Id);

            if (!statusFromDb.ValidForUpdateOrDeletion())
                return null;

            statusFromDb.Nome = Status.Nome;
            statusFromDb.Codigo = Status.Codigo;
            _statusRepo.Update(statusFromDb);
            _unityOfWork.Commit();

            return statusFromDb;

        } // Fim do método
    }
}
