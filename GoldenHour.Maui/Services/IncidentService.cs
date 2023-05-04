using GoldenHour.Maui.Interfaces;
using RestSharp;
using RestSharp.Authenticators;

namespace GoldenHour.Maui.Services
{
    internal class IncidentService : IIncidentService
    {
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
                await client.PostAsync(request);
                return true;
			}
			catch (Exception)
			{
                return false;
			}
        }
    }
}
