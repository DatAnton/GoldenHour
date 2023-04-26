using System.Net.Http.Headers;

namespace GoldenHour.Maui.Services
{
    public abstract class BaseHttpService
    {
        protected readonly HttpClient _httpClient;

        public BaseHttpService()
        {
            _httpClient = new()
            {
                BaseAddress = new Uri(Constants.BASE_ADDRESS)
            };
        }

        public async Task SetAuthToken()
        {
            var token = await SecureStorage.GetAsync(Constants.TOKEN_KEY_SECURE_STORAGE);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Constants.AUTH_HEADER_BEARER, token);
        }
    }
}
