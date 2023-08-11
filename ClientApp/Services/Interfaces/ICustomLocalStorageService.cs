namespace ClientApp.Services.Interfaces
{
    public interface ICustomLocalStorageService
    {
        Task<string> GetAccessToken();
        Task<DateTime> GetAccessTokenExpiration();

        Task<string> GetRefreshToken();
        Task<DateTime> GetRefreshTokenExpiration();
        Task<LoginResponse> GetTokens();
        Task StoreTokens(LoginResponse loginResponse);

        Task StoreMyPersonData(Person person);
        Task<Person> GetMyPersonData();

        /// <summary>
        /// After logout - remove all data from the local storage
        /// </summary>
        /// <returns></returns>
        Task RemoveData();
    }
}
