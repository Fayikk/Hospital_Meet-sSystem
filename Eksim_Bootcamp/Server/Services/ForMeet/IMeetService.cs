using Eksim_Bootcamp.Shared;

namespace Eksim_Bootcamp.Server.Services.ForMeet
{
    public interface IMeetService
    {
        Task<ServiceResponse<Meet>> CreateMeet(Meet meet);  
        Task<ServiceResponse<Meet>> CancelMeet(int id);

        Task<ServiceResponse<List<Meet>>> GetMeetById();
        //Task<ServiceResponse<Meet>> CreateMeet(Meet meet);
    }
}
