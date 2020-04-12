using Core.Data.Models;
using System.Collections.Generic;


namespace Core.Application.Interfaces
{
    public interface IExpProfissionalAppService
    {

        IList<ExpProfissional> Get();



        IList<ExpProfissional> GetSingle();





        ExpProfissional InsertSingle(ExpProfissional ExpProfissional);




        ExpProfissional UpdateSingle(ExpProfissional ExpProfissional);





        void DeleteSingle(int Id);





        ExpProfissional Update(ExpProfissional ExpProfissional);




        ExpProfissional Insert(ExpProfissional ExpProfissional);


        void Delete(int Id);
    }
}
