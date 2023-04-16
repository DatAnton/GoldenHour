using GoldenHour.Maui.DTO;
using GoldenHour.Maui.Interfaces;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace GoldenHour.Maui.Services
{
    public class AccountService : IAccountService
    {
        private readonly HttpClient _httpClient;

        private static string _baseAddress = DeviceInfo.Platform == DevicePlatform.Android 
            ? Constants.ANDROID_LOCALHOST : Constants.LOCALHOST;


        public AccountService()
        {
            _httpClient = new()
            {
                BaseAddress = new Uri(_baseAddress)
            };
        }

        public async Task<LoginResponseModel> Login(LoginRequestModel requestModel)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("/api/accounts/login", requestModel);
                response.EnsureSuccessStatusCode();
                return JsonConvert.DeserializeObject<LoginResponseModel>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
