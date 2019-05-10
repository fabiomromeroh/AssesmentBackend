using Business.Contracts;
using Business.Implementations;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace Services.Security
{
    public class AuthorizationProvider : OAuthAuthorizationServerProvider
    {

        public override async System.Threading.Tasks.Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            string uid = context.Parameters.Where(f => f.Key == "userid").Select(f => f.Value).SingleOrDefault()[0];
            context.OwinContext.Set<string>("UserID", uid);

            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            string uid = context.OwinContext.Get<string>("UserID");
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim("email", context.UserName));
            identity.AddClaim(new Claim("UserID", uid));
            context.Validated(identity);
        }
    }
}