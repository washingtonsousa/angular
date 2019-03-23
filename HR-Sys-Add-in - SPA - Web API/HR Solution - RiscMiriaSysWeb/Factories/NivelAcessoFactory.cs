using System.Collections.Generic;
using RiscServicesHRSharepointAddIn.Models;

namespace RiscServicesHRSharepointAddIn.Factories
{


  /// <summary>
  /// Fábrica de Áreas para o repositório de Áreas
  /// </summary>

  public class NivelAcessoFactory
    {

        private NivelAcesso NivelAcesso;


        public NivelAcessoFactory() {

            this.NivelAcesso = new NivelAcesso();

        }

        public IList<NivelAcesso> DefaultNivelAcessoInstallObjFactory()
        {

            this.NivelAcesso = new NivelAcesso();

            IList<NivelAcesso> NiveisdeAcesso = new List<NivelAcesso>();

            NiveisdeAcesso.Add(new NivelAcesso { Nivel = "Administrador" });

            NiveisdeAcesso.Add(new NivelAcesso { Nivel = "Funcionário" });

            return NiveisdeAcesso;

        }


    }
}
