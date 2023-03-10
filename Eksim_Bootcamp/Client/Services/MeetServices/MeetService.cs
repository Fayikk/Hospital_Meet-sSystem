using Eksim_Bootcamp.Shared;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Json;
using System.Numerics;

namespace Eksim_Bootcamp.Client.Services.MeetServices
{
    public class MeetService : IMeetService
    {
        private readonly HttpClient _http;
        private readonly AuthenticationStateProvider _stateProvider;
        public List<Meet> Meets { get; set; } = new List<Meet>();

        public MeetService(HttpClient http,AuthenticationStateProvider stateProvider)
        {
            _http = http;
            _stateProvider = stateProvider;
        }

        public async Task<ServiceResponse<Meet>> CreateMeet(Meet meet)
        {
            var response = await _http.PostAsJsonAsync("api/meet/add", meet);
            if (response.IsSuccessStatusCode)
            {
                var errorResponse = await response.Content.ReadFromJsonAsync<ServiceResponse<Meet>>();
                var errors = new ServiceResponse<Meet>
                {
                    Message = errorResponse.Message,
                    Success = errorResponse.Success
                };
                return errors;
            }
            var responseData = await response.Content.ReadFromJsonAsync<ServiceResponse<Meet>>();
            return responseData;
        }

        public async Task CancelMeet(int id)
        {
            var result = await _http.PutAsJsonAsync<ServiceResponse<Meet>>($"api/meet/cancel/{id}",null);
        }

        public async Task<List<Meet>> GetMeet()
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<Meet>>>("api/meet/getMeet");
            return result.Data;
        }
    }
}
