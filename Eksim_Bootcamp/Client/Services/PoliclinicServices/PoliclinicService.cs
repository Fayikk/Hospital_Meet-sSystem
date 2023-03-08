using Eksim_Bootcamp.Shared;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace Eksim_Bootcamp.Client.Services.PoliclinicServices
{
    public class PoliclinicService : IPoliclinicService
    {
        private readonly HttpClient _httpClient;
        public PoliclinicService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public List<Policlinic> Policlinics { get ; set ; } = new List<Policlinic>();


        public async Task CreatePoliclinics(Policlinic policlin)
        {
            var response = await _httpClient.PostAsJsonAsync("api/policlinic", policlin);
            OnChange?.Invoke();

            Policlinics = (await response.Content.ReadFromJsonAsync<ServiceResponse<List<Policlinic>>>()).Data;
        }
        public event Action OnChange;

        public async Task DeletePoliclinics(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/policlinic/delete/{id}");
            OnChange?.Invoke();
            Policlinics = (await result.Content.ReadFromJsonAsync<ServiceResponse<List<Policlinic>>>()).Data;
        }

        public async Task<List<Policlinic>> GetPoliclinics()
        {
            var result = await _httpClient.GetFromJsonAsync<ServiceResponse<List<Policlinic>>>("api/policlinic");

            if (result != null)
            {
                
                Policlinics = result.Data;
            }

            return Policlinics;

        }
    }
}
