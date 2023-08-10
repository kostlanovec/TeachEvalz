using AppServer.Core.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServer.Core.Services.Interfaces
{
    public interface IDbController
    {
        Task Test(CoreRegisterRequest request);
    }
}
