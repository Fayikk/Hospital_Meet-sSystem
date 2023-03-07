using Eksim_Bootcamp.Shared.Model;
using Eksim_Bootcamp.Shared;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.Authorization;

namespace Eksim_Bootcamp.Client.Services.AuthServices
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;
        private readonly AuthenticationStateProvider _stateProvider;
        public AuthService(HttpClient httpClient, AuthenticationStateProvider stateProvider)
        {
            _httpClient = httpClient;
            _stateProvider = stateProvider;
        }



        public async Task<bool> IsUserAuthenticated()
        {

            return (await _stateProvider.GetAuthenticationStateAsync()).User.Identity.IsAuthenticated;
        }

        public async Task<ServiceResponse<string>> Login(UserLogin user)
        {
            var result = await _httpClient.PostAsJsonAsync("api/auth/login", user);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<string>>();

        }

        public async Task<ServiceResponse<int>> Register(UserRegister request)
        {
            var result = await _httpClient.PostAsJsonAsync("api/auth/register", request);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<int>>();
        }
    }
}
