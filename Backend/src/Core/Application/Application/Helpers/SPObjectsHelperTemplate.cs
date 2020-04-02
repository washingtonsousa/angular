using Microsoft.SharePoint.Client;
using System;

namespace Core.Application.Helpers
{
  abstract public class SPObjectsHelperTemplate : IDisposable
    {

        private bool disposed = false;
        public ClientContext clientContext;

        protected SPObjectsHelperTemplate(ClientContext clientContext)
        {
            this.clientContext = clientContext;

        }


        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    clientContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }





         public void Save()
        {

            this.clientContext.ExecuteQuery();

        }




    }
}