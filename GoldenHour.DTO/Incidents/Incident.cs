using GoldenHour.DTO.Users;

namespace GoldenHour.DTO.Incidents
{
    public class Incident
    {
        public Guid Id { get; set; }
        public string ServiceManId { get; set; }
        public ServiceMan ServiceMan { get; set; }
        public DateTime DateTime { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Comment { get; set; }
        public string MedicId { get; set; }
        public string MedicFullName { get; set; }
        public List<string> Images { get; set; }
    }
}
