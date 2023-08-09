using AppServer.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServer.Core.Services
{
    public class GreetService : IGreetService
    {
        public GreetService() { }

        public Task Hello(string name)
        {
            Console.WriteLine("Hello" + name);
            return Task.CompletedTask;
        }
    }
}
