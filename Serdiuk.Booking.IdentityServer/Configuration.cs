using IdentityServer4;
using IdentityServer4.Models;

internal class Configuration
{
    internal static IEnumerable<ApiResource> ApiResources()
    {
        yield return new ApiResource("BookingApi", "Booking");
    }

    internal static IEnumerable<ApiScope> ApiScopes()
    {
        yield return new ApiScope("BookingApi", "Booking");
    }

    internal static IEnumerable<Client> Clients()
    {
        yield return new Client()
        {
            RedirectUris = { "http://localhost:3000/signin-oidc" },
            AllowedGrantTypes = GrantTypes.Implicit,
            ClientId = "booking-api",
            ClientName = "BookingApi",
            RequireClientSecret = false,
            RequirePkce = true,
            AllowedScopes =
            {
                "BookingApi",
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Email,
                IdentityServerConstants.StandardScopes.Profile,
            },
            AllowedCorsOrigins =
            {
                "http://localhost:3000"
            },
            PostLogoutRedirectUris =
            {
                "http://localhost:3000/signout-oidc"
            },
            AllowAccessTokensViaBrowser = true,
        };
    }

    internal static IEnumerable<IdentityResource> IdentityResources()
    {
        yield return new IdentityResources.OpenId();
        yield return new IdentityResources.Profile();
        yield return new IdentityResources.Email();

    }
}