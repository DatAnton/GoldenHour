using GoldenHour.Maui.Interfaces;
using GoldenHour.Maui.Models;
using RestSharp;

namespace GoldenHour.Maui.Managers
{
    public class IncidentManager
    {
        private readonly IIncidentService _incidentService;

        public IncidentManager(IIncidentService incidentService)
        {
            _incidentService = incidentService;
        }

        public async Task SaveIncident(string serviceManId, List<string> photos,
            GeolocationData geolocationData, DateTime currentDate, TimeSpan currentTime,
            string comment)
        {
            var dateTime = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day,
                currentTime.Hours, currentTime.Minutes, currentTime.Seconds);

            var request = new RestRequest("/api/Incidents")
                .AddParameter("ServiceManId", serviceManId)
                .AddParameter("MedicId", App.UserInfo.UserId)
                .AddParameter("Comment", comment)
                .AddParameter("Latitude", geolocationData.Latitude.ToString())
                .AddParameter("Longitude", geolocationData.Longitude.ToString())
                .AddParameter("DateTime", dateTime.ToString());

            foreach(var photo in photos)
            {
                request.AddFile("Files", photo);
            }

            await _incidentService.SaveIncident(request);
        }
    }
}
