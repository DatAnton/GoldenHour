using GoldenHour.Maui.Models;

namespace GoldenHour.Maui.Helpers
{
    public class GeoHelper
    {
        public async Task<GeolocationData> GetCurrentLocation()
        {
            try
            {
                GeolocationRequest request = new GeolocationRequest(GeolocationAccuracy.Best);


                Location location = await Geolocation.Default.GetLocationAsync(request);

                if (location != null)
                    return new GeolocationData
                    {
                        Latitude = location.Latitude,
                        Longitude = location.Longitude
                    };

                return null;
                
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
