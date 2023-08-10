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
        private readonly IDbController _dbController;
        public IdentityService(IDbController dbController) {
            _dbController = dbController;
        }
        public async Task<CoreLoginResponse> LoginPerson(CoreLoginRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<CoreRegisterResponse> RegisterPerson(CoreRegisterRequest request)
        {

            await _dbController.Test(request);
             return null;
        }
    }
}
