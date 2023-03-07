using Eksim_Bootcamp.Server.Context;
using Eksim_Bootcamp.Server.Services.ForAuth;
using Eksim_Bootcamp.Shared;
using Microsoft.EntityFrameworkCore;

namespace Eksim_Bootcamp.Server.Services.ForMeet
{
    public class MeetService : IMeetService
    {
        private readonly ApplicationDbContext _context;
        private readonly IAuthService _authService;
        public MeetService(ApplicationDbContext context,IAuthService authService)
        {
            _context = context;
            _authService = authService;

        }

        public async Task<ServiceResponse<Meet>> CancelMeet(int id)
        {
            var result = await _context.Meets.FirstOrDefaultAsync(x=>x.Id == id);

            var response = DateTime.UtcNow - result.MeetDate;
            var hour = response.Hours;

            if (result.Status != false)
            {
                if (hour < 6)
                {
                    return new ServiceResponse<Meet>
                    {
                        Success = false,

                    };
                }
                else
                {
                    result.Status = true;
                    return new ServiceResponse<Meet>
                    {
                        Success = true,
                    };
                }
            }

            return null;
        
        }

        public async Task<ServiceResponse<Meet>> CreateMeet(Meet meet)
        {
            var result = await _context.Doctors.FirstOrDefaultAsync(x => x.DoctorId == meet.DoctorId);
            var poly = await _context.Policlinics.FirstOrDefaultAsync(x => x.Id == result.PoliclinicId);
            var user = _authService.GetUserId();
            if (result != null && poly != null )
            {
                meet.PolyclinicName = poly.PoliclinicName;
                meet.CreatedMeet = DateTime.UtcNow;
                meet.DoctorId=result.DoctorId;
                meet.Status = true;
                meet.UserId = user;
                _context.Meets.Add(meet);
                await _context.SaveChangesAsync();

                return new ServiceResponse<Meet>
                {
                    Data = meet,
                    Success = true,
                };
            }
            return new ServiceResponse<Meet> { Success= false };
        }


        public async Task<ServiceResponse<List<Meet>>> GetMeetById()
        {
            var user = _authService.GetUserId();
            var result = await _context.Meets.Where(x => x.UserId == user).ToListAsync();

            var response = new ServiceResponse<List<Meet>>
            {
                Data = result,
                Success = true,
            };
            return response;

        }
    }
}
