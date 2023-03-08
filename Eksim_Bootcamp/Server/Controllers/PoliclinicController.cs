using Eksim_Bootcamp.Server.Services.ForPoly;
using Eksim_Bootcamp.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Eksim_Bootcamp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PoliclinicController : ControllerBase
    {

        private readonly IPoliclinicService _polyService;


        public PoliclinicController(IPoliclinicService polyService)
        {
            _polyService = polyService;
        }


        [HttpPost]
        //[Authorize(Roles ="Admin")]
        public async Task<ActionResult<ServiceResponse<Policlinic>>> AddPoliclinic(Policlinic policlinic)
        {
            var result = await _polyService.AddPoly(policlinic);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ServiceResponse<List<Policlinic>>> GetAll()
        {
            var result = await _polyService.GetAll();
            return result;
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<ServiceResponse<int>>> DeleteMeet([FromRoute] int id)
        {
            var result = await _polyService.DeletePoly(id);
            return Ok(result);
        }

    }
}
