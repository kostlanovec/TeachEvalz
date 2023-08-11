using AppServer.Core.Models.Db;
using AppServer.Core.Models.Requests;
using AppServer.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServer.Core.Services
{
    public class IdentityService : IIdentityService
    {
        protected readonly PersonContext _ctx; //Persons Context
        public IdentityService(PersonContext personContext) {
            _ctx = personContext;
        }
        public async Task<CoreLoginResponse> LoginPerson(CoreLoginRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<CoreRegisterResponse> RegisterPerson(CoreRegisterRequest request)
        {

            Person person = new Person
            {
                Email = request.email,
                FirstName = request.first_name,
                LastName = request.last_name,
                Password = request.password, //Needs some hashing for future
            };

            _ctx.Persons.Add(person);
            _ctx.SaveChanges();
            return new CoreRegisterResponse();
        }
    }
}
