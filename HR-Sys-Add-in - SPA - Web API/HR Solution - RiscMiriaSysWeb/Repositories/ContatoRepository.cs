using System.Collections.Generic;
using System.Linq;
using RiscServicesHRSharepointAddIn.Models;

namespace RiscServicesHRSharepointAddIn.Repositories
{
  public class ContatoRepository : RepositoryTemplate
    { 

        public ContatoRepository()
        {
    
        }

        public IList<Contato> GetContatos()
        {

            return this.Context.Contatos.ToList();

        }

        public Contato FindContato(int Id)
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

        public void UpdateContato(Contato contatoData)
        {
            contatoData.Atualizado_em = System.DateTime.Now;
            this.Context.Contatos.Update(contatoData);

        }

        public void InsertContato(Contato contato)
        {
            this.Context.Contatos.Add(contato);
            

        }

        public void DeleteContato(Contato contato)
        {
            this.Context.Contatos.Remove(contato);

        }

    }
}