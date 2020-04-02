using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Microsoft.SharePoint.Client;
using Microsoft.SharePoint.Client.UserProfiles;
using Core.Data.Models;

namespace Core.Data.Repositories
{
  public class SPUserRepository
    {

    private ClientContext clientContext;
    private SPPeopleManagerHelper peopleManagerHelper;
    private UsuarioRepository usuarioRepo;

    public SPUserRepository(ClientContext clientContext)
        {

          this.clientContext = clientContext;
          peopleManagerHelper = new SPPeopleManagerHelper(this.clientContext);
          usuarioRepo = new UsuarioRepository();
         
        }

        public IList<UsuarioOffice365> GetSPUsers()
        {

      IList<UsuarioOffice365> siteUsersList = new List<UsuarioOffice365>();
      IList<User> SysUsersList = new List<User>();

      UserCollection siteUsers = this.clientContext.Web.SiteUsers;

      clientContext.Load(siteUsers);
      clientContext.ExecuteQuery();

      clientContext.Load(siteUsers);
      foreach (var user in siteUsers)
      {

        PersonProperties personProperties = peopleManagerHelper.getPersonPropertiesByLoginName(user.LoginName);

        if (peopleManagerHelper.execQuery())
        {

          if (user.LoginName.Split("|".ToCharArray()).LastOrDefault().Split("@".ToCharArray()).LastOrDefault()
            == ConfigurationManager.AppSettings["ContextDomain"])
          {
            UsuarioOffice365 usuarioOffice365 = new UsuarioOffice365();

            usuarioOffice365.AccountName = personProperties.AccountName;
            usuarioOffice365.PictureUrl = personProperties.PictureUrl;
            usuarioOffice365.UserUrl = personProperties.UserUrl;
            usuarioOffice365.DisplayName = personProperties.DisplayName;
            usuarioOffice365.Email = user.LoginName.Split("|".ToCharArray()).LastOrDefault();
            usuarioOffice365.personProperties = personProperties.UserProfileProperties;

            if (usuarioRepo.FindUsuarioByEmail(usuarioOffice365.Email) != null)
            {
              usuarioOffice365.Status = true;
              usuarioOffice365.UsuarioFromDbId = usuarioRepo.FindUsuarioByEmail(usuarioOffice365.Email).Id;

            }
            else
            {
              usuarioOffice365.Status = false;
            }

            siteUsersList.Add(usuarioOffice365);

          }

        }

        }

        return siteUsersList;

        }

        public UsuarioOffice365 FindSPUser(string Email)
        {
            return this.GetSPUsers().FirstOrDefault(u => u.Email == Email);
        }
        
        }
    
    }
