using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using AppServer.Core.Models.Db;
using AppServer.Core.Services.Interfaces;
using AppServer.Core.Services;

var builder = Host.CreateDefaultBuilder(args);

builder.ConfigureServices(services =>
{
    services.AddDbContext<PersonContext>(options => options.UseSqlite("Data Source=person.db"));
});

var app = builder.Build();

app.Run();