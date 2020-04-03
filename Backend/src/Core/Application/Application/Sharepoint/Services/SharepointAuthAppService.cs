using Core.Data;
using Core.Data.Models;
using Microsoft.SharePoint.Client;
using System;
using System.Security;

namespace Core.Application.Sharepoint.Services
{
    public class SharepointAuthAppService
    {

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string getApplicationToken()
        {
            Uri webUri = new Uri(ConfigData.ContextAppUrl);
            string realm = TokenHelper.getRealmFromTargetUrl(webUri);
            return TokenHelper.getAppOnlyAccessToken(TokenHelper.SharePointPrincipal, webUri.Authority, realm).AccessToken;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ClientContext getAppOnlyClientContextByToken() => TokenHelper.getClientContextWithAccessToken(ConfigData.ContextAppUrl, getApplicationToken());
        

        public bool ValidateUserBySPCredentials(string userName, string Password)
        {

            var securePassword = new SecureString();
            foreach (var c in Password) { securePassword.AppendChar(c); }

            using (var context = new ClientContext(ConfigData.ContextAppUrl))
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