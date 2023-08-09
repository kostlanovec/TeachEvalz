using AppServer.API;
using AppServer.Core.Services.Interfaces;
using Grpc.Core;

namespace AppServer.API.Services
{
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly ILogger<GreeterService> _logger;
        private readonly IGreetService _greetService;
        public GreeterService(ILogger<GreeterService> logger, IGreetService greetService)
        {
            _greetService = greetService; //An dependency injection use example
            _logger = logger;
        }

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            _greetService.Hello(request.Name); //An example of calling an core service from API

            return Task.FromResult(new HelloReply
            {
                Message = "Hello " + request.Name
            });
        }
    }
}