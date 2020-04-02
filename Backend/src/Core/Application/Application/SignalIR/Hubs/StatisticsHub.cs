using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Core.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRWeb.Hubs
{

  [HubName("StatisticsHub")]
  public class StatisticsHub : Hub
  {

    private static IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<StatisticsHub>();


    public static void updateLog_Action(Log_Action log_action)
    {
      hubContext.Clients.All.updateLog_Action(log_action);
    }

  }
}
