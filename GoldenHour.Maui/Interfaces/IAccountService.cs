using GoldenHour.Maui.DTO;

namespace GoldenHour.Maui.Interfaces
{
    public interface IAccountService
    {
        Task<LoginResponseModel> Login(LoginRequestModel requestModel);
    }
}
