using Eksim_Bootcamp.Shared;
using Eksim_Bootcamp.Shared.DTO;

namespace Eksim_Bootcamp.Server.Services.ForMeet
{
    public interface IMeetService
    {
        Task<ServiceResponse<MeetDTO>> CreateMeet(MeetDTO meet);  
        Task<ServiceResponse<Meet>> CancelMeet(int id);

        Task<ServiceResponse<List<Meet>>> GetMeetById();
        //Task<ServiceResponse<Meet>> CreateMeet(Meet meet);
    }
}
