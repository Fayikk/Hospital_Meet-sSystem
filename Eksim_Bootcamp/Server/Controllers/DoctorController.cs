using Eksim_Bootcamp.Server.Services.ForDoctor;
using Eksim_Bootcamp.Shared.DTO;
using Eksim_Bootcamp.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Eksim_Bootcamp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;
        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }
        //Task<ServiceResponse<List<Doctor>>> GetDoctorByPoliclinic(int id);

        //Task<ServiceResponse<DoctorDTO>> AddDoctor(DoctorDTO doctor);//This metod will authorize

        [HttpPost("add")]
        public async Task<ActionResult<ServiceResponse<DoctorDTO>>> CreateDoctor(DoctorDTO doctor)
        {
            var result = await _doctorService.AddDoctor(doctor);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<Doctor>>> GetByDoctor(int id)
        {
            var result = await _doctorService.GetDoctorByPoliclinic(id);
            return Ok(result);
        }
        [HttpGet("getall")]
        public async Task<ActionResult<ServiceResponse<List<Doctor>>>> GetDoctors()
        {
            var result = await _doctorService.GetAllDoctor();
            return Ok(result);
        }

    }
}
