namespace GoldenHour.Domain
{
    public class HelpPhoto
    {
        public Guid Id { get; set; }
        public string Path { get; set; }
        public Guid IncidentId { get; set; }
        public Incident Incident { get; set; }
    }
}
