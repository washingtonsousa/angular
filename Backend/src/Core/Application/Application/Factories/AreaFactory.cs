using Core.Data.Models;

namespace Core.Application.Factories
{


  /// <summary>
  /// Fábrica de Áreas para o repositório de Áreas
  /// </summary>

  public class AreaFactory
    {

        private Area Area;


        public AreaFactory()
        {

            Area = new Area();
        }

        public Area DefaultAreaInstallObjFactory()
        {

            this.Area.Nome = "Default";


            return this.Area;

        }


    }
}