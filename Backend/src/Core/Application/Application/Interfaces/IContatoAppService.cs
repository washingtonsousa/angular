using Core.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Interfaces
{
    public interface IContatoAppService
    {


        IList<Contato> Get();



        IList<Contato> GetSingle();




        void DeleteSingle(int Id);





        Contato UpdateSingle(Contato Contato);




        Contato InsertSingle(Contato Contato);





        Contato Insert(Contato Contato);




        void Delete(int id);



        Contato Update(Contato Contato);

    }
}
