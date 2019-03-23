using System;
using System.Linq;
using RiscServicesHRSharepointAddIn.Models;
using RiscServicesHRSharepointAddIn.Repositories;

namespace RiscServicesHRSharepointAddIn.Factories
{
  public class UsuarioFactory
    {


        public Usuario UsuarioInstallObjFactory(String Nome, String Email,  
        CargoRepository cargoRepo, NivelAcessoRepository nivelacessoRepo, StatusRepository statusRepo)
        {
            
            return new Usuario {
              Nome = Nome,
              Email = Email,
              NivelAcessoId = nivelacessoRepo.GetNivelAcessos().Where(n => n.Nivel == "Administrador").Select(s => s.Id).FirstOrDefault(),
              CargoId = cargoRepo.GetCargos().Where(c => c.Nome == "Default").Select(s => s.Id).FirstOrDefault(),
              StatusId = statusRepo.GetStatus().Where(s => s.Nome == "ativo").Select(s => s.Id).FirstOrDefault(),
              DataNasc = DateTime.Now,
              DataAdmissao = DateTime.Now,
              Matricula = 0.ToString(),
              EstadoCivil = "Solteiro",
              Ramal = 0,
              Sexo = "Masculino"
             };


        }




    }
}
