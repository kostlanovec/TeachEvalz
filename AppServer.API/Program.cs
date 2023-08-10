using AppServer.API.Services;
using AppServer.Core.Services;
using AppServer.Core.Services.Interfaces;
using Grpc.AspNetCore.Server;
using Grpc.AspNetCore.Web;

var builder = WebApplication.CreateBuilder(args);

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

// Add services to the container.
builder.Services.AddGrpc(options =>
    {
    options.IgnoreUnknownServices = false;
    });
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", builder => 
    { 
        builder.WithOrigins("https://localhost:7024")
        .AllowAnyHeader()
        .AllowAnyMethod()
        .WithExposedHeaders("Grpc-Status", "Grpc-Message", "Grpc-Encoding", "Grpc-Accept-Encoding", "x-grpc-test-echo-initial", "x-grpc-test-echo-trailing-bin"); ;
    });
});

builder.Services.AddScoped<IIdentityService, IdentityService>(); //Maps the interface to the class

var app = builder.Build();

app.UseGrpcWeb();
app.UseCors("AllowSpecificOrigin");

// Configure the HTTP request pipeline.
app.MapGrpcService<AuthenticationService>().EnableGrpcWeb();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
