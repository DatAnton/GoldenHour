using GoldenHour.Maui.DTO;
using GoldenHour.Maui.Interfaces;
using Newtonsoft.Json;

namespace GoldenHour.Maui.Services
{
    public class UserService : BaseHttpService, IUserService
    {
        public async Task<byte[]> GetImageAsync()
        {
            try
            {
                var response = await GetWithHeadersAsync("/api/users/generateQr");

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

        public async Task<ServiceMan> GetInfoAsync()
        {
            try
            {
                var response = await GetWithHeadersAsync("/api/users/getInfo");

                response.EnsureSuccessStatusCode();
                return JsonConvert.DeserializeObject<ServiceMan>
                    (await response.Content.ReadAsStringAsync());
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
