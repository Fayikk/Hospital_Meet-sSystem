using Eksim_Bootcamp.Shared;

namespace Eksim_Bootcamp.Server.Services.ForPoly
{
    public interface IPoliclinicService
    {
      public  Task<ServiceResponse<Policlinic>> AddPoly(Policlinic poly);
        Task<ServiceResponse<List<Policlinic>>> GetAll();
        Task<ServiceResponse<Policlinic>> UpdatePoly(Policlinic poly);
        Task<ServiceResponse<int>> DeletePoly(int meetId);  
        Task<ServiceResponse<Policlinic>> GetPolyById(int id);
    }
}
