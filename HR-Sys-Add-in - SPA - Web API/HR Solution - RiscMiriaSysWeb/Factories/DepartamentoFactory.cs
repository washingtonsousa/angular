using RiscServicesHRSharepointAddIn.Models;

namespace RiscServicesHRSharepointAddIn.Factories
{
  public class DepartamentoFactory
    {


        public Departamento DefaultDepartamentoInstallObjFactory(int AreaId)
        {

            Departamento departamento = new Departamento();
            departamento.AreaId = AreaId;
            departamento.Nome = "Default";

            return departamento;

        }


    }
}