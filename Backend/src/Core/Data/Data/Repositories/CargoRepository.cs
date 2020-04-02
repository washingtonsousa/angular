using System.Collections.Generic;
using System.Linq;
using Core.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Core.Data.Repositories
{
  public class CargoRepository : RepositoryTemplate
  {




    public CargoRepository()
    {



    }



    public IList<Cargo> GetCargos()
    {



      IList<Cargo> cargos = this.Context.Cargos.Include(c => c.Departamento).ThenInclude(e => e.Area).ToList();

      /*
    *
    * Burlar problema com as strings de imagens ao fazer joins com a tabela de áreas
    */
      foreach (var cargo in cargos)
      {
        cargos.FirstOrDefault(u => u.Id == cargo.Id).Departamento.Area.imgStr = null; // string de imagem das áreas

      }

      return cargos;

    }

    public void InsertCargo(Cargo cargo)
    {


      this.Context.Cargos.Add(cargo);

    }

    public void DeleteCargo(Cargo cargo)
    {

      this.Context.Cargos.Remove(cargo);

    }

    public void UpdateCargo(Cargo cargoData)
    {

      cargoData.Atualizado_em = System.DateTime.Now;

      this.Context.Cargos.Update(cargoData);

    }



    public Cargo FindCargoById(int id)
    {

      return this.Context.Cargos.Where(c => c.Id == id).FirstOrDefault();
    }

    public int getTotalNumberCountRegisters()
    {
      return this.Context.Cargos.Count();
    }
  }
}
