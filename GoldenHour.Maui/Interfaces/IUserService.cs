using GoldenHour.Maui.DTO;

namespace GoldenHour.Maui.Interfaces
{
    public interface IUserService
    {
        Task<byte[]> GetImageAsync();
        Task<ServiceMan> GetInfoAsync();
        Task UpdatePassword(ChangePasswordModel changePasswordModel);
    }
}
