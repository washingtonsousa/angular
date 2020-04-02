using Microsoft.Owin.Security.OAuth;
using System;

namespace Core.Application.Providers
{
    public static class OAuthConfigProvider
    {
        private static OAuthAuthorizationServerOptions _oAuthOptions = null;

        public static OAuthAuthorizationServerOptions OAuthOptions { get {

                if(_oAuthOptions == null)
                _oAuthOptions = new OAuthAuthorizationServerOptions
                {

                    AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                    AllowInsecureHttp = true,
                    TokenEndpointPath = new Microsoft.Owin.PathString("/api/token"),
                    Provider = new OAuthProvider()

                };

                return _oAuthOptions;


                } }
}

    }
}
