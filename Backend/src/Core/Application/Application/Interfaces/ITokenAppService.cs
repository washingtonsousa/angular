using Core.Data.Models;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Interfaces
{
    public interface ITokenAppService
    {

        AuthenticationTicket BuildAuthTicketByUsuario(Usuario usuario);

    }
}
