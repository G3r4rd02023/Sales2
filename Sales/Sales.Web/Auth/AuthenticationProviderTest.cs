using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace Sales.WEB.Auth
{
    public class AuthenticationProviderTest : AuthenticationStateProvider
    {
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            await Task.Delay(3000);
            var anonimous = new ClaimsIdentity();
            var gerUser = new ClaimsIdentity(new List<Claim>
            {
                new Claim("FirstName", "Gerardo"),
                new Claim("LastName", "Lanza"),
                new Claim(ClaimTypes.Name, "gerardo@yopmail.com"),
                new Claim(ClaimTypes.Role, "Admin")
            },
            authenticationType: "test");
            return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(gerUser)));
        }
    }
}

