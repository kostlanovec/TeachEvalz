using ClientApp.Services.Interfaces;
using Google.Protobuf.WellKnownTypes;

namespace ClientApp.Services

{
    public class AuthenticationService : IAuthenticationService
    {
        public AuthenticationService() { }

        public Task<LoginResponse> LoginUser(LoginRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Person> Me(Empty request)
        {
            throw new NotImplementedException();
        }

        public Task<LoginResponse> RefreshAccessToken(RefreshAccessTokenRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<RegisterPersonResponse> RegisterPerson(RegisterPersonRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Failure> ValidateRegisterPersonData(RegisterPersonRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
