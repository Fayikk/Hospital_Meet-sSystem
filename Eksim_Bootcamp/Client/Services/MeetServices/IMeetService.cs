using Eksim_Bootcamp.Shared;

namespace Eksim_Bootcamp.Client.Services.MeetServices
{
    public interface IMeetService
    {
        Task<List<Meet>> GetMeet();
        //Task CancelMeet(int id);
    }
}
