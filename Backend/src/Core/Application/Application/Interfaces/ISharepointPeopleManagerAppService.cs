using Microsoft.SharePoint.Client.UserProfiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Interfaces
{
    public interface ISharepointPeopleManagerAppService
    {


        PersonProperties GetPersonPropertiesByEmail(string Email);

         PersonProperties GetPersonPropertiesByLoginName(string LoginName);

         bool ExecuteRequest();
    }
}
