using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Interfaces
{
    public interface ILogAppService
    {

        void GenerateArquivoLogAction(string ArquivoNome);
        void GenerateAccessListArquivoLogAction();

    }
}
