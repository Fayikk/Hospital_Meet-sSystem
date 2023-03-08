using Eksim_Bootcamp.Server.Services.ForMeet;
using Eksim_Bootcamp.Shared;
using Eksim_Bootcamp.Shared.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Eksim_Bootcamp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetController : ControllerBase
    {
        private readonly IMeetService _meetService;
        public MeetController(IMeetService meetService)
        {
            _meetService = meetService;
        }
        //Task<ServiceResponse<Meet>> CreateMeet(Meet meet);
        //Task<ServiceResponse<Meet>> CancelMeet(int id);

        [HttpPost("add")]
        [Authorize]
        public async Task<ActionResult<ServiceResponse<MeetDTO>>> CreateMap(MeetDTO meet)
        {
            var result = await _meetService.CreateMeet(meet);
            return Ok(result);
        }

        [HttpGet("getMeet")]
        public async Task<ActionResult<ServiceResponse<List<Meet>>>> GetMeet()
        {
            var result = await _meetService.GetMeetById();
            return Ok(result);
        }

        [HttpPut("cancel/{id}")]
        public async Task<ActionResult<ServiceResponse<Meet>>> CancelMeet(int id)
        {
            var result = await _meetService.CancelMeet(id);
            return Ok(result);
        }

       

    }
}
