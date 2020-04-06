using Core.Shared.Kernel.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Core.Application.Facades
{
    public class RequestFormDataProviderFacade
    {
        public static async Task<MultipartFormDataStreamProvider> BuildFormDataProvider()
        {
            HttpRequestMessage httpRequestMessage = HttpContext.Current.Items["MS_HttpRequestMessage"] as HttpRequestMessage;

            var provider = new MultipartFormDataStreamProvider(HttpContext.Current.Server.MapPath("~/App_Data"));

            try
            {
                return await httpRequestMessage.Content.ReadAsMultipartAsync(provider);
            }
            catch (System.Exception e)
            {
                DomainEvent.Notify(new DomainNotification("Ocorreu um erro ao processar os dados da requisição, tente novamente mais tarde"));
                return null;
            }
        }

    }
}
