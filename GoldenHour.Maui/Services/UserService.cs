using GoldenHour.Maui.DTO;
using GoldenHour.Maui.Helpers;
using GoldenHour.Maui.Interfaces;
using Newtonsoft.Json;

namespace GoldenHour.Maui.Services
{
    public class UserService : BaseHttpService, IUserService
    {
        public UserService(UserInfoHelper userInfoHelper, TabsBuilder tabsBuilder) : base(userInfoHelper, tabsBuilder)
        {
        }

        public async Task<byte[]> GetImageAsync()
        {
            var response = await GetWithHeadersAsync("/api/users/generateQr");
            var fileStream = await response.Content.ReadAsStreamAsync();
            var memoryStream = new MemoryStream();
            fileStream.CopyTo(memoryStream);

            return memoryStream.ToArray();
        }

        public async Task<ServiceMan> GetInfoAsync()
        {
            var response = await GetWithHeadersAsync("/api/users/getInfo");
            return JsonConvert.DeserializeObject<ServiceMan>
                (await response.Content.ReadAsStringAsync());
        }

        public async Task UpdatePassword(ChangePasswordModel changePasswordModel)
        {
            await PutWithHeadersAsync("/api/users/changePassword", changePasswordModel);
        }
    }
}
