using Core.Application.Interfaces;
using Core.Application.Singleton;
using IdentityModel.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Core.Application
{
    public class ApplicationContextManager: IApplicationContextManager
    {

        public ApplicationContext Context { get; private set; }

        public ApplicationContextManager() { }

        public ApplicationContext GetContext()
        {
            if (Context == null)
                Context = BuildAppContext();

                return Context;
        }


        public ApplicationContext BuildAppContext()
        {

            var httpOwinContext = HttpContext.Current.GetOwinContext();
            return new ApplicationContext(httpOwinContext?.Request?.RemoteIpAddress, httpOwinContext?.Request?.Host.ToString() + httpOwinContext?.Request?.Path.Value);

        }

    }
}
