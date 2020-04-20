using Core.Application.Interfaces;
using Core.Data;
using Core.Data.Models;
using Microsoft.SharePoint.Client;
using System;
using System.Security;

namespace Core.Application.Sharepoint.Services
{
    public class SharepointAuthAppService : ISharepointAuthAppService
    {

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetApplicationToken()
        {
            Uri webUri = new Uri(ConfigData.ContextAppUrl);
            string realm = TokenHelper.GetRealmFromTargetUrl(webUri);
            return TokenHelper.GetAppOnlyAccessToken(TokenHelper.SharePointPrincipal, webUri.Authority, realm).AccessToken;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ClientContext GetAppOnlyClientContextByToken() {

            try
            {
                return TokenHelper.GetClientContextWithAccessToken(ConfigData.ContextAppUrl, GetApplicationToken());
            }
            catch (Exception)
            {
            }

            return null;
         } 
        

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