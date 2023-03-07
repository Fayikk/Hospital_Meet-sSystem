using AutoMapper;
using Eksim_Bootcamp.Server.Context;
using Eksim_Bootcamp.Shared;
using Eksim_Bootcamp.Shared.DTO;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace Eksim_Bootcamp.Server.Services.ForDoctor
{
    public class DoctorService : IDoctorService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public DoctorService(ApplicationDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<Doctor>>> GetDoctorByPoliclinic(int id)
        {
            var result = await _context.Doctors.Where(x=>x.PoliclinicId== id).ToListAsync();

            if (result == null)
            {
                new ServiceResponse<List<Doctor>>
                {
                    Message = "This doctor not any meet",
                    Success = false,
                };
            }

            var response = new ServiceResponse<List<Doctor>>
            {
                Data = result,
                Success = true,

            };
            return response;

        }

        public async Task<ServiceResponse<DoctorDTO>> AddDoctor(DoctorDTO doctor)
        {
            var obj = _mapper.Map<DoctorDTO, Doctor>(doctor);
            var addedObj = _context.Doctors.Add(obj);
            await _context.SaveChangesAsync();
            var reverseMap = _mapper.Map<Doctor, DoctorDTO>(addedObj.Entity);
            return new ServiceResponse<DoctorDTO>
            {
                Data = reverseMap,
                Success = true,
                Message = "Doctor is added",
            };
        
        }

        public async Task<ServiceResponse<List<Doctor>>> GetAllDoctor( )
        {
            var response = await _context.Doctors.ToListAsync();
            if (response != null)
            {
                return new ServiceResponse<List<Doctor>> { Data = response };
            }
            return new ServiceResponse<List<Doctor>> { Message = "Fail" };
        }
    }
}
