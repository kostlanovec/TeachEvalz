using AppServer.Core.Models.Db;
using AppServer.Core.Models.Other;
using AppServer.Core.Models.Requests;
using AppServer.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

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
            CoreFailure validation = await ValidateRegisterData(request);

            if (validation.Code != 0) {
                return new CoreRegisterResponse
                {
                    Failure = validation
                };
            }
            if (validation == null)
            {
                return new CoreRegisterResponse
                {
                    Failure = new CoreFailure
                    {
                        Code = 2,
                        Message = "Unknown error has occurred during the registration"
                    }
                };
            }

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

        public async Task<CoreFailure> ValidateRegisterData(CoreRegisterRequest request)
        {
            CoreFailure result = new CoreFailure
            {
                Code = 0 //https://github.com/grpc/grpc/blob/master/doc/statuscodes.md
            };

            //Validation code here)
            if (!request.email.EndsWith("@pslib.cz"))
            {
                result.Code = 3;
            }

            return result;
        }
    }
}
