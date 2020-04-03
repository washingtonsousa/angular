using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Data.Interfaces;
using Core.Data.Models;
using Core.Data.ORM;

namespace Core.Data.Repositories
{
  public class EnderecoRepository :  IEnderecoRepository
    {

        private HrDbContext Context;
        public EnderecoRepository(HrDbContext context)
        {
            Context = context;
        }




        public Endereco FindByUsuarioId(int UsuarioId)
        {
            return this.Context.Enderecos.Where(e => e.UsuarioId == UsuarioId).FirstOrDefault();

        }

        public Endereco FindByBothIds(int Id, int UsuarioId)
        {

            return this.Context.Enderecos.Where(e => e.Id == Id && e.UsuarioId == UsuarioId).FirstOrDefault();

        }

        public IList<Endereco> Get()
        {
            return this.Context.Enderecos.ToList();

        }

        public Endereco Find(int Id)
        {
            return this.Context.Enderecos.Where(e => e.Id == Id).FirstOrDefault();

        }

        public void Insert(Endereco endereco)
        {

            this.Context.Add(endereco);
        }


        public void Delete(Endereco endereco)
        {
            this.Context.Enderecos.Remove(endereco);

        }

        public void Update(Endereco enderecoData)
        {
            enderecoData.Atualizado_em = System.DateTime.Now;
            this.Context.Enderecos.Update(enderecoData);

        }

        public Task<Endereco> FindAsync(int Id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IList<Endereco>> GetAsync()
        {
            throw new System.NotImplementedException();
        }

        public int GetCount()
        {
            throw new System.NotImplementedException();
        }
    }
}