using Core.Application.Abstractions;
using Core.Application.Interfaces;
using Core.Application.Specification;
using Core.Data.Interfaces;
using Core.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Core.Application
{
    public class DepartamentoAppService : AppService, IDepartamentoAppService
    {
        private IDepartamentoRepository _departamentoRepo;

        public DepartamentoAppService(IUnityOfWork unitOfWork, ICargoRepository cargoRepository, IDepartamentoRepository departamentoRepository, IUsuarioRepository usuarioRepository) : base(unitOfWork)
        {
             _departamentoRepo =  departamentoRepository;
        }


        public IList<Departamento> Get()
        {

            IList<Departamento> Departamentos = _departamentoRepo.Get().OrderBy(d => d.Nome).ToList();

            return Departamentos;

        }


        public Departamento Get(int Id)
        {

            Departamento Departamento = _departamentoRepo.Find(Id);

            if (Departamento.NotExists())
                return null;    

            return Departamento;

        }

        public Departamento Insert(Departamento departamento)
        {

            _departamentoRepo.Insert(departamento);
            _unityOfWork.Commit();

            return departamento;

        }


        public void Delete(int Id)
        {
            Departamento departamento = _departamentoRepo.Find(Id);

            if (!departamento.ValidDeletion())
                return;

                _departamentoRepo.Delete(departamento);
                _unityOfWork.Commit();

        }

        public Departamento Update(Departamento departamento)
        {
            Departamento departamentoFromDb = _departamentoRepo.Find(departamento.Id);

            if (departamentoFromDb.NotExists())
                return null;

                departamentoFromDb.Nome = departamento.Nome;
                departamentoFromDb.AreaId = departamento.AreaId;
                _departamentoRepo.Update(departamentoFromDb);
                _unityOfWork.Commit();
               
                return departamentoFromDb;

        }
    }
}
