using Core.Data.Interfaces;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Abstractions
{
    public abstract class AppServiceWithHub<THub> : AppService where THub : IHub
    {

        Lazy<IHubContext> hub = new Lazy<IHubContext>(
        () => GlobalHost.ConnectionManager.GetHubContext<THub>()
        );
        public AppServiceWithHub(IUnityOfWork unitOfWork) : base(unitOfWork)
        {
        }

        protected IHubContext Hub
        {
            get { return hub.Value; }
        }

    }
}
