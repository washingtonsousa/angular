using RiscServicesHRSharepointAddIn.Models;

namespace RiscServicesHRSharepointAddIn.Factories
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