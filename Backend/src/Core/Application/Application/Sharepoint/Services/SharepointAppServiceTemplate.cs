using Core.Application.Interfaces;
using Microsoft.SharePoint.Client;
using System;

namespace Core.Application.Sharepoint.Services
{
    abstract public class SharepointAppServiceTemplate : IDisposable, ISharepointAppService
    {

        private bool Disposed = false;
        public ClientContext ClientContext;
        ISharepointAuthAppService _sharepointAuthAppService;

        public SharepointAppServiceTemplate(ISharepointAuthAppService sharepointAuthAppService)
        {
            _sharepointAuthAppService = sharepointAuthAppService;
            Initialize();
        }

        public virtual void Initialize()
        {
            ClientContext = _sharepointAuthAppService.GetAppOnlyClientContextByToken();
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!this.Disposed)
            {
                if (disposing && ClientContext != null)
                {
                    ClientContext.Dispose();
                }
            }
            this.Disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual bool ExecuteRequest()
        {

            try
            {

                ClientContext.ExecuteQuery();
                return true;
            }
            catch
            {
                return false;
            }


        }
    }
}