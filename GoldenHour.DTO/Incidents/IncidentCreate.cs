using Microsoft.AspNetCore.Http;

namespace GoldenHour.DTO.Incidents
{
    public class IncidentCreate
    {
        public string ServiceManId { get; set; }
        public DateTime DateTime { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string? Comment { get; set; }
        public string MedicId { get; set; }
        public List<IFormFile> Files { get; set; }
    }
}
