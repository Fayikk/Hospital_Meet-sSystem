using Eksim_Bootcamp.Shared;

namespace Eksim_Bootcamp.Client.Services.PoliclinicServices
{
    public interface IPoliclinicService
    {
        event Action OnChange;
        List<Policlinic> Policlinics { get; set; }   
        Task  GetPoliclinics();
        Task CreatePoliclinics(Policlinic policlinic);

        

    }
}
