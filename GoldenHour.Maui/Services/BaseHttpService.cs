using System.Net.Http.Headers;
using System.Net.Http.Json;

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

        protected async Task<HttpResponseMessage> GetWithHeadersAsync(string url)
        {
            await SetAuthToken();
            return await _httpClient.GetAsync(url);
        }

        protected async Task<HttpResponseMessage> PostWithHeadersAsync<T>(string url, T entity)
        {
            await SetAuthToken();
            return await _httpClient.PostAsJsonAsync(url, entity);
        }

        protected async Task<HttpResponseMessage> PutWithHeadersAsync<T>(string url, T entity)
        {
            await SetAuthToken();
            return await _httpClient.PutAsJsonAsync(url, entity);
        }

        private async Task SetAuthToken()
        {
            var token = await SecureStorage.GetAsync(Constants.TOKEN_KEY_SECURE_STORAGE);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Constants.AUTH_HEADER_BEARER, token);
        }
    }
}
