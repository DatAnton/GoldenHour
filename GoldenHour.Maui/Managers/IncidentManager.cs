using GoldenHour.Maui.Domain;
using GoldenHour.Maui.Interfaces;
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

        public async Task SaveIncident(Incident incident, List<string> photos)
        {
            var request = new RestRequest("/api/Incidents")
                .AddParameter("ServiceManId", incident.ServiceManId)
                .AddParameter("MedicId", incident.MedicId)
                .AddParameter("Comment", incident.Comment)
                .AddParameter("Latitude", incident.Latitude.ToString())
                .AddParameter("Longitude", incident.Longitude.ToString())
                .AddParameter("DateTime", incident.DateTime.ToString());

            foreach(var photo in photos)
            {
                request.AddFile("Files", photo);
            }

            if(incident.Id == 0)
            {
                incident.IsSuccessfull = false;
                SaveIncidentToDb(incident, photos);
            }

            var requestSuccess = await _incidentService.SaveIncident(request);
            if(requestSuccess)
            {
                App.DbService.SetSuccessRequest(incident.Id, true);
            }    
        }

        public async Task SendAllUnsuccessfullIncidents(List<Incident> incidents)
        {
            foreach(var incident in incidents)
            {
                var photos = App.DbService.GetPhotos(incident.Id);
                await SaveIncident(incident, photos.Select(p => p.Path).ToList());
            }
        }

        private void SaveIncidentToDb(Incident incident, List<string> photos)
        {
            App.DbService.AddIncident(incident, 
                photos.Select(p => new Domain.Photo { Path = p}).ToList());
        }
    }
}
