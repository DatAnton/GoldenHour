using RestSharp;

namespace GoldenHour.Maui.Interfaces
{
    public interface IIncidentService
    {
        Task<bool> SaveIncident(RestRequest request);
    }
}
