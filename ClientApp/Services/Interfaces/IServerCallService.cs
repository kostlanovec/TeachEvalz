using Grpc.Net.Client;

namespace ClientApp.Services.Interfaces
{
    public interface IServerCallService
    {
        Task<GrpcChannel> CreateChannel(string uri);
        Task<GrpcChannel> CreateChannel(Uri uri);
        //Task<Greeter.GreeterClient> CreateGreeterClient(string uri);

    }
}
