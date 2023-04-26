using System.Drawing;

namespace GoldenHour.Maui.Interfaces
{
    public interface IUserService
    {
        Task<byte[]> GetImageAsync();
    }
}
