using GoldenHour.Maui.DTO;
using GoldenHour.Maui.Helpers;
using GoldenHour.Maui.Interfaces;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;

namespace GoldenHour.Maui.Services
{
    internal class IncidentService : BaseHttpService, IIncidentService
    {
        public IncidentService(UserInfoHelper userInfoHelper, TabsBuilder tabsBuilder) : base(userInfoHelper, tabsBuilder)
        {
        }

        public async Task<bool> SaveIncident(RestRequest request)
        {
			try
			{
                var token = await SecureStorage.GetAsync(Constants.TOKEN_KEY_SECURE_STORAGE);
                var options = new RestClientOptions(Constants.BASE_ADDRESS)
                {
                    Authenticator = new JwtAuthenticator(token)
                };
                
                var client = new RestClient(options);
                var response = await client.PostAsync(request);
                if(response.IsSuccessStatusCode)
                {
                    return true;
                }
                else if(response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    if(await RefreshToken())
                    {
                        await client.PostAsync(request);
                        return true;
                    }
                }
                else if(response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                {
                    var responseObject = JsonConvert.DeserializeObject<AppException>(response.Content);
                    await Shell.Current.DisplayAlert("Error", responseObject.Message, "Ok");
                }
                return false;
			}
			catch (Exception)
			{
                return false;
			}
        }
    }
}
