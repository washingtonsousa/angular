using System.Collections.Generic;
using System.Linq;
using RiscServicesHRSharepointAddIn.Models;
using Microsoft.EntityFrameworkCore;

namespace RiscServicesHRSharepointAddIn.Repositories
{
  public class UsuarioConhecimentoRepository : RepositoryTemplate
    {


  

        public UsuarioConhecimentoRepository()
        {
        }



        public IList<UsuarioConhecimento> GetUsuarioConhecimentos()
        {

            return this.Context.UsuarioConhecimentos.Include(us=>us.Usuario)
                .Include(u => u.Conhecimento)
                .ToList();



        }

        public void InsertUsuarioConhecimento(UsuarioConhecimento UsuarioConhecimento)
        {
        

            this.Context.UsuarioConhecimentos.Add(UsuarioConhecimento);

        }

        public void DeleteUsuarioConhecimento(UsuarioConhecimento UsuarioConhecimento)
        {

            this.Context.UsuarioConhecimentos.Remove(UsuarioConhecimento);

        }

        public void UpdateUsuarioConhecimento(UsuarioConhecimento UsuarioConhecimentoData)
        {

            UsuarioConhecimentoData.Atualizado_em = System.DateTime.Now;

            this.Context.UsuarioConhecimentos.Update(UsuarioConhecimentoData);

        }



        public UsuarioConhecimento FindUsuarioConhecimento(int Id)
        {

            return this.Context.UsuarioConhecimentos.Where(c => c.Id == Id).FirstOrDefault();
        }


    }
}
