using ClientApp.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;

namespace ClientApp.Provider
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ICustomLocalStorageService _storageService;
        private readonly ILogger<CustomAuthenticationStateProvider> _logger;
        public CustomAuthenticationStateProvider(ICustomLocalStorageService storageService, ILogger<CustomAuthenticationStateProvider> logger)
        {
            _storageService = storageService;
            _logger = logger;
        }

        public void StateChanged()
        {
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            string accessToken = await _storageService.GetAccessToken();
            Person person = await _storageService.GetMyPersonData();

            ClaimsIdentity identity;

            if (string.IsNullOrEmpty(accessToken) || person == null)
            {
                identity = new ClaimsIdentity();
            }
            else
            {
                List<Claim> claims = ExtractClaims(accessToken).ToList();
                claims.Add(new Claim(ClaimTypes.Email, person.Email));
                claims.Add(new Claim(ClaimTypes.Name, person.FirstName));
                claims.Add(new Claim(ClaimTypes.GivenName, person.FirstName));
                claims.Add(new Claim(ClaimTypes.Surname, person.LastName));

                identity = new ClaimsIdentity(claims, "jwt");
            }

            return new AuthenticationState(new ClaimsPrincipal(identity));
        }

        public IEnumerable<Claim> ExtractClaims(string jwtToken)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            JwtSecurityToken securityToken = (JwtSecurityToken)tokenHandler.ReadToken(jwtToken);

            IEnumerable<Claim> claims = securityToken.Claims;

            foreach (Claim l in claims) {
                _logger.LogInformation("{0}: {1} {2}", l.Type, l.Value, l.Subject);
            }

            return claims;
        }
    }
}
