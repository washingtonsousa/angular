using Core.Data.Models;

namespace Core.Application.Factories
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