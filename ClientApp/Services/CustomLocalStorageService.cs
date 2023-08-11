using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using ClientApp.Services.Interfaces;

namespace ClientApp.Services
{
    public enum StorageItemIdentification
    {
        LoginResponse = 1,
        PersonData = 2
    }
    public class CustomLocalStorageService : ICustomLocalStorageService
    {

        private readonly Blazored.LocalStorage.ILocalStorageService localStorageService;
        public CustomLocalStorageService(Blazored.LocalStorage.ILocalStorageService localStorageService)
        {
            this.localStorageService = localStorageService;
        }

        public async Task StoreTokens(LoginResponse loginResponse)
        {
            await localStorageService.SetItemAsync(StorageItemIdentification.LoginResponse.ToString(), loginResponse);
        }

        public async Task<LoginResponse> GetTokens()
        {
            return await localStorageService.GetItemAsync<LoginResponse>(StorageItemIdentification.LoginResponse.ToString());
        }

        public async Task RemoveData()
        {
            StorageItemIdentification[] identificators = (StorageItemIdentification[])Enum.GetValues(typeof(StorageItemIdentification));
            foreach (StorageItemIdentification ident in identificators)
            {
                await localStorageService.RemoveItemAsync(ident.ToString());
            }
        }

        public async Task<string> GetAccessToken()
        {
            LoginResponse tokens = await GetTokens();

            return tokens?.AccessToken ?? string.Empty;
        }
        public async Task<DateTime> GetAccessTokenExpiration()
        {
            string token = await GetAccessToken();

            return GetTokenExpiration(token);
        }
        public DateTime GetTokenExpiration(string token)
        {
            if (string.IsNullOrEmpty(token) == true)
            {
                return DateTime.UtcNow.AddSeconds(-1);
            }

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            TokenValidationParameters tokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuerSigningKey = false,
                ValidateIssuer = false,
                ValidateActor = false,
                ValidateAudience = false,
                ValidateLifetime = false,
                ValidateSignatureLast = false,
                ValidateTokenReplay = false,
                ValidateWithLKG = false,
                LogValidationExceptions = true,
                SignatureValidator = delegate (string token, TokenValidationParameters parameters)
                {
                    var jwt = new JwtSecurityToken(token);

                    return jwt;
                },
            };

            tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken validatedToken);

            return validatedToken.ValidTo;
        }
        public async Task<string> GetRefreshToken()
        {
            LoginResponse tokens = await GetTokens();

            return tokens?.RefreshToken ?? string.Empty;
        }
        public async Task<DateTime> GetRefreshTokenExpiration()
        {
            string token = await GetRefreshToken();

            return GetTokenExpiration(token);
        }

        public async Task StoreMyPersonData(Person person)
        {
            await localStorageService.SetItemAsync(StorageItemIdentification.PersonData.ToString(), person);
        }

        public async Task<Person> GetMyPersonData()
        {
            return await localStorageService.GetItemAsync<Person>(StorageItemIdentification.PersonData.ToString());
        }


    }
}
