using AppServer.Core.Models.Other;
using AppServer.Core.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServer.Core.Services.Interfaces
{
    public interface IIdentityService
    {
        Task<CoreRegisterResponse> RegisterPerson(CoreRegisterRequest request);
        Task<CoreLoginResponse> LoginPerson(CoreLoginRequest request);
        Task<CoreFailure> ValidateRegisterData(CoreRegisterRequest request);

    }
}
