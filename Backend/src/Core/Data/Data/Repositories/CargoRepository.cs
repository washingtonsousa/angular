using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Data.Interfaces;
using Core.Data.Models;
using Core.Data.ORM;
using Microsoft.EntityFrameworkCore;

namespace Core.Data.Repositories
{
    public class CargoRepository :  ICargoRepository
    {
        private HrDbContext Context;
        public CargoRepository(HrDbContext context)
        {
            Context = context;
        }



        public IList<Cargo> Get()
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

        public void Insert(Cargo cargo)
        {


            this.Context.Cargos.Add(cargo);

        }

        public void Delete(Cargo cargo)
        {

            this.Context.Cargos.Remove(cargo);

        }

        public void Update(Cargo model)
        {

            model.Atualizado_em = System.DateTime.Now;

            this.Context.Cargos.Update(model);

        }



        public Cargo Find(int id)
        {

            return this.Context.Cargos.Where(c => c.Id == id).FirstOrDefault();
        }

        public int getTotalNumberCountRegisters()
        {
            return this.Context.Cargos.Count();
        }

        public Task<Cargo> FindAsync(int Id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Cargo model, Cargo modelFromDb)
        {
            throw new System.NotImplementedException();
        }

        public Task<IList<Cargo>> GetAsync()
        {
            throw new System.NotImplementedException();
        }

        public int GetCount()
        {
            throw new System.NotImplementedException();
        }
    }
}
