using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Interfaces
{
    public interface IProfilePictureAppService
    {

        Task<string> GetSingle();


        Task<string> Get(int id);

        Task<string> Insert();


        Task<string> Update();



        Task Delete();
    }
}
