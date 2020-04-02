using System.Collections.Generic;
using System.Linq;
using Core.Data.Models;

namespace Core.Data.Repositories
{
  public class NivelAcessoRepository : RepositoryTemplate
    {




        public NivelAcessoRepository() 
        {

        }



        public IList<NivelAcesso> GetNivelAcessos()
        {

            return this.Context.NivelAcessos.ToList();



        }

        public void InsertNivelAcesso(NivelAcesso NivelAcesso)
        { 

            this.Context.NivelAcessos.Add(NivelAcesso);

        }

        public void DeleteNivelAcesso(NivelAcesso NivelAcesso)
        {

            this.Context.NivelAcessos.Remove(NivelAcesso);

        }

        public void UpdateNivelAcesso(NivelAcesso NivelAcessoData)
        {

            NivelAcessoData.Atualizado_em = System.DateTime.Now;

            this.Context.NivelAcessos.Update(NivelAcessoData);

        }



        public NivelAcesso FindNivelAcessoById(int id)
        {

            return this.Context.NivelAcessos.Where(c => c.Id == id).FirstOrDefault();
        }

        public int getTotalNumberCountRegisters()
        {
            return this.Context.NivelAcessos.Count();
        }
    }
}