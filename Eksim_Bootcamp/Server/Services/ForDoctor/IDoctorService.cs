using Eksim_Bootcamp.Shared;
using Eksim_Bootcamp.Shared.DTO;

namespace Eksim_Bootcamp.Server.Services.ForDoctor
{
    public interface IDoctorService
    {
        Task<ServiceResponse<List<Doctor>>> GetDoctorByPoliclinic(int id);
    
        Task<ServiceResponse<DoctorDTO>> AddDoctor(DoctorDTO doctor);//This metod will authorize
        Task<ServiceResponse<List<Doctor>>> GetAllDoctor();
    }

}
