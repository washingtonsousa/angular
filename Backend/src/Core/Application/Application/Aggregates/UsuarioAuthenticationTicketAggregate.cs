using Core.Data.Models;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Aggregates
{
    public class UsuarioAuthenticationTicketAggregate
    {
        public UsuarioAuthenticationTicketAggregate(Usuario usuario, AuthenticationTicket ticket)
        {
            Usuario = usuario;
            Ticket = ticket;
        }

        public Usuario Usuario { get; set; }
        public AuthenticationTicket Ticket {get; set;}

        public bool Valid { get {

                return Ticket != null;
            
            } }

    }
}
