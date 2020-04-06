using Core.Application.Entities;
using Core.Data.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Helpers
{
    public static class RequestDataHelper
    {

        public static ArquivoFromRequest BuildArquivoFromRequest(this MultipartFormDataStreamProvider provider)
        {
            if (provider.FileData.FirstOrDefault() == null)
                return null;

            var arquivoFromRequest = new ArquivoFromRequest(provider.FileData.FirstOrDefault(), new Arquivo(DateTime.ParseExact(provider.FormData.Get("Data_Referencia"), "yyyy-MM-dd", CultureInfo.InvariantCulture), int.Parse(provider.FormData.Get("Usuario_Id"))));

            return arquivoFromRequest;
        }

        public static ArquivoFromRequest BuildArquivoFromRequest(this MultipartFormDataStreamProvider provider, int UsuarioId)
        {
            if (provider.FileData.FirstOrDefault() == null)
                return null;

            var arquivoFromRequest = new ArquivoFromRequest(provider.FileData.FirstOrDefault(), new Arquivo(DateTime.ParseExact(provider.FormData.Get("Data_Referencia"), "yyyy-MM-dd", CultureInfo.InvariantCulture), UsuarioId, provider.FormData.Get("Descricao")));

            return arquivoFromRequest;
        }

    }
}
