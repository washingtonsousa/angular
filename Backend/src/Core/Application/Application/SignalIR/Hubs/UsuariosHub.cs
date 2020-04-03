using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Core.Data.Models;

namespace HRWeb.Hubs
{

  [HubName("UsuariosHub")]
  public class UsuariosHub : Hub
  {

    private static IHubContext hubContext = GlobalHost.ConnectionManager.getHubContext<UsuariosHub>();


    public static void newUsuario(Usuario usuario)
    {
      hubContext.Clients.All.newUsuario(usuario);
    }

    public static void updateUsuario(Usuario usuario)
    {
      hubContext.Clients.All.updateUsuario(usuario);
    }

    public static void deleteUsuario(Usuario usuario)
    {
      hubContext.Clients.All.deleteUsuario(usuario);
    }


  }
}
