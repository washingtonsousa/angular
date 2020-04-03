using Microsoft.SharePoint.Client;
using System;

namespace Core.Application.Sharepoint.Services
{
    abstract public class SharepointAppServiceTemplate : IDisposable
    {

        private bool Disposed = false;
        public ClientContext ClientContext;

        protected SharepointAppServiceTemplate(ClientContext clientContext)
        {
            ClientContext = clientContext;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.Disposed)
            {
                if (disposing)
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