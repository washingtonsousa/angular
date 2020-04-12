using Core.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Interfaces
{
    public interface IEnderecoAppService
    {


        IList<Endereco> Get();



        IList<Endereco> GetSingle();



        void DeleteSingle(int Id);




        Endereco UpdateSingle(Endereco Endereco);




        Endereco InsertSingle(Endereco Endereco);





        Endereco Insert(Endereco endereco);




        void Delete(int Id);




        Endereco Update(Endereco endereco);

    }
}
