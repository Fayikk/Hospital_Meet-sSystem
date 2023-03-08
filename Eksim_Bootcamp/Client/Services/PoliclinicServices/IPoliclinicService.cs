using Eksim_Bootcamp.Shared;

namespace Eksim_Bootcamp.Client.Services.PoliclinicServices
{
    public interface IPoliclinicService
    {
        public event Action OnChange;
        List<Policlinic> Policlinics { get; set; }   
        Task<List<Policlinic>>  GetPoliclinics();
        Task CreatePoliclinics(Policlinic policlinic);

        Task DeletePoliclinics(int id);

    }
}
