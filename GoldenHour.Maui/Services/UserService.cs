using GoldenHour.Maui.Interfaces;

namespace GoldenHour.Maui.Services
{
    public class UserService : BaseHttpService, IUserService
    {
        public async Task<byte[]> GetImageAsync()
        {
            try
            {
                await SetAuthToken();
                var response = await _httpClient.GetAsync("/api/users/generateQr");

                response.EnsureSuccessStatusCode();
                var fileStream = await response.Content.ReadAsStreamAsync();
                var memoryStream = new MemoryStream();
                fileStream.CopyTo(memoryStream);

                return memoryStream.ToArray();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
