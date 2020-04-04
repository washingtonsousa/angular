using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Singleton
{
    public class ApplicationContext
    {
        public ApplicationContext(string enderecoRemoto, string rota)
        {
            EnderecoRemoto = enderecoRemoto;
            Rota = rota;
        }

        public string EnderecoRemoto { get; private set;}

        public string Rota { get; private set; }


    
    }
}
