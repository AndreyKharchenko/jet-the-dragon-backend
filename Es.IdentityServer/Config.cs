using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace Es.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };


        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope("esapi", "Es API")
            };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "js",
                    ClientName = "JavaScript Client",
                    AllowedGrantTypes = GrantTypes.Code,
                    RequirePkce = true,
                    //AllowedGrantTypes = GrantTypes.Implicit,
                    RequireClientSecret = false,
                    //AllowAccessTokensViaBrowser = true,

                    RedirectUris =           { "http://localhost:3000" },
                    PostLogoutRedirectUris = { "http://localhost:3000" },
                    AllowedCorsOrigins =     { "http://localhost:3000" },

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "esapi"
                    }
                }
            };
    }
}