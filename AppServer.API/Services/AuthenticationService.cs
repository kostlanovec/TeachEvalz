using AppServer.API;
using AppServer.Core.Models.Requests;
using AppServer.Core.Services.Interfaces;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using System.Runtime.CompilerServices;

namespace AppServer.API.Services
{
    public class AuthenticationService : Identity.IdentityBase
    {
        private readonly ILogger<AuthenticationService> _logger;
        private readonly IIdentityService _identityService;
        public AuthenticationService(ILogger<AuthenticationService> logger, IIdentityService identityService)
        {
            _logger = logger;
            _identityService = identityService;
        }
        public async override Task<RegisterPersonResponse> Register(RegisterPersonRequest request, ServerCallContext context)
        {
            CoreRegisterResponse result = await _identityService.RegisterPerson(new CoreRegisterRequest
            {
                email = request.PrimaryEmail,
                first_name = request.FirstName,
                last_name = request.LastName,
                password = request.Password
            });
            return new RegisterPersonResponse
            {
                Failure = null, //Not implemented yet
                AccessToken = result.access_token,
                RefreshToken = result.refresh_token,
                PersonId = result.person_id
            };
        }
        public async override Task<LoginResponse> Login(LoginRequest request, ServerCallContext context)
        {
            throw new NotImplementedException();
        }

        public async override Task<Person> Me(Empty request, ServerCallContext context)
        {
            throw new NotImplementedException();
        }
        public async override Task<LoginResponse> RefreshAccessToken(RefreshAccessTokenRequest request, ServerCallContext context)
        {
            throw new NotImplementedException();
        }
        public async override Task<Failure> ValidateRegisterPersonData(RegisterPersonRequest request, ServerCallContext context)
        {
            throw new NotImplementedException();
        }
    }
}
