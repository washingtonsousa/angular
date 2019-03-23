using System.Collections.Generic;
using System.Linq;
using RiscServicesHRSharepointAddIn.Models;
using Microsoft.EntityFrameworkCore;

namespace RiscServicesHRSharepointAddIn.Repositories
{
  public class ArquivoRepository : RepositoryTemplate
    {

        public ArquivoRepository() 
        {
  

        }


        public Arquivo FindArquivoByBothIds(int Id, int UsuarioId)
        {

            return this.Context.Arquivos.Where(e => e.Id == Id && e.UsuarioId == UsuarioId).FirstOrDefault();

        }

        public IList<Arquivo> GetArquivosByBothIds(int Id, int UsuarioId)
        {

            return this.Context.Arquivos.Where(e => e.Id == Id && e.UsuarioId == UsuarioId).ToList();

        }



        public IList<Arquivo> GetArquivosByUsuarioId(int UsuarioId)
        {

            return this.Context.Arquivos.Where(e => e.UsuarioId == UsuarioId).ToList();

        }




        public IList<Arquivo> GetArquivos()
        {
            return this.Context.Arquivos.Include(a => a.Usuario).OrderByDescending(a=> a.Criado_em).ToList();

        }

        public Arquivo FindArquivo(int Id)
        {
            return this.Context.Arquivos.Include(a => a.Usuario).Where(e => e.Id == Id).FirstOrDefault();

        }

        public void InsertArquivo(Arquivo Arquivo)
        {
            this.Context.Arquivos.Add(Arquivo);
        }


        public void DeleteArquivo(Arquivo Arquivo)
        {
            this.Context.Arquivos.Remove(Arquivo);

        }

        public void UpdateArquivo(Arquivo ArquivoData)
        {
            ArquivoData.Atualizado_em = System.DateTime.Now;
            this.Context.Arquivos.Update(ArquivoData);

        }
    }
}
