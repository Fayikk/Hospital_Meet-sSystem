using AutoMapper;
using Eksim_Bootcamp.Server.Context;
using Eksim_Bootcamp.Server.Services.ForAuth;
using Eksim_Bootcamp.Shared;
using Eksim_Bootcamp.Shared.DTO;
using Microsoft.EntityFrameworkCore;

namespace Eksim_Bootcamp.Server.Services.ForMeet
{
    public class MeetService : IMeetService
    {
        private readonly ApplicationDbContext _context;
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;
        public MeetService(ApplicationDbContext context, IAuthService authService, IMapper mapper)
        {
            _context = context;
            _authService = authService;
            _mapper = mapper;

        }

        public async Task<ServiceResponse<Meet>> CancelMeet(int id)
        {
            var result = await _context.Meets.FirstOrDefaultAsync(x => x.Id == id);

            var response = result.MeetDate - DateTime.UtcNow;
            var hour = response.Hours;
            var day = response.Days;
            if (result.Status != false)
            {
                if (hour < 6 && day < 1)
                {
                    return new ServiceResponse<Meet>
                    {
                        Success = false,
                        Message = "Seçili randevu doludur",

                    };
                }
                else
                {
                    result.Status = false;
                    await _context.SaveChangesAsync();
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
            var mDate = await _context.Meets
                            .Where(x => x.MeetDate.Month == meet.MeetDate.Month).ToListAsync();
            var user = _authService.GetUserId();

            if (poly.Id == meet.DoctorId)
            {
                foreach (var item in mDate)
                {
                    if (item.MeetDate.Day == meet.MeetDate.Day)
                    {
                        if (item.MeetTime.Hours == meet.MeetTime.Hours)
                        {
                            return new ServiceResponse<Meet>
                            {
                                Success = false,
                                Message = "Seçili alanda ilgili doktora ait randevu bulunmamaktadır",
                            };
                        }
                    }
                }


            }

            if (result != null && poly != null)
            {
                meet.DoctorId = result.DoctorId;
                meet.UserId = user;
                meet.PolyclinicName = poly.PoliclinicName;
                meet.DoctorName = result.Name;
                var addedObj = _context.Meets.Add(meet);

                await _context.SaveChangesAsync();

                return new ServiceResponse<Meet>
                {
                    Data = addedObj.Entity,
                    Success = true,
                };
            }
            return new ServiceResponse<Meet> { Success = false };
        }

        public Task<ServiceResponse<bool>> ExistMeet()
        {
            throw new NotImplementedException();
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
