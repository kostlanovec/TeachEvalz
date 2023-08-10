using AppServer.Core.Models;
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
        public IdentityService() { }
        public async Task<CoreLoginResponse> LoginPerson(CoreLoginRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<CoreRegisterResponse> RegisterPerson(CoreRegisterRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
