using Microsoft.SharePoint.Client.UserProfiles;
using System;
namespace Core.Application.Interfaces
{
    public interface ISharepointPeopleManagerAppService : ISharepointAppService
    {

        void Initialize();

        PersonProperties GetPersonPropertiesByEmail(string Email);

         PersonProperties GetPersonPropertiesByLoginName(string LoginName);

         bool ExecuteRequest();
    }
}
