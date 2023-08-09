using ClientApp.Services.Interfaces;
using Grpc.Net.Client;
using Grpc.Net.Client.Web;
using Microsoft.AspNetCore.Components.Forms;
using System;

namespace ClientApp.Services
{
    public class ServerCallService : IServerCallService
    {
        /// <summary>
        /// Constructor defines all services to be injected by DependencyInjection
        /// </summary>
        public ServerCallService() {
             
        }
        /// <summary>
        /// Creates a gRPC channel out of given URI string
        /// </summary>
        /// <param name="uri"></param>
        /// <returns>call-ready gRPC channel</returns>
        public async Task<GrpcChannel> CreateChannel(string _uri)
        {
            if (_uri == null)
            {
                throw new NullReferenceException("The given URI cannot be null.");
            }
            return await CreateChannel(new Uri(_uri));
        }
        /// <summary>
        /// Creates a gRPC channel out of given URI
        /// </summary>
        /// <param name="uri"></param>
        /// <returns>call-ready gRPC channel</returns>
        public async Task<GrpcChannel> CreateChannel(Uri uri)
        {
            var httpClient = new HttpClient(new GrpcWebHandler(GrpcWebMode.GrpcWeb, new HttpClientHandler()));
            return GrpcChannel.ForAddress(uri, new GrpcChannelOptions { HttpClient = httpClient });
        }
    }
}
