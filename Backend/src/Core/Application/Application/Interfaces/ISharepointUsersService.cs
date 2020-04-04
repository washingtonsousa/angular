using Core.Data.Models;
using Microsoft.SharePoint.Client;
using System.Collections.Generic;

namespace Core.Application.Sharepoint.Services
{
    public interface ISharepointUsersService
    {
        UserCollection GetSiteUsersCollection();
        IList<UsuarioOffice365> Get();
        UsuarioOffice365 Find(string Email);
    }
}