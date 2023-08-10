using AppServer.API;
using AppServer.Core.Services.Interfaces;
using Grpc.Core;
using System.Runtime.CompilerServices;

namespace AppServer.API.Services
{
    public class AuthenticationService : Identity.IdentityBase
    {
        private readonly ILogger<AuthenticationService> _logger;
        public AuthenticationService(ILogger<AuthenticationService> logger)
        {
            _logger = logger;
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
            return await Task.FromResult(new RegisterPersonResponse
            {
                AccessToken = "KostLAN",
                Failure = null,
                PersonId = 727,
                RefreshToken = "tokeN"
            });
        }

        //public async override
    }
}
