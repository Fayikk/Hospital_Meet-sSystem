using Eksim_Bootcamp.Shared;
using System.Net.Http;
using System.Net.Http.Json;

namespace Eksim_Bootcamp.Client.Services.DoctorServices
{
    public class DoctorService : IDoctorService
    {
        private readonly HttpClient _http;
        public DoctorService(HttpClient http)
        {
            _http = http;
        }

        public List<Doctor> Doctors { get ; set ; } = new List<Doctor>();
        public string Message { get ; set ; }

        public event Action ProductsChanged;

        public async Task GetDoctors()
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<Doctor>>>("api/doctor/getall");
            if (result != null && result.Data != null)
            {
                Doctors = result.Data;
            }     
        }

        //public async Task<ServiceResponse<Doctor>> GetDoctor(int id)
        //{
        //    var result = await _http.GetFromJsonAsync<ServiceResponse<Doctor>>($"api/Doctor/{id}");
        //    return result;
        //}

        public async Task GetDoctor(string Id)
        {
            var rev = int.Parse(Id);

            var result = await _http.GetFromJsonAsync<ServiceResponse<List<Doctor>>>($"api/doctor/{rev}");
            if (result != null)
            {
                Doctors = result.Data;
            }
            ProductsChanged.Invoke();
        }

        public async Task CreateDoctor(Doctor doctor)
        {
            var response = await _http.PostAsJsonAsync("api/doctor/add", doctor);
            Doctors = (await response.Content.ReadFromJsonAsync<ServiceResponse<List<Doctor>>>()).Data;
            ProductsChanged.Invoke();
        }

    }
}
