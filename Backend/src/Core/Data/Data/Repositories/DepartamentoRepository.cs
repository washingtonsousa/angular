using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Data.Interfaces;
using Core.Data.Models;
using Core.Data.ORM;
using Microsoft.EntityFrameworkCore;

namespace Core.Data.Repositories
{
  public class DepartamentoRepository :  IDepartamentoRepository
    {

        private HrDbContext Context;
        public DepartamentoRepository(HrDbContext context)
        {
            Context = context;
        }


        public Departamento Find(int Id)
    {
      return this.Context.Departamentos.Where(u => u.Id == Id).FirstOrDefault();



    }

    public void Delete(Departamento departamento)
    {

      this.Context.Departamentos.Remove(departamento);

    }


    public Departamento FindByNome(string Nome)
    {
      Departamento departamento = this.Context.Departamentos.Where(u => u.Nome == Nome).FirstOrDefault();

      return departamento;

    }




    public void Update(Departamento departamentoData)
    {



      departamentoData.Atualizado_em = System.DateTime.Now;

      this.Context.Departamentos.Update(departamentoData);

    }



    public void Insert(Departamento departamento)
    {


      this.Context.Departamentos.Add(departamento);

    }

    public IList<Departamento> Get()
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

        public Task<Departamento> FindAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Departamento>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public int GetCount()
        {
            throw new NotImplementedException();
        }
    }
}
