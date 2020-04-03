using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Data.Interfaces;
using Core.Data.Models;
using Core.Data.ORM;

namespace Core.Data.Repositories
{
  public class NivelAcessoRepository :  INivelAcessoRepository
    {

        private HrDbContext Context;
        public NivelAcessoRepository(HrDbContext context)
        {
            Context = context;
        }

        public IList<NivelAcesso> Get()
        {

            return this.Context.NivelAcessos.ToList();



        }

        public void Insert(NivelAcesso NivelAcesso)
        { 

            this.Context.NivelAcessos.Add(NivelAcesso);

        }

        public void Delete(NivelAcesso NivelAcesso)
        {

            this.Context.NivelAcessos.Remove(NivelAcesso);

        }

        public void Update(NivelAcesso NivelAcessoData)
        {

            NivelAcessoData.Atualizado_em = System.DateTime.Now;

            this.Context.NivelAcessos.Update(NivelAcessoData);

        }



        public NivelAcesso Find(int id)
        {

            return this.Context.NivelAcessos.Where(c => c.Id == id).FirstOrDefault();
        }

        public int getTotalNumberCountRegisters()
        {
            return this.Context.NivelAcessos.Count();
        }

        public Task<NivelAcesso> FindAsync(int Id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IList<NivelAcesso>> GetAsync()
        {
            throw new System.NotImplementedException();
        }

        public int GetCount()
        {
            throw new System.NotImplementedException();
        }
    }
}