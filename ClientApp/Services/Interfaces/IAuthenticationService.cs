using Google.Protobuf.WellKnownTypes;

namespace ClientApp.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<LoginResponse> LoginUser(LoginRequest request);
        Task<RegisterPersonResponse> RegisterPerson(RegisterPersonRequest request);
        Task<LoginResponse> RefreshAccessToken(RefreshAccessTokenRequest request);
        Task<Person> Me(Empty request);
        Task<Failure> ValidateRegisterPersonData(RegisterPersonRequest request);

    }
}
