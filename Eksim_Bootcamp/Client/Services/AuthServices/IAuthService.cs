using Eksim_Bootcamp.Shared.Model;
using Eksim_Bootcamp.Shared;

namespace Eksim_Bootcamp.Client.Services.AuthServices
{
    public interface IAuthService
    {
        Task<ServiceResponse<int>> Register(UserRegister request);
        Task<ServiceResponse<string>> Login(UserLogin user);
        //Task<ServiceResponse<bool>> ChangePassword(UserChangePassword changePassword);
        Task<bool> IsUserAuthenticated();
    }
}
