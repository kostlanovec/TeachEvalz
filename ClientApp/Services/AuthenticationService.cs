using ClientApp.Services.Interfaces;
using Google.Protobuf.WellKnownTypes;

namespace ClientApp.Services

{
    public class AuthenticationService : IAuthenticationService
    {
        protected readonly IServerCallService _serverCallService;
        public AuthenticationService(IServerCallService serverCallService)
        {
            _serverCallService = serverCallService;
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
            return await client.RegisterAsync(request);
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
