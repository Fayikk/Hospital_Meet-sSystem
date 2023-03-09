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

        }
        public event Action OnChange;

        public async Task DeletePoliclinics(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/policlinic/delete/{id}");
            OnChange?.Invoke();
          
        }

        public async Task<List<Policlinic>> GetPoliclinics()
        {
            var result = await _httpClient.GetFromJsonAsync<ServiceResponse<List<Policlinic>>>("api/policlinic");

            if (result != null)
            {
                
                Policlinics = result.Data;
            }
            OnChange?.Invoke();

            return Policlinics;

        }
    }
}
