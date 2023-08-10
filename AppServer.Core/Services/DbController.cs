using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppServer.Core.Models.Db;
using AppServer.Core.Models.Requests;
using AppServer.Core.Services.Interfaces;

namespace AppServer.Core.Services
{
    public class DbController : IDbController
    {
        protected readonly PersonContext _ctx;
        public DbController(PersonContext personContext) { 
            _ctx = personContext;
        }
        public Task Test(CoreRegisterRequest request)
        {
            Person person = new Person
            {
                Email = request.email,
                FirstName = request.first_name,
                LastName = request.last_name,
                Password = request.password,
                PersonId = 1,
            };

            _ctx.Add(person);
            _ctx.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
