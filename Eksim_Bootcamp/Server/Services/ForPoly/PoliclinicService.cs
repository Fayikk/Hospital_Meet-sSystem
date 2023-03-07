using Eksim_Bootcamp.Server.Context;
using Eksim_Bootcamp.Shared;
using Microsoft.EntityFrameworkCore;

namespace Eksim_Bootcamp.Server.Services.ForPoly
{
    public class PoliclinicService : IPoliclinicService
    {
        private readonly ApplicationDbContext _context;
        public PoliclinicService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<Policlinic>> AddPoly(Policlinic poly)
        {
            _context.Policlinics.Add(poly);
            await _context.SaveChangesAsync();
            return new ServiceResponse<Policlinic>
            {
                Data = poly,
                Success = true,
                Message = "Succes",
            };
        }

        public async Task<ServiceResponse<int>> DeletePoly(int meetId)
        {
            var result = await _context.Policlinics.FirstOrDefaultAsync(x=>x.Id== meetId);  
            if (result != null) { 
                _context.Policlinics.Remove(result);
                await  _context.SaveChangesAsync();
                return new ServiceResponse<int> { Data = result.Id,Message="Your process is succes" };
            }
            return new ServiceResponse<int>
            {
                Data = 0,

            };
        }

        public async Task<ServiceResponse<List<Policlinic>>> GetAll()
        {
            var result = await _context.Policlinics.ToListAsync();
           
            return new ServiceResponse<List<Policlinic>> { Data= result};
        }

        public async Task<ServiceResponse<Policlinic>> GetPolyById(int id)
        {
            var result = await _context.Policlinics.FirstOrDefaultAsync(x=>x.Id== id);
            if (result != null)
            {
                return new ServiceResponse<Policlinic> { Message = "item is not found",Data=result };
            }
            return new ServiceResponse<Policlinic> { Success= false};
        }

        public async Task<ServiceResponse<Policlinic>> UpdatePoly(Policlinic poly)
        {
            var result = await _context.Policlinics.FirstOrDefaultAsync(x=>x.Id== poly.Id); 
            if (result != null)
            {

                result.PoliclinicName = poly.PoliclinicName;

                return new ServiceResponse<Policlinic>
                {
                    Data = result,
                };
            }
            return new ServiceResponse<Policlinic> {Success=false };
        }
    }
}
