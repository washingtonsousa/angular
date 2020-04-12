using Core.Application.Entities;
using Core.Data.Models;
using Microsoft.SharePoint.Client;
using System.Collections.Generic;

namespace Core.Application.Sharepoint.Services
{
    public interface ISharepointUsersService
    {
        UserCollection GetSiteUsersCollection();
        IList<UserFromAuthEngine> Get();
        UserFromAuthEngine Find(string Email);
    }
}