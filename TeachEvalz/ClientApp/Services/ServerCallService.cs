using ClientApp.Services.Interfaces;
using Grpc.Net.Client;

namespace ClientApp.Services
{
    public class ServerCallService : IServerCallService
    {
        public ServerCallService() { 
        
        }

        Task<GrpcChannel> IServerCallService.CreateChannel(string uri)
        {
            throw new NotImplementedException();
        }

        Task<GrpcChannel> IServerCallService.CreateChannel(Uri uri)
        {
            throw new NotImplementedException();
        }
    }
}
