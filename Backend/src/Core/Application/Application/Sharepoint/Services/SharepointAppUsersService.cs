using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Microsoft.SharePoint.Client;
using Microsoft.SharePoint.Client.UserProfiles;
using Core.Data.Models;
using Core.Application.Interfaces;
using Core.Data.Interfaces;

namespace Core.Application.Sharepoint.Services
{
  public class SharepointAppUsersService: SharepointAppServiceTemplate, ISharepointUsersService
    {

    private ISharepointPeopleManagerAppService _sharepointPeopleManagerAppService;

        public IUsuarioRepository _usuarioRepo { get; }

        public SharepointAppUsersService(ISharepointPeopleManagerAppService SharepointPeopleManagerAppService, IUsuarioRepository usuarioRepository, ISharepointAuthAppService sharepointAuthAppService) : base(sharepointAuthAppService)
        {

          _sharepointPeopleManagerAppService = SharepointPeopleManagerAppService;
          _usuarioRepo = usuarioRepository;
         
        }

        public UserCollection GetSiteUsersCollection()
        {
            Initialize();

            UserCollection siteUsers = ClientContext.Web.SiteUsers;
            ClientContext.Load(siteUsers);
            ClientContext.ExecuteQuery();
            ClientContext.Load(siteUsers);
            ExecuteRequest();

            return siteUsers;
        }

        public IList<UsuarioOffice365> Get()
        {

       _sharepointPeopleManagerAppService.Initialize();

      IList<UsuarioOffice365> siteUsersList = new List<UsuarioOffice365>();
      IList<User> SysUsersList = new List<User>();

      UserCollection siteUsers = GetSiteUsersCollection();

      foreach (var user in siteUsers)
      {

        PersonProperties personProperties = _sharepointPeopleManagerAppService.GetPersonPropertiesByLoginName(user.LoginName);

        if (_sharepointPeopleManagerAppService.ExecuteRequest())
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

            if (_usuarioRepo.FindUsuarioByEmail(usuarioOffice365.Email) != null)
            {
              usuarioOffice365.Status = true;
              usuarioOffice365.UsuarioFromDbId = _usuarioRepo.FindUsuarioByEmail(usuarioOffice365.Email).Id;

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

        public UsuarioOffice365 Find(string Email)
        {
            return this.Get().FirstOrDefault(u => u.Email == Email);
        }
        
        }
    
    }
