using Core.Application.Abstractions;
using Core.Application.Interfaces;
using Core.Application.Specification;
using Core.Data.Interfaces;
using Core.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Core.Application
{
   public class AreaAppService : AppService, IAreaAppService
    {
        private IAreaRepository areaRepo;        

        public AreaAppService(
            IAreaRepository areaRepository, 
            IUnityOfWork unityOfWork) : base(unityOfWork)
        {
            areaRepo =  areaRepository;
        }

        public IList<Area> Get()
        {
            IList<Area> Areas = areaRepo.Get().OrderBy(a => a.Nome).ToList();
            return Areas;
        }



        public Area Get(int Id)
        {

            Area Area = areaRepo.Get().Where(a => a.Id == Id).FirstOrDefault();
            return Area;

        }


        public Area Insert(Area Area)
        {
            Area areafromDb = areaRepo.Get().Where(a => a.Nome == Area.Nome).FirstOrDefault();

            if (areafromDb.Exists())
                return null;

            areaRepo.Insert(Area);
            _unityOfWork.Commit();

           return Area;

        }


        public void Delete(int Id)
        {
            Area Area = areaRepo.Find(Id);

            if (Area.NotExists())
                return;
            if (Area.ValidaParaDeletar())
                return;

                areaRepo.Delete(Area);
                _unityOfWork.Commit();

        }


        public Area Update(Area Area)
        {
            Area AreaFromDb = areaRepo.Find(Area.Id);

            if (Area.NotExists())
                return null;

            AreaFromDb.Nome = Area.Nome;
            AreaFromDb.imgStr = Area.imgStr;
            areaRepo.Update(AreaFromDb);
            _unityOfWork.Commit();

            return AreaFromDb;

        }
    }
}
