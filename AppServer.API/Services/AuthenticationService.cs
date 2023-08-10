using AppServer.API;
using AppServer.Core.Models;
using AppServer.Core.Services.Interfaces;
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

        /*public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            _greetService.Hello(request.Name); //An example of calling an core service from API

            return Task.FromResult(new HelloReply
            {
                Message = "Hello " + request.Name
            });*/
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

        //public async override
    }
}
