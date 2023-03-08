using Eksim_Bootcamp.Shared;

namespace Eksim_Bootcamp.Client.Services.MeetServices
{
    public interface IMeetService
    {
        Task<List<Meet>> GetMeet();
        Task CreateMeet(Meet meet);
        Task CancelMeet(int id);
    }
}
