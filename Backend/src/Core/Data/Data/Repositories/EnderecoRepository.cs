using System.Collections.Generic;
using System.Linq;
using Core.Data.Models;

namespace Core.Data.Repositories
{
  public class EnderecoRepository : RepositoryTemplate
    {
      
        public EnderecoRepository()
        {


        }

      

        public Endereco FindEnderecoByUsuarioId(int UsuarioId)
        {
            return this.Context.Enderecos.Where(e => e.UsuarioId == UsuarioId).FirstOrDefault();

        }

        public Endereco FindEnderecoByBothIds(int Id, int UsuarioId)
        {

            return this.Context.Enderecos.Where(e => e.Id == Id && e.UsuarioId == UsuarioId).FirstOrDefault();

        }

        public IList<Endereco> GetEnderecos()
        {
            return this.Context.Enderecos.ToList();

        }

        public Endereco FindEndereco(int Id)
        {
            return this.Context.Enderecos.Where(e => e.Id == Id).FirstOrDefault();

        }

        public void InsertEndereco(Endereco endereco)
        {

            this.Context.Add(endereco);
        }


        public void DeleteEndereco(Endereco endereco)
        {
            this.Context.Enderecos.Remove(endereco);

        }

        public void UpdateEndereco(Endereco enderecoData)
        {
            enderecoData.Atualizado_em = System.DateTime.Now;
            this.Context.Enderecos.Update(enderecoData);

        }
    }
}