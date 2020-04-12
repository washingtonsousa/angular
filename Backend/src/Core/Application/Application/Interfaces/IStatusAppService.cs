using Core.Data.Models;
using System.Collections.Generic;

namespace Core.Application.Interfaces
{
    public interface IStatusAppService
    {
        IList<Status> Get();

        Status Get(int Id);

        Status Insert(Status Status);


        void Delete(int Id);


        Status Update(Status Status);
    }
}
