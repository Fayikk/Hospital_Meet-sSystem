using Eksim_Bootcamp.Shared;

namespace Eksim_Bootcamp.Client.Services.MeetServices
{
    public interface IMeetService
    {
        List<Meet> Meets { get; set; }
        Task<List<Meet>> GetMeet();
        Task<ServiceResponse<Meet>> CreateMeet(Meet meet);
        Task<ServiceResponse<Meet>> CancelMeet(int id);
    }
}
