using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Security;
using System.Web;

namespace RiscServicesHRSharepointAddIn.Helpers
{
  public class BasicAuthHelper
  {

    /// <summary>
    /// 
    /// </summary>
      public BasicAuthHelper()
    {

                

    }



    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public string GetSPAppToken()
    {
      Uri webUri = new Uri(ConfigurationManager.AppSettings["UrlContext"]);

      string realm = TokenHelper.GetRealmFromTargetUrl(webUri);

      var token = TokenHelper.GetAppOnlyAccessToken(TokenHelper.SharePointPrincipal, webUri.Authority, realm).AccessToken;

      return token;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public ClientContext getAppOnlyClientContextByToken()
    {
      return TokenHelper.GetClientContextWithAccessToken(ConfigurationManager.AppSettings["UrlContext"], this.GetSPAppToken());
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userName"></param>
    /// <param name="Password"></param>
    /// <returns></returns>
    public bool ValidateUserByLdapCredentials(string userName, String Password)
    {
      using (var context = new PrincipalContext(ContextType.Domain, ConfigurationManager.AppSettings["LdapDomain"],
        ConfigurationManager.AppSettings["UrlContext"]+ @"\userName", Password))
      {
        //Username and password for authentication.
      try
        {
          context.ValidateCredentials(userName, Password);

          return true;
        }
        catch (Exception e)
        {

          return false;

        }

      }
    }


      public bool ValidateUserBySPCredentials(string userName, String Password)
    {

      var securePassword = new SecureString();
      foreach (var c in Password) { securePassword.AppendChar(c); }

      using (var context = new ClientContext(ConfigurationManager.AppSettings["UrlContext"]))
      {
        context.Credentials = new SharePointOnlineCredentials(userName, securePassword);
        context.Load(context.Web, web => web.Title);

        try
        {
          context.ExecuteQuery();

          return true;
        }
        catch (Microsoft.SharePoint.Client.IdcrlException e)
        {

          return false;

        }
      }
    }


  }
}
