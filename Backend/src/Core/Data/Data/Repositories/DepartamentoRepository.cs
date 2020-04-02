using System;
using System.Collections.Generic;
using System.Linq;
using Core.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Core.Data.Repositories
{
  public class DepartamentoRepository : RepositoryTemplate
  {


    public DepartamentoRepository()
    {
    }

    public Departamento FindDepartamento(int Id)
    {
      return this.Context.Departamentos.Where(u => u.Id == Id).FirstOrDefault();



    }

    public void DeleteDepartamento(Departamento departamento)
    {

      this.Context.Departamentos.Remove(departamento);

    }


    public Departamento FindDepartamentoByNome(String Nome)
    {
      Departamento departamento = this.Context.Departamentos.Where(u => u.Nome == Nome).FirstOrDefault();

      return departamento;

    }




    public void UpdateDepartamento(Departamento departamentoData)
    {



      departamentoData.Atualizado_em = System.DateTime.Now;

      this.Context.Departamentos.Update(departamentoData);

    }



    public void InsertDepartamento(Departamento departamento)
    {


      this.Context.Departamentos.Add(departamento);

    }

    public IList<Departamento> GetDepartamentos()
    {


      IList<Departamento> Departamentos = this.Context.Departamentos.Include(d => d.Cargos).Include(d => d.Area).ToList();
      /*
    *
    * Burlar problema com as strings de imagens ao fazer joins com a tabela de áreas
    */
      foreach (var departamento in Departamentos)
      {
        Departamentos.FirstOrDefault(u => u.Id == departamento.Id).Area.imgStr = null; // string de imagem das áreas

      }

      return Departamentos.OrderBy(d => d.Nome).ToList();


    }

  }
}
