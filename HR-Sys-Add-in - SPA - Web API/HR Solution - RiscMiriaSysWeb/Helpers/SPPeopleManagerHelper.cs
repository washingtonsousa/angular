using Microsoft.SharePoint.Client;
using Microsoft.SharePoint.Client.UserProfiles;
using System;

namespace RiscServicesHRSharepointAddIn.Helpers
{



  public class SPPeopleManagerHelper : SPObjectsHelperTemplate
    {

        public PeopleManager peopleManager { get; private set; }
        public PersonProperties personProperties { get; private set; }

        public SPPeopleManagerHelper(ClientContext clientContext) : base(clientContext)
        {
            initComponents();

        }

        private void initComponents()
        {

            peopleManager = new PeopleManager(this.clientContext);

        }

        public PersonProperties getPersonPropertiesByEmail(String Email)
        {
            personProperties = peopleManager.GetPropertiesFor(@"i:0#.f|membership|" + Email);

            this.clientContext.Load(personProperties, p => p.AccountName, p => p.DisplayName, p => p.UserUrl,
                    p => p.Email,p => p.PictureUrl, p => p.PersonalUrl, p => p.UserProfileProperties);

            return personProperties;

        }


    public PersonProperties getPersonPropertiesByLoginName(string LoginName)
    {
      personProperties = peopleManager.GetPropertiesFor(@LoginName);

      this.clientContext.Load(personProperties, p => p.AccountName, p => p.DisplayName, p => p.UserUrl,
              p => p.Email, p => p.PictureUrl, p => p.PersonalUrl, p => p.UserProfileProperties);

      return personProperties;

    }

    public bool execQuery()
        {
            try
            {

                this.clientContext.ExecuteQuery();

                if (personProperties.AccountName != null)
                {

                    return true;

                }

            }
            catch (Microsoft.SharePoint.Client.ServerObjectNullReferenceException e)
            {

                return false;

            }

            return false;

        }
        


    }
}
