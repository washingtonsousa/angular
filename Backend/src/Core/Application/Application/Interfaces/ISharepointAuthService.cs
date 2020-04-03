using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Interfaces
{
    public interface ISharepointAuthAppService
    {
        string GetApplicationToken();
        ClientContext GetAppOnlyClientContextByToken();
        bool ValidateUserBySPCredentials(string userName, string Password);
    }
}
