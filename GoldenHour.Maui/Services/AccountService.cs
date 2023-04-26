using GoldenHour.Maui.DTO;
using GoldenHour.Maui.Interfaces;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace GoldenHour.Maui.Services
{
    public class AccountService : BaseHttpService, IAccountService
    {
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
