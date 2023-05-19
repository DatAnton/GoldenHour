using GoldenHour.Maui.DTO;
using GoldenHour.Maui.Helpers;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace GoldenHour.Maui.Services
{
    public abstract class BaseHttpService
    {
        protected readonly HttpClient _httpClient;
        private readonly UserInfoHelper _userInfoHelper;
        private readonly TabsBuilder _tabsBuilder;

        public BaseHttpService(UserInfoHelper userInfoHelper, TabsBuilder tabsBuilder)
        {
            _httpClient = new()
            {
                BaseAddress = new Uri(Constants.BASE_ADDRESS)
            };
            _userInfoHelper = userInfoHelper;
            _tabsBuilder = tabsBuilder;
        }

        protected async Task<HttpResponseMessage> GetWithHeadersAsync(string url)
        {
            await SetAuthToken();
            try
            {
                var response = await _httpClient.GetAsync(url);
                var handleResult = await HandleResponse(response);
                return handleResult ? await GetWithHeadersAsync(url) : response;
            }
            catch (Exception)
            {
                Logout();

                return null;
            }
        }

        protected async Task<HttpResponseMessage> PostWithHeadersAsync<T>(string url, T entity)
        {
            await SetAuthToken(); 
            try
            {
                var response = await _httpClient.PostAsJsonAsync(url, entity);
                var handleResult = await HandleResponse(response);
                return handleResult ? await PostWithHeadersAsync(url, entity) : response;
            }
            catch (Exception)
            {
                Logout();

                return null;
            }
        }

        protected async Task<HttpResponseMessage> PutWithHeadersAsync<T>(string url, T entity)
        {
            await SetAuthToken();
            try
            {
                var response = await _httpClient.PutAsJsonAsync(url, entity);
                var handleResult = await HandleResponse(response);
                return handleResult ? await PutWithHeadersAsync(url, entity) : response;
            }
            catch (Exception)
            {
                Logout();

                return null;
            }
        }

        private async Task SetAuthToken()
        {
            var token = await SecureStorage.GetAsync(Constants.TOKEN_KEY_SECURE_STORAGE);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Constants.AUTH_HEADER_BEARER, token);
        }

        private async Task<bool> HandleResponse(HttpResponseMessage httpResponse)
        {
            if(httpResponse.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                return await RefreshToken();
            }
            else if(httpResponse.StatusCode == System.Net.HttpStatusCode.Forbidden)
            {
                await Shell.Current.DisplayAlert("Info", "Forbiddent request", "Ok");
            }
            else if(httpResponse.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            {
                var responseObject = JsonConvert.DeserializeObject<AppException>(await httpResponse.Content.ReadAsStringAsync());
                await Shell.Current.DisplayAlert("Error", responseObject.Message, "Ok");
            }

            return false;

        }

        protected async Task<bool> RefreshToken()
        {
            var token = await SecureStorage.GetAsync(Constants.TOKEN_KEY_SECURE_STORAGE);
            var refreshToken = await SecureStorage.GetAsync(Constants.REFRESH_TOKEN_KEY_SECURE_STORAGE);

            if (!string.IsNullOrEmpty(token) && !string.IsNullOrEmpty(refreshToken))
            {
                SecureStorage.Remove(Constants.TOKEN_KEY_SECURE_STORAGE);
                SecureStorage.Remove(Constants.REFRESH_TOKEN_KEY_SECURE_STORAGE);

                var responseObject = await RefreshRequest(token, refreshToken);

                await SecureStorage.SetAsync(Constants.TOKEN_KEY_SECURE_STORAGE, responseObject.Token);
                await SecureStorage.SetAsync(Constants.REFRESH_TOKEN_KEY_SECURE_STORAGE, responseObject.RefreshToken);
                return true;
            }
            return false;
        }

        protected async Task<LoginResponseModel> RefreshRequest(string token, string refreshToken)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/accounts/refresh", new RefreshRequestModel
            {
                AccessToken = token,
                RefreshToken = refreshToken
            });
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<LoginResponseModel>(await response.Content.ReadAsStringAsync());
        }

        protected async void Logout()
        {
            SecureStorage.Remove(Constants.TOKEN_KEY_SECURE_STORAGE);
            SecureStorage.Remove(Constants.REFRESH_TOKEN_KEY_SECURE_STORAGE);
            _userInfoHelper.CleanUserInfo();
            _userInfoHelper.RemoveUserFromStore();
            _tabsBuilder.BuildNavTabs();
            App.DbService.Clean();
            await Shell.Current.DisplayAlert("Info", "Please login", "Ok");
            await Shell.Current.GoToAsync(nameof(LoginPage));
        }
    }
}
