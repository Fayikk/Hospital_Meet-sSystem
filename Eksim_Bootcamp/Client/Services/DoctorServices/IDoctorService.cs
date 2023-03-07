
using Eksim_Bootcamp.Shared;

namespace Eksim_Bootcamp.Client.Services.DoctorServices
{
    public interface IDoctorService
    {
        event Action ProductsChanged;
        List<Doctor> Doctors { get; set; }
        string Message { get; set; }
        Task GetDoctor(string Id);
        Task GetDoctors();
        Task CreateDoctor(Doctor doctor);
        //Task<ServiceResponse<Doctor>> GetDoctor(int id);
    }
}
