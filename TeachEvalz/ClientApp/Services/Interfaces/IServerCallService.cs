using Grpc.Net.Client;

namespace ClientApp.Services.Interfaces
{
    public interface IServerCallService
    {
        protected Task<GrpcChannel> CreateChannel(string uri);
        protected Task<GrpcChannel> CreateChannel(Uri uri);

    }
}
