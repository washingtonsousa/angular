using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Data.Interfaces;
using Core.Data.Models;

namespace Core.Data.Repositories
{
  public class ContatoRepository : RepositoryTemplate, IContatoRepository
    { 

        public ContatoRepository()
        {
    
        }

        public IList<Contato> Get()
        {

            return this.Context.Contatos.ToList();

        }

        public Contato Find(int Id)
        {

            return this.Context.Contatos.Where(c => c.Id == Id).FirstOrDefault();
        }

        public IList<Contato> GetContatosByUsuarioId(int UsuarioId)
        {

            return this.Context.Contatos.Where(c => c.UsuarioId == UsuarioId).ToList();
        }

        public Contato FindContatoByBothIds(int Id, int UsuarioId)
        {

            return this.Context.Contatos.Where(c => c.UsuarioId == UsuarioId && c.Id == Id).FirstOrDefault();
        }

        public void Update(Contato contatoData)
        {
            contatoData.Atualizado_em = System.DateTime.Now;
            this.Context.Contatos.Update(contatoData);

        }

        public void Insert(Contato contato)
        {
            this.Context.Contatos.Add(contato);
            

        }

        public void Delete(Contato contato)
        {
            this.Context.Contatos.Remove(contato);

        }

        public Task<Contato> FindAsync(int Id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IList<Contato>> GetAsync()
        {
            throw new System.NotImplementedException();
        }

        public int GetCount()
        {
            throw new System.NotImplementedException();
        }
    }
}