using ClientApp.Services.Interfaces;
using ClientApp.Provider;
using Google.Protobuf.WellKnownTypes;

namespace ClientApp.Services

{
    public class AuthenticationService : IAuthenticationService
    {
        protected readonly IServerCallService _serverCallService;
        private readonly ICustomLocalStorageService _storageService;
        private readonly CustomAuthenticationStateProvider _customAuthenticationStateProvider;
        public AuthenticationService(IServerCallService serverCallService, ICustomLocalStorageService customLocalStorageService)
        {
            _serverCallService = serverCallService;
            _storageService = customLocalStorageService;
        }

        /// <summary>
        /// Processes the LoginRequest and sends it to API
        /// </summary>
        /// <returns>LoginResponse</returns>
        public Task<LoginResponse> LoginUser(LoginRequest request)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns caller's identity
        /// </summary>
        /// <returns>Person</returns>
        public Task<Person> Me(Empty request)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Sends RefreshAccessTokenRequest to API
        /// </summary>
        /// <returns>New access token (LoginResponse)</returns>
        public Task<LoginResponse> RefreshAccessToken(RefreshAccessTokenRequest request)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Processes the RegisterPersonRequest and sends it to API
        /// </summary>
        /// <returns>RegisterPersonResponse</returns>
        public async Task<RegisterPersonResponse> RegisterPerson(RegisterPersonRequest request)
        {
            var channel = await _serverCallService.CreateChannel("https://localhost:7130");
            var client = new Identity.IdentityClient(channel);

            var result = await client.RegisterAsync(request); await client.RegisterAsync(request);

            await _storageService.StoreTokens(new LoginResponse() { AccessToken = result.AccessToken, RefreshToken = result.RefreshToken });

            return result;
        }

        /// <summary>
        /// Validates the RegisterPersonRequest
        /// </summary>
        /// <returns>Validation result</returns>
        public Task<Failure> ValidateRegisterPersonData(RegisterPersonRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
