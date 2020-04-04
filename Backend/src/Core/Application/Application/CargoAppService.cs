using Core.Application.Abstractions;
using Core.Application.Interfaces;
using Core.Data.Interfaces;
using Core.Data.Models;
using Core.SharedKernel.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application
{
    public class CargoAppService : AppService, ICargoAppService
    {
        private ICargoRepository _cargoRepo;
        private IDepartamentoRepository _depRepo;
        private IUsuarioRepository _usuarioRepo;
        

        public CargoAppService(IDepartamentoRepository departamentoRepository, 
            ICargoRepository cargoRepository,
            IUsuarioRepository usuarioRepository,
            IUnityOfWork unityOfWork) : base(unityOfWork)
        {

            _cargoRepo =  cargoRepository;
            _usuarioRepo =  usuarioRepository;
            _depRepo =  departamentoRepository;

        }

        public IList<Cargo> Get()
        {

            IList<Cargo> Cargos = _cargoRepo.Get();
            return Cargos;

        }


        public Cargo Get(int id)
        {

            Cargo Cargo = _cargoRepo.Find(id);
            return Cargo;

        }

        public Cargo Insert(Cargo cargo)
        {

            _cargoRepo.Insert(cargo);
            _unityOfWork.Commit();

            return cargo;

        }

  
        public void Delete(int id)
        {

            Cargo cargo = _cargoRepo.Find(id);

            if (cargo.NotExists())
                return;

            if (cargo.ValidForDeletion())
                return;

                _cargoRepo.Delete(cargo);
                _unityOfWork.Commit();

        }

        public Cargo Update(Cargo cargo)
        {
            Cargo cargoFromDb = _cargoRepo.Find(cargo.Id);


            if (cargoFromDb.NotExists())
                return null;

                cargoFromDb.DepartamentoId = cargo.DepartamentoId;
                cargoFromDb.Nome = cargo.Nome;
                _cargoRepo.Update(cargoFromDb);

                _unityOfWork.Commit();

            return cargoFromDb;


        }
    }
}
