using Core.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Interfaces
{
    public interface IArquivoAppService
    {
        IList<Arquivo> Get();
        IList<Arquivo> GetSingle();
        void Delete(int Id);
        HttpResponseMessage DownloadSingle(int Id);
        HttpResponseMessage Download(int Id);
        Task SaveFileByUserId();
        Task SaveFileByMatricula();

    }
}
