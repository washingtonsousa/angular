using Core.Application.Helpers;
using Core.Application.Interfaces;
using Microsoft.SharePoint.Client;
using Microsoft.SharePoint.Client.UserProfiles;
using System;

namespace Core.Application.Sharepoint.Services
{
    public class SharepointPeopleManagerAppService : SharepointAppServiceTemplate, ISharepointPeopleManagerAppService
    {

        public PeopleManager PeopleManager { get; private set; }
        public PersonProperties PersonProperties { get; private set; }

        public SharepointPeopleManagerAppService(ClientContext clientContext) : base(clientContext)
        {
        }

        public override void Initialize()
        {
            base.Initialize();
            PeopleManager = new PeopleManager(ClientContext);

        }

        
        public PersonProperties GetPersonPropertiesByEmail(string Email)
        {
            PersonProperties = PeopleManager.GetPropertiesFor(@"i:0#.f|membership|" + Email);

            ClientContext.Load(PersonProperties, p => p.AccountName, p => p.DisplayName, p => p.UserUrl,
                    p => p.Email, p => p.PictureUrl, p => p.PersonalUrl, p => p.UserProfileProperties);

            return PersonProperties;
        }


        public PersonProperties GetPersonPropertiesByLoginName(string LoginName)
        {
            PersonProperties = PeopleManager.GetPropertiesFor(@LoginName);

            ClientContext.Load(PersonProperties, p => p.AccountName, p => p.DisplayName, p => p.UserUrl,
                    p => p.Email, p => p.PictureUrl, p => p.PersonalUrl, p => p.UserProfileProperties);

            return PersonProperties;

        }

        public override bool ExecuteRequest()
        {
            bool result = base.ExecuteRequest();

            if (result && PersonProperties?.AccountName != null)
                return true;

            return false;
        }



    }
}
