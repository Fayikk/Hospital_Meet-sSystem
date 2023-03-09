
using Eksim_Bootcamp.Shared;

namespace Eksim_Bootcamp.Client.Services.DoctorServices
{
    public interface IDoctorService
    {
        event Action doctorsChanged;
        List<Doctor> Doctors { get; set; }
        string Message { get; set; }
        Task GetDoctor(int Id);
        Task GetDoctors();
        Task CreateDoctor(Doctor doctor);
        //Task<ServiceResponse<Doctor>> GetDoctor(int id);
    }
}
