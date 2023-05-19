using GoldenHour.Maui.DTO;
using GoldenHour.Maui.Helpers;
using GoldenHour.Maui.Interfaces;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace GoldenHour.Maui.Services
{
    public class AccountService : BaseHttpService, IAccountService
    {
        public AccountService(UserInfoHelper userInfoHelper, TabsBuilder tabsBuilder) : base(userInfoHelper, tabsBuilder)
        {
        }

        public async Task<LoginResponseModel> Login(LoginRequestModel requestModel)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/accounts/login", requestModel);
            return JsonConvert.DeserializeObject<LoginResponseModel>(await response.Content.ReadAsStringAsync());
        }

        public async Task<LoginResponseModel> Refresh(string token, string refreshToken)
        {
            try
            {
                return await RefreshRequest(token, refreshToken);
            }
            catch (Exception)
            {
                Logout();
                return null;
            }
        }
    }
}
